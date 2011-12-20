using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace RealEstateBusinessLogicObject
{
    [DataObject(true)]
    public class LegalBLO: BusinessParent<RealEstateDataContext.LEGAL>
    {        
        /// <summary>
        /// Contructor
        /// </summary>
        public LegalBLO()
        {
            _db = new RealEstateDataAccessObject.LegalDAO();
        }

        /// <summary>
        /// Get all row in table LEGAL
        /// </summary>
        /// <returns>List of entities</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public override ICollection<RealEstateDataContext.LEGAL> GetAllRows()
        {
            return new ObservableCollection<RealEstateDataContext.LEGAL>(_db.GetAllRows());
        }

        /// <summary>
        /// Insert a row into LEGAL table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row have just inserted</returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public override int Insert(RealEstateDataContext.LEGAL entity)
        {
            entity.ID = this.CreateNewID();
            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Insert a row into LEGAL table
        /// </summary>
        /// <param name="name">Legal's name</param>
        /// <param name="description">Description</param>
        /// <returns>ID of row have just inserted</returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int Insert(string name, string description)
        {
            RealEstateDataContext.LEGAL entity = new RealEstateDataContext.LEGAL();
            entity.ID          = this.CreateNewID();
            entity.Name        = name;
            entity.Description = description;

            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Update a row in LEGAL table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row have just updated</returns>
        /// <exception cref="GroupIDException"></exception>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public override int Update(RealEstateDataContext.LEGAL entity)
        {
            if (ValidationID(entity.ID))
            {
                _db.Update(entity);
                return entity.ID;
            }
            else throw new RealEstateDataContext.Utility.LegalIDException();
        }

        /// <summary>
        /// Update a row in LEGAL table
        /// </summary>
        /// <param name="id">ID of row</param>
        /// <param name="name">Legal's name</param>
        /// <param name="description">Description</param>
        /// <returns>ID of row have just updated</returns>
        /// <exception cref="LegalIDException"></exception>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public int Update(int id, string name, string description)
        {
            if (ValidationID(id))
            {
                RealEstateDataContext.LEGAL entity = new RealEstateDataContext.LEGAL();
                entity.ID          = id;
                entity.Name        = name;
                entity.Description = description;

                _db.Update(entity);
                return entity.ID;
            }
            else throw new RealEstateDataContext.Utility.LegalIDException();
        }

        /// <summary>
        /// Delete a row from LEGAL table
        /// </summary>
        /// <param name="ID">ID of row want to delete</param>
        /// <returns>ID of row just delete</returns>
        /// <exception cref="LegalIDException"></exception>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public override void Delete(int ID)
        {
            if (ValidationID(ID))
            {
                _db.Delete(ID);
            }
            else throw new RealEstateDataContext.Utility.LegalIDException();
        }

        /// <summary>
        /// Get a row in LEGAL table
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        /// <exception cref="LegalIDException"></exception>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public override RealEstateDataContext.LEGAL GetARecord(int ID)
        {
            if (ValidationID(ID))
            {
                return _db.GetARecord(ID);
            }
            else throw new RealEstateDataContext.Utility.LegalIDException();
        }
    }
}
