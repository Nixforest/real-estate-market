﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RealEstateBusinessLogicObject
{
    [DataObject(true)]
    public class CityBLO : BusinessParent<RealEstateDataContext.CITY>
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public CityBLO()
        {
            _db = new RealEstateDataAccessObject.CityDAO();
        }

        /// <summary>
        /// Get all row in table CITY
        /// </summary>
        /// <returns>List of entities</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public override ICollection<RealEstateDataContext.CITY> GetAllRows()
        {
            return new ObservableCollection<RealEstateDataContext.CITY>(_db.GetAllRows());
        }

        /// <summary>
        /// Insert a row into CITY table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row just insert</returns>
        /// <exception cref="NationIDException: ID not exist in NATION table"></exception>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public override int Insert(RealEstateDataContext.CITY entity)
        {
            if (new RealEstateDataAccessObject.NationDAO().ValidationID(entity.NationID))
            {
                entity.ID = this.CreateNewID();
                _db.Insert(entity);
                return entity.ID;
            }
            else throw new RealEstateDataContext.Utility.NationIDException();
        }

        /// <summary>
        /// Insert a row into CITY table
        /// </summary>
        /// <param name="name">Name of city</param>
        /// <param name="nationID">ID of Nation</param>
        /// <returns>ID of row just insert</returns>
        /// <exception cref="NationIDException: ID not exist in NATION table"></exception>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int Insert(string name, int nationID)
        {
            if (new RealEstateDataAccessObject.NationDAO().ValidationID(nationID))
            {
                RealEstateDataContext.CITY entity = new RealEstateDataContext.CITY();
                entity.ID       = this.CreateNewID();
                entity.Name     = name;
                entity.NationID = nationID;

                _db.Insert(entity);
                return entity.ID;
            }
            else throw new RealEstateDataContext.Utility.NationIDException();
        }

        /// <summary>
        /// Update a row in NATION table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row just update</returns>
        /// <exception cref="CityIDException: ID not exist in CITY table"></exception>
        /// <exception cref="NationIDException: ID not exist in NATION table"></exception>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public override int Update(RealEstateDataContext.CITY entity)
        {
            if (ValidationID(entity.ID))
            {
                if (new RealEstateDataAccessObject.NationDAO().ValidationID(entity.NationID))
                {
                    _db.Update(entity);
                    return entity.ID;
                }
                else throw new RealEstateDataContext.Utility.NationIDException();
            }
            else throw new RealEstateDataContext.Utility.CityIDException();
        }

        /// <summary>
        /// Update a row in NATION table
        /// </summary>
        /// <param name="id">ID of row</param>
        /// <param name="name">Name of city</param>
        /// <param name="nationID">ID of Nation</param>
        /// <returns>ID of row just update</returns>
        /// <exception cref="CityIDException: ID not exist in CITY table"></exception>
        /// <exception cref="NationIDException: ID not exist in NATION table"></exception>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public int Update(int id, string name, int nationID)
        {
            if (ValidationID(id))
            {
                if (new RealEstateDataAccessObject.NationDAO().ValidationID(nationID))
                {
                    RealEstateDataContext.CITY entity = new RealEstateDataContext.CITY();
                    entity.ID       = id;
                    entity.Name     = name;
                    entity.NationID = nationID;

                    _db.Update(entity);
                    return entity.ID;
                }
                else throw new RealEstateDataContext.Utility.NationIDException();
            }
            else throw new RealEstateDataContext.Utility.CityIDException();
        }

        /// <summary>
        /// Delete a row from CITY table
        /// </summary>
        /// <param name="ID">ID of row want to delete</param>
        /// <returns>ID of row just delete</returns>
        /// <exception cref="CityIDException: ID not exist in CITY table"></exception>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public override void Delete(int ID)
        {
            if (ValidationID(ID))
            {
                _db.Delete(ID);
            }
            else throw new RealEstateDataContext.Utility.CityIDException();
        }

        /// <summary>
        /// Get a row in CITY table
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        /// <exception cref="CityIDException: ID not exist in CITY table"></exception>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public override RealEstateDataContext.CITY GetARecord(int ID)
        {
            if (ValidationID(ID))
            {
                return _db.GetARecord(ID);
            }
            else throw new RealEstateDataContext.Utility.CityIDException();
        }

        /// <summary>
        /// Get Districts in a City
        /// </summary>
        /// <param name="ID">City's ID</param>
        /// <returns>List of Districts</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public ICollection<RealEstateDataContext.DISTRICT> GetDistrictsByCityID(int ID)
        {
            if (_db.ValidationID(ID))
            {
                return new ObservableCollection<RealEstateDataContext.DISTRICT>(_db.GetARecord(ID).DISTRICTs);
            }
            else return new ObservableCollection<RealEstateDataContext.DISTRICT>();
        }
    }
}
