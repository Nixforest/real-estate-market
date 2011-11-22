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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlNation_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlCity.DataBind();
        }
        protected void ddlCity_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlDistrict.DataBind();
        }
        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlWard.DataBind();
            ddlStreet.DataBind();
        }
        protected void ddlTest_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}