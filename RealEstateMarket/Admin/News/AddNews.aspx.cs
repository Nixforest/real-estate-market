using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Admin.News
{
    public partial class AddNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("Author"))
            {
                Response.Redirect("~/AccessDeny.aspx");
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
            _FileBrowser.BasePath = "../../ckfinder/";
            _FileBrowser.SetupCKEditor(Descript);
            _FileBrowser.SetupCKEditor(Content);
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            bool flag = true;
            DateTime now = DateTime.Now;
            int id = Convert.ToInt32(NewsType.SelectedValue);
            String title = "";
            String descript = "";
            String content = "";
            String author = "";
            bool check = Check.Checked;
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
            if (TitleNews.Text == "")
            {
                ErrorTitleNewsLabel.Text = "Chưa nhập tiêu đề bài viết";
                flag = false;
            }
            else
            {
                title = TitleNews.Text;
                ErrorTitleNewsLabel.Text = "";
            }
            if (Descript.Text == "")
            {
                ErrorDescriptLabel.Text = "Chưa nhập nội dung tóm tắt";
                flag = false;
            }
            else
            {
                descript = Descript.Text;
                ErrorDescriptLabel.Text = "";
            }
            if (Content.Text == "")
            {
                ErrorContentLabel.Text = "Chưa nhập nội dung bài viết";
                flag = false;
            }
            else
            {
                content = Content.Text;
                ErrorContentLabel.Text = "";
            }
            if (Author.Text == "")
            {
                ErrorAuthorLabel.Text = "Chưa nhập tác giả bài viết";
                flag = false;
            }
            else
            {
                author = Author.Text;
                ErrorAuthorLabel.Text = "";
            }

            if (flag == true)
            {               
                int newsid = RealEstateMarket._Default.db.InsertNews(id, title, descript, content, author, 1, now, now, idimage, check);
                Response.Redirect(String.Format("~/Pages/News/ReadNews.aspx?id={0}", newsid));
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