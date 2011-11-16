using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateDataAccessObject
{
    /// <summary>
    /// Class access to USER table in database
    /// </summary>
    public class UserDAO : DataParent<RealEstateDataContext.USER>
    {
        /// <summary>
        /// Get Max ID
        /// </summary>
        /// <returns>Max ID</returns>
        public override int GetMaxID()
        {
            return _db.USERs.Max(entity => entity.ID);
        }

        /// <summary>
        /// Get all rows in table USER
        /// </summary>
        /// <returns>List of entity</returns>
        public override ICollection<RealEstateDataContext.USER> GetAllRows()
        {
            return _db.USERs.ToList();
        }

        /// <summary>
        /// Insert a row into table USER
        /// </summary>
        /// <param name="entity">Entity</param>
        public override void Insert(RealEstateDataContext.USER entity)
        {
            _db.USERs.InsertOnSubmit(entity);
            _db.SubmitChanges();
        }

        /// <summary>
        /// Update a row in table USER
        /// </summary>
        /// <param name="entity">Entity</param>
        public override void Update(RealEstateDataContext.USER entity)
        {
            RealEstateDataContext.USER oldEntity = _db.USERs.Single(record => record.ID == entity.ID);
            oldEntity.Username = entity.Username;
            oldEntity.Password = entity.Password;
            oldEntity.Email = entity.Email;
            oldEntity.Phone = entity.Phone;
            oldEntity.GroupID = entity.GroupID;

            _db.SubmitChanges();
        }

        /// <summary>
        /// Delete a row in table USER
        /// </summary>
        /// <param name="ID">ID of row</param>
        public override void Delete(int ID)
        {
            var entity = from record in _db.USERs
                         where record.ID.Equals(ID)
                         select record;
            _db.USERs.DeleteAllOnSubmit(entity);
            _db.SubmitChanges();
        }

        /// <summary>
        /// Get a row from table USER
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        public override RealEstateDataContext.USER GetARecord(int ID)
        {
            var entity = from record in _db.USERs
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
            if (_db.USERs.Count() > 0)
            {
                foreach (RealEstateDataContext.USER entity in _db.USERs)
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
