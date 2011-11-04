using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace RealEstateBusinessLogicObject
{
    public class ProjectBLO : BusinessParent<RealEstateDataContext.PROJECT>
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public ProjectBLO()
        {
            _db = new RealEstateDataAccessObject.ProjectDAO();
        }

        /// <summary>
        /// Get all row in table PROJECT
        /// </summary>
        /// <returns>List of entities</returns>
        public override ICollection<RealEstateDataContext.PROJECT> GetAllRows()
        {
            return new ObservableCollection<RealEstateDataContext.PROJECT>(_db.GetAllRows());
        }

        /// <summary>
        /// Insert a row into PROJECT table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row has just inserted</returns>
        public override int Insert(RealEstateDataContext.PROJECT entity)
        {
            entity.ID = _db.CreateID();
            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Insert a row into PROJECT table
        /// </summary>
        /// <param name="typeID">ID of type</param>
        /// <param name="name">Project's name</param>
        /// <param name="beginDay">Project's begin day</param>
        /// <param name="addressID">Project's address ID</param>
        /// <param name="description">Project's description</param>
        /// <returns>ID of row has just inserted</returns>
        public int Insert(int typeID, string name, DateTime? beginDay, int addressID, string description)
        {
            RealEstateDataContext.PROJECT entity = new RealEstateDataContext.PROJECT();
            entity.ID = _db.CreateID();
            entity.TypeID = typeID;
            entity.Name = name;
            entity.BeginDay = beginDay;
            entity.AddressID = addressID;
            entity.Description = description;

            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Update a row in PROJECT table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row has just updated</returns>
        public override int Update(RealEstateDataContext.PROJECT entity)
        {
            _db.Update(entity);
            return entity.ID;
        }

        /// <summary>
        /// Update a row in PROJECT table
        /// </summary>
        /// <param name="id">ID of row</param>
        /// <param name="typeID">ID of type</param>
        /// <param name="name">Project's name</param>
        /// <param name="beginDay">Project's begin day</param>
        /// <param name="addressID">Project's address ID</param>
        /// <param name="description">Project's description</param>
        /// <returns>ID of row has just updated</returns>
        public int Update(int id, int typeID, string name, DateTime? beginDay, int addressID, string description)
        {
            RealEstateDataContext.PROJECT entity = new RealEstateDataContext.PROJECT();
            entity.ID = id;
            entity.TypeID = typeID;
            entity.Name = name;
            entity.BeginDay = beginDay;
            entity.AddressID = addressID;
            entity.Description = description;

            _db.Update(entity);
            return entity.ID;
        }

        /// <summary>
        /// Delete a row from PROJECT table
        /// </summary>
        /// <param name="ID">ID of row want to delete</param>
        /// <returns>ID of row has just deleted</returns>
        public override void Delete(int ID)
        {
            _db.Delete(ID);
        }

        /// <summary>
        /// Get a row in PROJECT table
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        public override RealEstateDataContext.PROJECT GetARecord(int ID)
        {
            return _db.GetARecord(ID);
        }
    }
}
