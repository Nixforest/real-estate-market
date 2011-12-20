using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Admin.News
{
    public partial class News : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Label2.Text = DateTime.Now.ToString();
            //RealEstateMarket._Default.db.GetNewsType(5).NEWs.ToList(); //ok?
        }
        public String getImageUrl(object id) 
        {
            return RealEstateMarket._Default.db.GetImage(Convert.ToInt32(id)).Path.ToString();
        }
    }
}