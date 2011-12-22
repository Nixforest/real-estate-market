using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace RealEstateBusinessLogicObject
{
    [DataObject(true)]
    public class Count_RealEstateBLO
    {
        RealEstateDataAccessObject.Count_RealEstateDAO _db = new RealEstateDataAccessObject.Count_RealEstateDAO();
        public Count_RealEstateBLO()
        {
            _db = new RealEstateDataAccessObject.Count_RealEstateDAO();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public override IEnumerable<RealEstateDataContext.COUNT_REALESTATE> GetAllByDate(int month, int year)
        {
            return new ObservableCollection<RealEstateDataContext.COUNT_REALESTATE>(_db.GetAllByDate(month, year));
        }
    }
}
