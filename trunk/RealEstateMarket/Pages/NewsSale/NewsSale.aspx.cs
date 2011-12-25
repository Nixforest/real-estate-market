using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Pages
{
    public partial class NewsSale : System.Web.UI.Page
    {
        private RealEstateServiceReference.NEWS_SALE newsSale;
        private int id;
        private RealEstateServiceReference.REAL_ESTATE realEstate;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            try
            {
                int id = Convert.ToInt32(Request.QueryString["id"]);
                newsSale = RealEstateMarket._Default.db.GetNewsSale(id);
                realEstate = RealEstateMarket._Default.db.GetRealEstate(newsSale.RealEstateID);
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("RealEstateDataContext.Utility"))
                {
                    Response.Redirect("~/Pages/ErrorPage.aspx");
                }
            }
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                //------------------ Title -------------------------------------
                Title                    = newsSale.Title;
                TitleLabel.Text          = newsSale.Title;
                SlideShowImage.ImageUrl  = RealEstateMarket._Default.db.GetImagesByRealEstateID(newsSale.RealEstateID)[0].Path;
                NewsSaleTypeImage.ImageUrl = (newsSale.TypeID == 1) ? (String.Format("~/Image/ico_canban.gif")) : (
                                            (newsSale.TypeID == 2) ? (String.Format("~/Image/ico_canmua.gif")) : (
                                            (newsSale.TypeID == 3) ? (String.Format("~/Image/ico_canthue.gif")) : (String.Format("~/Image/ico_chothue.gif"))));
                NewsSaleTypeImage.ToolTip = RealEstateMarket._Default.db.GetNewsSaleType(newsSale.TypeID).Name;
                RealEstateIDLabel.Text   = (newsSale.RealEstateID + 300000).ToString();
                AddressTitle.Text = RealEstateMarket.Pages.Project.Project.GetAddressString(realEstate.AddressID);
                // Price
                UnitLabel.Text = RealEstateMarket._Default.db.GetUnit(realEstate.UnitID).Name;//UnitDropDownList.SelectedValue = realEstate.UnitID.ToString();
                //GetPrice();
                //UnitDropDownList_SelectedIndexChanged(new object(), new EventArgs());
                PriceLabel.Text = Utility.ConvertPriceText(Convert.ToInt32(newsSale.ID));
                
                UnitPriceLabel.Text = " / " + realEstate.UNIT_PRICE.Name;
                LivingRoomLabel.Text     = realEstate.LivingRoom.ToString();
                BedRoomLabel.Text        = realEstate.BedRoom.ToString();
                BathRoomLabel.Text       = realEstate.BathRoom.ToString();
                DifferentRoomLabel.Text = realEstate.DifferentRoom.ToString();
                CampusFrontLabel.Text    = (realEstate.CampusFront == 0) ? ("_") : (realEstate.CampusFront.ToString());
                CampustLengthLabel.Text  = (realEstate.CampusLength == 0) ? ("_") : (realEstate.CampusLength.ToString());
                TotalUseAreaLabel.Text   = realEstate.TotalUseArea.ToString();
                if (realEstate.ContactID != 0)        // Contact exist
                {
                    ContactNameLabel.Text = realEstate.CONTACT.Name;
                    AddressContactLabel.Text = realEstate.CONTACT.Address;
                    ContactHomePhoneLabel.Text = realEstate.CONTACT.HomePhone;
                    ContactPhoneLabel.Text = realEstate.CONTACT.Phone;
                    ContactNoteLabel.Text = realEstate.CONTACT.Note;
                }
                ContentLabel.Text       = newsSale.Content;

                //---------------- Detail Information ----------------------------
                TotalUseAreaLabel1.Text  = realEstate.TotalUseArea.ToString();
                RETypeLabel.Text         = RealEstateMarket._Default.db.GetRealEstateTypeByRealEstateID(newsSale.RealEstateID).Name; //realEstate.REAL_ESTATE_TYPE.Name;
                CampusFrontLabel1.Text   = CampusFrontLabel.Text;
                CampusBehindLabel.Text   = (realEstate.CampusBehind == 0) ? ("_") : (realEstate.CampusBehind.ToString());
                CampusLengthLabel1.Text  = CampustLengthLabel.Text;
                BuildFrontLabel.Text     = (realEstate.BuildFront == 0) ? ("_") : (realEstate.BuildFront.ToString());
                BuildBedindLabel.Text    = (realEstate.BuildBehind == 0) ? ("_") : (realEstate.BuildBehind.ToString());
                BuildLengthLabel.Text    = (realEstate.BuildLength == 0) ? ("_") : (realEstate.BuildLength.ToString());
                LegalLabel.Text          = (realEstate.LegalID == 0) ? ("_") : (realEstate.LEGAL.Name);
                DirectionLabel.Text      = realEstate.Direction;
                FrontStreetLabel.Text    = realEstate.FrontStreet;
                LocationLabel.Text       = (realEstate.LocationID == 0) ? ("_") : (realEstate.LOCATION.Name);
                StoreyLabel.Text         = realEstate.Storey.ToString();
                LivingRoomLabel1.Text    = LivingRoomLabel.Text;
                BedRoomLabel1.Text       = BedRoomLabel.Text;
                BathRoomLabel1.Text      = BathRoomLabel.Text;
                DifferentRoomLabel1.Text = DifferentRoomLabel.Text;

                foreach (RealEstateServiceReference.UTILITY_DETAIL item in realEstate.UTILITY_DETAILs)
                {
                    if (item.UtilityID == 1)
                    {
                        FullImage.Visible = true;
                    }
                    if (item.UtilityID == 2)
                    {
                        GarageImage.Visible = true;
                    }
                    if (item.UtilityID == 3)
                    {
                        GardenImage.Visible = true;
                    }
                    if (item.UtilityID == 4)
                    {
                        SwimmingPoolImage.Visible = true;
                    }
                    if (item.UtilityID == 5)
                    {
                        ForSaleImage.Visible = true;
                    }
                    if (item.UtilityID == 6)
                    {
                        ForStayImage.Visible = true;
                    }
                    if (item.UtilityID == 7)
                    {
                        ForOfficeImage.Visible = true;
                    }
                    if (item.UtilityID == 8)
                    {
                        ForProduceImage.Visible = true;
                    }
                    if (item.UtilityID == 9)
                    {
                        ForRentImage.Visible = true;
                    }
                }

                //------------------- Member Information ---------------------------------
                if (RealEstateMarket._Default.db.GetCustomerByRealEstateID(newsSale.RealEstateID) != null)
                {
                    RealEstateServiceReference.CUSTOMER customer = RealEstateMarket._Default.db.GetCustomerByRealEstateID(newsSale.RealEstateID);
                    MemberNameLabel.Text      = customer.Name;
                    AddressMemberLabel.Text = RealEstateMarket.Pages.Project.Project.GetAddressString(customer.AddressID);
                    MemberHomePhoneLabel.Text = customer.HomePhone;
                    MemberPhoneLabel.Text     = customer.Phone;
                }

            }
        }

        protected void UnitDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetPrice();
        }
       
        protected void GetPrice()
        {
            PriceLabel.Text = Utility.ConvertPriceText(Convert.ToInt32(newsSale.ID));
            //if (RealEstateMarket._Default.db.GetUnit(Convert.ToInt32(UnitDropDownList.SelectedValue)).Name == "VND")
            //{
            //    PriceLabel.Text = Utility.ConvertPriceText(Convert.ToInt32(newsSale.ID));
            //}
            //if (RealEstateMarket._Default.db.GetUnit(Convert.ToInt32(UnitDropDownList.SelectedValue)).Name == "SJC")
            //{
            //    PriceLabel.Text = Utility.ConvertVNDToSJC(Convert.ToDouble(realEstate.Price)).ToString() + " lượng";
            //}
            //if (RealEstateMarket._Default.db.GetUnit(Convert.ToInt32(UnitDropDownList.SelectedValue)).Name == "USD")
            //{
            //    PriceLabel.Text = Utility.ConvertVNDToUSD(Convert.ToDouble(realEstate.Price)).ToString() + "USD";
            //}
        }
    }
}