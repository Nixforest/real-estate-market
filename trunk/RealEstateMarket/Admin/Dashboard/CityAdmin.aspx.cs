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
            // Only Moderator or Administrator can access
            if (!User.IsInRole("Moderator"))
            {
                Response.Redirect("~/AccessDEny.aspx");
            }
        }

        // Insert a City
        protected void InsertButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Call a method from Web Service
                ErrorLabel.Text = "Bạn đã cập nhật Thành phố có ID = " + RealEstateMarket._Default.db.InsertCity(
                    CityNameTextBox.Text.Trim(), NationDropDownList.SelectedIndex + 1).ToString();
                CityGridView.DataBind();
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains("NationIDException"))
                {
                    ErrorLabel.Text = "NationID Exception";
                }
            }

        }
    }
}