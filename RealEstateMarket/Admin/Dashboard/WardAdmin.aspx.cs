using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Admin.Dashboard
{
    public partial class WardAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Only Moderator or Administrator can access
            if (!User.IsInRole("Moderator"))
            {
                Response.Redirect("~/AccessDeny.aspx");
            }
        }

        protected void InsertButton_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorLabel.Text= "Bạn đã cập nhật Phường có ID = " +
                    RealEstateMarket._Default.db.InsertWard(WardNameTextBox.Text.Trim(), Convert.ToInt32(InDistrictDropDownList.SelectedValue));
                WardGridView.DataBind();
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains(new RealEstateDataContext.Utility.DistrictIDException().ToString()))
                {
                    ErrorLabel.Text = "Not exist district";
                }
            }
        }
    }
}