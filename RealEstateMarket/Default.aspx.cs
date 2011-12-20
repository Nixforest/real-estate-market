using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket
{
    public partial class _Default : System.Web.UI.Page
    {
        public static RealEstateServiceReference.RealEstateWebServiceSoapClient db = new RealEstateServiceReference.RealEstateWebServiceSoapClient();
        protected void Page_Load(object sender, EventArgs e)
        {
            db.SetConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=RealEstate;Integrated Security=True");
            if (!IsPostBack)
            {
                //TestLabel.Text = SJCLabel.Text.Replace("<script language=\"Javascript\">document.write(vGoldSjcBuy);</script>", "");
                //try
                //{
                //    RealEstateMarket.Utility.RateSJCToVND = Convert.ToDouble(TestLabel.Text);
                //}
                //catch (Exception ex)
                //{
                //    SJCLabel.Text = ex.ToString();
                //}
            }
        }
    }
}
