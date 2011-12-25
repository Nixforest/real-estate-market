using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Member
{
    public partial class EditNewsSale : System.Web.UI.Page
    {
        protected List<string> listImage = new List<string>();
        private int editId = 0;
        private RealEstateServiceReference.NEWS_SALE newsSale;
        private RealEstateServiceReference.REAL_ESTATE realEstate;
        private RealEstateServiceReference.ADDRESS address;
        private RealEstateServiceReference.CONTACT contact;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            editId = Convert.ToInt32(Request.QueryString["editId"]);
            newsSale = RealEstateMarket._Default.db.GetNewsSale(editId);
            realEstate = RealEstateMarket._Default.db.GetRealEstate(newsSale.RealEstateID);
            address = RealEstateMarket._Default.db.GetAddress(realEstate.AddressID);
            contact = RealEstateMarket._Default.db.GetContact(realEstate.ContactID.GetValueOrDefault());
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("Customer"))
            {
                Response.Redirect("~/AccessDeny.aspx");
            }
            if (!IsPostBack)
            {
                {
                    NewsSaleTypeRadioButtonList.SelectedValue = newsSale.TypeID.ToString();
                    RealEstateTypeDropDownList.SelectedValue = realEstate.TypeID.ToString();
                    LocationDropDownList.SelectedValue = realEstate.LocationID.ToString();

                    //--------------------Address---------------------------
                    // Nation
                    NationDropDownList.DataSource = RealEstateMarket._Default.db.GetAllNations();
                    NationDropDownList.DataTextField = "Name";
                    NationDropDownList.DataValueField = "ID";
                    NationDropDownList.DataBind();                    
                    NationDropDownList.SelectedValue = address.NationID.ToString();
                    // City
                    CityDropDownList.DataSource = RealEstateMarket._Default.db.GetCitiesByNationID(address.NationID);
                    CityDropDownList.DataTextField = "Name";
                    CityDropDownList.DataValueField = "ID";
                    CityDropDownList.DataBind();
                    CityDropDownList.SelectedValue = address.CityID.ToString();
                    // District
                    DistrictDropDownList.DataSource = RealEstateMarket._Default.db.GetDistrictsByCityID(address.CityID);
                    DistrictDropDownList.DataTextField = "Name";
                    DistrictDropDownList.DataValueField = "ID";
                    DistrictDropDownList.DataBind();
                    if (address.DistrictID != null)
                    {
                        DistrictDropDownList.SelectedValue = address.DistrictID.ToString();
                        // Ward
                        WardDropDownList.DataSource = RealEstateMarket._Default.db.GetWardsByDistrictID(address.DistrictID.Value);
                        WardDropDownList.DataTextField = "Name";
                        WardDropDownList.DataValueField = "ID";
                        WardDropDownList.DataBind();
                        if (address.WardID != null)
                        {
                            WardDropDownList.SelectedValue = address.WardID.Value.ToString();
                            // Street
                            StreetDropDownList.DataSource = RealEstateMarket._Default.db.GetStreetsByDistrictID(address.DistrictID.Value);
                            StreetDropDownList.DataTextField = "Name";
                            StreetDropDownList.DataValueField = "ID";
                            StreetDropDownList.DataBind();
                            if (address.StreetID != null)
                            {
                                StreetDropDownList.SelectedValue = address.StreetID.ToString();
                            }
                            else
                            {
                                StreetDropDownList.SelectedIndex = 0;
                            }
                        }
                        else
                        {
                            WardDropDownList.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        DistrictDropDownList.SelectedIndex = 0;
                        DifferentCheckBox.Checked = true;
                        WardDropDownList.DataSource = RealEstateMarket._Default.db.GetWardsByDistrictID(Convert.ToInt32(DistrictDropDownList.SelectedValue));
                        WardDropDownList.DataTextField = "Name";
                        WardDropDownList.DataValueField = "ID";
                        WardDropDownList.DataBind();
                        StreetDropDownList.DataSource = RealEstateMarket._Default.db.GetStreetsByDistrictID(Convert.ToInt32(DistrictDropDownList.SelectedValue));
                        StreetDropDownList.DataTextField = "Name";
                        StreetDropDownList.DataValueField = "ID";
                        StreetDropDownList.DataBind();
                        DistrictDropDownList.Enabled = !DifferentCheckBox.Checked;
                        WardDropDownList.Enabled = !DifferentCheckBox.Checked;
                        StreetDropDownList.Enabled = !DifferentCheckBox.Checked;
                    }
                    DetailTextBox.Text = address.Detail;

                    //------------------Project--------------------------
                    ProjectDropDownList.DataSource = RealEstateMarket._Default.db.GetAllProjects();
                    ProjectDropDownList.DataTextField = "Name";
                    ProjectDropDownList.DataValueField = "ID";
                    ProjectDropDownList.DataBind();
                    if (realEstate.ProjectID != null)
                    {                        
                        ProjectDropDownList.SelectedValue = realEstate.ProjectID.Value.ToString();
                    }
                    else
                    {
                        ProjectCheckBox.Checked = true;
                        ProjectDropDownList.Enabled = !ProjectCheckBox.Checked;
                    }

                    //------------------Price----------------------
                    PriceTextBox.Text = realEstate.Price.ToString().Replace(",", ".");
                    UnitDropDownList.SelectedValue = realEstate.UnitID.ToString();
                    UnitPriceDropDownList.SelectedValue = realEstate.UnitPriceID.ToString();
                    if (newsSale.Broker)
                    {
                        BrokerRadioButtonList.SelectedIndex = 1;
                    }
                    else
                    {
                        BrokerRadioButtonList.SelectedIndex = 0;
                    }

                    //-----------------Area-------------------
                    TotalUseAreaTextBox.Text = realEstate.TotalUseArea.Value.ToString();
                    if (realEstate.CampusFront.HasValue)
                    {
                        CampusFrontTextBox.Text = realEstate.CampusFront.Value.ToString();
                    }
                    if (realEstate.CampusLength.HasValue)
                    {
                        CampusLengthTextBox.Text = realEstate.CampusLength.Value.ToString();
                    }
                    if (realEstate.CampusBehind.HasValue)
                    {
                        CampusOpenBehindCheckBox.Checked = true;
                        CampusMLabel.Visible = CampusOpenBehindCheckBox.Checked;
                        CampusBehindTextBox.Visible = CampusOpenBehindCheckBox.Checked;
                        
                        CampusBehindTextBox.Text = realEstate.CampusBehind.Value.ToString();
                    }
                    if (realEstate.BuildFront.HasValue)
                    {
                        BuildFrontTextBox.Text = realEstate.BuildFront.Value.ToString();
                    }
                    if (realEstate.BuildLength.HasValue)
                    {
                        BuildLengthTextBox.Text = realEstate.BuildLength.Value.ToString();
                    }
                    if (realEstate.BuildBehind.HasValue)
                    {
                        BuildOpenBehindCheckBox.Checked = true;
                        BuildMLabel.Visible = BuildOpenBehindCheckBox.Checked;
                        BuildBehindTextBox.Visible = BuildOpenBehindCheckBox.Checked;
                        BuildBehindTextBox.Text = realEstate.BuildBehind.Value.ToString();
                    }
                    //------------Legal-----------------------------
                    LegalDropDownList.DataSource = RealEstateMarket._Default.db.GetAllLegals();
                    LegalDropDownList.DataTextField = "Name";
                    LegalDropDownList.DataValueField = "ID";
                    LegalDropDownList.DataBind();
                    LegalDropDownList.SelectedValue = realEstate.LegalID.ToString();
                    DirectionDropDownList.SelectedValue = realEstate.Direction;
                    StoreyDropDownList.SelectedIndex = realEstate.Storey.GetValueOrDefault();
                    LivingRoomDropDownList.SelectedIndex = realEstate.LivingRoom.GetValueOrDefault();
                    BedRoomDropDownList.SelectedIndex = realEstate.BedRoom.GetValueOrDefault();
                    BathRoomDropDownList.SelectedIndex = realEstate.BathRoom.GetValueOrDefault();
                    DifferentRoomDropDownList.SelectedIndex = realEstate.DifferentRoom.GetValueOrDefault();

                    //---------------------Utility----------------------------
                    foreach (RealEstateServiceReference.UTILITY_DETAIL item in realEstate.UTILITY_DETAILs)
                    {
                        if (item.UtilityID == 1)
                        {
                            FullCheckBox.Checked = true;
                        }
                        if (item.UtilityID == 2)
                        {
                            GarageCheckBox.Checked = true;
                        }
                        if (item.UtilityID == 3)
                        {
                            GardenCheckBox.Checked = true;
                        }
                        if (item.UtilityID == 4)
                        {
                            SwimmingPoolCheckBox.Checked = true;
                        }
                        if (item.UtilityID == 5)
                        {
                            ForSaleCheckBox.Checked = true;
                        }
                        if (item.UtilityID == 6)
                        {
                            ForStayCheckBox.Checked = true;
                        }
                        if (item.UtilityID == 7)
                        {
                            ForOfficeCheckBox.Checked = true;
                        }
                        if (item.UtilityID == 8)
                        {
                            ForProduceCheckBox.Checked = true;
                        }
                        if (item.UtilityID == 9)
                        {
                            ForRentCheckBox.Checked = true;
                        }
                    }

                    //---------------NewsSale------------------------
                    TitleTextBox.Text = newsSale.Title;
                    ContentCKEditor.Text = newsSale.Content;

                    //---------------Contact------------------------
                    if (realEstate.ContactID != 0)
                    {
                        ContactNameTextBox.Text = contact.Name;
                        ContactHomePhoneTextBox.Text = contact.HomePhone;
                        ContactPhoneTextBox.Text = contact.Phone;
                        ContactAddressTextBox.Text = contact.Address;
                        ContactNoteTextBox.Text = contact.Note;
                    }
                }
            }
        }

        protected void PostButton_Click(object sender, EventArgs e)
        {
            try
            {
                //-------- Upload Image to Server--------
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
                int nationID = Convert.ToInt32(NationDropDownList.SelectedValue);
                int cityID = Convert.ToInt32(CityDropDownList.SelectedValue);
                int? districtID = null;
                int? wardID = null;
                int? streetID = null;
                string detail = DetailTextBox.Text;
                bool different = DifferentCheckBox.Checked;
                if (!different)
                {
                    districtID = Convert.ToInt32(DistrictDropDownList.SelectedValue);
                    wardID = Convert.ToInt32(WardDropDownList.SelectedValue);
                    streetID = Convert.ToInt32(StreetDropDownList.SelectedValue);
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
                decimal price = Convert.ToDecimal(PriceTextBox.Text);
                int unitID = Convert.ToInt32(UnitDropDownList.SelectedValue);
                int unitPriceID = Convert.ToInt32(UnitPriceDropDownList.SelectedValue);
                int? projectID = 0;
                if (!ProjectCheckBox.Checked)
                {
                    projectID = Convert.ToInt32(ProjectDropDownList.SelectedValue);
                }

                int? contactID = 0;

                //-------- Insert address for realestate ----------------
                addressID = RealEstateMarket._Default.db.UpdateAddress(address.ID, nationID, cityID, districtID, wardID, streetID, detail);

                //-------- Check for News_Sale ----------------
                int newsSaleTypeID = Convert.ToInt32(NewsSaleTypeRadioButtonList.SelectedValue);
                string title;
                if (TitleTextBox.Text.Trim() == "")
                {
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
                int rate = newsSale.Rate.Value;
                DateTime updateTime = System.DateTime.Now;
                int status = newsSale.Status;
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
                    contactID = RealEstateMarket._Default.db.UpdateContact(realEstate.ContactID.GetValueOrDefault(), ContactNameTextBox.Text, ContactAddressTextBox.Text,
                        ContactPhoneTextBox.Text, ContactHomePhoneTextBox.Text, ContactNoteTextBox.Text);
                }

                //------------------------ RealEstate ----------------------------
                realEstateID = RealEstateMarket._Default.db.UpdateRealEstate(newsSale.RealEstateID, realEstateTypeID, addressID,
                    livingRoom, bedRoom, bathRoom, differentRoom, storey, totalUseArea,
                    campusFront, campuBehind, campusLength,
                    buildFront, buildBehind, buildLength,
                    legalID, direction, frontStreet, locationID, price,
                    unitID, unitPriceID, projectID, contactID);

                //------------------------ News Sale -----------------------------
                int newsSaleID = RealEstateMarket._Default.db.UpdateNewsSale(editId, newsSaleTypeID, title, content,
                    realEstateID, rate, updateTime, status, broker);

                //----------------------- RealEstate's Image ------------------------
                if (listImage.Count > 0)
                {
                    foreach (string item in listImage)
                    {
                        int imageID = RealEstateMarket._Default.db.InsertImage("", "~/Image/images/" + item, "");
                        RealEstateMarket._Default.db.InsertImageToRealEstate(imageID, realEstateID);
                    }
                }
                //----------------------- RealEstate's Utility -----------------------
                RealEstateMarket._Default.db.RemoveAllUtilitiesByRealEstateID(realEstateID);
                if (FullCheckBox.Checked)
                {
                    RealEstateMarket._Default.db.InsertUtilityToRealEstate(1, realEstateID);
                }
                if (GarageCheckBox.Checked)
                {
                    RealEstateMarket._Default.db.InsertUtilityToRealEstate(2, realEstateID);
                }
                if (GardenCheckBox.Checked)
                {
                    RealEstateMarket._Default.db.InsertUtilityToRealEstate(3, realEstateID);
                }
                if (SwimmingPoolCheckBox.Checked)
                {
                    RealEstateMarket._Default.db.InsertUtilityToRealEstate(4, realEstateID);
                }
                if (ForSaleCheckBox.Checked)
                {
                    RealEstateMarket._Default.db.InsertUtilityToRealEstate(5, realEstateID);
                }
                if (ForStayCheckBox.Checked)
                {
                    RealEstateMarket._Default.db.InsertUtilityToRealEstate(6, realEstateID);
                }
                if (ForOfficeCheckBox.Checked)
                {
                    RealEstateMarket._Default.db.InsertUtilityToRealEstate(7, realEstateID);
                }
                if (ForProduceCheckBox.Checked)
                {
                    RealEstateMarket._Default.db.InsertUtilityToRealEstate(8, realEstateID);
                }
                if (ForRentCheckBox.Checked)
                {
                    RealEstateMarket._Default.db.InsertUtilityToRealEstate(9, realEstateID);
                }
                //ErrorLabel.Text = "Bạn đăng tin rao bán thành công!";
                Response.Redirect(String.Format("~/Pages/NewsSale/NewsSale.aspx?id={0}", editId));
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.ToString();
            }
                    
        }
        protected void NationDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CityDropDownList.DataSource = RealEstateMarket._Default.db.GetCitiesByNationID(Convert.ToInt32(NationDropDownList.SelectedValue));
            CityDropDownList.DataTextField = "Name";
            CityDropDownList.DataValueField = "ID";
            CityDropDownList.DataBind();
        }
        protected void CityDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DistrictDropDownList.DataSource = RealEstateMarket._Default.db.GetDistrictsByCityID(Convert.ToInt32(CityDropDownList.SelectedValue));
            DistrictDropDownList.DataTextField = "Name";
            DistrictDropDownList.DataValueField = "ID";
            DistrictDropDownList.DataBind();
        }
        protected void DistrictDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            WardDropDownList.DataSource = RealEstateMarket._Default.db.GetWardsByDistrictID(Convert.ToInt32(DistrictDropDownList.SelectedValue));
            WardDropDownList.DataTextField = "Name";
            WardDropDownList.DataValueField = "ID";
            WardDropDownList.DataBind();
            StreetDropDownList.DataSource = RealEstateMarket._Default.db.GetStreetsByDistrictID(Convert.ToInt32(DistrictDropDownList.SelectedValue));
            StreetDropDownList.DataTextField = "Name";
            StreetDropDownList.DataValueField = "ID";
            StreetDropDownList.DataBind();
        }
        protected void WardDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void StreetDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void DifferentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DistrictDropDownList.Enabled = !DifferentCheckBox.Checked;
            WardDropDownList.Enabled = !DifferentCheckBox.Checked;
            StreetDropDownList.Enabled = !DifferentCheckBox.Checked;
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
    }
}