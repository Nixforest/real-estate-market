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
            if (!IsPostBack)
            {
                Title = "Đăng tin Dự án";
            }
            // Only Author or Moderator or Administrator can access
            if (!User.IsInRole("Author"))
            {
                Response.Redirect("~/AccessDeny.aspx");
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
            _FileBrowser.BasePath = "../../ckfinder/";
            _FileBrowser.SetupCKEditor(DescriptionCKEditor);
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
                bool different = Convert.ToBoolean(AddressCustomControl.Attributes["Different"]);
                string detail = AddressCustomControl.Attributes["Detail"];
                int? districtID = null;
                int? wardID = null;
                int? streetID = null;
                if (!different)
                {
                    districtID = Convert.ToInt32(AddressCustomControl.Attributes["DistrictID"]);
                    wardID = Convert.ToInt32(AddressCustomControl.Attributes["WardID"]);
                    streetID = Convert.ToInt32(AddressCustomControl.Attributes["StreetID"]);
                }

                int addressID = RealEstateMarket._Default.db.InsertAddress(nationID, cityID,
                   districtID, wardID, streetID, detail);

                DateTime? beginDay = null;
                if (BeginDayTextBox.Text != "")
                {
                    beginDay = Convert.ToDateTime(BeginDayTextBox.Text);
                }
                int projectID = RealEstateMarket._Default.db.InsertProject(Convert.ToInt32(ProjectTypeDropDownList.SelectedValue),
                    ProjectNameTextBox.Text.Trim(), beginDay, addressID, DescriptionCKEditor.Text);
                
                ErrorLabel.Text = "Bạn đã đăng tin về Dự án có ID = " + projectID.ToString() + "thành công.";
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.ToString();
            }
        }
    }
}