using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateDataAccessObject
{
    /// <summary>
    /// Class access to IMAGE table in database
    /// </summary>
    public class ImageDAO : DataParent<RealEstateDataContext.IMAGE>
    {
        /// <summary>
        /// Create a new ID for new entity in table
        /// </summary>
        /// <returns>ID just create.</returns>
        public override int CreateID()
        {
            int numberRecord;
            int value;
            numberRecord = _db.IMAGEs.Count();
            if (numberRecord == 0)
            {
                value = 1;
            }
            else
            {
                value = numberRecord + 1;
            }
            return value;
        }

        /// <summary>
        /// Get all rows in table IMAGE
        /// </summary>
        /// <returns>List of entity</returns>
        public override ICollection<RealEstateDataContext.IMAGE> GetAllRows()
        {
            return _db.IMAGEs.ToList();
        }

        /// <summary>
        /// Insert a row into table IMAGE
        /// </summary>
        /// <param name="entity">Entity</param>
        public override void Insert(RealEstateDataContext.IMAGE entity)
        {
            _db.IMAGEs.InsertOnSubmit(entity);
            _db.SubmitChanges();
        }

        /// <summary>
        /// Update a row in table IMAGE
        /// </summary>
        /// <param name="entity">Entity</param>
        public override void Update(RealEstateDataContext.IMAGE entity)
        {
            RealEstateDataContext.IMAGE oldEntity = _db.IMAGEs.Single(record => record.ID == entity.ID);
            oldEntity.Name = entity.Name;
            oldEntity.Path = entity.Path;
            oldEntity.Description = entity.Description;
            _db.SubmitChanges();
        }

        /// <summary>
        /// Delete a row in table IMAGE
        /// </summary>
        /// <param name="ID">ID of row</param>
        public override void Delete(int ID)
        {
            var entity = from record in _db.IMAGEs
                         where record.ID.Equals(ID)
                         select record;
            _db.IMAGEs.DeleteAllOnSubmit(entity);
            _db.SubmitChanges();
        }

        /// <summary>
        /// Get a row from table IMAGE
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        public override RealEstateDataContext.IMAGE GetARecord(int ID)
        {
            var entity = from record in _db.IMAGEs
                         where record.ID.Equals(ID)
                         select record;
            return entity.Single();
        }
    }
}
