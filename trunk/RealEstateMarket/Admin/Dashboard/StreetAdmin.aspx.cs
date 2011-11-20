using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Admin.Dashboard
{
    public partial class StreetAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            if (txbName.Text.Trim() != "")
            {
                try
                {
                    error.Text = "Bạn đã cập nhật Đường phố có ID = " + RealEstateMarket._Default.db.InsertStreet(txbName.Text);
                    //Response.Redirect(Request.RawUrl);
                    dataTable.DataBind();
                }
                catch (Exception ex)
                {
                    if (ex.ToString().Contains(new RealEstateDataContext.Utility.DoubleStreetNameException().ToString()))
                    {
                        error.Text = "Bạn đã nhập một đường đã có trong cơ sở dữ liệu của Website!";
                    }
                }
            }
        }
    }
}