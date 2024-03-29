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
        /// Get Max ID
        /// </summary>
        /// <returns>Max ID</returns>
        public override int GetMaxID()
        {
            return _db.UNITs.Max(entity => entity.ID);
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
            oldEntity.Name        = entity.Name;
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

        /// <summary>
        /// Check an ID exist in table or not
        /// </summary>
        /// <param name="ID">ID need to check</param>
        /// <returns>True if ID has exist, false otherwise</returns>
        public override bool ValidationID(int ID)
        {
            if (_db.UNITs.Count() > 0)
            {
                foreach (RealEstateDataContext.UNIT entity in _db.UNITs)
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
