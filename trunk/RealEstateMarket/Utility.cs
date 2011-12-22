using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RealEstateMarket
{
    public static class Utility
    {
        public static double RateSJCToVND = 40000000.0;
        public static double RateUSDToVND = 20000.0;

        public static string GetSummary(string str, int numberChar)
        {
            if (str.Length >= numberChar)
            {
                for (int i = numberChar; i > 0; i--)
                {
                    if (Char.IsWhiteSpace(str[i]))
                    {
                        return (str.Substring(0, i) + "...");
                    }
                }
                return (str.Substring(0, numberChar) + "...");
            }
            else
            {
                return str;
            }
        }
        public static string NormalizationPrice(string price)
        {
            int pos = price.IndexOf(".");
            string nguyen = "";
            string thapphan = "0";
            if (pos != -1)
            {
                nguyen = price.Substring(0, pos);
                thapphan = price.Substring(pos + 1, 2);
            }
            else
            {
                nguyen = price;
            }
            string donvi = "";
            string ngan = "";
            string trieu = "";
            string ty = "";
            string result = "";
            //if (nguyen.Length > 9)
            //{
            //    ty = nguyen.Substring(0, nguyen.Length - 9);
            //    result += ty + ",";
            //}else if(nguyen.Length > 6){
            //    trieu = nguyen.Substring(0, nguyen.Length - 6);
            //    result += trieu + ",";
            //}else if(nguyen.Length > 3){
            //    ngan = nguyen.Substring(0, nguyen.Length - 3);
            //    result += ngan + ",";
            //}else{
            //    result += nguyen;
            //}

            if (nguyen.Length > 3)
            {
                if (nguyen.Length > 6)
                {
                    if (nguyen.Length > 9)
                    {
                        ty = nguyen.Substring(0, nguyen.Length - 9);
                        trieu = nguyen.Substring(nguyen.Length - 9, 3);
                        result += ty + ",";
                    }
                    else
                    {
                        trieu = nguyen.Substring(0, nguyen.Length - 6);
                    }
                    result += trieu + ",";
                    ngan = nguyen.Substring(nguyen.Length - 6, 3);
                }
                else
                {
                    ngan = nguyen.Substring(0, nguyen.Length - 3);
                }
                result += ngan + ",";
                donvi = nguyen.Substring(nguyen.Length - 3, 3);
            }
            else
            {
                donvi = nguyen;
            }
            result += donvi;

            return result + "." + thapphan;
        }
        public static string ConvertPriceText(int newsSaleID)
        {
            double price = Convert.ToDouble(RealEstateMarket._Default.db.GetNewsSale(newsSaleID).REAL_ESTATE.Price);
            if (price == 0)
            {
                return "Thương lượng";
            }
            string unit = RealEstateMarket._Default.db.GetNewsSale(newsSaleID).REAL_ESTATE.UNIT.Name;
            string strTextPrice = "";
            if (unit == "VND")
            {
                int priceBillion = (int)(price / 1000000000.0);
                int priceMillion = (int)((price % 1000000000) / 1000000.0);
                int priceThousand = (int)(((price % 1000000000) % 1000000) / 1000.0);
                //int priceDong     = Int32.Parse((((price % 1000000000) % 1000000) % 1000.0).ToString());
                
                if (priceBillion > 0 && price > 900000000)
                {
                    strTextPrice = strTextPrice + "<b>" + priceBillion + "</b> tỷ ";
                }
                if (priceMillion > 0)
                {
                    strTextPrice = strTextPrice + "<b>" + priceMillion + "</b> triệu ";
                }
                if (priceThousand > 0)
                {
                    strTextPrice = strTextPrice + "<b>" + priceThousand + "</b> ngàn ";
                }

                return strTextPrice +" đồng";
            }
            else if (unit == "SJC")
            {
                return "<b>" + RealEstateMarket.Utility.NormalizationPrice(price.ToString()) + "</b> lượng";
            }
            else
            {
                return "<b>" + RealEstateMarket.Utility.NormalizationPrice(price.ToString()) + "</b> USD";
            }            
        }

        public static string ConvertPriceText(double price)
        {
            string strTextPrice = "";
            int priceBillion = (int)(price / 1000000000.0);
            int priceMillion = (int)((price % 1000000000) / 1000000.0);
            int priceThousand = (int)(((price % 1000000000) % 1000000) / 1000.0);
            //int priceDong     = Int32.Parse((((price % 1000000000) % 1000000) % 1000.0).ToString());

            if (priceBillion > 0 && price > 900000000)
            {
                strTextPrice = strTextPrice + "<b>" + priceBillion + "</b> tỷ ";
            }
            if (priceMillion > 0)
            {
                strTextPrice = strTextPrice + "<b>" + priceMillion + "</b> triệu ";
            }
            if (priceThousand > 0)
            {
                strTextPrice = strTextPrice + "<b>" + priceThousand + "</b> ngàn ";
            }

            return strTextPrice + "<b>VNĐ</b>";
        }
    }
}