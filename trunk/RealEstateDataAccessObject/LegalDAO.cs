using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateDataAccessObject
{
    /// <summary>
    /// Class access to LEGAL table in database
    /// </summary>
    public class LegalDAO: DataParent<RealEstateDataContext.LEGAL>
    {
        /// <summary>
        /// Get Max ID
        /// </summary>
        /// <returns>Max ID</returns>
        public override int GetMaxID()
        {
            return _db.LEGALs.Max(entity => entity.ID);
        }

        /// <summary>
        /// Get all rows in table LEGAL
        /// </summary>
        /// <returns>List of entity</returns>
        public override ICollection<RealEstateDataContext.LEGAL> GetAllRows()
        {
            return _db.LEGALs.ToList();
        }

        /// <summary>
        /// Insert a row into table LEGAL
        /// </summary>
        /// <param name="entity">Entity</param>
        public override void Insert(RealEstateDataContext.LEGAL entity)
        {
            _db.LEGALs.InsertOnSubmit(entity);
            _db.SubmitChanges();
        }

        /// <summary>
        /// Update a row in table LEGAL
        /// </summary>
        /// <param name="entity">Entity</param>
        public override void Update(RealEstateDataContext.LEGAL entity)
        {
            RealEstateDataContext.LEGAL oldEntity = _db.LEGALs.Single(record => record.ID == entity.ID);
            oldEntity.Name        = entity.Name;
            oldEntity.Description = entity.Description;

            _db.SubmitChanges();
        }

        /// <summary>
        /// Delete a row in table LEGAL
        /// </summary>
        /// <param name="ID">ID of row</param>
        public override void Delete(int ID)
        {
            var entity = from record in _db.LEGALs
                         where record.ID.Equals(ID)
                         select record;
            _db.LEGALs.DeleteAllOnSubmit(entity);
            _db.SubmitChanges();
        }

        /// <summary>
        /// Get a row from table LEGAL
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        public override RealEstateDataContext.LEGAL GetARecord(int ID)
        {
            var entity = from record in _db.LEGALs
                         where record.ID.Equals(ID)
                         select record;
            return entity.Single();
        }
    }
}
