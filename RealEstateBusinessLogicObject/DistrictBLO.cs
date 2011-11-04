using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace RealEstateBusinessLogicObject
{
    public class DistrictBLO : BusinessParent<RealEstateDataContext.DISTRICT>
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public DistrictBLO()
        {
            _db = new RealEstateDataAccessObject.DistrictDAO();
        }

        /// <summary>
        /// Get all row in table DISTRICT
        /// </summary>
        /// <returns>List of entities</returns>
        public override ICollection<RealEstateDataContext.DISTRICT> GetAllRows()
        {
            return new ObservableCollection<RealEstateDataContext.DISTRICT>(_db.GetAllRows());
        }

        /// <summary>
        /// Insert a row into DISTRICT table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row have just inserted</returns>
        public override int Insert(RealEstateDataContext.DISTRICT entity)
        {
            entity.ID = _db.CreateID();
            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Insert a row into DISTRICT table
        /// </summary>
        /// <param name="name">District's name</param>
        /// <param name="cityID">ID of city</param>
        /// <returns>ID of row have just inserted</returns>
        public int Insert(string name, int cityID)
        {
            RealEstateDataContext.DISTRICT entity = new RealEstateDataContext.DISTRICT();
            entity.ID = _db.CreateID();
            entity.Name = name;
            entity.CityID = cityID;

            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Update a row in DISTRICT table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row have just updated</returns>
        public override int Update(RealEstateDataContext.DISTRICT entity)
        {
            _db.Update(entity);
            return entity.ID;
        }

        /// <summary>
        /// Update a row in DISTRICT table
        /// </summary>
        /// <param name="id">ID of row</param>
        /// <param name="name">District's name</param>
        /// <param name="cityID">ID of city</param>
        /// <returns>ID of row have just updated</returns>
        public int Update(int id, string name, int cityID)
        {
            RealEstateDataContext.DISTRICT entity = new RealEstateDataContext.DISTRICT();
            entity.ID = id;
            entity.Name = name;
            entity.CityID = cityID;

            _db.Update(entity);
            return entity.ID;
        }

        /// <summary>
        /// Delete a row from DISTRICT table
        /// </summary>
        /// <param name="ID">ID of row want to delete</param>
        /// <returns>ID of row have just deleted</returns>
        public override void Delete(int ID)
        {
            _db.Delete(ID);
        }

        /// <summary>
        /// Get a row in DISTRICT table
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        public override RealEstateDataContext.DISTRICT GetARecord(int ID)
        {
            return _db.GetARecord(ID);
        }
    }
}
