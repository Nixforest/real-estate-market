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

                return strTextPrice + "<b>VNĐ</b>";
            }
            else if (unit == "SJC")
            {
                return "<b>" + price + "</b> lượng";
            }
            else
            {
                return "<b>" + price + "</b> USD";
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