using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Admin.Dashboard
{
    public partial class DistrictAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                try
                {
                    RealEstateMarket._Default.db.InsertDistrict(txtName.Text, ddlCity.SelectedIndex + 1);
                    Response.Redirect(Request.RawUrl);
                }
                catch (Exception ex)
                {
                    if (ex.ToString().Contains(new RealEstateDataContext.Utility.DistrictIDException().ToString()))
                    {
                        error.Text = "Not exist city";
                    }
                }
            }
        }
    }
}