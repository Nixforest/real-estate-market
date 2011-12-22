using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using RealEstateDataContext;

namespace RealEstateDataAccessObject
{
    public class Customer_RealEatateDAO : DataParent<RealEstateDataContext.CUSTOMER_REALESTATE>
    {
        public CUSTOMER_REALESTATE ce;
        public Customer_RealEatateDAO()
        {
            ce = new CUSTOMER_REALESTATE();
        }

        public override IEnumerable<RealEstateDataContext.CUSTOMER_REALESTATE> GetAll()
        {
            var sql = @"select distinct CUSTOMER.Name[CustomerName],REAL_ESTATE_TYPE.Name[RealEstateTypeName]
                        from CUSTOMER
                        left join PROPERTY_CUSTOMER
                        on CUSTOMER.ID=PROPERTY_CUSTOMER.CustomerID
                        left join REAL_ESTATE
                        on REAL_ESTATE.ID=PROPERTY_CUSTOMER.RealEstateID
                        left join REAL_ESTATE_TYPE
                        on REAL_ESTATE.TypeID=REAL_ESTATE_TYPE.ID";
            
            var table = _db.ExecuteQuery<CUSTOMER_REALESTATE>(sql);
            return table;
        }
    }
}
