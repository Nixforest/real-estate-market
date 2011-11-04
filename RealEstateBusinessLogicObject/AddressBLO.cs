using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace RealEstateBusinessLogicObject
{
    public class AddressBLO : BusinessParent<RealEstateDataContext.ADDRESS>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AddressBLO()
        {
            _db = new RealEstateDataAccessObject.AddressDAO();
        }

        /// <summary>
        /// Get all row in table ADDRESS
        /// </summary>
        /// <returns>List of entities</returns>
        public override ICollection<RealEstateDataContext.ADDRESS> GetAllRows()
        {
            return new ObservableCollection<RealEstateDataContext.ADDRESS>(_db.GetAllRows());
        }

        /// <summary>
        /// Insert a row into ADDRESS table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row just insert</returns>
        public override int Insert(RealEstateDataContext.ADDRESS entity)
        {
            entity.ID = _db.CreateID();
            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Insert a row into ADDRESS table
        /// </summary>
        /// <param name="nationID">ID of nation</param>
        /// <param name="cityID">ID of city</param>
        /// <param name="districtID">ID of district</param>
        /// <param name="wardID">ID of ward</param>
        /// <param name="streetID">ID of street</param>
        /// <param name="detail">Detail Address</param>
        /// <returns>ID of row just insert</returns>
        public int Insert(int nationID, int cityID, int districtID, int wardID, int streetID, string detail)
        {
            RealEstateDataContext.ADDRESS entity = new RealEstateDataContext.ADDRESS();
            entity.ID = _db.CreateID();
            entity.NationID = nationID;
            entity.CityID = cityID;
            entity.DistrictID = districtID;
            entity.WardID = wardID;
            entity.StreetID = streetID;
            entity.Detail = detail;

            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Update a row in ADDRESS table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row just update</returns>
        public override int Update(RealEstateDataContext.ADDRESS entity)
        {
            _db.Update(entity);
            return entity.ID;
        }

        /// <summary>
        /// Update a row in ADDRESS table
        /// </summary>
        /// <param name="id">ID of row</param>
        /// <param name="nationID">ID of nation</param>
        /// <param name="cityID">ID of city</param>
        /// <param name="districtID">ID of district</param>
        /// <param name="wardID">ID of ward</param>
        /// <param name="streetID">ID of street</param>
        /// <param name="detail">Detail Address</param>
        /// <returns>ID of row just update</returns>
        public int Update(int id, int nationID, int cityID, int districtID, int wardID, int streetID, string detail)
        {
            RealEstateDataContext.ADDRESS entity = new RealEstateDataContext.ADDRESS();
            entity.ID = id;
            entity.NationID = nationID;
            entity.CityID = cityID;
            entity.DistrictID = districtID;
            entity.WardID = wardID;
            entity.StreetID = streetID;
            entity.Detail = detail;

            _db.Update(entity);
            return entity.ID;
        }


        /// <summary>
        /// Delete a row from ADDRESS table
        /// </summary>
        /// <param name="ID">ID of row want to delete</param>
        public override void Delete(int ID)
        {
            _db.Delete(ID);
        }

        /// <summary>
        /// Get a row in ADDRESS table
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        public override RealEstateDataContext.ADDRESS GetARecord(int ID)
        {
            return _db.GetARecord(ID);
        }

        public RealEstateDataContext.NATION GetNation(int ID)
        {
            return _db.GetARecord(ID).NATION;
        }
    }
}
