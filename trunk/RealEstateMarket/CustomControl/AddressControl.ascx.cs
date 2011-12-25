using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.CustomControl
{
    public partial class AddressControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Attributes.Add("NationID", NationDropDownList.SelectedValue);
            this.Attributes.Add("CityID", CityDropDownList.SelectedValue);
            this.Attributes.Add("DistrictID", DistrictDropDownList.SelectedValue);
            this.Attributes.Add("WardID", WardDropDownList.SelectedValue);
            this.Attributes.Add("StreetID", StreetDropDownList.SelectedValue);
            this.Attributes.Add("Detail", DetailTextBox.Text.Trim());
            this.Attributes.Add("Different", DifferentCheckBox.Checked.ToString());
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);            
        }

        protected void NationDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            CityDropDownList.DataBind();
        }
        protected void CityDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            DistrictDropDownList.DataBind();
        }
        protected void DistrictDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
            WardDropDownList.DataBind();
            StreetDropDownList.DataBind();
        }
        protected void WardDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        protected void StreetDropDownList_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        protected void DifferentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DistrictDropDownList.Enabled = !DifferentCheckBox.Checked;
            WardDropDownList.Enabled     = !DifferentCheckBox.Checked;
            StreetDropDownList.Enabled   = !DifferentCheckBox.Checked;
        }
    }
}