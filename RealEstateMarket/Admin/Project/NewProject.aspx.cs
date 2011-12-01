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
            // Only Author or Moderator or Administrator can access
            if (!User.IsInRole("Author"))
            {
                Response.Redirect("~/AccessDeny.aspx");
            }
        }

        protected void PreviewButton_Click(object sender, EventArgs e)
        {
            try
            {
                Convert.ToDateTime(BeginDayTextBox.Text);
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.ToString();
            }
            //ErrorLabel.Text = BeginDayTextBox.Text.Trim(); ;
        }

        protected void PostButton_Click(object sender, EventArgs e)
        {
            try
            {
                int nationID = Convert.ToInt32(AddressCustomControl.Attributes["NationID"]);
                int cityID = Convert.ToInt32(AddressCustomControl.Attributes["CityID"]);
                int districtID = Convert.ToInt32(AddressCustomControl.Attributes["DistrictID"]);
                int wardID = Convert.ToInt32(AddressCustomControl.Attributes["WardID"]);
                int streetID = Convert.ToInt32(AddressCustomControl.Attributes["StreetID"]);
                string detail = AddressCustomControl.Attributes["Detail"];
                int addressID = RealEstateMarket._Default.db.InsertAddress(nationID, cityID, 
                   districtID, wardID, streetID, detail);

                DateTime? beginDay = null;
                if (BeginDayTextBox.Text != "")
                {
                    beginDay = Convert.ToDateTime(BeginDayTextBox.Text);
                }
                int projectID = RealEstateMarket._Default.db.InsertProject(Convert.ToInt32(ProjectTypeDropDownList.SelectedValue),
                    ProjectNameTextBox.Text.Trim(), beginDay, addressID, DescriptionCKEditor.Text);
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
                ErrorLabel.Text = "Bạn đã đăng tin về Dự án có ID = " + projectID.ToString() + "thành công.";
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.ToString();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ErrorLabel.Text = "Nixforest";
        }
    }
}