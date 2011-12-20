using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RealEstateBusinessLogicObject
{
    [DataObject(true)]
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
        [DataObjectMethod(DataObjectMethodType.Select)]
        public override ICollection<RealEstateDataContext.NEWS_SALE> GetAllRows()
        {
            return new ObservableCollection<RealEstateDataContext.NEWS_SALE>(_db.GetAllRows());
        }

        /// <summary>
        /// Insert a row into NEWS_SALE table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row has just inserted</returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public override int Insert(RealEstateDataContext.NEWS_SALE entity)
        {
            if (new RealEstateDataAccessObject.News_Sale_TypeDAO().ValidationID(entity.TypeID))
            {
                if (new RealEstateDataAccessObject.Real_EstateDAO().ValidationID(entity.RealEstateID))
                {
                    if (entity.Rate == null ||
                        (entity.Rate >= new RealEstateDataAccessObject.ParameterDAO().GetARecord("MinRate").Value &&
                            entity.Rate <= new RealEstateDataAccessObject.ParameterDAO().GetARecord("MaxRate").Value))
                    {
                        entity.ID = this.CreateNewID();
                        _db.Insert(entity);
                        return entity.ID;
                    }
                    else throw new RealEstateDataContext.Utility.Rate_LimitationException();
                }
                else throw new RealEstateDataContext.Utility.Real_EstateIDException();
            }
            else throw new RealEstateDataContext.Utility.News_Sale_TypeIDException();
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
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int Insert(int typeID, string title, string content,
            int realEstateID, int? rate, DateTime updateTime, int status, bool broker)
        {
            if (new RealEstateDataAccessObject.News_Sale_TypeDAO().ValidationID(typeID))
            {
                if (new RealEstateDataAccessObject.Real_EstateDAO().ValidationID(realEstateID))
                {
                    if (rate == null ||
                        (rate >= new RealEstateDataAccessObject.ParameterDAO().GetARecord("MinRate").Value &&
                            rate <= new RealEstateDataAccessObject.ParameterDAO().GetARecord("MaxRate").Value))
                    {
                        RealEstateDataContext.NEWS_SALE entity = new RealEstateDataContext.NEWS_SALE();
                        entity.ID           = this.CreateNewID();
                        entity.TypeID       = typeID;
                        entity.Title        = title;
                        entity.Content      = content;
                        entity.RealEstateID = realEstateID;
                        entity.Rate         = rate;
                        entity.UpdateTime   = updateTime;
                        entity.Status       = status;
                        entity.Broker       = broker;

                        _db.Insert(entity);
                        return entity.ID;
                    }
                    else throw new RealEstateDataContext.Utility.Rate_LimitationException();
                }
                else throw new RealEstateDataContext.Utility.Real_EstateIDException();
            }
            else throw new RealEstateDataContext.Utility.News_Sale_TypeIDException();
        }

        /// <summary>
        /// Update a row in NEWS_SALE table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row has just updated</returns>
        /// <exception cref="News_SaleIDException"></exception>
        /// <exception cref="News_Sale_TypeIDException"></exception>
        /// <exception cref="Real_EstateIDException"></exception>
        /// <exception cref="Rate_LimitationException: Rate value must between MinRate and MaxRate"></exception>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public override int Update(RealEstateDataContext.NEWS_SALE entity)
        {
            if (ValidationID(entity.ID))
            {
                if (new RealEstateDataAccessObject.News_Sale_TypeDAO().ValidationID(entity.TypeID))
                {
                    if (new RealEstateDataAccessObject.Real_EstateDAO().ValidationID(entity.RealEstateID))
                    {
                        if (entity.Rate == null ||
                            (entity.Rate >= new RealEstateDataAccessObject.ParameterDAO().GetARecord("MinRate").Value &&
                                entity.Rate <= new RealEstateDataAccessObject.ParameterDAO().GetARecord("MaxRate").Value))
                        {
                            _db.Update(entity);
                            return entity.ID;
                        }
                        else throw new RealEstateDataContext.Utility.Rate_LimitationException();
                    }
                    else throw new RealEstateDataContext.Utility.Real_EstateIDException();
                }
                else throw new RealEstateDataContext.Utility.News_Sale_TypeIDException();
            }
            else throw new RealEstateDataContext.Utility.News_SaleIDException();
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
        /// <exception cref="News_SaleIDException"></exception>
        /// <exception cref="News_Sale_TypeIDException"></exception>
        /// <exception cref="Real_EstateIDException"></exception>
        /// <exception cref="Rate_LimitationException: Rate value must between MinRate and MaxRate"></exception>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public int Update(int id, int typeID, string title, string content,
            int realEstateID, int? rate, DateTime updateTime, int status, bool broker)
        {
            if (ValidationID(id))
            {
                if (new RealEstateDataAccessObject.News_Sale_TypeDAO().ValidationID(typeID))
                {
                    if (new RealEstateDataAccessObject.Real_EstateDAO().ValidationID(realEstateID))
                    {
                        if (rate == null ||
                            (rate >= new RealEstateDataAccessObject.ParameterDAO().GetARecord("MinRate").Value &&
                                rate <= new RealEstateDataAccessObject.ParameterDAO().GetARecord("MaxRate").Value))
                        {
                            RealEstateDataContext.NEWS_SALE entity = new RealEstateDataContext.NEWS_SALE();
                            entity.ID           = id;
                            entity.TypeID       = typeID;
                            entity.Title        = title;
                            entity.Content      = content;
                            entity.RealEstateID = realEstateID;
                            entity.Rate         = rate;
                            entity.UpdateTime   = updateTime;
                            entity.Status       = status;
                            entity.Broker       = broker;

                            _db.Update(entity);
                            return entity.ID;
                        }
                        else throw new RealEstateDataContext.Utility.Rate_LimitationException();
                    }
                    else throw new RealEstateDataContext.Utility.Real_EstateIDException();
                }
                else throw new RealEstateDataContext.Utility.News_Sale_TypeIDException();
            }
            else throw new RealEstateDataContext.Utility.News_SaleIDException();
        }

        /// <summary>
        /// Delete a row from NEWS_SALE table
        /// </summary>
        /// <param name="ID">ID of row want to delete</param>
        /// <returns>ID of row has just deleted</returns>
        /// <exception cref="News_SaleIDException"></exception>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public override void Delete(int ID)
        {
            if (ValidationID(ID))
            {
                _db.Delete(ID);
            }
            else throw new RealEstateDataContext.Utility.News_SaleIDException();
        }

        /// <summary>
        /// Get a row in NEWS_SALE table
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        /// <exception cref="News_SaleIDException"></exception>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public override RealEstateDataContext.NEWS_SALE GetARecord(int ID)
        {
            if (ValidationID(ID))
            {
                return _db.GetARecord(ID);
            }
            else throw new RealEstateDataContext.Utility.News_SaleIDException();
        }

        /// <summary>
        /// Get News Sale sale for a RealEstate has price between from and to
        /// </summary>
        /// <param name="from">From</param>
        /// <param name="to">To</param>
        /// <returns>List of NewsSales</returns>
        public ICollection<RealEstateDataContext.NEWS_SALE> GetNewsSalesByPrice(decimal from, decimal to)
        {
            if (from == 0 && to == 0)
            {
                return new ObservableCollection<RealEstateDataContext.NEWS_SALE>(_db.GetAllRows());
            }
            if (from >= 0 && (from <= to))
            {
                ObservableCollection<RealEstateDataContext.NEWS_SALE> result = new ObservableCollection<RealEstateDataContext.NEWS_SALE>();
                foreach (RealEstateDataContext.NEWS_SALE item in _db.GetAllRows())
                {
                    if (item.REAL_ESTATE.UNIT.Name == "VND")
                    {
                        if (item.REAL_ESTATE.Price >= from && item.REAL_ESTATE.Price <= to)
                        {
                            result.Add(item);
                        }
                    }
                    else if (item.REAL_ESTATE.UNIT.Name == "SJC")
                    {
                        if ((item.REAL_ESTATE.Price * RealEstateBusinessLogicObject.Parameter.RateSJCToVND) >= from &&
                            (item.REAL_ESTATE.Price * RealEstateBusinessLogicObject.Parameter.RateSJCToVND) <= to)
                        {
                            result.Add(item);
                        }
                    }
                    else
                    {
                        if ((item.REAL_ESTATE.Price * RealEstateBusinessLogicObject.Parameter.RateUSDToVND) >= from &&
                            (item.REAL_ESTATE.Price * RealEstateBusinessLogicObject.Parameter.RateUSDToVND) <= to)
                        {
                            result.Add(item);
                        }
                    }

                }
                return result;
            }
            else return new ObservableCollection<RealEstateDataContext.NEWS_SALE>();
        }

        /// <summary>
        /// Get News Sale sale for a RealEstate has total use area between from and to
        /// </summary>
        /// <param name="from">From</param>
        /// <param name="to">To</param>
        /// <returns>List of NewsSales</returns>
        public ICollection<RealEstateDataContext.NEWS_SALE> GetNewsSalesByTotalUseArea(double from, double to)
        {
            if (from == 0 && to == 0)
            {
                return new ObservableCollection<RealEstateDataContext.NEWS_SALE>(_db.GetAllRows());
            }
            if (from >= 0 && from <= to)
            {
                ObservableCollection<RealEstateDataContext.NEWS_SALE> result = new ObservableCollection<RealEstateDataContext.NEWS_SALE>();
                foreach (RealEstateDataContext.NEWS_SALE item in _db.GetAllRows())
                {
                    if (item.REAL_ESTATE.TotalUseArea != null)
                    {
                        if (item.REAL_ESTATE.TotalUseArea >= from && item.REAL_ESTATE.TotalUseArea <= to)
                        {
                            result.Add(item);
                        }
                    }
                }
                return result;
            }
            else return new ObservableCollection<RealEstateDataContext.NEWS_SALE>();
        }

        /// <summary>
        /// Get NewsSale by Project
        /// </summary>
        /// <param name="projectID">Project's ID</param>
        /// <returns>List of NewsSales</returns>
        public ICollection<RealEstateDataContext.NEWS_SALE> GetNewsSalesByProjectID(int projectID)
        {
            ObservableCollection<RealEstateDataContext.NEWS_SALE> result = new ObservableCollection<RealEstateDataContext.NEWS_SALE>();
            if (new RealEstateDataAccessObject.ProjectDAO().ValidationID(projectID))
            {
                foreach (RealEstateDataContext.REAL_ESTATE item in new RealEstateDataAccessObject.ProjectDAO().GetARecord(projectID).REAL_ESTATEs)
                {
                    result.Add(new RealEstateBusinessLogicObject.Real_EstateBLO().GetNewsSaleByRealEstateID(item.ID));
                }
            }
            return result;
        }

        /// <summary>
        /// Get NewsSales sale for Real Estate has location's ID
        /// </summary>
        /// <param name="locationID">Location's ID</param>
        /// <returns>List of NewsSales</returns>
        public ICollection<RealEstateDataContext.NEWS_SALE> GetNewsSalesByRealEstateLocation(int locationID)
        {
            ObservableCollection<RealEstateDataContext.NEWS_SALE> result = new ObservableCollection<RealEstateDataContext.NEWS_SALE>();
            if (new RealEstateDataAccessObject.LocationDAO().ValidationID(locationID))
            {
                foreach (RealEstateDataContext.NEWS_SALE item in _db.GetAllRows())
                {
                    if (item.REAL_ESTATE.LocationID == locationID)
                    {
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Get NewsSale sale for RealEstate has bedroom number
        /// </summary>
        /// <param name="from">From</param>
        /// <param name="to">To</param>
        /// <returns>List of News Sales</returns>
        public ICollection<RealEstateDataContext.NEWS_SALE> GetNewsSaleByBedRoom(int from, int to)
        {
            ObservableCollection<RealEstateDataContext.NEWS_SALE> result = new ObservableCollection<RealEstateDataContext.NEWS_SALE>();
            if (from == 0 && to == 0)
            {
                return new ObservableCollection<RealEstateDataContext.NEWS_SALE>(_db.GetAllRows());
            }
            else if (from >=0 && from <= to)
            {
                foreach (RealEstateDataContext.NEWS_SALE item in _db.GetAllRows())
                {
                    if (item.REAL_ESTATE.BedRoom != null && item.REAL_ESTATE.BedRoom >= from && item.REAL_ESTATE.BedRoom <= to)
                    {
                        result.Add(item);
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Get NewsSale sale for RealEstate has some direction
        /// </summary>
        /// <param name="direction">Direction</param>
        /// <returns>List of NewsSales</returns>
        public ICollection<RealEstateDataContext.NEWS_SALE> GetNewsSaleByDirection(string direction)
        {
            ObservableCollection<RealEstateDataContext.NEWS_SALE> result = new ObservableCollection<RealEstateDataContext.NEWS_SALE>();
            if (direction.Equals("Không xác định"))
            {
                foreach (RealEstateDataContext.NEWS_SALE item in _db.GetAllRows())
                {
                    if (item.REAL_ESTATE.Direction.Equals("") || item.REAL_ESTATE.Direction.Equals("Không xác định"))
                    {
                        result.Add(item);
                    }
                }
                return result;
            }
            foreach (RealEstateDataContext.NEWS_SALE item in _db.GetAllRows())
            {
                if (RealEstateDataContext.Utility.Utils.RemoveSign4VietNameseString(item.REAL_ESTATE.Direction.ToLower()).Equals(RealEstateDataContext.Utility.Utils.RemoveSign4VietNameseString(direction.ToLower())))
                {
                    result.Add(item);
                }
            }
            return result;
        }

        /// <summary>
        /// Get NewsSale sale Real Estate main owner.
        /// </summary>
        /// <returns>List of NewsSales</returns>
        public ICollection<RealEstateDataContext.NEWS_SALE> GetNewsSaleByMainOwner()
        {
            ObservableCollection<RealEstateDataContext.NEWS_SALE> result = new ObservableCollection<RealEstateDataContext.NEWS_SALE>();
            foreach (RealEstateDataContext.NEWS_SALE item in _db.GetAllRows())
            {
                if (!item.Broker)
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
