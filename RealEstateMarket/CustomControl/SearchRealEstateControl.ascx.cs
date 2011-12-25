using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.CustomControl
{
    public partial class SearchRealEstateControl : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CityDropDownList.Items.Add(new ListItem("Chọn Tỉnh/Thành phố"));
                foreach (RealEstateServiceReference.CITY item in RealEstateMarket._Default.db.GetAllCities())
                {
                    CityDropDownList.Items.Add(new ListItem(item.Name, item.ID.ToString()));
                }
                NewsSaleTypeDropDownList.Items.Add(new ListItem("Chọn Loại tin đăng"));
                foreach (RealEstateServiceReference.NEWS_SALE_TYPE item in RealEstateMarket._Default.db.GetAllNewsSaleTypes())
                {
                    NewsSaleTypeDropDownList.Items.Add(new ListItem(item.Name, item.ID.ToString()));
                }
                RealEstateTypeDropDownList.Items.Add(new ListItem("Chọn Loại địa ốc"));
                foreach (RealEstateServiceReference.REAL_ESTATE_TYPE item in RealEstateMarket._Default.db.GetAllRealEstateTypes())
                {
                    RealEstateTypeDropDownList.Items.Add(new ListItem(item.Name, item.ID.ToString()));
                }
                SearchButton.Text = "Xem " + RealEstateMarket._Default.db.GetAllNewsSalesPosted().Count().ToString() + " tài sản";
            }
        }
        protected void KeyTextBox_Click(object sender, EventArgs e)
        {
            KeyTextBox.Text = "";
        }

        protected void SearchButton_Click(object sender, EventArgs e)
        {
            string query = "";
            if (KeyTextBox.Text != "" && KeyTextBox.Text != "Từ khóa tìm kiếm")
            {
                query += "&key=" + KeyTextBox.Text.Trim();
            }
            if (CityDropDownList.SelectedIndex != 0)
            {
                query += "&cityId=" + CityDropDownList.SelectedValue;
            }
            if (NewsSaleTypeDropDownList.SelectedIndex != 0)
            {
                query += "&newsSaleTypeId=" + NewsSaleTypeDropDownList.SelectedValue;
            }
            if (RealEstateTypeDropDownList.SelectedIndex != 0)
            {
                query += "&realEstateTypeSearchId=" + RealEstateTypeDropDownList.SelectedValue;
            }

            if (PriceDropDownList.SelectedValue != "0#0")
            {
                string price = PriceDropDownList.SelectedValue;
                string minPrice = "";
                string maxPrice = "";
                minPrice = price.Substring(0, price.IndexOf("#"));
                maxPrice = price.Substring(price.IndexOf("#") + 1, price.Length - minPrice.Length - 1);
                query += "&minPrice=" + minPrice;
                query += "&maxPrice=" + maxPrice;
            }
            Response.Redirect("~/Pages/NewsSale/NewsSales.aspx?search=1" + query);
            //foreach (string item in RealEstateDataContext.Utility.Utils.NormalizationString(KeyTextBox.Text.Trim()))
            //{
            //    TestLabel.Text += item;                
            //}
        }
    }
}