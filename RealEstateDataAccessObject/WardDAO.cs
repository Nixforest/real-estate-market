﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateDataAccessObject
{
    /// <summary>
    /// Class access to WARD table in database
    /// </summary>
    public class WardDAO: DataParent<RealEstateDataContext.WARD>
    {
        /// <summary>
        /// Create a new ID for new entity in table
        /// </summary>
        /// <returns>ID just create.</returns>
        public override int CreateID()
        {
            int numberRecord;
            int value;
            numberRecord = _db.WARDs.Count();
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
        /// Get all rows in table WARD
        /// </summary>
        /// <returns>List of entity</returns>
        public override ICollection<RealEstateDataContext.WARD> GetAllRows()
        {
            return _db.WARDs.ToList();
        }

        /// <summary>
        /// Insert a row into table WARD
        /// </summary>
        /// <param name="entity">Entity</param>
        public override void Insert(RealEstateDataContext.WARD entity)
        {
            _db.WARDs.InsertOnSubmit(entity);
            _db.SubmitChanges();
        }

        /// <summary>
        /// Update a row in table WARD
        /// </summary>
        /// <param name="entity">Entity</param>
        public override void Update(RealEstateDataContext.WARD entity)
        {
            RealEstateDataContext.WARD oldEntity = _db.WARDs.Single(record => record.ID == entity.ID);
            oldEntity.Name = entity.Name;
            oldEntity.DistrictID = entity.DistrictID;
            _db.SubmitChanges();
        }

        /// <summary>
        /// Delete a row in table WARD
        /// </summary>
        /// <param name="ID">ID of row</param>
        public override void Delete(int ID)
        {
            var entity = from record in _db.WARDs
                         where record.ID.Equals(ID)
                         select record;
            _db.WARDs.DeleteAllOnSubmit(entity);
            _db.SubmitChanges();
        }

        /// <summary>
        /// Get a row from table WARD
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        public override RealEstateDataContext.WARD GetARecord(int ID)
        {
            var entity = from record in _db.WARDs
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
            if (_db.WARDs.Count() > 0)
            {
                foreach (RealEstateDataContext.WARD entity in _db.WARDs)
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
