﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateDataAccessObject
{
    /// <summary>
    /// Class access to PROJECT_TYPE table in database
    /// </summary>
    public class Project_TypeDAO : DataParent<RealEstateDataContext.PROJECT_TYPE>
    {
        /// <summary>
        /// Get Max ID
        /// </summary>
        /// <returns>Max ID</returns>
        public override int GetMaxID()
        {
            return _db.PROJECT_TYPEs.Max(entity => entity.ID);
        }

        /// <summary>
        /// Get all rows in table PROJECT_TYPE
        /// </summary>
        /// <returns>List of entity</returns>
        public override ICollection<RealEstateDataContext.PROJECT_TYPE> GetAllRows()
        {
            return _db.PROJECT_TYPEs.ToList();
        }

        /// <summary>
        /// Insert a row into table PROJECT_TYPE
        /// </summary>
        /// <param name="entity">Entity</param>
        public override void Insert(RealEstateDataContext.PROJECT_TYPE entity)
        {
            _db.PROJECT_TYPEs.InsertOnSubmit(entity);
            _db.SubmitChanges();
        }

        /// <summary>
        /// Update a row in table PROJECT_TYPE
        /// </summary>
        /// <param name="entity">Entity</param>
        public override void Update(RealEstateDataContext.PROJECT_TYPE entity)
        {
            RealEstateDataContext.PROJECT_TYPE oldEntity = _db.PROJECT_TYPEs.Single(record => record.ID == entity.ID);
            oldEntity.Name        = entity.Name;
            oldEntity.Description = entity.Description;

            _db.SubmitChanges();
        }

        /// <summary>
        /// Delete a row in table PROJECT_TYPE
        /// </summary>
        /// <param name="ID">ID of row</param>
        public override void Delete(int ID)
        {
            var entity = from record in _db.PROJECT_TYPEs
                         where record.ID.Equals(ID)
                         select record;
            _db.PROJECT_TYPEs.DeleteAllOnSubmit(entity);
            _db.SubmitChanges();
        }

        /// <summary>
        /// Get a row from table PROJECT_TYPE
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        public override RealEstateDataContext.PROJECT_TYPE GetARecord(int ID)
        {
            var entity = from record in _db.PROJECT_TYPEs
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
            if (_db.PROJECT_TYPEs.Count() > 0)
            {
                foreach (RealEstateDataContext.PROJECT_TYPE entity in _db.PROJECT_TYPEs)
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
