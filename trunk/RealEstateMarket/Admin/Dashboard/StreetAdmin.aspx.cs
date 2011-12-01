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
            if (!User.IsInRole("Moderator"))
            {
                Response.Redirect("~/AccessDeny.aspx");
            }
        }

        protected void InsertButton_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorLabel.Text = "Bạn đã cập nhật Đường có ID = " +
                    RealEstateMarket._Default.db.InsertStreet(StreetNameTextBox.Text.Trim());
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains(new RealEstateDataContext.Utility.DoubleStreetNameException().ToString()))
                {
                    ErrorLabel.Text = "Bạn đã nhập một đường đã có trong cơ sở dữ liệu của Website!";
                }
            }
        }
    }
}