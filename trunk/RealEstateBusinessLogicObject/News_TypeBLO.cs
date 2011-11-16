﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RealEstateBusinessLogicObject
{
    [DataObject(true)]
    public class News_TypeBLO: BusinessParent<RealEstateDataContext.NEWS_TYPE>
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public News_TypeBLO()
        {
            _db = new RealEstateDataAccessObject.News_TypeDAO();
        }

        /// <summary>
        /// Get all row in table NEWS_TYPE
        /// </summary>
        /// <returns>List of entities</returns>
        public override ICollection<RealEstateDataContext.NEWS_TYPE> GetAllRows()
        {
            return base.GetAllRows();
        }

        /// <summary>
        /// Insert a row into NEWS_TYPE table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row has just inserted</returns>
        public override int Insert(RealEstateDataContext.NEWS_TYPE entity)
        {
            entity.ID = _db.CreateID();
            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Insert a row into NEWS_TYPE table
        /// </summary>
        /// <param name="name">News type's name</param>
        /// <param name="description">News type's description</param>
        /// <returns>ID of row has just inserted</returns>
        public int Insert(string name, string description)
        {
            RealEstateDataContext.NEWS_TYPE entity = new RealEstateDataContext.NEWS_TYPE();
            entity.ID = _db.CreateID();
            entity.Name = name;
            entity.Description = description;

            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Update a row in NEWS_TYPE table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row has just updated</returns>
        /// <exception cref="News_TypeIDException"></exception>
        public override int Update(RealEstateDataContext.NEWS_TYPE entity)
        {
            if (ValidationID(entity.ID))
            {
                _db.Update(entity);
                return entity.ID;
            }
            else throw new RealEstateDataContext.Utility.News_TypeIDException();
        }

        /// <summary>
        /// Update a row in NEWS_TYPE table
        /// </summary>
        /// <param name="id">ID of row</param>
        /// <param name="name">News type's name</param>
        /// <param name="description">News type's </param>
        /// <returns>ID of row has just updated</returns>
        /// <exception cref="News_TypeIDException"></exception>
        public int Update(int id, string name, string description)
        {
            if (ValidationID(id))
            {
                RealEstateDataContext.NEWS_TYPE entity = new RealEstateDataContext.NEWS_TYPE();
                entity.ID = id;
                entity.Name = name;
                entity.Description = description;

                _db.Update(entity);
                return entity.ID;
            }
            else throw new RealEstateDataContext.Utility.News_TypeIDException();
        }

        /// <summary>
        /// Delete a row from NEWS_TYPE table
        /// </summary>
        /// <param name="ID">ID of row want to delete</param>
        /// <returns>ID of row has just deleted</returns>
        /// <exception cref="News_TypeIDException"></exception>
        public override void Delete(int ID)
        {
            if (ValidationID(ID))
            {
                _db.Delete(ID);
            }
            else throw new RealEstateDataContext.Utility.News_TypeIDException();
        }

        /// <summary>
        /// Get a row in NEWS_TYPE table
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        /// <exception cref="News_TypeIDException"></exception>
        public override RealEstateDataContext.NEWS_TYPE GetARecord(int ID)
        {
            if (ValidationID(ID))
            {
                return _db.GetARecord(ID);
            }
            else throw new RealEstateDataContext.Utility.News_TypeIDException();
        }
    }
}
