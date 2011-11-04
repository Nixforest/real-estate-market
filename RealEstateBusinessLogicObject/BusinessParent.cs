using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateBusinessLogicObject
{
    public class BusinessParent<T>
    {
        protected RealEstateDataAccessObject.DataParent<T> _db;

        public virtual ICollection<T> GetAllRows() { return null; }
        public virtual int Insert(T entity) { return 0; }
        public virtual int Update(T entity) { return 0; }
        public virtual void Delete(int ID) { }
        public virtual T GetARecord(int ID) { return default(T); }
    }
}
