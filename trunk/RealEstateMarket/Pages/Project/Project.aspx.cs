using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Pages.Project
{
    public partial class Project : System.Web.UI.Page
    {
        private RealEstateServiceReference.PROJECT project = new RealEstateServiceReference.PROJECT();
        private RealEstateServiceReference.ADDRESS address = new RealEstateServiceReference.ADDRESS();
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            project = RealEstateMarket._Default.db.GetProject(id);

            if (!IsPostBack)
            {
                Title = project.Name;
                ProjectNameLabel.Text = project.Name;
                address = project.ADDRESS;
                AddressLabel.Text = "Vị trí: " + GetAddressString(address.ID);
                if (project.BeginDay == null)
                {
                    BeginDayLabel.Text = "Đang cập nhật";
                }
                else
                {
                    BeginDayLabel.Text = Convert.ToDateTime(project.BeginDay).ToShortDateString();// ((DateTime)(project.BeginDay)).ToShortDateString();
                }
                
                ContentLabel.Text = project.Description;
            }
        }

        public static string GetAddressString(int addressID)
        {
            RealEstateServiceReference.ADDRESS address = RealEstateMarket._Default.db.GetAddress(addressID);
            string result = "";
            result += address.Detail + " ";
            try
            {
                result += RealEstateMarket._Default.db.GetStreet((int)address.StreetID).Name + ", ";
            }
            catch (Exception)
            {
            }
            try
            {
                result += RealEstateMarket._Default.db.GetWard((int)address.WardID).Name + ", ";
            }
            catch (Exception)
            {
            }
            try
            {
                result += RealEstateMarket._Default.db.GetDistrict((int)address.DistrictID).Name + ", ";
            }
            catch (Exception)
            {
            }
            result += address.CITY.Name + ", "+ address.NATION.Name;
            return result;
        }
    }
}