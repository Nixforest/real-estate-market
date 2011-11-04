using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace RealEstateBusinessLogicObject
{
    public class NewsBLO : BusinessParent<RealEstateDataContext.NEW>
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public NewsBLO()
        {
            _db = new RealEstateDataAccessObject.NewsDAO();
        }

        /// <summary>
        /// Get all row in table NEWS
        /// </summary>
        /// <returns>List of entities</returns>
        public override ICollection<RealEstateDataContext.NEW> GetAllRows()
        {
            return new ObservableCollection<RealEstateDataContext.NEW>(_db.GetAllRows());
        }

        /// <summary>
        /// Insert a row into NEWS table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row has just inserted</returns>
        public override int Insert(RealEstateDataContext.NEW entity)
        {
            entity.ID = _db.CreateID();
            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Insert a row into NEWS table
        /// </summary>
        /// <param name="typeID">ID of News type</param>
        /// <param name="title">News's title</param>
        /// <param name="content">News's content</param>
        /// <param name="author">News's author</param>
        /// <param name="rate">News's rate</param>
        /// <param name="publishTime">News's publish time</param>
        /// <param name="imageID">ID of image</param>
        /// <returns>ID of row has just inserted</returns>
        public int Insert(int typeID, string title, string content,
            string author, int? rate, DateTime publishTime, int imageID)
        {
            RealEstateDataContext.NEW entity = new RealEstateDataContext.NEW();

            entity.ID = _db.CreateID();
            entity.TypeID = typeID;
            entity.Title = title;
            entity.Content = content;
            entity.Author = author;
            entity.Rate = rate;
            entity.PublishTime = publishTime;
            entity.ImageID = imageID;

            _db.Insert(entity);
            return entity.ImageID;
        }

        /// <summary>
        /// Update a row in NEWS table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row has just updated</returns>
        public override int Update(RealEstateDataContext.NEW entity)
        {
            _db.Update(entity);
            return entity.ID;
        }

        /// <summary>
        /// Update a row in NEWS table
        /// </summary>
        /// <param name="id">ID of row</param>
        /// <param name="typeID">ID of News type</param>
        /// <param name="title">News's title</param>
        /// <param name="content">News's content</param>
        /// <param name="author">News's author</param>
        /// <param name="rate">News's rate</param>
        /// <param name="publishTime">News's publish time</param>
        /// <param name="imageID">ID of image</param>
        /// <returns>ID of row has just updated</returns>
        public int Update(int id, int typeID, string title, string content,
            string author, int? rate, DateTime publishTime, int imageID)
        {
            RealEstateDataContext.NEW entity = new RealEstateDataContext.NEW();

            entity.ID = id;
            entity.TypeID = typeID;
            entity.Title = title;
            entity.Content = content;
            entity.Author = author;
            entity.Rate = rate;
            entity.PublishTime = publishTime;
            entity.ImageID = imageID;

            _db.Update(entity);
            return entity.ID;
        }

        /// <summary>
        /// Delete a row from NEWS table
        /// </summary>
        /// <param name="ID">ID of row want to delete</param>
        /// <returns>ID of row has just deleted</returns>
        public override void Delete(int ID)
        {
            _db.Delete(ID);
        }

        /// <summary>
        /// Get a row in NEWS table
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        public override RealEstateDataContext.NEW GetARecord(int ID)
        {
            return _db.GetARecord(ID);
        }
    }
}
