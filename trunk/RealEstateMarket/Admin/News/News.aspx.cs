﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Admin.News
{
    public partial class News1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public String getNewsType(object id)
        {
            return RealEstateMarket._Default.db.GetNewsType(Convert.ToInt32(id)).Name.ToString();
        }
    }
}