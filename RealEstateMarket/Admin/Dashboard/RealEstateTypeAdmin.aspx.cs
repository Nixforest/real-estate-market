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

        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            if (txtName.Text.Trim() != "")
            {
                try
                {
                    error.Text = "Bạn đã nhập Loại Địa ốc có ID = " + 
                        RealEstateMarket._Default.db.InsertRealEstateType(txtName.Text.Trim(), txtDescription.Text.Trim()).ToString();
                    dataTable.DataBind();
                }
                catch (Exception ex)
                {
                }
            }
        }
    }
}