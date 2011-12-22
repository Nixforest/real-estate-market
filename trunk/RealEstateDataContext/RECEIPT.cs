using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateDataContext
{
    public class RECEIPT
    {
        private string _customerName;
        private int _total;

        public string CustumerName
        {
            get { return _customerName; }
            set { _customerName = value; }
        }

        public int Total
        {
            get { return _total; }
            set { _total = value; }
        }
    }
}
