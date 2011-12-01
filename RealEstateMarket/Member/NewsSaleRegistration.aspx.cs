﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Member
{
    public partial class NewsSaleRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("Customer"))
            {
                Response.Redirect("~/AccessDeny.aspx");
            }
            if (!IsPostBack)
            {
                NewsSaleTypeRadioButtonList.SelectedIndex = 0;
                if (RealEstateMarket._Default.db.GetCustomerByUserName(User.Identity.Name) != null)
                {
                    ContactNameTextBox.Text = RealEstateMarket._Default.db.GetCustomerByUserName(User.Identity.Name).Name;
                }
            }
        }
        protected void ProjectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            ProjectDropDownList.Enabled = !ProjectCheckBox.Checked;
        }

        protected void CampusOpenBehindCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            CampusBehindTextBox.Visible = CampusOpenBehindCheckBox.Checked;
            CampusMLabel.Visible = CampusOpenBehindCheckBox.Checked;
            CampusOpenBehindRegularExpressionValidator.Enabled = CampusOpenBehindCheckBox.Checked;
        }

        protected void BuildOpenBehindCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            BuildBehindTextBox.Visible = BuildOpenBehindCheckBox.Checked;
            BuildMLabel.Visible = BuildOpenBehindCheckBox.Checked;
            BuildOpenBehindRegularExpressionValidator.Enabled = BuildOpenBehindCheckBox.Checked;
        }

        protected void PostButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Check for Address Real Estate
                int addressID = 0;
                int nationID = Convert.ToInt32(AddressCustomControl.Attributes["NationID"]);
                int cityID = Convert.ToInt32(AddressCustomControl.Attributes["CityID"]);
                int districtID = Convert.ToInt32(AddressCustomControl.Attributes["DistrictID"]);
                int wardID = Convert.ToInt32(AddressCustomControl.Attributes["WardID"]);
                int streetID = Convert.ToInt32(AddressCustomControl.Attributes["StreetID"]);
                string detail = AddressCustomControl.Attributes["Detail"];

                // Check for Real Estate
                int realEstateTypeID = Convert.ToInt32(RealEstateTypeDropDownList.SelectedValue);
                int? livingRoom = null;
                if (LivingRoomDropDownList.SelectedIndex != 0)
                {
                    livingRoom = Convert.ToInt32(LivingRoomDropDownList.SelectedValue);
                }
                int? bedRoom = null;
                if (BedRoomDropDownList.SelectedIndex != 0)
                {
                    bedRoom = Convert.ToInt32(BedRoomDropDownList.SelectedValue);
                }
                int? bathRoom = null;
                if (BathRoomDropDownList.SelectedIndex != 0)
                {
                    bathRoom = Convert.ToInt32(BathRoomDropDownList.SelectedValue);
                }
                int? storey = null;
                if (StoreyDropDownList.SelectedIndex != 0)
                {
                    storey = Convert.ToInt32(StoreyDropDownList.SelectedValue);
                }

                double totalUseArea = Convert.ToDouble(TotalUseAreaTextBox.Text);
                double campusFront = Convert.ToDouble(CampusFrontTextBox.Text);
                double campusLength = Convert.ToDouble(CampusLengthTextBox.Text);
                double? campuBehind = null;
                double? buildBehind = null;
                if (CampusOpenBehindCheckBox.Checked)
                {
                    campuBehind = Convert.ToDouble(CampusBehindTextBox.Text);
                }
                double buildFront = Convert.ToDouble(BuildFrontTextBox.Text);
                double buildLength = Convert.ToDouble(BuildLengthTextBox.Text);
                if (BuildOpenBehindCheckBox.Checked)
                {
                    buildBehind = Convert.ToDouble(BuildBehindTextBox.Text);
                }
                int legalID = Convert.ToInt32(LegalDropDownList.SelectedValue);
                string direction = null;
                if (DirectionDropDownList.SelectedIndex != 0)
                {
                    direction = DirectionDropDownList.SelectedValue;
                }
                string frontStreet = null;
                if (FrontStreetDropDownList.SelectedIndex != 0)
                {
                    frontStreet = FrontStreetDropDownList.SelectedValue;
                }
                int locationID = Convert.ToInt32(LocationDropDownList.SelectedValue);
                decimal price = Convert.ToDecimal(PriceTextBox.Text);
                int unitID = Convert.ToInt32(UnitDropDownList.SelectedValue);
                int unitPriceID = Convert.ToInt32(UnitPriceDropDownList.SelectedValue);
                int? projectID = null;
                if (!ProjectCheckBox.Checked)
                {
                    projectID = Convert.ToInt32(ProjectDropDownList.SelectedValue);
                }

                int? contactID = null;

                // Insert Address
                addressID = RealEstateMarket._Default.db.InsertAddress(nationID, cityID, districtID, wardID, streetID, detail);

                // Check for News_Sale
                int newsSaleTypeID = Convert.ToInt32(NewsSaleTypeRadioButtonList.SelectedValue);
                string title;
                if (TitleTextBox.Text.Trim() == "")
                {
                    RealEstateServiceReference.ADDRESS address = new RealEstateServiceReference.ADDRESS();
                    address = RealEstateMarket._Default.db.GetAddress(addressID);
                    title = RealEstateMarket._Default.db.GetNewsSaleType(newsSaleTypeID).Name +
                    RealEstateMarket._Default.db.GetRealEstateType(Convert.ToInt32(RealEstateTypeDropDownList.SelectedValue)).Name +
                        ", " + address.Detail + " " +
                        address.STREET.Name + ", " +
                        address.WARD.Name + ", " +
                        address.DISTRICT.Name + ", " +
                        address.CITY.Name + ", " +
                        address.NATION.Name + ".";
                }
                else
                {
                    title = TitleTextBox.Text.Trim();
                }

                string content = ContentCKEditor.Text;
                int realEstateID = 0;
                int rate = RealEstateMarket._Default.db.GetMinRate();
                DateTime updateTime = System.DateTime.Now;


                // Action            
                if (ContactNameTextBox.Text != RealEstateMarket._Default.db.GetCustomerByUserName(User.Identity.Name).Name)
                {
                    // Check for Address Contact
                    int addressContactID = 0;
                    int nationContactID = Convert.ToInt32(AddressContactCustomControl.Attributes["NationID"]);
                    int cityContactID = Convert.ToInt32(AddressContactCustomControl.Attributes["CityID"]);
                    int districtContactID = Convert.ToInt32(AddressContactCustomControl.Attributes["DistrictID"]);
                    int wardContactID = Convert.ToInt32(AddressContactCustomControl.Attributes["WardID"]);
                    int streetContactID = Convert.ToInt32(AddressContactCustomControl.Attributes["StreetID"]);
                    string detailContact = AddressContactCustomControl.Attributes["Detail"];
                    addressContactID = RealEstateMarket._Default.db.InsertAddress(nationContactID, cityContactID, districtContactID,
                        wardContactID, streetContactID, detailContact);

                    contactID = RealEstateMarket._Default.db.InsertContact(ContactNameTextBox.Text, addressContactID,
                        ContactPhoneTextBox.Text, ContactHomePhoneTextBox.Text, ContactNoteTextBox.Text);
                }


                realEstateID = RealEstateMarket._Default.db.InsertRealEstate(realEstateTypeID, addressID,
                    livingRoom, bedRoom, bathRoom, storey, totalUseArea, 
                    campusFront, 
                    campuBehind,
                    campusLength,
                    buildFront, buildBehind, buildLength, legalID, direction, frontStreet, locationID, price,
                    unitID, unitPriceID, projectID, contactID);

                RealEstateMarket._Default.db.InsertNewsSale(newsSaleTypeID, title, content,
                    realEstateID, rate, updateTime);
                if (RealEstateMarket._Default.db.GetCustomerByUserName(User.Identity.Name) != null)
                {
                    RealEstateMarket._Default.db.InsertRealEstateToCustomer(realEstateID, RealEstateMarket._Default.db.GetCustomerByUserName(User.Identity.Name).ID);
                }

                // Insert Image
                bool flag = true;
                float intFileSizeLimit = 3072000;
                string strFileNameWithPath = ImageFileUpload.PostedFile.FileName;
                string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);
                string strFileName = System.IO.Path.GetFileName(strFileNameWithPath);
                int intFileSize = ImageFileUpload.PostedFile.ContentLength / 1024;
                strExtensionName = strExtensionName.ToLower();
                if (strExtensionName.Equals(".jpg") || strExtensionName.Equals(".gif")
                    || strExtensionName.Equals(".png"))
                {
                    if (intFileSize < intFileSizeLimit)
                    {
                        ImageFileUpload.PostedFile.SaveAs(Server.MapPath("~/Image/") + strFileName);
                        ErrorLabel.Text = "";
                    }
                    else
                    {
                        ErrorLabel.Text = "Kích thước hình ảnh phải nhỏ hơn " + intFileSizeLimit + " KB";
                        flag = false;
                    }
                }
                else
                {
                    if (strFileName == "")
                    {
                        ErrorLabel.Text = "Chưa chọn hình ảnh";
                    }
                    else
                    {
                        ErrorLabel.Text = "Chỉ được upload các hình ảnh có phần mở rộng là .jpg .gif .png";
                    }
                    flag = false;
                }
                if (flag)
                {
                    int imageID = RealEstateMarket._Default.db.InsertImage("", "~/Image/" + strFileName, "");
                    RealEstateMarket._Default.db.InsertImageToRealEstate(imageID, realEstateID);
                }

                // Insert Utility
                foreach (ListItem item in UtilityCheckBoxList.Items)
                {
                    if (item.Selected)
                    {
                        RealEstateMarket._Default.db.InsertUtilityToRealEstate(Convert.ToInt32(item.Value), realEstateID);
                    }
                }
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.ToString();
            }
            

            
        }

        protected void PreviewButton_Click(object sender, EventArgs e)
        {
            int nationID = Convert.ToInt32(AddressCustomControl.Attributes["NationID"]);
            int cityID = Convert.ToInt32(AddressCustomControl.Attributes["CityID"]);
            int districtID = Convert.ToInt32(AddressCustomControl.Attributes["DistrictID"]);
            int wardID = Convert.ToInt32(AddressCustomControl.Attributes["WardID"]);
            int streetID = Convert.ToInt32(AddressCustomControl.Attributes["StreetID"]);
            string detail = AddressCustomControl.Attributes["Detail"]; 
            
            int realEstateTypeID = Convert.ToInt32(RealEstateTypeDropDownList.SelectedValue);
            int livingRoom = Convert.ToInt32(LivingRoomDropDownList.SelectedValue);
            int bedRoom = Convert.ToInt32(BedRoomDropDownList.SelectedValue);
            int bathRoom = Convert.ToInt32(BathRoomDropDownList.SelectedValue);
            int storey = Convert.ToInt32(StoreyDropDownList.SelectedValue);
            double totalUseArea = Convert.ToDouble(TotalUseAreaTextBox.Text);
            double campusFront = Convert.ToDouble(CampusFrontTextBox.Text);
            double campusLength = Convert.ToDouble(CampusLengthTextBox.Text);
            double? campuBehind = null;
            double? buildBehind = null;
            if (CampusOpenBehindCheckBox.Checked)
            {
                campuBehind = Convert.ToDouble(CampusBehindTextBox.Text);
            }
            double buildFront = Convert.ToDouble(BuildFrontTextBox.Text);
            double buildLength = Convert.ToDouble(BuildLengthTextBox.Text);
            if (BuildOpenBehindCheckBox.Checked)
            {
                buildBehind = Convert.ToDouble(BuildBehindTextBox.Text);
            }
            int legalID = Convert.ToInt32(LegalDropDownList.SelectedValue);
            string direction = DirectionDropDownList.SelectedValue;
            string frontStreet = FrontStreetDropDownList.SelectedValue;
            int locationID = Convert.ToInt32(LocationDropDownList.SelectedValue);
            decimal price = Convert.ToDecimal(PriceTextBox.Text);
            int unitID = Convert.ToInt32(UnitDropDownList.SelectedValue);
            int unitPriceID = Convert.ToInt32(UnitPriceDropDownList.SelectedValue);
            int? projectID = null;
            if (!ProjectCheckBox.Checked)
            {
                projectID = Convert.ToInt32(ProjectDropDownList.SelectedValue);
            }
            int? contactID = null;
            // Check for News_Sale
            int newsSaleTypeID = Convert.ToInt32(NewsSaleTypeRadioButtonList.SelectedValue);
            string title;
            if (TitleTextBox.Text.Trim() == "")
            {
                RealEstateServiceReference.ADDRESS address = new RealEstateServiceReference.ADDRESS();
                address = RealEstateMarket._Default.db.GetAddress(16);
                title = RealEstateMarket._Default.db.GetNewsSaleType(newsSaleTypeID).Name +
                RealEstateMarket._Default.db.GetRealEstateType(Convert.ToInt32(RealEstateTypeDropDownList.SelectedValue)).Name +
                    ", " + address.Detail + " " +
                    address.STREET.Name + ", " +
                    address.WARD.Name + ", " +
                    address.DISTRICT.Name + ", " +
                    address.CITY.Name + ", " +
                    address.NATION.Name + ".";
            }
            else
            {
                title = TitleTextBox.Text.Trim();
            }

            string content = ContentCKEditor.Text;
            int realEstateID = 0;
            int rate = RealEstateMarket._Default.db.GetMinRate();
            DateTime updateTime = System.DateTime.Now;

            // Action            
            //if (ContactNameTextBox.Text != RealEstateMarket._Default.db.GetCustomerByUserName(User.Identity.Name).Name)
            //{
            //    // Check for Address Contact
            //    int addressContactID = 0;
            //    int nationContactID = Convert.ToInt32(AddressContactCustomControl.Attributes["NationID"]);
            //    int cityContactID = Convert.ToInt32(AddressContactCustomControl.Attributes["CityID"]);
            //    int districtContactID = Convert.ToInt32(AddressContactCustomControl.Attributes["DistrictID"]);
            //    int wardContactID = Convert.ToInt32(AddressContactCustomControl.Attributes["WardID"]);
            //    int streetContactID = Convert.ToInt32(AddressContactCustomControl.Attributes["StreetID"]);
            //    string detailContact = AddressContactCustomControl.Attributes["Detail"];
            //    addressContactID = RealEstateMarket._Default.db.InsertAddress(nationContactID, cityContactID, districtContactID,
            //        wardContactID, streetContactID, detailContact);

            //    contactID = RealEstateMarket._Default.db.InsertContact(ContactNameTextBox.Text, addressContactID,
            //        ContactPhoneTextBox.Text, ContactHomePhoneTextBox.Text, ContactNoteTextBox.Text);
            //}

            //realEstateID = RealEstateMarket._Default.db.InsertRealEstate(realEstateTypeID, 16,
            //        livingRoom, bedRoom, bathRoom, storey, totalUseArea,
            //        campusFront,
            //        campuBehind,
            //        campusLength,
            //        buildFront, buildBehind, buildLength, legalID, direction, frontStreet, locationID, price,
            //        unitID, unitPriceID, projectID, 1);
            int newsSaleID = 0;
            newsSaleTypeID = RealEstateMarket._Default.db.InsertNewsSale(newsSaleTypeID, title, content,
                    2, rate, updateTime);
            //if (RealEstateMarket._Default.db.GetCustomerByUserName(User.Identity.Name) != null)
            //{
            //    RealEstateMarket._Default.db.InsertRealEstateToCustomer(2, RealEstateMarket._Default.db.GetCustomerByUserName(User.Identity.Name).ID);
            //}
            // Insert Image
            //bool flag = true;
            //float intFileSizeLimit = 3072000;
            //string strFileNameWithPath = ImageFileUpload.PostedFile.FileName;
            //string strExtensionName = System.IO.Path.GetExtension(strFileNameWithPath);
            //string strFileName = System.IO.Path.GetFileName(strFileNameWithPath);
            //int intFileSize = ImageFileUpload.PostedFile.ContentLength / 1024;
            //strExtensionName = strExtensionName.ToLower();
            //if (strExtensionName.Equals(".jpg") || strExtensionName.Equals(".gif")
            //    || strExtensionName.Equals(".png"))
            //{
            //    if (intFileSize < intFileSizeLimit)
            //    {
            //        ImageFileUpload.PostedFile.SaveAs(Server.MapPath("~/Image/") + strFileName);
            //        ErrorLabel.Text = "";
            //    }
            //    else
            //    {
            //        ErrorLabel.Text = "Kích thước hình ảnh phải nhỏ hơn " + intFileSizeLimit + " KB";
            //        flag = false;
            //    }
            //}
            //else
            //{
            //    if (strFileName == "")
            //    {
            //        ErrorLabel.Text = "Chưa chọn hình ảnh";
            //    }
            //    else
            //    {
            //        ErrorLabel.Text = "Chỉ được upload các hình ảnh có phần mở rộng là .jpg .gif .png";
            //    }
            //    flag = false;
            //}
            //int imageID = 0;
            //if (flag)
            //{
            //    imageID = RealEstateMarket._Default.db.InsertImage("", "~/Image/" + strFileName, "");
            //    //RealEstateMarket._Default.db.InsertImageToRealEstate(imageID, realEstateID);
            //}
            string s = "";
            s += "XXX" +
                //"NationID = " + nationID + "<br />" +
                //"CityID = " + cityID + "<br />" +
                //"DistrictID = " + districtID + "<br />" +
                //"WardID = " + wardID + "<br />" +
                //"StreetID = " + streetID + "<br />" +
                //"Detail = " + detail + "<br />" +
                //"Loại Địa ốc = " + realEstateTypeID + "<br />" +
                //"Phòng khách = " + livingRoom + "<br />" +
                //"Phòng ngủ = " + bedRoom + "<br />" +
                //"Phòng tắm = " + bathRoom + "<br />" +
                //"Số lầu = " + storey + "<br />" +
                //"Tổng diện tích = " + totalUseArea + "<br />" +
                //"CampusFront = " + campusFront + "<br />" +
                //"CampusLength = " + campusLength + "<br />" +
                //"CampusBehind = " + campuBehind.ToString() + "<br />" +
                //"BuildFront = " + buildFront + "<br />" +
                //"BuildLength = " + buildLength + "<br />" +
                //"BuildBehind = " + buildBehind.ToString() + "<br />" +
                //"Pháp lý = " + legalID + "<br />" +
                //"Hướng = " + direction + "<br />" +
                //"Đường trước nhà = " + frontStreet + "<br />" +
                //"Vị trí = " + locationID + "<br />" +
                //"Giá = " + price + "<br />" +
                //"Đơn vị = " + unitID + "<br />" +
                //"Đơn giá = " + unitPriceID + "<br />" +
                //"Dự án = " + projectID + "<br />" +
                //"Liên hệ = " + contactID.ToString() + "<br />" +
                "Loại tin rao = " + newsSaleTypeID + "<br />" +
                "Tiêu đề = " + title + "<br />" +
                "Nội dung = " + content + "<br />" +
                "Đánh giá = " + rate + "<br />" +
                "Thời gian = " + updateTime.ToLongDateString() + "<br />" +
                "Địa ốc = " + realEstateID + "<br />" +
                "Tin rao = " + newsSaleID + "<br />";
            ErrorLabel.Text = s;
        }
    }
}