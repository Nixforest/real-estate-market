using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RealEstateDataAccessObject;
using RealEstateDataContext;
using System.Collections.ObjectModel;

namespace RealEstateBusinessLogicObject
{
    public class NationBLO : BusinessParent<RealEstateDataContext.NATION>
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public NationBLO()
        {
            _db = new NationDAO();
        }

        /// <summary>
        /// Get all row in table NATION
        /// </summary>
        /// <returns>List of entities</returns>
        public override ICollection<NATION> GetAllRows()
        {
            return new ObservableCollection<NATION>(_db.GetAllRows());
        }

        /// <summary>
        /// Insert a row into NATION table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row just insert</returns>
        public override int Insert(NATION entity)
        {
            entity.ID = _db.CreateID();
            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Insert a row into NATION table
        /// </summary>
        /// <param name="name">Name of Nation</param>
        /// <param name="nationCode">National code</param>
        /// <returns>ID of row just insert</returns>
        public int Insert(string name, string nationCode)
        {
            NATION entity = new NATION();
            entity.ID = _db.CreateID();
            entity.Name = name;
            entity.NationCode = nationCode;
            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Update a row in NATION table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row just update</returns>
        public override int Update(NATION entity)
        {
            _db.Update(entity);
            return entity.ID;
        }

        /// <summary>
        /// Update a row in NATION table
        /// </summary>
        /// <param name="id">ID of Nation</param>
        /// <param name="name">Name of Nation</param>
        /// <param name="nationCode">National code</param>
        /// <returns>ID of row just update</returns>
        public int Update(int id, string name, string nationCode)
        {
            NATION entity = new NATION();
            entity.ID = _db.CreateID();
            entity.Name = name;
            entity.NationCode = nationCode;
            _db.Update(entity);
            return entity.ID;
        }

        /// <summary>
        /// Delete a row from NATION table
        /// </summary>
        /// <param name="ID">ID of row want to delete</param>
        /// <returns>ID of row just delete</returns>
        public override void Delete(int ID)
        {
            _db.Delete(ID);
        }

        /// <summary>
        /// Get a row in NATION table
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        public override NATION GetARecord(int ID)
        {
            return _db.GetARecord(ID);
        }
    }
}
