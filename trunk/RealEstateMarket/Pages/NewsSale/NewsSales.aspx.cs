using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.ObjectModel;

namespace RealEstateMarket.Pages
{
    public partial class NewsSales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            // Filter query
            int typeId = 0;
            int realEstateTypeId = 0;
            decimal minPrice = 0;
            decimal maxPrice = decimal.MaxValue;
            double minArea = 0;
            double maxArea = double.MaxValue;
            int projectId = 0;
            int locationId = 0;
            int minBed = 0;
            int maxBed = 0;
            int direction = 0;
            string broker = "";

            // Search query
            string key = "";
            int cityId = 0;
            int newsSaleTypeId = 0;
            int realEstateTypeSearchId = 0;
            decimal minPriceSearch = 0;
            decimal maxPriceSearch = 0;
            int search = 0;
            
            if (!IsPostBack)
            {
                TotalLabel.Text = "<b>" + RealEstateMarket._Default.db.GetAllNewsSalesPosted().Count().ToString() + "</b>" + " tài sản:";
                // Set title
                Title = "Siêu thị - Nhà đất, Bất động sản, Địa ốc";
                NewsSaleDataList.DataSource = NewsSaleObjectDataSource;
                NewsSaleDataList.DataBind();
                try
                {
                    // Filter query get value
                    typeId = Convert.ToInt32(Request.QueryString["typeId"]);
                    realEstateTypeId = Convert.ToInt32(Request.QueryString["realEstateTypeId"]);
                    minPrice = Convert.ToDecimal(Request.QueryString["min"]);
                    maxPrice = Convert.ToDecimal(Request.QueryString["max"]);
                    minArea = Convert.ToDouble(Request.QueryString["minArea"]);
                    maxArea = Convert.ToDouble(Request.QueryString["maxArea"]);
                    projectId = Convert.ToInt32(Request.QueryString["projectId"]);
                    locationId = Convert.ToInt32(Request.QueryString["locationId"]);
                    minBed = Convert.ToInt32(Request.QueryString["minBed"]);
                    maxBed = Convert.ToInt32(Request.QueryString["maxBed"]);
                    direction = Convert.ToInt32(Request.QueryString["direction"]);
                    broker = Request.QueryString["broker"];

                    // Search query get value
                    search = Convert.ToInt32(Request.QueryString["search"]);
                    key = Request.QueryString["key"];
                    cityId = Convert.ToInt32(Request.QueryString["cityId"]);
                    newsSaleTypeId = Convert.ToInt32(Request.QueryString["newsSaleTypeId"]);
                    realEstateTypeSearchId = Convert.ToInt32(Request.QueryString["realEstateTypeSearchId"]);
                    minPriceSearch = Convert.ToDecimal(Request.QueryString["minPrice"]);
                    maxPriceSearch = Convert.ToDecimal(Request.QueryString["maxPrice"]);
                }
                catch (FormatException)
                {

                }
                #region Filter
                //-------- Filter by News Sale Type -----------------
                if (typeId != 0)
                {
                    Array source = RealEstateMarket._Default.db.GetNewsSalesByTypeID(typeId);
                    NewsSaleDataList.DataSource = source;
                    NewsSaleDataList.DataBind();
                    int count = source.Length;
                    if (count == 0)
                    {
                        TotalLabel.Text = "<b> Loại tin rao:</b> " + RealEstateMarket._Default.db.GetNewsSaleType(typeId).Name;
                        NoteLabel.Visible = true;
                    }
                    else
                    {
                        TotalLabel.Text = "<b>" + count.ToString() + "</b>" +
                        " tài sản:" + "<b> Loại tin rao:</b> " + RealEstateMarket._Default.db.GetNewsSaleType(typeId).Name;
                    }
                }

                //------------ Filter by Real Estate Type -----------------
                if (realEstateTypeId != 0)
                {
                    Array source = RealEstateMarket._Default.db.GetNewsSalesByRealEstateTypeID(realEstateTypeId);
                    NewsSaleDataList.DataSource = source;
                    NewsSaleDataList.DataBind();
                    int count = source.Length;
                    if (count == 0)
                    {
                        TotalLabel.Text = "<b> Loại địa ốc:</b> " + RealEstateMarket._Default.db.GetRealEstateType(realEstateTypeId).Name;
                        NoteLabel.Visible = true;
                    }
                    else
                    {
                        TotalLabel.Text = "<b>" + count.ToString() + "</b>" +
                        " tài sản:" + "<b> Loại địa ốc:</b> " + RealEstateMarket._Default.db.GetRealEstateType(realEstateTypeId).Name;
                    }
                    Title = RealEstateMarket._Default.db.GetRealEstateType(realEstateTypeId).Name;
                }

                //---------- Filter by Real Estate's price ------------------
                if (minPrice != 0 || maxPrice != 0)
                {
                    Array source = RealEstateMarket._Default.db.GetNewsSalesByPrice(minPrice, maxPrice);
                    NewsSaleDataList.DataSource = source;
                    NewsSaleDataList.DataBind();
                    int count = source.Length;
                    if (count == 0)
                    {
                        if (minPrice == 0)
                        {
                            TotalLabel.Text = "<b>Giá nhỏ hơn</b> " + RealEstateMarket.Utility.ConvertPriceText((double)maxPrice);
                        }
                        else if (maxPrice == decimal.MaxValue)
                        {
                            TotalLabel.Text = "<b>Giá lớn hơn</b> " + RealEstateMarket.Utility.ConvertPriceText((double)minPrice);
                        }
                        else
                        {
                            TotalLabel.Text = "<b>Giá lớn hơn</b> " + RealEstateMarket.Utility.ConvertPriceText((double)minPrice) +
                                " <b>Giá nhỏ hơn</b> " + RealEstateMarket.Utility.ConvertPriceText((double)maxPrice);
                        }
                        NoteLabel.Visible = true;
                    }
                    else
                    {
                        if (minPrice == 0)
                        {
                            TotalLabel.Text = "<b>" + count.ToString() + "</b>" +
                                " tài sản: " + "<b>Giá nhỏ hơn</b> " + RealEstateMarket.Utility.ConvertPriceText((double)maxPrice);
                        }
                        else if (maxPrice == decimal.MaxValue)
                        {
                            TotalLabel.Text = "<b>" + count.ToString() + "</b>" +
                                " tài sản: " + "<b>Giá lớn hơn</b> " + RealEstateMarket.Utility.ConvertPriceText((double)minPrice);
                        }
                        else
                        {
                            TotalLabel.Text = "<b>" + count.ToString() + "</b>" +
                                " tài sản: " + "<b>Giá lớn hơn</b> " + RealEstateMarket.Utility.ConvertPriceText((double)minPrice) +
                                " <b>Giá nhỏ hơn</b> " + RealEstateMarket.Utility.ConvertPriceText((double)maxPrice);
                        }
                    }
                }

                //---------------- Filter by Real Estate's total use area
                if (minArea != 0 || maxArea != 0)
                {
                    Array source = RealEstateMarket._Default.db.GetNewsSalesByTotalUseArea(minArea, maxArea);
                    NewsSaleDataList.DataSource = source;
                    NewsSaleDataList.DataBind();
                    int count = source.Length;
                    if (count == 0)
                    {
                        if (minArea == 0)
                        {
                            TotalLabel.Text = "<b>DTSD nhỏ hơn</b> " + maxArea.ToString() + " m<sup>2</sup>";
                        }
                        else if (maxArea == double.MaxValue)
                        {
                            TotalLabel.Text = "<b>DTSD lớn hơn</b> " + minArea.ToString() + " m<sup>2</sup>";
                        }
                        else
                        {
                            TotalLabel.Text = "<b>DTSD lớn hơn</b> " + minArea.ToString() + " m<sup>2</sup>" +
                                " <b>DTSD nhỏ hơn</b> " + maxArea.ToString() + " m<sup>2</sup>";
                        }
                        NoteLabel.Visible = true;
                    }
                    else
                    {
                        if (minArea == 0)
                        {
                            TotalLabel.Text = "<b>" + count.ToString() + "</b>" +
                                " tài sản: " + "<b>DTSD nhỏ hơn</b> " + maxArea.ToString() + " m<sup>2</sup>";
                        }
                        else if (maxArea == double.MaxValue)
                        {
                            TotalLabel.Text = "<b>" + count.ToString() + "</b>" +
                                " tài sản: " + "<b>DTSD lớn hơn</b> " + minArea.ToString() + " m<sup>2</sup>";
                        }
                        else
                        {
                            TotalLabel.Text = "<b>" + count.ToString() + "</b>" +
                                " tài sản: " + "<b>DTSD lớn hơn</b> " + minArea.ToString() + " m<sup>2</sup>" +
                                " <b>DTSD nhỏ hơn</b> " + maxArea.ToString() + " m<sup>2</sup>";
                        }
                    }
                }

                //----------- Filter by Project --------------
                if (projectId != 0)
                {
                    Array source = RealEstateMarket._Default.db.GetNewsSalesByProjectID(projectId);
                    NewsSaleDataList.DataSource = source;
                    NewsSaleDataList.DataBind();
                    int count = source.Length;
                    if (count == 0)
                    {
                        TotalLabel.Text = "<b> Dự án:</b> " + RealEstateMarket._Default.db.GetProject(projectId).Name;
                        NoteLabel.Visible = true;
                    }
                    else
                    {
                        TotalLabel.Text = "<b>" + count.ToString() + "</b>" +
                        " tài sản:" + "<b> Dự án:</b> " + RealEstateMarket._Default.db.GetProject(projectId).Name;
                    }
                    Title = "Dự án " + RealEstateMarket._Default.db.GetProject(projectId).Name;
                }

                //----------- Filter by Location of RealEstate---------------
                if (locationId != 0)
                {
                    Array source = RealEstateMarket._Default.db.GetNewsSalesByRealEstateLocation(locationId);
                    NewsSaleDataList.DataSource = source;
                    NewsSaleDataList.DataBind();
                    int count = source.Length;
                    if (count == 0)
                    {
                        TotalLabel.Text = "<b>Vị trí Địa ốc:</b> " + RealEstateMarket._Default.db.GetLocation(locationId).Name;
                        NoteLabel.Visible = true;
                    }
                    else
                    {
                        TotalLabel.Text = "<b>" + count.ToString() + "</b>" +
                        " tài sản:" + "<b> Vị trí Địa ốc:</b> " + RealEstateMarket._Default.db.GetLocation(locationId).Name;
                    }
                    Title = "Vị trí Địa ốc: " + RealEstateMarket._Default.db.GetLocation(locationId).Name;
                }

                //--------------------Filter by bedroom -----------------------
                if (minBed != 0 || maxBed != 0)
                {
                    Array source = RealEstateMarket._Default.db.GetNewsSaleByBedRoom(minBed, maxBed);
                    NewsSaleDataList.DataSource = source;
                    NewsSaleDataList.DataBind();
                    int count = source.Length;
                    if (count == 0)
                    {
                        if (maxBed != int.MaxValue)
                        {
                            TotalLabel.Text = "<b>Phòng ngủ lớn hơn</b>: " + minBed.ToString() +
                                    " <b>Phòng ngủ nhỏ hơn</b>: " + maxBed.ToString();
                            NoteLabel.Visible = true;
                        }
                        else
                        {
                            TotalLabel.Text = "<b>Phòng ngủ lớn hơn</b>: " + minBed.ToString();
                            NoteLabel.Visible = true;
                        }

                    }
                    else
                    {
                        if (maxBed != int.MaxValue)
                        {
                            TotalLabel.Text = "<b>" + count.ToString() + "</b>" +
                                " tài sản:" + " <b>Phòng ngủ lớn hơn</b>: " + minBed.ToString() +
                                    " <b>Phòng ngủ nhỏ hơn</b>: " + maxBed.ToString();
                        }
                        else
                        {
                            TotalLabel.Text = "<b>" + count.ToString() + "</b>" +
                                " tài sản:" + " <b>Phòng ngủ lớn hơn</b>: " + minBed.ToString();
                        }

                    }
                }

                //---------------------Filter by Direction------------------------------
                if (direction != 0)
                {
                    string directionString = "";
                    switch (direction)
                    {
                        case 1: directionString = "Đông";
                            break;
                        case 2: directionString = "Tây";
                            break;
                        case 3: directionString = "Nam";
                            break;
                        case 4: directionString = "Bắc";
                            break;
                        case 5: directionString = "Đông Bắc";
                            break;
                        case 6: directionString = "Đông Nam";
                            break;
                        case 7: directionString = "Tây Bắc";
                            break;
                        case 8: directionString = "Tây Nam";
                            break;
                        default: directionString = "Không xác định";
                            break;
                    }
                    Array source = RealEstateMarket._Default.db.GetNewsSaleByDirection(directionString);
                    NewsSaleDataList.DataSource = source;
                    NewsSaleDataList.DataBind();
                    int count = source.Length;
                    if (count == 0)
                    {
                        TotalLabel.Text = "<b>Hướng tài sản: </b>" + directionString;
                        NoteLabel.Visible = true;
                    }
                    else
                    {
                        TotalLabel.Text = "<b>" + count.ToString() + "</b> " +
                                "tài sản: " + "<b>Hướng tài sản</b>: " + directionString;
                    }
                }

                //--------------Filter by broker----------------------------
                if (broker == "1")
                {
                    Array source = RealEstateMarket._Default.db.GetNewsSaleByMainOwner();
                    NewsSaleDataList.DataSource = source;
                    NewsSaleDataList.DataBind();
                    int count = source.Length;
                    if (count == 0)
                    {
                        TotalLabel.Text = "<b>Tài sản chính chủ</b>";
                        NoteLabel.Visible = true;
                    }
                    else
                    {
                        TotalLabel.Text = "<b>" + count.ToString() + "</b>" + " tài sản: <b>Tài sản chính chủ</b>";
                    }
                }
                #endregion

                #region Search
                if (search == 1)
                {
                    List<RealEstateServiceReference.NEWS_SALE> searchResult = (RealEstateMarket._Default.db.GetAllNewsSalesPosted()).ToList();
                    string searchString = "";
                    //--------------- Search by City----------------------
                    if (cityId != 0)
                    {
                        searchResult = RealEstateMarket._Default.db.SearchNewsSaleByCityID(cityId, searchResult.ToArray()).ToList();
                        if (searchResult.Count() == 0)
                        {
                            searchString = "<b>Thành phố:</b> " + RealEstateMarket._Default.db.GetCity(cityId).Name;
                            NoteLabel.Visible = true;
                        }
                        else
                        {
                            searchString += "<b> Thành phố:</b> " + RealEstateMarket._Default.db.GetCity(cityId).Name;
                        }
                    }
                    //----------------------Search by NewsSaleType----------------------------------------
                    if (newsSaleTypeId != 0)
                    {
                        searchResult = RealEstateMarket._Default.db.SearchNewsSaleByTypeID(newsSaleTypeId, searchResult.ToArray()).ToList();
                        searchString += "<b> Loại tin đăng:</b> " + RealEstateMarket._Default.db.GetNewsSaleType(newsSaleTypeId).Name;
                        if (searchResult.Count() == 0)
                        {
                            NoteLabel.Visible = true;
                        }
                    }
                    //----------------------Search by RealEstateType----------------------------------------
                    if (realEstateTypeSearchId != 0)
                    {
                        searchResult = RealEstateMarket._Default.db.SearchNewsSaleByRealEstateTypeID(realEstateTypeSearchId, searchResult.ToArray()).ToList();
                        searchString += "<b> Loại địa ốc:</b> " + RealEstateMarket._Default.db.GetRealEstateType(realEstateTypeSearchId).Name;
                        if (searchResult.Count() == 0)
                        {
                            NoteLabel.Visible = true;
                        }
                    }
                    if (minPriceSearch != 0 || maxPriceSearch != 0)
                    {
                        searchResult = RealEstateMarket._Default.db.SearchNewsSaleByPrice(minPriceSearch, maxPriceSearch, searchResult.ToArray()).ToList();
                        if (minPriceSearch == 0)
                        {
                            searchString += " <b>Giá nhỏ hơn</b> " + RealEstateMarket.Utility.ConvertPriceText((double)maxPriceSearch);
                        }
                        else if (maxPriceSearch == decimal.MaxValue)
                        {
                            searchString += " <b>Giá lớn hơn</b> " + RealEstateMarket.Utility.ConvertPriceText((double)minPriceSearch);
                        }
                        else
                        {
                            searchString += " <b>Giá lớn hơn</b> " + RealEstateMarket.Utility.ConvertPriceText((double)minPriceSearch) +
                                " <b>Giá nhỏ hơn</b> " + RealEstateMarket.Utility.ConvertPriceText((double)maxPriceSearch);
                        }
                        if (searchResult.Count() == 0)
                        {
                            NoteLabel.Visible = true;
                        }
                    }

                    //-------------------Search by keyword------------------------------------
                    if (key != null)
                    {
                        searchResult = RealEstateMarket._Default.db.SearchNewsSaleByKeywordInList(key, searchResult.ToArray()).ToList();
                        searchString += "<b> Từ khóa:</b> " + key;
                        if (searchResult.Count() == 0)
                        {
                            NoteLabel.Visible = true;
                        }
                    }

                    //----------- Result -------------------------
                    TotalLabel.Text = "<b>" + searchResult.Count().ToString() + "</b> tài sản:" + searchString;
                    NewsSaleDataList.DataSource = searchResult;
                    NewsSaleDataList.DataKeyField = "ID";
                    NewsSaleDataList.DataBind();
                }
                
                #endregion
            }
        }

        protected void VNDButton_Click(object sender, EventArgs e)
        {
            
            
        }
        protected void SJCButton_Click(object sender, EventArgs e)
        {

        }
        protected void USDButton_Click(object sender, EventArgs e)
        {

        }

        protected double GetPriceVND(double price, string unit)
        {
            if (unit == "SJC")
            {
                return price * RealEstateMarket.Utility.RateSJCToVND;
            }
            if (unit == "USD")
            {
                return price * RealEstateMarket.Utility.RateUSDToVND;
            }
            return price;
        }

        protected double GetPriceSJC(double price, string unit)
        {
            if (unit == "VND")
            {

                //return (60000000 / 40000000.0).ToString();
                return price / RealEstateMarket.Utility.RateSJCToVND;
                //System.Console.Write("{0}", 1 / 2.0);
                //<script type="javascript">alert('dfd');</script>
                //return (0.5).ToString();
                
                //Title = (price / RealEstateMarket.Utility.RateSJCToVND).ToString();
            }
            if (unit == "USD")
            {
                return price * RealEstateMarket.Utility.RateUSDToVND / RealEstateMarket.Utility.RateSJCToVND;
            }
            return price;
        }

        protected double GetPriceUSD(double price, string unit)
        {
            if (unit == "SJC")
            {
                return price * RealEstateMarket.Utility.RateSJCToVND / RealEstateMarket.Utility.RateUSDToVND;
            }
            if (unit == "VND")
            {
                return price / RealEstateMarket.Utility.RateUSDToVND;
            }
            return price;
        }
    }
}