using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RealEstateDataAccessObject
{
    /// <summary>
    /// Class access to PARAMETER table in database
    /// </summary>
    public class ParameterDAO : DataParent<RealEstateDataContext.PARAMETER>
    {
        /// <summary>
        /// Get all rows in table PARAMETER
        /// </summary>
        /// <returns>List of entity</returns>
        public override ICollection<RealEstateDataContext.PARAMETER> GetAllRows()
        {
            return _db.PARAMETERs.ToList();
        }

        /// <summary>
        /// Insert a row into table PARAMETER
        /// </summary>
        /// <param name="entity">Entity</param>
        public override void Insert(RealEstateDataContext.PARAMETER entity)
        {
            _db.PARAMETERs.InsertOnSubmit(entity);
            _db.SubmitChanges();
        }

        /// <summary>
        /// Update a row in table PARAMETER
        /// </summary>
        /// <param name="entity">Entity</param>
        public override void Update(RealEstateDataContext.PARAMETER entity)
        {
            RealEstateDataContext.PARAMETER oldEntity = _db.PARAMETERs.Single(record => record.Key.Equals(entity.Key));
            oldEntity.Value = entity.Value;
            _db.SubmitChanges();
        }

        /// <summary>
        /// Get a row from table PARAMETER
        /// </summary>
        /// <param name="key">ID of row</param>
        /// <returns>Entity</returns>
        public RealEstateDataContext.PARAMETER GetARecord(string key)
        {
            var entity = from record in _db.PARAMETERs
                         where record.Key.Equals(key)
                         select record;
            return entity.Single();
        }
    }
}
