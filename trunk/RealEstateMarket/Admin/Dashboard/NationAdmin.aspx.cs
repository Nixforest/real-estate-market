using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Admin.Dashboard
{
    public partial class NationAdmin : System.Web.UI.Page
    {        
        protected void Page_Load(object sender, EventArgs e)
        {
            // Only Moderator or Administrator can access
            if (!User.IsInRole("Moderator"))
            {
                Response.Redirect("~/AccessDeny.aspx");
            }
        }


        // Insert a Nation
        protected void InsertNationButton_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorLabel.Text = "Bạn đã cập nhật Quốc gia có ID = " + 
                    RealEstateMarket._Default.db.InsertNation(NationNameTextBox.Text.Trim(), NationCodeTextBox.Text.Trim());
                NationGridView.DataBind();
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