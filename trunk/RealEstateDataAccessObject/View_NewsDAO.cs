using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RealEstateDataContext;

namespace RealEstateDataAccessObject
{
    public class View_NewsDAO : DataParent<RealEstateDataContext.VIEW_NEWS>
    {
        public VIEW_NEWS vn;
        public View_NewsDAO()
        {
            vn = new VIEW_NEWS();
        }

        public IEnumerable<RealEstateDataContext.VIEW_NEWS> GetAll()
        {
            var sql = @"select distinct NEWS_TYPE.Name[Name], SUM(NEWS.[View]) as TotalView
                        from NEWS, NEWS_TYPE
                        where NEWS.TypeID = NEWS_TYPE.ID
                        group by NEWS_TYPE.Name";
            var table = _db.ExecuteQuery<VIEW_NEWS>(sql);
            return table;
        }
    }
}
