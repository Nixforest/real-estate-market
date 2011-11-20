using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Admin.Dashboard
{
    public partial class NationAdmin : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //dataTable.DataSource = db.GetAllNations();
            //dataTable.DataBind();
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            if (textboxName.Text != "" && textboxNationCode.Text != "")
            {
                try
                {
                    RealEstateMarket._Default.db.InsertNation(textboxName.Text, textboxNationCode.Text);
                    Response.Redirect(Request.RawUrl);
                }
                catch (Exception ex)
                {
                    if (ex.ToString().Contains("NationIDException"))
                    {
                        error.Text = "NationID Exception";
                    }
                }
            }
            
        }
    }
}