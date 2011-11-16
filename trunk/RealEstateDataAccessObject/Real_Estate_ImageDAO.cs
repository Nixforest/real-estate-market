using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateDataAccessObject
{
    /// <summary>
    /// Class access to REAL_ESTATE_IMAGE table in database
    /// </summary>
    public class Real_Estate_ImageDAO : DataParent<RealEstateDataContext.REAL_ESTATE_IMAGE>
    {
        /// <summary>
        /// Get Max ID
        /// </summary>
        /// <returns>Max ID</returns>
        public override int GetMaxID()
        {
            return _db.REAL_ESTATE_IMAGEs.Max(entity => entity.ID);
        }

        /// <summary>
        /// Get all rows in table REAL_ESTATE_IMAGE
        /// </summary>
        /// <returns>List of entity</returns>
        public override ICollection<RealEstateDataContext.REAL_ESTATE_IMAGE> GetAllRows()
        {
            return _db.REAL_ESTATE_IMAGEs.ToList();
        }

        /// <summary>
        /// Insert a row into table REAL_ESTATE_IMAGE
        /// </summary>
        /// <param name="entity">Entity</param>
        public override void Insert(RealEstateDataContext.REAL_ESTATE_IMAGE entity)
        {
            _db.REAL_ESTATE_IMAGEs.InsertOnSubmit(entity);
            _db.SubmitChanges();
        }

        /// <summary>
        /// Update a row in table REAL_ESTATE_IMAGE
        /// </summary>
        /// <param name="entity">Entity</param>
        public override void Update(RealEstateDataContext.REAL_ESTATE_IMAGE entity)
        {
            RealEstateDataContext.REAL_ESTATE_IMAGE oldEntity = _db.REAL_ESTATE_IMAGEs.Single(record => record.ID == entity.ID);
            oldEntity.RealEstateID = entity.RealEstateID;
            oldEntity.ImageID = entity.ImageID;

            _db.SubmitChanges();
        }

        /// <summary>
        /// Delete a row in table REAL_ESTATE_IMAGE
        /// </summary>
        /// <param name="ID">ID of row</param>
        public override void Delete(int ID)
        {
            var entity = from record in _db.REAL_ESTATE_IMAGEs
                         where record.ID.Equals(ID)
                         select record;
            _db.REAL_ESTATE_IMAGEs.DeleteAllOnSubmit(entity);
            _db.SubmitChanges();
        }

        /// <summary>
        /// Get a row from table REAL_ESTATE_IMAGE
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        public override RealEstateDataContext.REAL_ESTATE_IMAGE GetARecord(int ID)
        {
            var entity = from record in _db.REAL_ESTATE_IMAGEs
                         where record.ID.Equals(ID)
                         select record;
            return entity.Single();
        }
    }
}
