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
            bool flag = true;
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

                int idimage = 0;
                if (IdImageHidden.Value.ToString() == "")
                {
                    ErrorImageUploadLabel.Text = "Chưa chọn hình ảnh";
                    flag = false;
                }
                else
                {
                    idimage = Convert.ToInt32(IdImageHidden.Value);
                    ErrorImageUploadLabel.Text = "";
                }
                string summary = "";
                if (SummaryTextBox.Text.Length >= 500)
                {
                    summary = SummaryTextBox.Text.Substring(0, 500);
                }
                else
                {
                    summary = SummaryTextBox.Text;
                }

                int projectID = RealEstateMarket._Default.db.InsertProject(Convert.ToInt32(ProjectTypeDropDownList.SelectedValue),
                    ProjectNameTextBox.Text.Trim(), beginDay, addressID, summary, DescriptionCKEditor.Text, idimage);

                //ErrorLabel.Text = "Bạn đã đăng tin về Dự án có ID = " + projectID.ToString() + "thành công.";
                Response.Redirect(String.Format("~/Pages/Project/Project.aspx?id={0}", projectID));
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.ToString();
            }
        }

        protected void Upload_Click(object sender, EventArgs e)
        {
            //upload image
            // limitation of maximum file size
            float intFileSizeLimit = 3072000;//3 MB

            // get the full path of your computer
            string strFileNameWithPath = ImageUpload.PostedFile.FileName;
            // get the extension name of the file
            string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);
            // get the filename of user file
            string strFileName = System.IO.Path.GetFileName(strFileNameWithPath);
            // get the file size
            int intFileSize = ImageUpload.PostedFile.ContentLength / 1024; // convert into byte

            // Restrict the user to upload only .gif or .jpg or .pngfile
            strExtensionName = strExtensionName.ToLower();
            if (strExtensionName.Equals(".jpg") || strExtensionName.Equals(".gif") || strExtensionName.Equals(".png"))
            {
                // Rstrict the File Size 
                if (intFileSize < intFileSizeLimit)
                {
                    // upload the file on the server
                    // you can save the file with any name, However as this is the sample so I have saved the file same name for all users. So it will overwrite your file with next user's who will test this tutorials.
                    ImageUpload.PostedFile.SaveAs(Server.MapPath("~/Image/images/") + strFileName);
                    IdImageHidden.Value = RealEstateMarket._Default.db.InsertImage("", "~/Image/images/" + strFileName, "").ToString();
                    Image.ImageUrl = "~/Image/images/" + strFileName;
                    ErrorImageUploadLabel.Text = "";
                }
                else
                {
                    ErrorImageUploadLabel.Text = "Kích thước hình ảnh phải nhỏ hơn " + intFileSizeLimit + " KB";
                }
            }
            else
            {
                if (strFileName == "")
                    ErrorImageUploadLabel.Text = "Chưa chọn hình ảnh";
                else
                    ErrorImageUploadLabel.Text = "Chỉ được upload các hình ảnh có phần mở rộng là .jpg .gif .png";
                ErrorImageUploadLabel.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}