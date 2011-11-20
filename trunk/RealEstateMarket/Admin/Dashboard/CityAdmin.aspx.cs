using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Admin.Dashboard
{
    public partial class CityAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Insert_Click(object sender, EventArgs e)
        {
            if (textboxName.Text != "")
            {
                try
                {
                    RealEstateMarket._Default.db.InsertCity(textboxName.Text, ddlNation.SelectedIndex + 1);
                    Response.Redirect(Request.RawUrl);
                }
                catch (Exception ex)
                {
                    if (ex.ToString().Contains("NationIDException"))
                    {
                        error.Text = "NationID Exception";
                    }
                }
            }

        }
    }
}