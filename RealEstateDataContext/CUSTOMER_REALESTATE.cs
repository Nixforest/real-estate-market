using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateDataContext
{
   /// <summary>
   /// @author: Cong
   /// </summary>
    
    public class CUSTOMER_REALESTATE
    {
        private string customerName;
        private string realEstateTypeName;

        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }

        public string RealEstateTypeName
        {
            get { return realEstateTypeName; }
            set { realEstateTypeName = value; }
        }

        public CUSTOMER_REALESTATE()
        { }
    }
}
