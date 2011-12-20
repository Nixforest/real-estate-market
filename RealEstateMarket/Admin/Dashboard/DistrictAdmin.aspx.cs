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
            if (!IsPostBack)
            {
                Title = "Cập nhật thông tin các Quận/Huyện";
            }
            // Only Moderator and Administrator can access
            if (!User.IsInRole("Moderator"))
            {
                Response.Redirect("~/AccessDeny.aspx");
            }
        }

        protected void InsertDistrictButton_Click(object sender, EventArgs e)
        {
            try
            {
                ErrorLabel.Text= "Bạn đã cập nhật Quận có ID = "+ 
                    RealEstateMarket._Default.db.InsertDistrict(DistrictNameTextBox.Text.Trim(), Convert.ToInt32(CityDropDownList.SelectedValue));
                DistrictGridView.DataBind();
            }
            catch (Exception ex)
            {
                if (ex.ToString().Contains(new RealEstateDataContext.Utility.DistrictIDException().ToString()))
                {
                    ErrorLabel.Text = "Not exist city";
                }
            }
        }

        protected void DistrictDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            //StreetObjectDataSource.DataBind();
            //StreetGridView.DataBind();
        }

        protected void StreetGridView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int id = Convert.ToInt32(StreetGridView.SelectedRow.Cells[3].Text);
            //ErrorLabel.Text = id.ToString();
            //try
            //{
            //    RealEstateMarket._Default.db.InsertDistrictDetail(Convert.ToInt32(DistrictDropDownList.SelectedValue), id);
            //    StreetObjectDataSource.DataBind();
            //    StreetGridView.DataBind();
            //}
            //catch (Exception ex)
            //{
            //    if (ex.ToString().Contains(new RealEstateDataContext.Utility.DistrictIDException().ToString()))
            //    {
            //        ErrorLabel.Text = "District ID not valid!";
            //    }
            //}
        }
    }
}