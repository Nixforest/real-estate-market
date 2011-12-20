using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.CustomControl
{
    public partial class FilterNewsSale : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                NewsSaleTypeRadioButtonList.SelectedIndex = 0;
                RealEstateTypeRadioButtonList.SelectedIndex = 0;

                //--------- Set link for filter by price ------------------
                FiveMillionLowerHyperLink.NavigateUrl = String.Format("~/Pages/NewsSale/NewsSales.aspx?min={0}&max={1}", 0, 5000000);
                FiveToTwentyMillionHyperLink.NavigateUrl = String.Format("~/Pages/NewsSale/NewsSales.aspx?min={0}&max={1}", 5000000, 20000000);
                TwentyToOneHundredMillionHyperLink.NavigateUrl = String.Format("~/Pages/NewsSale/NewsSales.aspx?min={0}&max={1}", 20000000, 100000000);
                OneHundredToFiveHundredMillionHyperLink.NavigateUrl = String.Format("~/Pages/NewsSale/NewsSales.aspx?min={0}&max={1}", 100000000, 500000000);
                FiveHundredMillionToOneBillionHyperLink.NavigateUrl = String.Format("~/Pages/NewsSale/NewsSales.aspx?min={0}&max={1}", 500000000, 1200000000);
                OneBillionToTwoBillionHyperLink.NavigateUrl = String.Format("~/Pages/NewsSale/NewsSales.aspx?min={0}&max={1}", 1200000000, 2000000000);
                TwoBillionToThreeBillionHyperLink.NavigateUrl = String.Format("~/Pages/NewsSale/NewsSales.aspx?min={0}&max={1}", 2000000000, 3000000000);
                ThreeBillionToFiveBillionHyperLink.NavigateUrl = String.Format("~/Pages/NewsSale/NewsSales.aspx?min={0}&max={1}", 3000000000, 5000000000);
                FiveBillionHigherHyperLink.NavigateUrl = String.Format("~/Pages/NewsSale/NewsSales.aspx?min={0}&max={1}", 5000000000, decimal.MaxValue);

                //----------- Set link for filter by bedroom number ---------------
                OneLink.NavigateUrl = String.Format("~/Pages/NewsSale/NewsSales.aspx?minBed={0}&maxBed={1}", 1, int.MaxValue);
                TwoLink.NavigateUrl = String.Format("~/Pages/NewsSale/NewsSales.aspx?minBed={0}&maxBed={1}", 2, int.MaxValue);
                ThreeLink.NavigateUrl = String.Format("~/Pages/NewsSale/NewsSales.aspx?minBed={0}&maxBed={1}", 3, int.MaxValue);
                FourLink.NavigateUrl = String.Format("~/Pages/NewsSale/NewsSales.aspx?minBed={0}&maxBed={1}", 4, int.MaxValue);
            }            
        }

        protected void CityDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DistrictDropDownList.DataBind();
            //SetProperties();
        }
        protected void DistrictDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProjectDropDownList.DataBind();
        }

        protected void NewsSaleTypeRadioButtonList_SelectedIndexChanged1(object sender, EventArgs e)
        {
            //Response.Redirect(String.Format("~/Pages/NewsSale/NewsSales.aspx?typeId={0}", Convert.ToInt32(NewsSaleTypeRadioButtonList.SelectedValue)));
        }

        protected void NewsSaleTypeRadioButtonList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void FilterNewsSaleTypeImageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Pages/NewsSale/NewsSales.aspx?typeId={0}", Convert.ToInt32(NewsSaleTypeRadioButtonList.SelectedValue)));
        }

        protected void FilterRealEstateTypeImageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Pages/NewsSale/NewsSales.aspx?realEstateTypeId={0}", Convert.ToInt32(RealEstateTypeRadioButtonList.SelectedValue)));
        }

        protected void FilterImageButton_Click(object sender, EventArgs e)
        {            
            Response.Redirect(String.Format("~/Pages/NewsSale/NewsSales.aspx?min={0}&max={1}", 
                Convert.ToDecimal(FromPriceDropDownList.SelectedValue), Convert.ToDecimal(ToPriceDropDownList.SelectedValue)));
        }

        protected void AreaImageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Pages/NewsSale/NewsSales.aspx?minArea={0}&maxArea={1}",
                Convert.ToDouble(FromAreaTextBox.Text), Convert.ToDouble(ToAreaTextBox.Text)));
        }

        protected void ProjectImageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Pages/NewsSale/NewsSales.aspx?projectId={0}",
                Convert.ToInt32(ProjectDropDownList.SelectedValue)));
        }

        protected void LocationImageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Pages/NewsSale/NewsSales.aspx?locationId={0}",
                Convert.ToInt32(LocationRadioButtonList.SelectedValue)));
        }

        protected void BedRoomImageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Pages/NewsSale/NewsSales.aspx?minBed={0}&maxBed={1}",
                Convert.ToInt32(FromBedRoomTextBox.Text), Convert.ToInt32(ToBedRoomTextBox.Text)));
        }

        protected void DirectionImageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Pages/NewsSale/NewsSales.aspx?direction={0}",
                DirectionRadioButtonList.SelectedIndex + 1));
        }

        protected void NonBrokerImageButton_Click(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("~/Pages/NewsSale/NewsSales.aspx?broker={0}",1));
        }
    }
}