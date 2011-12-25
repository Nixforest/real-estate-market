using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RealEstateDataContext;

namespace RealEstateDataAccessObject
{
    public class Count_RealEstateDAO : DataParent<RealEstateDataContext.COUNT_REALESTATE>
    {
        public COUNT_REALESTATE cr;
        public Count_RealEstateDAO()
        {
            cr = new COUNT_REALESTATE();
        }

        public IEnumerable<RealEstateDataContext.COUNT_REALESTATE> GetAllByDate(int month, int year)
        {
            var sql = @"select NEWS_SALE_TYPE.Name[Name], SUM(REAL_ESTATE.Price) as Total, UNIT.Name[UnitName]
                        from NEWS_SALE, NEWS_SALE_TYPE, REAL_ESTATE,UNIT
                        where NEWS_SALE.TypeID = NEWS_SALE_TYPE.ID and REAL_ESTATE.ID = NEWS_SALE.RealEstateID and UNIT.ID = REAL_ESTATE.UnitID
                        and MONTH(NEWS_SALE.UpdateTime) = {0} and YEAR(NEWS_SALE.UpdateTime) = {1}
                        group by NEWS_SALE_TYPE.Name, UNIT.Name";

            var table = _db.ExecuteQuery<COUNT_REALESTATE>(sql, month, year);
            return table;
        }
    }
}
