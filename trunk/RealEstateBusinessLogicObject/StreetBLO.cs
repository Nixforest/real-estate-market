using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace RealEstateBusinessLogicObject
{
    public class StreetBLO : BusinessParent<RealEstateDataContext.STREET>
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public StreetBLO()
        {
            _db = new RealEstateDataAccessObject.StreetDAO();
        }

        /// <summary>
        /// Get all row in table STREET
        /// </summary>
        /// <returns>List of entities</returns>
        public override ICollection<RealEstateDataContext.STREET> GetAllRows()
        {
            return new ObservableCollection<RealEstateDataContext.STREET>(_db.GetAllRows());
        }

        /// <summary>
        /// Insert a row into STREET table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row has just inserted</returns>
        public override int Insert(RealEstateDataContext.STREET entity)
        {
            entity.ID = _db.CreateID();
            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Insert a row into STREET table
        /// </summary>
        /// <param name="name">Name of street</param>
        /// <returns>ID of row has just inserted</returns>
        public int Insert(string name)
        {
            RealEstateDataContext.STREET entity = new RealEstateDataContext.STREET();
            entity.ID = _db.CreateID();
            entity.Name = name;

            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Update a row in STREET table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row has just updated</returns>
        public override int Update(RealEstateDataContext.STREET entity)
        {
            if (ValidationID(entity.ID))
            {
                _db.Update(entity);
                return entity.ID;
            }
            else throw new RealEstateDataContext.Utility.StreetID();
        }

        /// <summary>
        /// Update a row in STREET table
        /// </summary>
        /// <param name="id">ID of row</param>
        /// <param name="name">Name of street</param>
        /// <returns>ID of row has just updated</returns>
        public int Update(int id, string name)
        {
            if (ValidationID(id))
            {
                RealEstateDataContext.STREET entity = new RealEstateDataContext.STREET();
                entity.ID = id;
                entity.Name = name;

                _db.Update(entity);
                return entity.ID;
            }
            else throw new RealEstateDataContext.Utility.StreetID();
        }

        /// <summary>
        /// Delete a row from STREET table
        /// </summary>
        /// <param name="ID">ID of row want to delete</param>
        /// <returns>ID of row has just deleted</returns>
        public override void Delete(int ID)
        {
            if (ValidationID(ID))
            {
                _db.Delete(ID);
            }
            else throw new RealEstateDataContext.Utility.StreetID();
        }

        /// <summary>
        /// Get a row in STREET table
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        public override RealEstateDataContext.STREET GetARecord(int ID)
        {
            if (ValidationID(ID))
            {
                return _db.GetARecord(ID);
            }
            else throw new RealEstateDataContext.Utility.StreetID();
        }
    }
}
