using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace RealEstateBusinessLogicObject
{
    public class CityBLO : BusinessParent<RealEstateDataContext.CITY>
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public CityBLO()
        {
            _db = new RealEstateDataAccessObject.CityDAO();
        }

        /// <summary>
        /// Get all row in table CITY
        /// </summary>
        /// <returns>List of entities</returns>
        public override ICollection<RealEstateDataContext.CITY> GetAllRows()
        {
            return new ObservableCollection<RealEstateDataContext.CITY>(_db.GetAllRows());
        }

        /// <summary>
        /// Insert a row into CITY table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row just insert</returns>
        public override int Insert(RealEstateDataContext.CITY entity)
        {
            if (new RealEstateDataAccessObject.NationDAO().ValidationID(entity.NationID))
            {
                entity.ID = _db.CreateID();
                _db.Insert(entity);
                return entity.ID;
            }
            else throw new RealEstateDataContext.Utility.NationID();
        }

        /// <summary>
        /// Insert a row into CITY table
        /// </summary>
        /// <param name="name">Name of city</param>
        /// <param name="nationID">ID of Nation</param>
        /// <returns>ID of row just insert</returns>
        public int Insert(string name, int nationID)
        {
            if (new RealEstateDataAccessObject.NationDAO().ValidationID(nationID))
            {
                RealEstateDataContext.CITY entity = new RealEstateDataContext.CITY();
                entity.ID = _db.CreateID();
                entity.Name = name;
                entity.NationID = nationID;

                _db.Insert(entity);
                return entity.ID;
            }
            else throw new RealEstateDataContext.Utility.NationID();
        }

        /// <summary>
        /// Update a row in NATION table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row just update</returns>
        public override int Update(RealEstateDataContext.CITY entity)
        {
            if (ValidationID(entity.ID))
            {
                if (new RealEstateDataAccessObject.NationDAO().ValidationID(entity.NationID))
                {
                    _db.Update(entity);
                    return entity.ID;
                }
                else throw new RealEstateDataContext.Utility.NationID();
            }
            else throw new RealEstateDataContext.Utility.CityID();
        }

        /// <summary>
        /// Update a row in NATION table
        /// </summary>
        /// <param name="id">ID of row</param>
        /// <param name="name">Name of city</param>
        /// <param name="nationID">ID of Nation</param>
        /// <returns>ID of row just update</returns>
        public int Update(int id, string name, int nationID)
        {
            if (ValidationID(id))
            {
                if (new RealEstateDataAccessObject.NationDAO().ValidationID(nationID))
                {
                    RealEstateDataContext.CITY entity = new RealEstateDataContext.CITY();
                    entity.ID = id;
                    entity.Name = name;
                    entity.NationID = nationID;

                    _db.Update(entity);
                    return entity.ID;
                }
                else throw new RealEstateDataContext.Utility.NationID();
            }
            else throw new RealEstateDataContext.Utility.CityID();
        }

        /// <summary>
        /// Delete a row from CITY table
        /// </summary>
        /// <param name="ID">ID of row want to delete</param>
        /// <returns>ID of row just delete</returns>
        public override void Delete(int ID)
        {
            if (ValidationID(ID))
            {
                _db.Delete(ID);
            }
            else throw new RealEstateDataContext.Utility.CityID();
        }

        /// <summary>
        /// Get a row in CITY table
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        public override RealEstateDataContext.CITY GetARecord(int ID)
        {
            if (ValidationID(ID))
            {
                return _db.GetARecord(ID);
            }
            else throw new RealEstateDataContext.Utility.CityID();
        }
    }
}
