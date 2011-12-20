﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Admin.News
{
    public partial class EditNews : System.Web.UI.Page
    {
        private int id;
        private RealEstateMarket.RealEstateServiceReference.NEW news;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            id = Convert.ToInt32(Request.QueryString["id"]);
            news = RealEstateMarket._Default.db.GetNews(id);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //int id = Convert.ToInt32(Request.QueryString["id"]);
                //RealEstateMarket.RealEstateServiceReference.NEW news = RealEstateMarket._Default.db.GetNews(id);
                //NewsType.DataSource = RealEstateMarket._Default.db.GetAllNewsTypes();
                //NewsType.DataTextField = "Name";
                //NewsType.DataValueField = "ID";
                //NewsType.SelectedValue = news.TypeID.ToString();
                //NewsType.DataBind();
                NewsType.SelectedValue = news.TypeID.ToString();
                NewsType.DataBind();
                TitleNews.Text = news.Title;
                Descript.Text = news.Descript;
                Content.Text = news.Content;
                Author.Text = news.Author;
                Check.Checked = news.Check;
                ImageOld.ImageUrl = news.IMAGE.Path;
                if (news.Check == true)
                    Check.Text = "Đã Duyệt";
                else
                    Check.Text = "Chưa Duyệt";
            }
        }

        protected void Submit_Click(object sender, EventArgs e)
        {
            bool flag = true;
            DateTime now = DateTime.Now;
            int idType = Convert.ToInt32(NewsType.SelectedValue);
            String title = "";
            String descript = "";
            String content = "";
            String author = "";
            bool check = Check.Checked;
            int idImage;
            if (IdImageHidden.Value.ToString() != "")
            {
                idImage = Convert.ToInt32(IdImageHidden.Value.ToString());
            }
            else 
            {
                idImage = news.ImageID;
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
                RealEstateMarket._Default.db.UpdateNews(id, idType, title, descript, content, author, news.Rate, news.PublishTime , now, idImage, check);
                Response.Redirect("~/Admin/News/ListNews.aspx");
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
                    ImageUpload.PostedFile.SaveAs(Server.MapPath("~/Image/") + strFileName);
                    IdImageHidden.Value = RealEstateMarket._Default.db.InsertImage("", "~/Image/" + strFileName, "").ToString();
                    CancelUpload.Enabled = true;
                    ImageOld.ImageUrl = "~/Image/" + strFileName;
                    ErrorImageUploadLabel.Text = "";
                }
                else
                {
                    ErrorImageUploadLabel.Text = "Kích thước hình ảnh phải nhỏ hơn " + intFileSizeLimit + " KB";
                }
            }
            else
            {
                ErrorImageUploadLabel.Text = "Chỉ được upload các hình ảnh có phần mở rộng là .jpg .gif .png";
                ErrorImageUploadLabel.ForeColor = System.Drawing.Color.Red;
            }
        }

        protected void CancelUpload_Click(object sender, EventArgs e)
        {
            //int id = Convert.ToInt32(IdImageHidden.Value);
            //int id = Convert.ToInt32(Request.QueryString["id"]);
            //RealEstateMarket.RealEstateServiceReference.NEW news = RealEstateMarket._Default.db.GetNews(id);
            ImageOld.ImageUrl = news.IMAGE.Path;
            IdImageHidden.Value = "";
        }
    }
}