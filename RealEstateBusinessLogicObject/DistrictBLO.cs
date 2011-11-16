using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RealEstateBusinessLogicObject
{
    [DataObject(true)]
    public class DistrictBLO : BusinessParent<RealEstateDataContext.DISTRICT>
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public DistrictBLO()
        {
            _db = new RealEstateDataAccessObject.DistrictDAO();
        }

        /// <summary>
        /// Get all row in table DISTRICT
        /// </summary>
        /// <returns>List of entities</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public override ICollection<RealEstateDataContext.DISTRICT> GetAllRows()
        {
            return new ObservableCollection<RealEstateDataContext.DISTRICT>(_db.GetAllRows());
        }

        /// <summary>
        /// Insert a row into DISTRICT table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row have just inserted</returns>
        /// <exception cref="CityIDException"></exception>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public override int Insert(RealEstateDataContext.DISTRICT entity)
        {
            if (new RealEstateDataAccessObject.CityDAO().ValidationID(entity.CityID))
            {
                entity.ID = this.CreateNewID();
                _db.Insert(entity);
                return entity.ID;
            }
            else throw new RealEstateDataContext.Utility.CityIDException();
        }

        /// <summary>
        /// Insert a row into DISTRICT table
        /// </summary>
        /// <param name="name">District's name</param>
        /// <param name="cityID">ID of city</param>
        /// <returns>ID of row have just inserted</returns>
        /// <exception cref="CityIDException"></exception>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int Insert(string name, int cityID)
        {
            if (new RealEstateDataAccessObject.CityDAO().ValidationID(cityID))
            {
                RealEstateDataContext.DISTRICT entity = new RealEstateDataContext.DISTRICT();
                entity.ID = this.CreateNewID();
                entity.Name = name;
                entity.CityID = cityID;

                _db.Insert(entity);
                return entity.ID;
            }
            else throw new RealEstateDataContext.Utility.CityIDException();
        }

        /// <summary>
        /// Update a row in DISTRICT table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row have just updated</returns>
        /// <exception cref="DistrictIDException"></exception>
        /// <exception cref="CityIDException"></exception>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public override int Update(RealEstateDataContext.DISTRICT entity)
        {
            if (ValidationID(entity.ID))
            {
                if (new RealEstateDataAccessObject.CityDAO().ValidationID(entity.CityID))
                {
                    _db.Update(entity);
                    return entity.ID;
                }
                else throw new RealEstateDataContext.Utility.CityIDException();
            }
            else throw new RealEstateDataContext.Utility.DistrictIDException();
        }

        /// <summary>
        /// Update a row in DISTRICT table
        /// </summary>
        /// <param name="id">ID of row</param>
        /// <param name="name">District's name</param>
        /// <param name="cityID">ID of city</param>
        /// <returns>ID of row have just updated</returns>
        /// <exception cref="DistrictIDException"></exception>
        /// <exception cref="CityIDException"></exception>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public int Update(int id, string name, int cityID)
        {
            if (ValidationID(id))
            {
                if (new RealEstateDataAccessObject.CityDAO().ValidationID(cityID))
                {
                    RealEstateDataContext.DISTRICT entity = new RealEstateDataContext.DISTRICT();
                    entity.ID = id;
                    entity.Name = name;
                    entity.CityID = cityID;

                    _db.Update(entity);
                    return entity.ID;
                }
                else throw new RealEstateDataContext.Utility.CityIDException();
            }
            else throw new RealEstateDataContext.Utility.DistrictIDException();
        }

        /// <summary>
        /// Delete a row from DISTRICT table
        /// </summary>
        /// <param name="ID">ID of row want to delete</param>
        /// <returns>ID of row have just deleted</returns>
        /// <exception cref="DistrictIDException"></exception>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public override void Delete(int ID)
        {
            if (ValidationID(ID))
            {
                _db.Delete(ID);
            }
            else throw new RealEstateDataContext.Utility.DistrictIDException();
        }

        /// <summary>
        /// Get a row in DISTRICT table
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        /// <exception cref="DistrictIDException"></exception>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public override RealEstateDataContext.DISTRICT GetARecord(int ID)
        {
            if (ValidationID(ID))
            {
                return _db.GetARecord(ID);
            }
            else throw new RealEstateDataContext.Utility.DistrictIDException();
        }
    }
}
