using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RealEstateBusinessLogicObject
{
    [DataObject(true)]
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
            if (!ValidationName(entity.Name))
            {
                entity.ID = this.CreateNewID();
                _db.Insert(entity);
                return entity.ID;
            }
            else throw new RealEstateDataContext.Utility.DoubleStreetNameException();
        }

        /// <summary>
        /// Insert a row into STREET table
        /// </summary>
        /// <param name="name">Name of street</param>
        /// <returns>ID of row has just inserted</returns>
        public int Insert(string name)
        {
            if (!ValidationName(name))
            {
                RealEstateDataContext.STREET entity = new RealEstateDataContext.STREET();
                entity.ID = this.CreateNewID();
                entity.Name = name;

                _db.Insert(entity);
                return entity.ID;
            }
            else throw new RealEstateDataContext.Utility.DoubleStreetNameException();
        }

        /// <summary>
        /// Update a row in STREET table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row has just updated</returns>
        /// <exception cref="StreetIDException"></exception>
        public override int Update(RealEstateDataContext.STREET entity)
        {
            if (ValidationID(entity.ID))
            {
                if (!ValidationName(entity.Name))
                {
                    _db.Update(entity);
                    return entity.ID;
                }
                else throw new RealEstateDataContext.Utility.DoubleStreetNameException();
            }
            else throw new RealEstateDataContext.Utility.StreetIDException();
        }

        /// <summary>
        /// Update a row in STREET table
        /// </summary>
        /// <param name="id">ID of row</param>
        /// <param name="name">Name of street</param>
        /// <returns>ID of row has just updated</returns>
        /// <exception cref="StreetIDException"></exception>
        public int Update(int id, string name)
        {
            if (ValidationID(id))
            {
                if (!ValidationName(name)
                    || (ValidationName(name) && GetIDFromName(name) == id))
                {
                    RealEstateDataContext.STREET entity = new RealEstateDataContext.STREET();
                    entity.ID = id;
                    entity.Name = name;

                    _db.Update(entity);
                    return entity.ID;
                }
                else throw new RealEstateDataContext.Utility.DoubleStreetNameException();
            }
            else throw new RealEstateDataContext.Utility.StreetIDException();
        }

        /// <summary>
        /// Delete a row from STREET table
        /// </summary>
        /// <param name="ID">ID of row want to delete</param>
        /// <returns>ID of row has just deleted</returns>
        /// <exception cref="StreetIDException"></exception>
        public override void Delete(int ID)
        {
            if (ValidationID(ID))
            {
                _db.Delete(ID);
            }
            else throw new RealEstateDataContext.Utility.StreetIDException();
        }

        /// <summary>
        /// Get a row in STREET table
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        /// <exception cref="StreetIDException"></exception>
        public override RealEstateDataContext.STREET GetARecord(int ID)
        {
            if (ValidationID(ID))
            {
                return _db.GetARecord(ID);
            }
            else throw new RealEstateDataContext.Utility.StreetIDException();
        }

        /// <summary>
        /// Check a name exist in table STREET
        /// </summary>
        /// <param name="name">Street's name</param>
        /// <returns>True if name exist, false if otherwise</returns>
        public bool ValidationName(string name)
        {
            foreach (RealEstateDataContext.STREET entity in _db.GetAllRows())
            {
                if (entity.Name.ToLower().Equals(name.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// Get ID of Street if Street's name exist in table STREET
        /// </summary>
        /// <param name="name">Street's name</param>
        /// <returns>ID of name or 0 if name does not exist!</returns>
        public int GetIDFromName(string name)
        {
            if (ValidationName(name))
            {
                foreach (RealEstateDataContext.STREET entity in _db.GetAllRows())
                {
                    if (entity.Name.ToLower().Equals(name.ToLower()))
                    {
                        return entity.ID;
                    }
                }
            }
            return 0;
        }
    }
}
