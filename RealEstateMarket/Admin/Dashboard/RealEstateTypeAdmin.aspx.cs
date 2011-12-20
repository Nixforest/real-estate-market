using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Admin.Dashboard
{
    public partial class RealEstateTypeAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Title = "Quản lý các Loại Địa ốc";
            }
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
                ErrorLabel.Text = "Bạn đã nhập Loại Địa ốc có ID = " + 
                    RealEstateMarket._Default.db.InsertRealEstateType(RETypeNameTextBox.Text.Trim(), DescriptionTextBox.Text.Trim()).ToString();
                RealEstateTypeGridView.DataBind();
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.ToString();
            }
        }
    }
}