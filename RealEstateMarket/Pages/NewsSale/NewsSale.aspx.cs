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
        RealEstateServiceReference.NEWS_SALE newsSale = new RealEstateServiceReference.NEWS_SALE();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            
            newsSale = RealEstateMarket._Default.db.GetNewsSale(id);
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
                AddressTitle.Text        = RealEstateMarket.Pages.Project.GetAddressString(newsSale.REAL_ESTATE.AddressID);
                // Price
                UnitDropDownList.SelectedValue = newsSale.REAL_ESTATE.UnitID.ToString();
                //GetPrice();
                //UnitDropDownList_SelectedIndexChanged(new object(), new EventArgs());
                PriceLabel.Text = Utility.ConvertPriceText(Convert.ToInt32(newsSale.ID));
                
                UnitPriceLabel.Text = " / " + newsSale.REAL_ESTATE.UNIT_PRICE.Name;
                LivingRoomLabel.Text     = newsSale.REAL_ESTATE.LivingRoom.ToString();
                BedRoomLabel.Text        = newsSale.REAL_ESTATE.BedRoom.ToString();
                BathRoomLabel.Text       = newsSale.REAL_ESTATE.BathRoom.ToString();
                DifferentRoomLabel1.Text = newsSale.REAL_ESTATE.DifferentRoom.ToString();
                CampusFrontLabel.Text    = (newsSale.REAL_ESTATE.CampusFront == 0) ? ("_") : (newsSale.REAL_ESTATE.CampusFront.ToString());
                CampustLengthLabel.Text  = (newsSale.REAL_ESTATE.CampusLength == 0) ? ("_") : (newsSale.REAL_ESTATE.CampusLength.ToString());
                TotalUseAreaLabel.Text   = newsSale.REAL_ESTATE.TotalUseArea.ToString();
                if (newsSale.REAL_ESTATE.ContactID != 0)        // Contact exist
                {
                    ContactNameLabel.Text = newsSale.REAL_ESTATE.CONTACT.Name;
                    AddressContactLabel.Text = newsSale.REAL_ESTATE.CONTACT.Address;
                    ContactHomePhoneLabel.Text = newsSale.REAL_ESTATE.CONTACT.HomePhone;
                    ContactPhoneLabel.Text = newsSale.REAL_ESTATE.CONTACT.Phone;
                    ContactNoteLabel.Text = newsSale.REAL_ESTATE.CONTACT.Note;
                }
                ContentLabel.Text       = newsSale.Content;

                //---------------- Detail Information ----------------------------
                TotalUseAreaLabel1.Text  = newsSale.REAL_ESTATE.TotalUseArea.ToString();
                RETypeLabel.Text         = RealEstateMarket._Default.db.GetRealEstateTypeByRealEstateID(newsSale.RealEstateID).Name; //newsSale.REAL_ESTATE.REAL_ESTATE_TYPE.Name;
                CampusFrontLabel1.Text   = CampusFrontLabel.Text;
                CampusBehindLabel.Text   = (newsSale.REAL_ESTATE.CampusBehind == 0) ? ("_") : (newsSale.REAL_ESTATE.CampusBehind.ToString());
                CampusLengthLabel1.Text  = CampustLengthLabel.Text;
                BuildFrontLabel.Text     = (newsSale.REAL_ESTATE.BuildFront == 0) ? ("_") : (newsSale.REAL_ESTATE.BuildFront.ToString());
                BuildBedindLabel.Text    = (newsSale.REAL_ESTATE.BuildBehind == 0) ? ("_") : (newsSale.REAL_ESTATE.BuildBehind.ToString());
                BuildLengthLabel.Text    = (newsSale.REAL_ESTATE.BuildLength == 0) ? ("_") : (newsSale.REAL_ESTATE.BuildLength.ToString());
                LegalLabel.Text          = (newsSale.REAL_ESTATE.LegalID == 0) ? ("_") : (newsSale.REAL_ESTATE.LEGAL.Name);
                DirectionLabel.Text      = newsSale.REAL_ESTATE.Direction;
                FrontStreetLabel.Text    = newsSale.REAL_ESTATE.FrontStreet;
                LocationLabel.Text       = (newsSale.REAL_ESTATE.LocationID == 0) ? ("_") : (newsSale.REAL_ESTATE.LOCATION.Name);
                StoreyLabel.Text         = newsSale.REAL_ESTATE.Storey.ToString();
                LivingRoomLabel1.Text    = LivingRoomLabel.Text;
                BedRoomLabel1.Text       = BedRoomLabel.Text;
                BathRoomLabel1.Text      = BathRoomLabel.Text;
                DifferentRoomLabel1.Text = DifferentRoomLabel.Text;

                foreach (RealEstateServiceReference.UTILITY_DETAIL item in newsSale.REAL_ESTATE.UTILITY_DETAILs)
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

                //------------------- Member Information ---------------------------------
                if (RealEstateMarket._Default.db.GetCustomerByRealEstateID(newsSale.RealEstateID) != null)
                {
                    RealEstateServiceReference.CUSTOMER customer = RealEstateMarket._Default.db.GetCustomerByRealEstateID(newsSale.RealEstateID);
                    MemberNameLabel.Text      = customer.Name;
                    AddressMemberLabel.Text   = RealEstateMarket.Pages.Project.GetAddressString(customer.AddressID);
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
            //    PriceLabel.Text = Utility.ConvertVNDToSJC(Convert.ToDouble(newsSale.REAL_ESTATE.Price)).ToString() + " lượng";
            //}
            //if (RealEstateMarket._Default.db.GetUnit(Convert.ToInt32(UnitDropDownList.SelectedValue)).Name == "USD")
            //{
            //    PriceLabel.Text = Utility.ConvertVNDToUSD(Convert.ToDouble(newsSale.REAL_ESTATE.Price)).ToString() + "USD";
            //}
        }
    }
}