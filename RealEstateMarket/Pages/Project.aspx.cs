using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Pages
{
    public partial class Project : System.Web.UI.Page
    {
        private RealEstateServiceReference.PROJECT project = new RealEstateServiceReference.PROJECT();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            project = RealEstateMarket._Default.db.GetProject(Convert.ToInt32(ddlProject.SelectedValue));
            lblName.Text = project.Name;
            lblBeginDay.Text = project.BeginDay.ToString();
            lblContent.Text = project.Description;
        }
    }
}