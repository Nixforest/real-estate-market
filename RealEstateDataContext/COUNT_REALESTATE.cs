using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateDataContext
{
    public class COUNT_REALESTATE
    {
        private string _name;
        private Decimal _total;
        private string _unitName;
        
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public Decimal Total
        {
            get { return _total; }
            set { _total = value; }
        }

        public string UnitName
        {
            get { return _unitName; }
            set { _unitName = value; }
        }

        public COUNT_REALESTATE()
        { }
    }
}
