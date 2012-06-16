using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Member
{
    public partial class NewsSaleRegistration : System.Web.UI.Page
    {
        protected List<string> listImage = new List<string>();
        int editId = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            // Only Customer or highter role can access
            if (!User.IsInRole("Customer"))
            {
                Response.Redirect("~/AccessDeny.aspx");
            }

            // Initializing
            if (!IsPostBack)
            {                
                Title = "Đăng tài sản mới";
                NewsSaleTypeRadioButtonList.SelectedIndex = 0;
                ProjectDropDownList.SelectedValue = "0";
                if (RealEstateMarket._Default.db.GetCustomerByUserName(User.Identity.Name) != null)
                {
                    ContactNameTextBox.Text = RealEstateMarket._Default.db.GetCustomerByUserName(User.Identity.Name).Name;
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CKFinder.FileBrowser _FileBrowser = new CKFinder.FileBrowser();
            _FileBrowser.BasePath = "../ckfinder/";
            _FileBrowser.SetupCKEditor(ContentCKEditor);
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
                //-------- Upload Image to Server--------
                bool flag = true;
                float intFileSizeLimit = 3072000;
                List<FileUpload> listFileUpload = new List<FileUpload>();                   // List FileUpload Control
                listFileUpload.Add(ImageFileUpload0);
                listFileUpload.Add(ImageFileUpload1);
                listFileUpload.Add(ImageFileUpload2);
                listFileUpload.Add(ImageFileUpload3);
                listFileUpload.Add(ImageFileUpload4);
                listFileUpload.Add(ImageFileUpload5);
                listFileUpload.Add(ImageFileUpload6);
                listFileUpload.Add(ImageFileUpload7);
                listFileUpload.Add(ImageFileUpload8);
                listFileUpload.Add(ImageFileUpload9);
                foreach (FileUpload item in listFileUpload)
                {
                    if (System.IO.Path.GetFileName(item.PostedFile.FileName) != "")                 // if exist file to upload
                    {
                        listImage.Add(item.PostedFile.FileName);
                        int intFileSize = item.PostedFile.ContentLength / 1024;
                        string strExtensionName = System.IO.Path.GetExtension(item.PostedFile.FileName).ToLower();
                        if (strExtensionName.Equals(".jpg") || strExtensionName.Equals(".gif")
                            || strExtensionName.Equals(".png"))
                        {
                            if (intFileSize < intFileSizeLimit)                                     // file size must smaller than limiter
                            {
                                item.PostedFile.SaveAs(Server.MapPath("~/Image/images/") + System.IO.Path.GetFileName(item.PostedFile.FileName));  // Upload
                                ErrorLabel.Text = "";
                            }
                            else
                            {
                                //ErrorLabel.Text = "Kích thước hình ảnh phải nhỏ hơn " + intFileSizeLimit + " KB";
                                throw new Exception("Kích thước hình ảnh phải nhỏ hơn " + intFileSizeLimit + " KB");
                            }
                        }
                        else
                        {
                            //ErrorLabel.Text = "Chỉ được upload các hình ảnh có phần mở rộng là .jpg .gif .png";
                            throw new Exception("Chỉ được upload các hình ảnh có phần mở rộng là .jpg .gif .png");
                        }
                    }
                }

                //-------- Check for Address Real Estate----------------
                int addressID = 0;
                int nationID = Convert.ToInt32(AddressCustomControl.Attributes["NationID"]);
                int cityID = Convert.ToInt32(AddressCustomControl.Attributes["CityID"]);
                int? districtID = null; 
                int? wardID = null; 
                int? streetID = null; 
                string detail = AddressCustomControl.Attributes["Detail"];
                bool different = Convert.ToBoolean(AddressCustomControl.Attributes["Different"]);
                if (!different)
                {
                    districtID = Convert.ToInt32(AddressCustomControl.Attributes["DistrictID"]);
                    wardID = Convert.ToInt32(AddressCustomControl.Attributes["WardID"]);
                    streetID = Convert.ToInt32(AddressCustomControl.Attributes["StreetID"]);
                }

                //-------- Check for Real Estate ----------------
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
                int? differentRoom = null;
                if (DifferentRoomDropDownList.SelectedIndex != 0)
                {
                    differentRoom = Convert.ToInt32(DifferentRoomDropDownList.SelectedValue);
                }
                int? storey = null;
                if (StoreyDropDownList.SelectedIndex != 0)
                {
                    storey = Convert.ToInt32(StoreyDropDownList.SelectedValue);
                }

                double totalUseArea = Convert.ToDouble(TotalUseAreaTextBox.Text);
                double campusFront = 0.0;
                if (!String.IsNullOrEmpty(CampusFrontTextBox.Text))
                {
                    campusFront = Convert.ToDouble(CampusFrontTextBox.Text);
                }
                double campusLength = 0.0;
                if (!String.IsNullOrEmpty(CampusLengthTextBox.Text))
                {
                    campusLength = Convert.ToDouble(CampusLengthTextBox.Text);
                }
                double? campuBehind = null;
                double? buildBehind = null;
                if (CampusOpenBehindCheckBox.Checked)
                {
                    if (!String.IsNullOrEmpty(CampusBehindTextBox.Text))
                    {
                        campuBehind = Convert.ToDouble(CampusBehindTextBox.Text);
                    }
                }
                double buildFront = 0.0;
                if (!String.IsNullOrEmpty(BuildFrontTextBox.Text))
                {
                    buildFront = Convert.ToDouble(BuildFrontTextBox.Text);
                }
                double buildLength = 0.0;
                if (!String.IsNullOrEmpty(BuildLengthTextBox.Text))
                {
                    buildLength = Convert.ToDouble(BuildLengthTextBox.Text);
                }
                if (BuildOpenBehindCheckBox.Checked)
                {
                    if (!String.IsNullOrEmpty(BuildBehindTextBox.Text))
                    {
                        buildBehind = Convert.ToDouble(BuildBehindTextBox.Text);
                    }
                }
                int legalID = Convert.ToInt32(LegalDropDownList.SelectedValue);
                string direction = "";
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
                decimal price = 0;
                if (!String.IsNullOrEmpty(PriceInput.Value))
                {
                    price = Convert.ToDecimal(PriceInput.Value);
                }
                int unitID = Convert.ToInt32(UnitDropDownList.SelectedValue);
                int unitPriceID = Convert.ToInt32(UnitPriceDropDownList.SelectedValue);
                int? projectID = 0;
                if (!ProjectCheckBox.Checked)
                {
                    projectID = Convert.ToInt32(ProjectDropDownList.SelectedValue);
                }

                int? contactID = 0;

                //-------- Insert address for realestate ----------------
                addressID = RealEstateMarket._Default.db.InsertAddress(nationID, cityID, districtID, wardID, streetID, detail);


                //-------- Check for News_Sale ----------------
                int newsSaleTypeID = Convert.ToInt32(NewsSaleTypeRadioButtonList.SelectedValue);
                string title;
                if (TitleTextBox.Text.Trim() == "")
                {
                    RealEstateServiceReference.ADDRESS address = new RealEstateServiceReference.ADDRESS();
                    address = RealEstateMarket._Default.db.GetAddress(addressID);
                    title = RealEstateMarket._Default.db.GetNewsSaleType(newsSaleTypeID).Name + " " +
                    RealEstateMarket._Default.db.GetRealEstateType(Convert.ToInt32(RealEstateTypeDropDownList.SelectedValue)).Name +
                        ", " + RealEstateMarket.Pages.Project.Project.GetAddressString(address.ID);
                }
                else
                {
                    title = TitleTextBox.Text.Trim();
                }

                string content = ContentCKEditor.Text;
                int realEstateID = 0;
                int rate = RealEstateMarket._Default.db.GetParameter("MinRate");
                DateTime updateTime = System.DateTime.Now;
                int status = RealEstateMarket._Default.db.GetParameter("Unactived");
                bool broker = false;
                if (BrokerRadioButtonList.SelectedIndex == 1)
                {
                    broker = true;
                }

                /////////////////////////////////////////////////////////////////////
                //---------------- Contact --------------------------------
                if ((ContactNameTextBox.Text != RealEstateMarket._Default.db.GetCustomerByUserName(User.Identity.Name).Name) || ContactAddressTextBox.Text.Trim() != "")     // Contact maybe not customer
                {
                    // Insert a contact
                    contactID = RealEstateMarket._Default.db.InsertContact(ContactNameTextBox.Text, ContactAddressTextBox.Text,
                        ContactPhoneTextBox.Text, ContactHomePhoneTextBox.Text, ContactNoteTextBox.Text);
                }

                //------------------------ RealEstate ----------------------------
                realEstateID = RealEstateMarket._Default.db.InsertRealEstate(realEstateTypeID, addressID,
                    livingRoom, bedRoom, bathRoom, differentRoom, storey, totalUseArea, 
                    campusFront, campuBehind,campusLength,
                    buildFront, buildBehind, buildLength, 
                    legalID, direction, frontStreet, locationID, price,
                    unitID, unitPriceID, projectID, contactID);

                //------------------------ News Sale -----------------------------
                int newsSaleID = RealEstateMarket._Default.db.InsertNewsSale(newsSaleTypeID, title, content,
                    realEstateID, rate, updateTime, status, broker);
                if (RealEstateMarket._Default.db.GetCustomerByUserName(User.Identity.Name) != null)
                {
                    RealEstateMarket._Default.db.InsertRealEstateToCustomer(realEstateID, RealEstateMarket._Default.db.GetCustomerByUserName(User.Identity.Name).ID);
                }

                //----------------------- RealEstate's Image ------------------------
                if (listImage.Count > 0)
                {
                    foreach (string item in listImage)
                    {
                        int imageID = RealEstateMarket._Default.db.InsertImage("", "~/Image/images/" + item, "");
                        RealEstateMarket._Default.db.InsertImageToRealEstate(imageID, realEstateID);
                    }
                }
                RealEstateMarket._Default.db.InsertImageToRealEstate(realEstateTypeID, realEstateID);       // Default image for RealEstate type

                //----------------------- RealEstate's Utility -----------------------
                foreach (ListItem item in UtilityCheckBoxList.Items)
                {
                    if (item.Selected)
                    {
                        RealEstateMarket._Default.db.InsertUtilityToRealEstate(Convert.ToInt32(item.Value), realEstateID);
                    }
                }
                //ErrorLabel.Text = "Bạn đăng tin rao bán thành công!";
                Response.Redirect(String.Format("~/Pages/NewsSale/NewsSale.aspx?id={0}", newsSaleID));
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.ToString();
            }
        }

        protected void PreviewButton_Click(object sender, EventArgs e)
        {
            //ErrorLabel.Text = String.IsNullOrEmpty(PriceInput.Value).ToString();
            Response.Redirect("~/Pages/TempPage.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Pages/TempPage.aspx");
        }
    }
}