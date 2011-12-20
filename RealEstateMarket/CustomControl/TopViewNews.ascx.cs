using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.CustomControl
{
    public partial class TopViewNews : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public String getImageUrl(object id)
        {
            return RealEstateMarket._Default.db.GetImage(Convert.ToInt32(id)).Path.ToString();
        }
    }
}