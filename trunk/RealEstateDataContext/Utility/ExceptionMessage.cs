using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RealEstateDataContext.Utility
{
    public class AddressIDException : Exception { }
    public class NationIDException : Exception { }
    public class CityIDException : Exception { }
    public class DistrictIDException : Exception { }
    public class WardIDException : Exception { }
    public class StreetIDException : Exception { }
    public class ShareCapitalException : Exception { }
    public class RoomNumberException : Exception { }
    public class CompanyIDException : Exception { }
    public class UserIDException : Exception { }
    public class CustomerIDException : Exception { }
    public class GroupIDException : Exception { }
    public class ImageIDException : Exception { }
    public class News_Sale_TypeIDException : Exception { }
    public class News_SaleIDException : Exception { }
    public class Real_EstateIDException : Exception { }
    public class Real_Estate_TypeIDException : Exception { }
    public class Rate_LimitationException : Exception { }
    public class News_TypeIDException : Exception { }
    public class NewsIDException : Exception { }
    public class Project_TypeIDException : Exception { }
    public class ProjectIDException : Exception { }
    public class GreaterZeroException : Exception { }
    public class UnitIDException : Exception { }
    public class Unit_PriceIDException : Exception { }
    public class ContactIDException : Exception { }
    public class RuleIDException : Exception { }
    public class UtilityIDException : Exception { }
    public class DoubleStreetNameException : Exception { }
    public class LegalIDException : Exception { }
    public class LocationIDException : Exception { }

    public class Utils
    {
        public static string ConvertToUnSign(string text)
        {
            for (int i = 33; i < 48; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            for (int i = 58; i < 65; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }
            for (int i = 91; i < 97; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            for (int i = 123; i < 127; i++)
            {
                text = text.Replace(((char)i).ToString(), "");
            }

            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(strFormD, String.Empty).Replace("\u0111", "d").Replace("\u0110", "D");
            //for (int i = 33; i < 48; i++)
            //{
            //    text = text.Replace(((char)i).ToString(), "");
            //}

            //for (int i = 58; i < 65; i++)
            //{

            //    text = text.Replace(((char)i).ToString(), "");

            //}

            //for (int i = 91; i < 97; i++)
            //{

            //    text = text.Replace(((char)i).ToString(), "");

            //}

            //for (int i = 123; i < 127; i++)
            //{

            //    text = text.Replace(((char)i).ToString(), "");

            //}

            ////text = text.Replace(" ", "-"); //Comment lại để không đưa khoảng trắng thành ký tự -

            //Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");

            //string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);
            //return regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        private static String[] VietnameseSigns = new String[] { 
            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };
        public static string RemoveSign4VietNameseString(string text)
        {
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                {
                    text = text.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
                }
            }
            return text;
        }

        public static List<string> NormalizationString(string str)
        {
            while (str.IndexOf("  ") != -1)
            {
                str = str.Replace("  ", " ");
            }
            List<string> resutl = new List<string>();

            int index = 0;
            foreach (char item in str)
            {
                if (item.Equals(" "))
                {
                    resutl.Add(str.Substring(index, str.IndexOf(item) - index));
                    index = str.IndexOf(item);
                }
            }
            resutl.Add(str.Substring(index, str.Length - index));
            return resutl;
        }
        
    }
}
