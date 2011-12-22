using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateDataContext
{
    public class VIEW_NEWS
    {
        private string _name;
        private int _view;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int TotalView
        {
            get { return _view; }
            set { _view = value; }
        }
    }
}
