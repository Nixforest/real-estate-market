using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Admin.NewsSale
{
    public partial class ListNewsSales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("Moderator"))
            {
                Response.Redirect("~/AccessDeny.aspx");
            }
        }

        protected void StatusDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList status = (DropDownList)sender;
            GridViewRow row = (GridViewRow)status.NamingContainer;
            int id = Convert.ToInt32(ListGridView.DataKeys[row.DataItemIndex].Value);
            RealEstateMarket._Default.db.UpdateNewsSaleStatus(id, Convert.ToInt32(status.SelectedValue));
        }
    }
}