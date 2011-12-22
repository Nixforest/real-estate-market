using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.CustomControl
{
    public partial class RealEstateBoxControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<RealEstateServiceReference.NEWS_SALE> list = RealEstateMarket._Default.db.GetAllNewsSales().ToList();
                LeftDataList.DataSource = list.Skip(0).Take(10).ToList();
                LeftDataList.DataKeyField = "ID";
                LeftDataList.DataBind();
                //RightDataList.DataSource = list.Skip(5).Take(5).ToList();
                //RightDataList.DataKeyField = "ID";
                //RightDataList.DataBind();
            }
        }
    }
}