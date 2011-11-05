using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateDataContext.Utility
{
    public class AddressID : Exception { }
    public class NationID : Exception { }
    public class CityID : Exception { }
    public class DistrictID : Exception { }
    public class WardID : Exception { }
    public class StreetID : Exception { }
    public class ShareCapital : Exception { }
    public class RoomNumber : Exception { }
    public class CompanyID : Exception { }
    public class UserID : Exception { }
    public class CustomerID : Exception { }
    public class GroupID : Exception { }
    public class ImageID : Exception { }
    public class News_Sale_TypeID : Exception { }
    public class News_SaleID : Exception { }
    public class Real_EstateID : Exception { }
    public class Real_Estate_TypeID : Exception { }
    public class Rate_Limitation : Exception { }
    public class News_TypeID : Exception { }
    public class NewsID : Exception { }
    public class Project_TypeID : Exception { }
    public class ProjectID : Exception { }
    public class GreaterZero : Exception { }
    public class UnitID : Exception { }
    public class Unit_PriceID : Exception { }
    public class ContactID : Exception { }
    public class RuleID : Exception { }
    public class UtilityID : Exception { }

    public class ExceptionMessage
    {
        public static string AddressID = "AddressID Not Exist";
        public static string NationID = "NationID Not Exist";
        public static string CityID = "CityID Not Exist";
        public static string DistrictID = "DistrictID Not Exist";
        public static string WardID = "WardID Not Exist";
        public static string StreetID = "StreetID Not Exist";
        public static string ShareCapital = "Share Capital Must Greater Than Zero";
        public static string CompanyID = "CompanyID Not Exist";
        public static string UserID = "UserID Not Exist";
        public static string CustomerID = "CustomerID Not Exist";
        public static string GroupID = "GroupID Not Exist";
    }
}
