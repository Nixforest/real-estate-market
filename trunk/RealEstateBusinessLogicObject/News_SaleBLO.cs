using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace RealEstateBusinessLogicObject
{
    public class News_SaleBLO : BusinessParent<RealEstateDataContext.NEWS_SALE>
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public News_SaleBLO()
        {
            _db = new RealEstateDataAccessObject.News_SaleDAO();
        }

        /// <summary>
        /// Get all row in table NEWS_SALE
        /// </summary>
        /// <returns>List of entities</returns>
        public override ICollection<RealEstateDataContext.NEWS_SALE> GetAllRows()
        {
            return new ObservableCollection<RealEstateDataContext.NEWS_SALE>(_db.GetAllRows());
        }

        /// <summary>
        /// Insert a row into NEWS_SALE table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row has just inserted</returns>
        public override int Insert(RealEstateDataContext.NEWS_SALE entity)
        {
            entity.ID = _db.CreateID();
            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Insert a row into NEWS_SALE table
        /// </summary>
        /// <param name="typeID">ID of type</param>
        /// <param name="title">News sale's title</param>
        /// <param name="content">News sale's content</param>
        /// <param name="realEstateID">Id of real estate</param>
        /// <param name="rate">News sale's rate</param>
        /// <param name="updateTime">News sale's update time</param>
        /// <returns>ID of row has just inserted</returns>
        public int Insert(int typeID, string title, string content,
            int realEstateID, int? rate, DateTime updateTime)
        {
            RealEstateDataContext.NEWS_SALE entity = new RealEstateDataContext.NEWS_SALE();
            entity.ID = _db.CreateID();
            entity.TypeID = typeID;
            entity.Title = title;
            entity.Content = content;
            entity.RealEstateID = realEstateID;
            entity.Rate = rate;
            entity.UpdateTime = updateTime;

            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Update a row in NEWS_SALE table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row has just updated</returns>
        public override int Update(RealEstateDataContext.NEWS_SALE entity)
        {
            _db.Update(entity);
            return entity.ID;
        }

        /// <summary>
        /// Update a row in NEWS_SALE table
        /// </summary>
        /// <param name="id">ID of row</param>
        /// <param name="typeID">ID of type</param>
        /// <param name="title">News sale's title</param>
        /// <param name="content">News sale's content</param>
        /// <param name="realEstateID">Id of real estate</param>
        /// <param name="rate">News sale's rate</param>
        /// <param name="updateTime">News sale's update time</param>
        /// <returns>ID of row has just updated</returns>
        public int Update(int id, int typeID, string title, string content,
            int realEstateID, int? rate, DateTime updateTime)
        {
            RealEstateDataContext.NEWS_SALE entity = new RealEstateDataContext.NEWS_SALE();
            entity.ID = _db.CreateID();
            entity.TypeID = typeID;
            entity.Title = title;
            entity.Content = content;
            entity.RealEstateID = realEstateID;
            entity.Rate = rate;
            entity.UpdateTime = updateTime;

            _db.Update(entity);
            return entity.ID;
        }

        /// <summary>
        /// Delete a row from NEWS_SALE table
        /// </summary>
        /// <param name="ID">ID of row want to delete</param>
        /// <returns>ID of row has just deleted</returns>
        public override void Delete(int ID)
        {
            _db.Delete(ID);
        }

        /// <summary>
        /// Get a row in NEWS_SALE table
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        public override RealEstateDataContext.NEWS_SALE GetARecord(int ID)
        {
            return _db.GetARecord(ID);
        }
    }
}
