using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace RealEstateBusinessLogicObject
{
    [DataObject(true)]
    public class View_NewsBLO
    {
        RealEstateDataAccessObject.View_NewsDAO _db = new RealEstateDataAccessObject.View_NewsDAO();
        public View_NewsBLO()
        {
            _db = new RealEstateDataAccessObject.View_NewsDAO();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public override IEnumerable<RealEstateDataContext.VIEW_NEWS> GetAll()
        {
            return new ObservableCollection<RealEstateDataContext.VIEW_NEWS>(_db.GetAll());
        }
    }
}
