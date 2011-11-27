using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Member
{
    public partial class NewsSaleRegistration : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                rblNewsSaleType.SelectedIndex = 0;
            }
        }

        protected void cbCampusOpenBehind_CheckedChanged(object sender, EventArgs e)
        {
            tbxCampusBehind.Visible = cbCampusOpenBehind.Checked;
            lblCampusM.Visible = cbCampusOpenBehind.Checked;
        }

        protected void cbBuildOpenBehind_CheckedChanged(object sender, EventArgs e)
        {
            tbxBuildBehind.Visible = cbBuildOpenBehind.Checked;
            lblBuilM.Visible = cbBuildOpenBehind.Checked;
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            // Check for News_Sale
            //error.Text = rblNewsSaleType.SelectedValue;
            int newsSaleTypeID = Convert.ToInt32(rblNewsSaleType.SelectedValue);
            //int addressID;
            //int nationID = Convert.ToInt32(address.Attributes["NationID"]);
            //int cityID = Convert.ToInt32(address.Attributes["CityID"]);
            //int districtID = Convert.ToInt32(address.Attributes["DistrictID"]);
            //int wardID = Convert.ToInt32(address.Attributes["WardID"]);
            //int streetID = Convert.ToInt32(address.Attributes["StreetID"]);
            //string detail = address.Attributes["Detail"];
            //addressID = RealEstateMarket._Default.db.InsertAddress(nationID, cityID, districtID, wardID, streetID, detail);
            //int? campusBehind = null;
            //int? buildBehind = null;
            //if (cbCampusOpenBehind.Checked)
            //{
            //    campusBehind = Convert.ToInt32(tbxCampusBehind.Text);
            //}
            //if (cbBuildOpenBehind.Checked)
            //{
            //    buildBehind = Convert.ToInt32(tbxBuildBehind.Text);
            //}
            //RealEstateMarket._Default.db.InsertRealEstate(
            //    Convert.ToInt32(ddlRealEstateType.SelectedValue),
            //    addressID,
            //    Convert.ToInt32(ddlLivingRoom.SelectedValue),
            //    Convert.ToInt32(ddlBedRoom.SelectedValue),
            //    Convert.ToInt32(ddlBathRoom.SelectedValue),
            //    Convert.ToInt32(ddlStorey.SelectedValue),
            //    Convert.ToInt32(tbxTotalUseArea.Text),
            //    Convert.ToInt32(tbxCampusFront.Text),
            //    campusBehind,
            //    Convert.ToInt32(tbxCampusLength.Text),
            //    Convert.ToInt32(tbxBuildFront.Text),
            //    buildBehind,
            //    Convert.ToInt32(tbxBuildLength.Text),
            //    Convert.ToInt32(ddlLegal.SelectedValue),
            //    ddlDirection.SelectedValue,
            //    ddlFrontStreet.SelectedValue,
            //    Convert.ToInt32(ddlLocation.SelectedValue),
            //    Convert.ToDecimal(tbxPrice.Text),
            //    Convert.ToInt32(ddlUnit.SelectedValue),
            //    Convert.ToInt32(ddlUnitPrice.SelectedValue),
            //    Convert.ToInt32(ddlProject.SelectedValue),
            //    null);
        }

        protected void test_Click(object sender, EventArgs e)
        {
            error.Text = rblNewsSaleType.SelectedValue;
        }
    }
}