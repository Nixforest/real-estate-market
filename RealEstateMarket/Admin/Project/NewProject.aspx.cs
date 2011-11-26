using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Admin.Project
{
    public partial class NewProject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnPreview_Click(object sender, EventArgs e)
        {
            error.Text = "Preview";
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            try
            {
                int nationID = Convert.ToInt32(address.Attributes["NationID"]);
                int cityID = Convert.ToInt32(address.Attributes["CityID"]);
                int districtID = Convert.ToInt32(address.Attributes["DistrictID"]);
                int wardID = Convert.ToInt32(address.Attributes["WardID"]);
                int streetID = Convert.ToInt32(address.Attributes["StreetID"]);
                string detail = address.Attributes["Detail"];
                int addressID = RealEstateMarket._Default.db.InsertAddress(nationID, cityID, 
                   districtID, wardID, streetID, detail);

                int projectID = RealEstateMarket._Default.db.InsertProject(Convert.ToInt32(ddlProjectType.SelectedValue),
                    tbxName.Text.Trim(), cldBeginDay.SelectedDate, addressID, editor.Text);
                //error.Text = ddlProjectType.SelectedValue;
                //error.Text = tbxName.Text.Trim();
                //error.Text = cldBeginDay.SelectedDate.ToLongDateString();
                //error.Text = addressID.ToString();
                //error.Text = address.Attributes["NationID"] + " " +
                //    address.Attributes["CityID"] + " " +
                //    address.Attributes["DistrictID"] + " " +
                //    address.Attributes["WardID"] + " " +
                //    address.Attributes["StreetID"] + " " + 
                //    address.Attributes["Detail"];
                error.Text = projectID.ToString();
            }
            catch (Exception ex)
            {
                error.Text = ex.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            error.Text = "Nixforest";
        }
    }
}