using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Pages.Project
{
    public partial class ListProjects : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ProjectsDataList.DataSource = RealEstateMarket._Default.db.GetAllProjects().Skip(0).Take(10).ToList();
                ProjectsDataList.DataKeyField = "ID";
                ProjectsDataList.DataBind();
            }            
        }
    }
}