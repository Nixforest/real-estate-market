using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.CustomControl
{
    public partial class AddressControl : System.Web.UI.UserControl
    {
        public int nationID;
        public int cityID;
        public int districtID;
        public int wardID;
        public int streetID;
        public string detail;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Attributes.Add("NationID", ddlNation.SelectedValue);
            this.Attributes.Add("CityID", ddlCity.SelectedValue);
            this.Attributes.Add("DistrictID", ddlDistrict.SelectedValue);
            this.Attributes.Add("WardID", ddlWard.SelectedValue);
            this.Attributes.Add("StreetID", ddlStreet.SelectedValue);
            this.Attributes.Add("Detail", tbxDetail.Text.Trim());
        }

        protected void SetProperties()
        {
            //nationID = Convert.ToInt32(ddlNation.SelectedValue);
            //cityID = Convert.ToInt32(ddlCity.SelectedValue);
            //districtID = Convert.ToInt32(ddlDistrict.SelectedValue);
            //wardID = Convert.ToInt32(ddlWard.SelectedValue);
            //streetID = Convert.ToInt32(ddlStreet.SelectedValue);
            //detail = tbxDetail.Text.Trim();
        }

        protected void ddlNation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCity.DataBind();
            //SetProperties();
        }
        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDistrict.DataBind();
            //SetProperties();
        }
        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlWard.DataBind();
            ddlStreet.DataBind();
            //SetProperties();
        }
        protected void ddlWard_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SetProperties();
        }
        protected void ddlStreet_SelectedIndexChanged(object sender, EventArgs e)
        {
            //SetProperties();
        }
    }
}