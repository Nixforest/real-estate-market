using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace RealEstateBusinessLogicObject
{
    public class AddressBLO : BusinessParent<RealEstateDataContext.ADDRESS>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public AddressBLO()
        {
            _db = new RealEstateDataAccessObject.AddressDAO();
        }

        /// <summary>
        /// Get all row in table ADDRESS
        /// </summary>
        /// <returns>List of entities</returns>
        public override ICollection<RealEstateDataContext.ADDRESS> GetAllRows()
        {
            return new ObservableCollection<RealEstateDataContext.ADDRESS>(_db.GetAllRows());
        }

        /// <summary>
        /// Insert a row into ADDRESS table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row just insert</returns>
        public override int Insert(RealEstateDataContext.ADDRESS entity)
        {
            if ((new RealEstateDataAccessObject.NationDAO()).ValidationID(entity.NationID))
            {
                if (new RealEstateDataAccessObject.CityDAO().ValidationID(entity.CityID))
                {
                    if (new RealEstateDataAccessObject.DistrictDAO().ValidationID((int)entity.DistrictID) || entity.DistrictID == null)
                    {
                        if (new RealEstateDataAccessObject.WardDAO().ValidationID((int)entity.WardID) || entity.WardID == null)
                        {
                            if (new RealEstateDataAccessObject.StreetDAO().ValidationID((int)entity.StreetID) || entity.StreetID == null)
                            {
                                entity.ID = _db.CreateID();
                                _db.Insert(entity);
                                return entity.ID;
                            }
                            else throw new RealEstateDataContext.Utility.StreetID();
                        }
                        else throw new RealEstateDataContext.Utility.WardID();
                    }
                    else throw new RealEstateDataContext.Utility.DistrictID();
                }
                else throw new RealEstateDataContext.Utility.CityID();
            }
            else throw new RealEstateDataContext.Utility.NationID();
            
        }

        /// <summary>
        /// Insert a row into ADDRESS table
        /// </summary>
        /// <param name="nationID">ID of nation</param>
        /// <param name="cityID">ID of city</param>
        /// <param name="districtID">ID of district</param>
        /// <param name="wardID">ID of ward</param>
        /// <param name="streetID">ID of street</param>
        /// <param name="detail">Detail Address</param>
        /// <returns>ID of row just insert</returns>
        public int Insert(int nationID, int cityID, int? districtID, int? wardID, int? streetID, string detail)
        {
            if ((new RealEstateDataAccessObject.NationDAO()).ValidationID(nationID))
            {
                if (new RealEstateDataAccessObject.CityDAO().ValidationID(cityID))
                {
                    if (new RealEstateDataAccessObject.DistrictDAO().ValidationID((int)districtID) || districtID == null)
                    {
                        if (new RealEstateDataAccessObject.WardDAO().ValidationID((int)wardID) || wardID == null)
                        {
                            if (new RealEstateDataAccessObject.StreetDAO().ValidationID((int)streetID) || streetID == null)
                            {
                                RealEstateDataContext.ADDRESS entity = new RealEstateDataContext.ADDRESS();
                                entity.ID = _db.CreateID();
                                entity.NationID = nationID;
                                entity.CityID = cityID;
                                entity.DistrictID = districtID;
                                entity.WardID = wardID;
                                entity.StreetID = streetID;
                                entity.Detail = detail;

                                _db.Insert(entity);
                                return entity.ID;
                            }
                            else throw new RealEstateDataContext.Utility.StreetID();
                        }
                        else throw new RealEstateDataContext.Utility.WardID();
                    }
                    else throw new RealEstateDataContext.Utility.DistrictID();
                }
                else throw new RealEstateDataContext.Utility.CityID();
            }
            else throw new RealEstateDataContext.Utility.NationID();         
        }

        /// <summary>
        /// Update a row in ADDRESS table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row just update</returns>
        public override int Update(RealEstateDataContext.ADDRESS entity)
        {
            if (ValidationID(entity.ID))
            {
                if (new RealEstateDataAccessObject.NationDAO().ValidationID(entity.NationID))
                {
                    if (new RealEstateDataAccessObject.CityDAO().ValidationID(entity.CityID))
                    {
                        if (new RealEstateDataAccessObject.DistrictDAO().ValidationID((int)entity.DistrictID) || entity.DistrictID == null)
                        {
                            if (new RealEstateDataAccessObject.WardDAO().ValidationID((int)entity.WardID) || entity.WardID == null)
                            {
                                if (new RealEstateDataAccessObject.StreetDAO().ValidationID((int)entity.StreetID) || entity.StreetID == null)
                                {
                                    _db.Update(entity);
                                    return entity.ID;
                                }
                                else throw new RealEstateDataContext.Utility.StreetID();
                            }
                            else throw new RealEstateDataContext.Utility.WardID();
                        }
                        else throw new RealEstateDataContext.Utility.DistrictID();
                    }
                    else throw new RealEstateDataContext.Utility.CityID();
                }
                else throw new RealEstateDataContext.Utility.NationID();
            }
            else throw new RealEstateDataContext.Utility.AddressID();
        }

        /// <summary>
        /// Update a row in ADDRESS table
        /// </summary>
        /// <param name="id">ID of row</param>
        /// <param name="nationID">ID of nation</param>
        /// <param name="cityID">ID of city</param>
        /// <param name="districtID">ID of district</param>
        /// <param name="wardID">ID of ward</param>
        /// <param name="streetID">ID of street</param>
        /// <param name="detail">Detail Address</param>
        /// <returns>ID of row just update</returns>
        public int Update(int id, int nationID, int cityID, int? districtID, int? wardID, int? streetID, string detail)
        {
            if (ValidationID(id))
            {
                if (new RealEstateDataAccessObject.NationDAO().ValidationID(nationID))
                {
                    if (new RealEstateDataAccessObject.CityDAO().ValidationID(cityID))
                    {
                    if (new RealEstateDataAccessObject.DistrictDAO().ValidationID((int)districtID) || districtID == null)
                    {
                        if (new RealEstateDataAccessObject.WardDAO().ValidationID((int)wardID) || wardID == null)
                        {
                            if (new RealEstateDataAccessObject.StreetDAO().ValidationID((int)streetID) || streetID == null)
                            {
                                RealEstateDataContext.ADDRESS entity = new RealEstateDataContext.ADDRESS();
                                entity.ID = id;
                                entity.NationID = nationID;
                                entity.CityID = cityID;
                                entity.DistrictID = districtID;
                                entity.WardID = wardID;
                                entity.StreetID = streetID;
                                entity.Detail = detail;

                                _db.Update(entity);
                                return entity.ID;
                            }
                            else throw new RealEstateDataContext.Utility.StreetID();
                        }
                        else throw new RealEstateDataContext.Utility.WardID();
                    }
                    else throw new RealEstateDataContext.Utility.DistrictID();
                    }
                    else throw new RealEstateDataContext.Utility.CityID();
                }
                else throw new RealEstateDataContext.Utility.NationID();
            }
            else throw new RealEstateDataContext.Utility.AddressID();
        }


        /// <summary>
        /// Delete a row from ADDRESS table
        /// </summary>
        /// <param name="ID">ID of row want to delete</param>
        /// <exception cref="AddressID"></exception>
        public override void Delete(int ID)
        {
            if (ValidationID(ID))
            {
                _db.Delete(ID);
            }
            else throw new RealEstateDataContext.Utility.AddressID();
        }

        public override RealEstateDataContext.ADDRESS GetARecord(int ID)
        {
            if (ValidationID(ID))
            {
                return _db.GetARecord(ID);
            }
            else throw new RealEstateDataContext.Utility.AddressID();
        }
    }
}
