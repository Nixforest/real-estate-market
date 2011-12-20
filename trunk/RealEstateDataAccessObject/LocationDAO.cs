using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateDataAccessObject
{
    /// <summary>
    /// Class access to LOCATION table in database
    /// </summary>
    public class LocationDAO: DataParent<RealEstateDataContext.LOCATION>
    {
        /// <summary>
        /// Get Max ID
        /// </summary>
        /// <returns>Max ID</returns>
        public override int GetMaxID()
        {
            return _db.LOCATIONs.Max(entity => entity.ID);
        }

        /// <summary>
        /// Get all rows in table LOCATION
        /// </summary>
        /// <returns>List of entity</returns>
        public override ICollection<RealEstateDataContext.LOCATION> GetAllRows()
        {
            return _db.LOCATIONs.ToList();
        }

        /// <summary>
        /// Insert a row into table LOCATION
        /// </summary>
        /// <param name="entity">Entity</param>
        public override void Insert(RealEstateDataContext.LOCATION entity)
        {
            _db.LOCATIONs.InsertOnSubmit(entity);
            _db.SubmitChanges();
        }

        /// <summary>
        /// Update a row in table LOCATION
        /// </summary>
        /// <param name="entity">Entity</param>
        public override void Update(RealEstateDataContext.LOCATION entity)
        {
            RealEstateDataContext.LOCATION oldEntity = _db.LOCATIONs.Single(record => record.ID == entity.ID);
            oldEntity.Name        = entity.Name;
            oldEntity.Description = entity.Description;

            _db.SubmitChanges();
        }

        /// <summary>
        /// Delete a row in table LOCATION
        /// </summary>
        /// <param name="ID">ID of row</param>
        public override void Delete(int ID)
        {
            var entity = from record in _db.LOCATIONs
                         where record.ID.Equals(ID)
                         select record;
            _db.LOCATIONs.DeleteAllOnSubmit(entity);
            _db.SubmitChanges();
        }

        /// <summary>
        /// Get a row from table LOCATION
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        public override RealEstateDataContext.LOCATION GetARecord(int ID)
        {
            var entity = from record in _db.LOCATIONs
                         where record.ID.Equals(ID)
                         select record;
            return entity.Single();
        }

        /// <summary>
        /// Check an ID exist in table or not
        /// </summary>
        /// <param name="ID">ID need to check</param>
        /// <returns>True if ID has exist, false otherwise</returns>
        public override bool ValidationID(int ID)
        {
            if (_db.LOCATIONs.Count() > 0)
            {
                foreach (RealEstateDataContext.LOCATION entity in _db.LOCATIONs)
                {
                    if (entity.ID.Equals(ID))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
