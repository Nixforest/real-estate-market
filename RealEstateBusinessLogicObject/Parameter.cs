using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace RealEstateBusinessLogicObject
{
    [DataObject(true)]
    public class Parameter : BusinessParent<RealEstateDataContext.PARAMETER>
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public Parameter()
        {
            _db = new RealEstateDataAccessObject.ParameterDAO();
        }

        /// <summary>
        /// Get all row in table PARAMETER
        /// </summary>
        /// <returns>List of entities</returns>
        public override ICollection<RealEstateDataContext.PARAMETER> GetAllRows()
        {
            return new ObservableCollection<RealEstateDataContext.PARAMETER>(_db.GetAllRows());
        }

        /// <summary>
        /// Insert a row into PARAMETER table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Key of entity</returns>
        public string Insert(RealEstateDataContext.PARAMETER entity)
        {
            _db.Insert(entity);
            return entity.Key;
        }

        /// <summary>
        /// Insert a row into PARAMETER table
        /// </summary>
        /// <param name="key">Key of Parameter</param>
        /// <param name="value">Value of Parameter</param>
        public void Insert(string key, int value)
        {
            RealEstateDataContext.PARAMETER entity = new RealEstateDataContext.PARAMETER();
            entity.Key   = key;
            entity.Value = value;
            _db.Insert(entity);
        }

        /// <summary>
        /// Update a row in PARAMETER table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>Key of entity</returns>
        public string Update(RealEstateDataContext.PARAMETER entity)
        {
            _db.Update(entity);
            return entity.Key;
        }

        /// <summary>
        /// Update a row in PARAMETER table
        /// </summary>
        /// <param name="key">Key of Parameter</param>
        /// <param name="value">Value of Parameter</param>
        public void Update(string key, int value)
        {
            RealEstateDataContext.PARAMETER entity = new RealEstateDataContext.PARAMETER();
            entity.Key   = key;
            entity.Value = value;
            _db.Update(entity);
        }

        /// <summary>
        /// Get a record
        /// </summary>
        /// <param name="key">Key of parameter</param>
        /// <returns>Entity</returns>
        public RealEstateDataContext.PARAMETER GetARecord(string key)
        {
            return new RealEstateDataAccessObject.ParameterDAO().GetARecord(key);
        }
        public static int MinRate = 1;
        public static int MaxRate = 5;

        public static int MaxSummaryLength = 160;

        public static int StreetHouse = 1;
        public static int TempHouse = 2;
        public static int Villa = 3;
        public static int LuxuryApartment = 4;
        public static int Apartment = 5;
        public static int Office = 6;
        public static int ProductionLand = 7;
        public static int ProjectLand = 8;
        public static int ForestLand = 9;
        public static int AgriculturalLand = 10;
        public static int StayLand = 11;
        public static int Store = 12;
        public static int Restaurant = 13;
        public static int Other = 14;
        public static int Renting = 15;

        public static decimal RateSJCToVND = 40000000;
        public static decimal RateUSDToVND = 20000;
    }
}
