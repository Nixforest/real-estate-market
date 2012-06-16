using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.CustomControl
{
    public partial class ProjectBoxControl : System.Web.UI.UserControl
    {
        private int numberRecord;

        public int NumberRecord
        {
            get { return numberRecord; }
            set { numberRecord = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProjectsDataList.DataSource = RealEstateMarket._Default.db.GetAllProjects().Skip(0).Take(numberRecord).ToList();
                ProjectsDataList.DataKeyField = "ID";
                ProjectsDataList.DataBind();
            }
        }
    }
}