using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RealEstateBusinessLogicObject
{
    [DataObject(true)]
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
        /// Get some row in table NEWS
        /// </summary>
        /// <param name="from">From record</param>
        /// <param name="numrow">Number of Row</param>
        /// <returns>List of entities</returns>
        public override ICollection<RealEstateDataContext.NEW> GetRows(int from, int numrow)
        {
            return new ObservableCollection<RealEstateDataContext.NEW>(_db.GetRows(from, numrow));
        }

        /// <summary>
        /// Get some row in table NEWS
        /// </summary>
        /// <param name="from">From record</param>
        /// <param name="numrow">Number of Row</param>
        /// <param name="check">Check</param>
        /// <returns>List of entities</returns>
        public override ICollection<RealEstateDataContext.NEW> GetRows(int from, int numrow, bool check)
        {
            return new ObservableCollection<RealEstateDataContext.NEW>(_db.GetRows(from, numrow, check));
        }

        /// <summary>
        /// Insert a row into NEWS table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row has just inserted</returns>
        /// <exception cref="News_TypeIDException"></exception>
        /// <exception cref="Rate_LimitationException: Rate value must between MinRate and MaxRate""></exception>
        /// <exception cref="ImageIDException"></exception>
        public override int Insert(RealEstateDataContext.NEW entity)
        {
            if (new RealEstateDataAccessObject.News_TypeDAO().ValidationID(entity.TypeID))
            {
                if (entity.Rate == null ||
                    (entity.Rate >= new RealEstateDataAccessObject.ParameterDAO().GetARecord("MinRate").Value &&
                     entity.Rate <= new RealEstateDataAccessObject.ParameterDAO().GetARecord("MaxRate").Value))
                {
                    if (new RealEstateDataAccessObject.ImageDAO().ValidationID(entity.ImageID))
                    {
                        entity.ID = this.CreateNewID();
                        entity.View = 0;
                        _db.Insert(entity);
                        return entity.ID;
                    }
                    else throw new RealEstateDataContext.Utility.ImageIDException();
                }
                else throw new RealEstateDataContext.Utility.Rate_LimitationException();
            }
            else throw new RealEstateDataContext.Utility.News_TypeIDException();
        }

        /// <summary>
        /// Insert a row into NEWS table
        /// </summary>
        /// <param name="typeID">ID of News type</param>
        /// <param name="title">News's title</param>
        /// <param name="descript">News's Description</param>
        /// <param name="content">News's content</param>
        /// <param name="author">News's author</param>
        /// <param name="rate">News's rate</param>
        /// <param name="publishTime">News's publish time</param>
        /// <param name="editTime">News's edit time</param>
        /// <param name="imageID">ID of image</param>
        /// <param name="check"></param>
        /// <returns>ID of row has just inserted</returns>
        /// <exception cref="News_TypeIDException"></exception>
        /// <exception cref="Rate_LimitationException: Rate value must between MinRate and MaxRate""></exception>
        /// <exception cref="ImageIDException"></exception>
        public int Insert(int typeID, string title, string descript, string content,
            string author, int? rate, DateTime publishTime, DateTime editTime,
            int imageID, bool check)
        {
            if (new RealEstateDataAccessObject.News_TypeDAO().ValidationID(typeID))
            {
                if (rate == null ||
                    (rate >= new RealEstateDataAccessObject.ParameterDAO().GetARecord("MinRate").Value &&
                        rate <= new RealEstateDataAccessObject.ParameterDAO().GetARecord("MaxRate").Value))
                {
                    if (new RealEstateDataAccessObject.ImageDAO().ValidationID(imageID))
                    {
                        RealEstateDataContext.NEW entity = new RealEstateDataContext.NEW();

                        entity.ID          = this.CreateNewID();
                        entity.TypeID      = typeID;
                        entity.Title       = title;
                        entity.Descript    = descript;
                        entity.Content     = content;
                        entity.Author      = author;
                        entity.Rate        = rate;
                        entity.PublishTime = publishTime;
                        entity.EditTime    = editTime;
                        entity.ImageID     = imageID;
                        entity.Check       = check;
                        entity.View        = 0;

                        _db.Insert(entity);
                        return entity.ID;
                    }
                    else throw new RealEstateDataContext.Utility.ImageIDException();
                }
                else throw new RealEstateDataContext.Utility.Rate_LimitationException();
            }
            else throw new RealEstateDataContext.Utility.News_TypeIDException();
        }

        /// <summary>
        /// Update a row in NEWS table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row has just updated</returns>
        /// <exception cref="NewsIDException"></exception>
        /// <exception cref="News_TypeIDException"></exception>
        /// <exception cref="Rate_LimitationException: Rate value must between MinRate and MaxRate""></exception>
        /// <exception cref="ImageIDException"></exception>
        public override int Update(RealEstateDataContext.NEW entity)
        {
            if (ValidationID(entity.ID))
            {
                if (new RealEstateDataAccessObject.News_TypeDAO().ValidationID(entity.TypeID))
                {
                    if (entity.Rate == null ||
                        (entity.Rate >= new RealEstateDataAccessObject.ParameterDAO().GetARecord("MinRate").Value &&
                         entity.Rate <= new RealEstateDataAccessObject.ParameterDAO().GetARecord("MaxRate").Value))
                    {
                        if (new RealEstateDataAccessObject.ImageDAO().ValidationID(entity.ImageID))
                        {
                            _db.Update(entity);
                            return entity.ID;
                        }
                        else throw new RealEstateDataContext.Utility.ImageIDException();
                    }
                    else throw new RealEstateDataContext.Utility.Rate_LimitationException();
                }
                else throw new RealEstateDataContext.Utility.News_TypeIDException();
            }
            else throw new RealEstateDataContext.Utility.NewsIDException();
        }

        /// <summary>
        /// Update a row in NEWS table
        /// </summary>
        /// <param name="id">ID of row</param>
        /// <param name="typeID">ID of News type</param>
        /// <param name="title">News's title</param>
        /// <param name="descript">News's Description</param>
        /// <param name="content">News's content</param>
        /// <param name="author">News's author</param>
        /// <param name="rate">News's rate</param>
        /// <param name="publishTime">News's publish time</param>
        /// <param name="editTime">News's edit time</param>
        /// <param name="imageID">ID of image</param>
        /// <param name="check"></param>
        /// <param name="view">Number of view</param>
        /// <returns>ID of row has just updated</returns>
        /// <exception cref="NewsIDException"></exception>
        /// <exception cref="News_TypeIDException"></exception>
        /// <exception cref="Rate_LimitationException: Rate value must between MinRate and MaxRate""></exception>
        /// <exception cref="ImageIDException"></exception>
        public int Update(int id, int typeID, string title, string descript, 
            string content, string author, int? rate, DateTime publishTime,
            DateTime editTime, int imageID, bool check, int? view)
        {
            if (ValidationID(id))
            {
                if (new RealEstateDataAccessObject.News_TypeDAO().ValidationID(typeID))
                {
                    if (rate == null ||
                        (rate >= new RealEstateDataAccessObject.ParameterDAO().GetARecord("MinRate").Value &&
                            rate <= new RealEstateDataAccessObject.ParameterDAO().GetARecord("MaxRate").Value))
                    {
                        if (new RealEstateDataAccessObject.ImageDAO().ValidationID(imageID))
                        {
                            RealEstateDataContext.NEW entity = new RealEstateDataContext.NEW();
                            entity.ID          = id;
                            entity.TypeID      = typeID;
                            entity.Title       = title;
                            entity.Descript    = descript;
                            entity.Content     = content;
                            entity.Author      = author;
                            entity.Rate        = rate;
                            entity.PublishTime = publishTime;
                            entity.EditTime    = editTime;
                            entity.ImageID     = imageID;
                            entity.Check       = check;
                            entity.View        = view;

                            _db.Update(entity);
                            return entity.ID;
                        }
                        else throw new RealEstateDataContext.Utility.ImageIDException();
                    }
                    else throw new RealEstateDataContext.Utility.Rate_LimitationException();
                }
                else throw new RealEstateDataContext.Utility.News_TypeIDException();
            }
            else throw new RealEstateDataContext.Utility.NewsIDException();
        }

        /// <summary>
        /// Delete a row from NEWS table
        /// </summary>
        /// <param name="ID">ID of row want to delete</param>
        /// <returns>ID of row has just deleted</returns>
        /// <exception cref="NewsIDException"></exception>
        public override void Delete(int ID)
        {
            if (ValidationID(ID))
            {
                _db.Delete(ID);
            }
            else throw new RealEstateDataContext.Utility.NewsIDException();
        }

        /// <summary>
        /// Get a row in NEWS table
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        /// <exception cref="NewsIDException"></exception>
        public override RealEstateDataContext.NEW GetARecord(int ID)
        {
            if (ValidationID(ID))
            {
                return _db.GetARecord(ID);
            }
            else throw new RealEstateDataContext.Utility.NewsIDException();
        }

        /// <summary>
        /// Get a Summary from News
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string GetSummary(int ID)
        {
            if (ValidationID(ID))
            {
                return _db.GetARecord(ID).Content.Substring(0, Parameter.MaxSummaryLength);
            }
            else throw new RealEstateDataContext.Utility.NationIDException();
        }

        /// <summary>
        /// Get News by Type ID
        /// </summary>
        /// <param name="ID">Type ID</param>
        /// <returns>List News</returns>
        public ICollection<RealEstateDataContext.NEW> GetNewsByTypeID(int typeID)
        {
            return new ObservableCollection<RealEstateDataContext.NEW>(new RealEstateDataAccessObject.News_TypeDAO().GetARecord(typeID).NEWs);
        }

        /// <summary>
        /// Get News by Type ID
        /// </summary>
        /// <param name="from">From record</param>
        /// <param name="numrow">Number of record</param>
        /// <param name="typeID">ID of NewsType</param>
        /// <returns>List News</returns>
        public ICollection<RealEstateDataContext.NEW> GetNewsByTypeID(int from, int numrow, int typeID)
        {
            var entities = from record in new RealEstateDataAccessObject.News_TypeDAO().GetARecord(typeID).NEWs
                         orderby record.ID descending
                         select record;
            return entities.Skip(from).Take(numrow).ToList();
        }

        /// <summary>
        /// Get News by Type ID
        /// </summary>
        /// <param name="from">From record</param>
        /// <param name="numrow">Number of record</param>
        /// <param name="check">Check value</param>
        /// <param name="typeID">ID of NewsType</param>
        /// <returns>List News</returns>
        public ICollection<RealEstateDataContext.NEW> GetNewsByTypeID(int from, int numrow, bool check, int typeID)
        {
            var entities = from record in new RealEstateDataAccessObject.News_TypeDAO().GetARecord(typeID).NEWs
                       where record.Check.Equals(check)
                       orderby record.ID descending
                       select record;
            return entities.Skip(from).Take(numrow).ToList();
        }

        /// <summary>
        /// Get rows in table NEWS are popular News
        /// </summary>
        /// <param name="numrow">Number of record</param>
        /// <returns>List News</returns>
        public ICollection<RealEstateDataContext.NEW> GetNewsTopView(int numrow)
        {
            var entities = from record in _db.GetAllRows()
                           orderby record.View descending
                           select record;
            return entities.Skip(0).Take(numrow).ToList();
        }

        /// <summary>
        /// Get top popular news
        /// </summary>
        /// <param name="number">Number of record</param>
        /// <returns>List of news</returns>
        public ICollection<RealEstateDataContext.NEW> GetNewsTopPopular(int number)
        {
            var entities = from record in _db.GetAllRows()
                           where record.EditTime < DateTime.Now && 
                                 record.EditTime > DateTime.Now.AddDays(0 - new RealEstateDataAccessObject.ParameterDAO().GetARecord("Popular").Value)
                           orderby record.View descending
                           select record;
            return entities.Skip(0).Take(number).ToList();
        }

        /// <summary>
        /// Get more news
        /// </summary>
        /// <param name="oldID">ID of viewing news</param>
        /// <param name="from">From Record</param>
        /// <param name="number">Number of record</param>
        /// <param name="typeID">ID of NewsType</param>
        /// <returns>List of News</returns>
        public ICollection<RealEstateDataContext.NEW> GetMoreNews(int? oldID, int from, int number, int? typeID)
        {
            if (oldID != null)
            {
                if (typeID == null)
                {
                    var entity = from record in _db.GetAllRows()
                                 where record.ID < oldID
                                 orderby record.ID descending
                                 select record;
                    return entity.Skip(from).Take(number).ToList();
                }
                else
                {
                    var entity = from record in _db.GetAllRows()
                                 where record.ID < oldID &&
                                    record.TypeID.Equals(typeID)
                                 orderby record.ID descending
                                 select record;
                    return entity.Skip(from).Take(number).ToList();
                }
            }
            else
            {
                if (typeID == null)
                {
                    var entity = from record in _db.GetAllRows()
                                 orderby record.ID descending
                                 select record;
                    return entity.Skip(from).Take(number).ToList();
                }
                else
                {
                    var entity = from record in _db.GetAllRows()
                                 where record.TypeID.Equals(typeID)
                                 orderby record.ID descending
                                 select record;
                    return entity.Skip(from).Take(number).ToList();
                }
            }
        }

        /// <summary>
        /// Increate view in a news
        /// </summary>
        /// <param name="id">Id of entity</param>
        public void IncreaseView(int id)
        {
            RealEstateDataContext.NEW entity = _db.GetARecord(id);
            entity.View++;
            _db.Update(entity);
        }

        /// <summary>
        /// Update check
        /// </summary>
        /// <param name="id">Id of entity</param>
        /// <param name="check"></param>
        public void UpdateCheck(int id, bool check)
        {
            RealEstateDataContext.NEW entity = _db.GetARecord(id);
            entity.Check = check;
            _db.Update(entity);
        }

        /// <summary>
        /// Searching in News table
        /// </summary>
        /// <param name="keyword">Keyword to find</param>
        /// <returns>List of News</returns>
        public ICollection<RealEstateDataContext.NEW> SearchNews(String keyword)
        {
            string key = RealEstateDataContext.Utility.Utils.ConvertToUnSign(keyword.ToString()).ToLower();
            return _db.GetAllRows().ToList().FindAll(
                delegate(RealEstateDataContext.NEW entity)
                {
                    if (RealEstateDataContext.Utility.Utils.ConvertToUnSign(entity.Content.ToLower()).Contains(key))
                    {
                        return true;
                    }
                    else return false;
                }
            );
        }
    }
}
