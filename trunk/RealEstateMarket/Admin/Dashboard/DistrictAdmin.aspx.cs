using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Admin.Dashboard
{
    public partial class DistrictAdmin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
            {
                try
                {
                    RealEstateMarket._Default.db.InsertDistrict(txtName.Text, ddlCity.SelectedIndex + 1);
                    dataTable.DataBind();
                }
                catch (Exception ex)
                {
                    if (ex.ToString().Contains(new RealEstateDataContext.Utility.DistrictIDException().ToString()))
                    {
                        error.Text = "Not exist city";
                    }
                }
            }
        }

        protected void addStreet_Click(object sender, EventArgs e)
        {
            //int index = Convert.ToInt32(dataTableStreet.);
            //int id = Convert.ToInt32(dataTableStreet.SelectedRow.Cells[3].Text);
            //error.Text = index.ToString();
            //try
            //{
            //    RealEstateMarket._Default.db.InsertDistrictDetail(Convert.ToInt32(ddlDistrict.SelectedValue), id);
            //}
            //catch (Exception ex)
            //{
            //    if (ex.ToString().Contains(new RealEstateDataContext.Utility.DistrictIDException().ToString()))
            //    {
            //        error.Text = "District ID not valid!";
            //    }
            //}
        }

        protected void ddlDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataSourceStreet.DataBind();
            dataTableStreet.DataBind();
        }

        protected void dataTableStreet_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dataTableStreet.SelectedRow.Cells[3].Text);
            error.Text = id.ToString();
            try
            {
                RealEstateMarket._Default.db.InsertDistrictDetail(Convert.ToInt32(ddlDistrict.SelectedValue), id);
                dataTableStreet.DataBind();
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains(new RealEstateDataContext.Utility.DistrictIDException().ToString()))
                {
                    error.Text = "District ID not valid!";
                }
            }
        }

    }
}