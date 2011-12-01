using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateDataAccessObject
{
    /// <summary>
    /// Class access to UTILITY_DETAIL table in database
    /// </summary>
    public class Utility_DetailDAO : DataParent<RealEstateDataContext.UTILITY_DETAIL>
    {
        /// <summary>
        /// Get Max ID
        /// </summary>
        /// <returns>Max ID</returns>
        public override int GetMaxID()
        {
            return _db.UTILITY_DETAILs.Max(entity => entity.ID);
        }

        /// <summary>
        /// Get all rows in table UTILITY_DETAIL
        /// </summary>
        /// <returns>List of entity</returns>
        public override ICollection<RealEstateDataContext.UTILITY_DETAIL> GetAllRows()
        {
            return _db.UTILITY_DETAILs.ToList();
        }

        /// <summary>
        /// Insert a row into table UTILITY_DETAIL
        /// </summary>
        /// <param name="entity">Entity</param>
        public override void Insert(RealEstateDataContext.UTILITY_DETAIL entity)
        {
            try
            {
                entity.ID = this.GetMaxID() + 1;
            }
            catch (System.InvalidOperationException)
            {
                entity.ID = 1;
            }
            _db.UTILITY_DETAILs.InsertOnSubmit(entity);
            _db.SubmitChanges();
        }

        /// <summary>
        /// Update a row in table UTILITY_DETAIL
        /// </summary>
        /// <param name="entity">Entity</param>
        public override void Update(RealEstateDataContext.UTILITY_DETAIL entity)
        {
            RealEstateDataContext.UTILITY_DETAIL oldEntity = _db.UTILITY_DETAILs.Single(record => record.ID == entity.ID);
            oldEntity.RealEstateID = entity.RealEstateID;
            oldEntity.UtilityID = entity.UtilityID;

            _db.SubmitChanges();
        }

        /// <summary>
        /// Delete a row in table UTILITY_DETAIL
        /// </summary>
        /// <param name="ID">ID of row</param>
        public override void Delete(int ID)
        {
            var entity = from record in _db.UTILITY_DETAILs
                         where record.ID.Equals(ID)
                         select record;
            _db.UTILITY_DETAILs.DeleteAllOnSubmit(entity);
            _db.SubmitChanges();
        }

        /// <summary>
        /// Get a row from table UTILITY_DETAIL
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        public override RealEstateDataContext.UTILITY_DETAIL GetARecord(int ID)
        {
            var entity = from record in _db.UTILITY_DETAILs
                         where record.ID.Equals(ID)
                         select record;
            return entity.Single();
        }
    }
}
