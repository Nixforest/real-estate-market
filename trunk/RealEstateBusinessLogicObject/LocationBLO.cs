using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RealEstateBusinessLogicObject
{
    [DataObject(true)]
    public class LocationBLO: BusinessParent<RealEstateDataContext.LOCATION>
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public LocationBLO()
        {
            _db = new RealEstateDataAccessObject.LocationDAO();
        }

        /// <summary>
        /// Get all row in table LOCATION
        /// </summary>
        /// <returns>List of entities</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public override ICollection<RealEstateDataContext.LOCATION> GetAllRows()
        {
            return new ObservableCollection<RealEstateDataContext.LOCATION>(_db.GetAllRows());
        }

        /// <summary>
        /// Insert a row into LOCATION table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row have just inserted</returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public override int Insert(RealEstateDataContext.LOCATION entity)
        {
            entity.ID = this.CreateNewID();
            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Insert a row into LOCATION table
        /// </summary>
        /// <param name="name">Location's name</param>
        /// <param name="description">Description</param>
        /// <returns>ID of row have just inserted</returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int Insert(string name, string description)
        {
            RealEstateDataContext.LOCATION entity = new RealEstateDataContext.LOCATION();
            entity.ID = this.CreateNewID();
            entity.Name = name;
            entity.Description = description;

            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Update a row in LOCATION table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row have just updated</returns>
        /// <exception cref="LocationIDException"></exception>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public override int Update(RealEstateDataContext.LOCATION entity)
        {
            if (ValidationID(entity.ID))
            {
                _db.Update(entity);
                return entity.ID;
            }
            else throw new RealEstateDataContext.Utility.LocationIDException();
        }

        /// <summary>
        /// Update a row in LOCATION table
        /// </summary>
        /// <param name="id">ID of row</param>
        /// <param name="name">Location's name</param>
        /// <param name="description">Description</param>
        /// <returns>ID of row have just updated</returns>
        /// <exception cref="LocationIDException"></exception>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public int Update(int id, string name, string description)
        {
            if (ValidationID(id))
            {
                RealEstateDataContext.LOCATION entity = new RealEstateDataContext.LOCATION();
                entity.ID = id;
                entity.Name = name;
                entity.Description = description;

                _db.Update(entity);
                return entity.ID;
            }
            else throw new RealEstateDataContext.Utility.LocationIDException();
        }

        /// <summary>
        /// Delete a row from LOCATION table
        /// </summary>
        /// <param name="ID">ID of row want to delete</param>
        /// <returns>ID of row just delete</returns>
        /// <exception cref="LocationIDException"></exception>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public override void Delete(int ID)
        {
            if (ValidationID(ID))
            {
                _db.Delete(ID);
            }
            else throw new RealEstateDataContext.Utility.LocationIDException();
        }

        /// <summary>
        /// Get a row in LOCATION table
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        /// <exception cref="LocationIDException"></exception>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public override RealEstateDataContext.LOCATION GetARecord(int ID)
        {
            if (ValidationID(ID))
            {
                return _db.GetARecord(ID);
            }
            else throw new RealEstateDataContext.Utility.LocationIDException();
        }
    }
}
