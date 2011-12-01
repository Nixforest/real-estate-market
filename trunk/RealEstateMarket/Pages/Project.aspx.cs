using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Pages
{
    public partial class Project : System.Web.UI.Page
    {
        private RealEstateServiceReference.PROJECT project = new RealEstateServiceReference.PROJECT();
        private RealEstateServiceReference.ADDRESS address = new RealEstateServiceReference.ADDRESS();
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void ProjectDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            project = RealEstateMarket._Default.db.GetProject(Convert.ToInt32(ProjectDropDownList.SelectedValue));
            ProjectNameLabel.Text = project.Name;
            address = project.ADDRESS;
            AddressLabel.Text = "Vị trí: " +
                address.Detail + " " +
                address.STREET.Name + ", " +
                address.WARD.Name + ", " + 
                address.DISTRICT.Name + ", " +
                address.CITY.Name + ", " +
                address.NATION.Name + ".";
            BeginDayLabel.Text = project.BeginDay.ToString();
            ContentLabel.Text = project.Description;
        }
    }
}