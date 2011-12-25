using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace RealEstateBusinessLogicObject
{
    [DataObject(true)]
    public class ReceiptBLO 
    {
        RealEstateDataAccessObject.ReceiptDAO _db = new RealEstateDataAccessObject.ReceiptDAO();
        public ReceiptBLO()
        {
            _db = new RealEstateDataAccessObject.ReceiptDAO();
        }

        [DataObjectMethod(DataObjectMethodType.Select)]
        public IEnumerable<RealEstateDataContext.RECEIPT> GetAllByDate(int month, int year)
        {
            return new ObservableCollection<RealEstateDataContext.RECEIPT>(_db.GetAllByDate(month, year));
        }
    }
}
