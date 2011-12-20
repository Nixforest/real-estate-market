using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;

namespace RealEstateMarket.CustomControl
{
    public partial class NewsSaleControl : System.Web.UI.UserControl
    {
        private int newsSaleID = 1;
        private RealEstateServiceReference.NEWS_SALE newsSale = new RealEstateServiceReference.NEWS_SALE();

        [PropertyTab]
        public RealEstateServiceReference.NEWS_SALE NewsSale
        {
            get { return newsSale; }
            set { newsSale = value; }
        }

        [PropertyTab]
        public int NewsSaleID
        {
            get { return newsSaleID; }
            set { newsSaleID = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            newsSale = RealEstateMarket._Default.db.GetNewsSale(newsSaleID);
        }
    }
}