using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace RealEstateBusinessLogicObject
{
    [DataObject(true)]
    public class Customer_RealEstateBLO
    {
        RealEstateDataAccessObject.Customer_RealEatateDAO _db = new RealEstateDataAccessObject.Customer_RealEatateDAO();
        public Customer_RealEstateBLO()
        {
            _db = new RealEstateDataAccessObject.Customer_RealEatateDAO();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<RealEstateDataContext.CUSTOMER_REALESTATE> GetAll()
        {
            return new ObservableCollection<RealEstateDataContext.CUSTOMER_REALESTATE>(_db.GetAll());
        }
    }
}
