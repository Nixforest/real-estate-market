﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateDataAccessObject
{
    /// <summary>
    /// Class access to UNIT table in database
    /// </summary>
    public class UnitDAO : DataParent<RealEstateDataContext.UNIT>
    {
        /// <summary>
        /// Create a new ID for new entity in table
        /// </summary>
        /// <returns>ID just create.</returns>
        public override int CreateID()
        {
            int numberRecord;
            int value;
            numberRecord = _db.UNITs.Count();
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
        /// Get all rows in table UNIT
        /// </summary>
        /// <returns>List of entity</returns>
        public override ICollection<RealEstateDataContext.UNIT> GetAllRows()
        {
            return _db.UNITs.ToList();
        }

        /// <summary>
        /// Insert a row into table UNIT
        /// </summary>
        /// <param name="entity">Entity</param>
        public override void Insert(RealEstateDataContext.UNIT entity)
        {
            _db.UNITs.InsertOnSubmit(entity);
            _db.SubmitChanges();
        }

        /// <summary>
        /// Update a row in table UNIT
        /// </summary>
        /// <param name="entity">Entity</param>
        public override void Update(RealEstateDataContext.UNIT entity)
        {
            RealEstateDataContext.UNIT oldEntity = _db.UNITs.Single(record => record.ID == entity.ID);
            oldEntity.Name = entity.Name;
            oldEntity.Description = entity.Description;

            _db.SubmitChanges();
        }

        /// <summary>
        /// Delete a row in table UNIT
        /// </summary>
        /// <param name="ID">ID of row</param>
        public override void Delete(int ID)
        {
            var entity = from record in _db.UNITs
                         where record.ID.Equals(ID)
                         select record;
            _db.UNITs.DeleteAllOnSubmit(entity);
            _db.SubmitChanges();
        }

        /// <summary>
        /// Get a row from table UNIT
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        public override RealEstateDataContext.UNIT GetARecord(int ID)
        {
            var entity = from record in _db.UNITs
                         where record.ID.Equals(ID)
                         select record;
            return entity.Single();
        }
    }
}
