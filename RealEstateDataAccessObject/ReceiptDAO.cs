using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RealEstateDataContext;

namespace RealEstateDataAccessObject
{
    public class ReceiptDAO : DataParent<RealEstateDataContext.RECEIPT>
    {
        public IEnumerable<RealEstateDataContext.RECEIPT> GetAllByDate(int month, int year)
        {
            var sql = @"select CUSTOMER.Name[CustumerName], Count(CUSTOMER.Name)*(PARAMETER.Value) as Total
                       from CUSTOMER, NEWS_SALE, REAL_ESTATE, PROPERTY_CUSTOMER, PARAMETER
                       where REAL_ESTATE.ID = NEWS_SALE.RealEstateID and CUSTOMER.ID = PROPERTY_CUSTOMER.CustomerID 
                       and REAL_ESTATE.ID = PROPERTY_CUSTOMER.RealEstateID 
                       and MONTH(NEWS_SALE.UpdateTime) = {0} and YEAR(NEWS_SALE.UpdateTime) = {1}
                       and PARAMETER.[Key] = 'Price'
                       group by CUSTOMER.Name, PARAMETER.Value";
            var table = _db.ExecuteQuery<RECEIPT>(sql, month, year);
            return table;
        }
    }
}
