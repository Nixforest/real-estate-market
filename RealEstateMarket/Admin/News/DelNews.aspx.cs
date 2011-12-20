using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Admin.News
{
    public partial class DelNews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["id"]);
            RealEstateMarket._Default.db.DeleteNews(id);
            Response.Redirect("~/Admin/News/ListNews.aspx");
        }
    }
}