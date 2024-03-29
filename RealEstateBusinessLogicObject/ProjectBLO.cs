﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RealEstateBusinessLogicObject
{
    [DataObject(true)]
    public class ProjectBLO : BusinessParent<RealEstateDataContext.PROJECT>
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public ProjectBLO()
        {
            _db = new RealEstateDataAccessObject.ProjectDAO();
        }

        /// <summary>
        /// Get all row in table PROJECT
        /// </summary>
        /// <returns>List of entities</returns>
        public override ICollection<RealEstateDataContext.PROJECT> GetAllRows()
        {
            return new ObservableCollection<RealEstateDataContext.PROJECT>(_db.GetAllRows());
        }

        /// <summary>
        /// Insert a row into PROJECT table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row has just inserted</returns>
        /// <exception cref="Project_TypeIDException"></exception>
        /// <exception cref="AddressIDException"></exception>
        public override int Insert(RealEstateDataContext.PROJECT entity)
        {
            if (new RealEstateDataAccessObject.Project_TypeDAO().ValidationID(entity.TypeID))
            {
                if (new RealEstateDataAccessObject.AddressDAO().ValidationID(entity.AddressID))
                {
                    entity.ID = this.CreateNewID();
                    _db.Insert(entity);
                    return entity.ID;
                }
                else throw new RealEstateDataContext.Utility.AddressIDException();
            }
            else throw new RealEstateDataContext.Utility.Project_TypeIDException();
        }

        /// <summary>
        /// Insert a row into PROJECT table
        /// </summary>
        /// <param name="typeID">ID of type</param>
        /// <param name="name">Project's name</param>
        /// <param name="beginDay">Project's begin day</param>
        /// <param name="addressID">Project's address ID</param>
        /// <param name="description">Project's description</param>
        /// <returns>ID of row has just inserted</returns>
        /// <exception cref="Project_TypeIDException"></exception>
        /// <exception cref="AddressIDException"></exception>
        public int Insert(int typeID, string name, DateTime? beginDay, int addressID, string summary, string description, int imageID)
        {
            if (new RealEstateDataAccessObject.Project_TypeDAO().ValidationID(typeID))
            {
                if (new RealEstateDataAccessObject.AddressDAO().ValidationID(addressID))
                {
                    RealEstateDataContext.PROJECT entity = new RealEstateDataContext.PROJECT();
                    entity.ID          = this.CreateNewID();
                    entity.TypeID      = typeID;
                    entity.Name        = name;
                    entity.BeginDay    = beginDay;
                    entity.AddressID   = addressID;
                    entity.Summary     = summary;
                    entity.Description = description;
                    entity.ImageID     = imageID;

                    _db.Insert(entity);
                    return entity.ID;
                }
                else throw new RealEstateDataContext.Utility.AddressIDException();
            }
            else throw new RealEstateDataContext.Utility.Project_TypeIDException();
        }

        /// <summary>
        /// Update a row in PROJECT table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row has just updated</returns>
        /// <exception cref="ProjectIDException"></exception>
        /// <exception cref="Project_TypeIDException"></exception>
        /// <exception cref="AddressIDException"></exception>
        public override int Update(RealEstateDataContext.PROJECT entity)
        {
            if (ValidationID(entity.ID))
            {
                if (new RealEstateDataAccessObject.Project_TypeDAO().ValidationID(entity.TypeID))
                {
                    if (new RealEstateDataAccessObject.AddressDAO().ValidationID(entity.AddressID))
                    {
                        _db.Update(entity);
                        return entity.ID;
                    }
                    else throw new RealEstateDataContext.Utility.AddressIDException();
                }
                else throw new RealEstateDataContext.Utility.Project_TypeIDException();
            }
            else throw new RealEstateDataContext.Utility.ProjectIDException();
        }

        /// <summary>
        /// Update a row in PROJECT table
        /// </summary>
        /// <param name="id">ID of row</param>
        /// <param name="typeID">ID of type</param>
        /// <param name="name">Project's name</param>
        /// <param name="beginDay">Project's begin day</param>
        /// <param name="addressID">Project's address ID</param>
        /// <param name="description">Project's description</param>
        /// <returns>ID of row has just updated</returns>
        /// <exception cref="ProjectIDException"></exception>
        /// <exception cref="Project_TypeIDException"></exception>
        /// <exception cref="AddressIDException"></exception>
        public int Update(int id, int typeID, string name, DateTime? beginDay, int addressID, string summary, string description, int imageID)
        {
            if (ValidationID(id))
            {
                if (new RealEstateDataAccessObject.Project_TypeDAO().ValidationID(typeID))
                {
                    if (new RealEstateDataAccessObject.AddressDAO().ValidationID(addressID))
                    {
                        RealEstateDataContext.PROJECT entity = new RealEstateDataContext.PROJECT();
                        entity.ID          = id;
                        entity.TypeID      = typeID;
                        entity.Name        = name;
                        entity.BeginDay    = beginDay;
                        entity.AddressID   = addressID;
                        entity.Summary     = summary;
                        entity.Description = description;
                        entity.ImageID     = imageID;

                        _db.Update(entity);
                        return entity.ID;
                    }
                    else throw new RealEstateDataContext.Utility.AddressIDException();
                }
                else throw new RealEstateDataContext.Utility.Project_TypeIDException();
            }
            else throw new RealEstateDataContext.Utility.ProjectIDException();
        }

        /// <summary>
        /// Delete a row from PROJECT table
        /// </summary>
        /// <param name="ID">ID of row want to delete</param>
        /// <returns>ID of row has just deleted</returns>
        /// <exception cref="ProjectIDException"></exception>
        public override void Delete(int ID)
        {
            if (ValidationID(ID))
            {
                _db.Delete(ID);
            }
            else throw new RealEstateDataContext.Utility.ProjectIDException();
        }

        /// <summary>
        /// Get a row in PROJECT table
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        /// <exception cref="ProjectIDException"></exception>
        public override RealEstateDataContext.PROJECT GetARecord(int ID)
        {
            if (ValidationID(ID))
            {
                return _db.GetARecord(ID);
            }
            else throw new RealEstateDataContext.Utility.ProjectIDException();
        }

        /// <summary>
        /// Get Projects in a District
        /// </summary>
        /// <param name="districtID">District ID</param>
        /// <returns>List of entities</returns>
        public ICollection<RealEstateDataContext.PROJECT> GetProjectsByDistrictID(int districtID)
        {
            if (new RealEstateDataAccessObject.DistrictDAO().ValidationID(districtID))
            {
                ObservableCollection<RealEstateDataContext.PROJECT> result = new ObservableCollection<RealEstateDataContext.PROJECT>();
                foreach (RealEstateDataContext.PROJECT item in _db.GetAllRows())
                {
                    if (item.ADDRESS.DistrictID == districtID && item.ID != 0)
                    {
                        result.Add(item);
                    }
                }
                return result;
            }
            else return new ObservableCollection<RealEstateDataContext.PROJECT>();
        }

        /// <summary>
        /// Get Summary of Project Description
        /// </summary>
        /// <param name="id">Project ID</param>
        /// <returns>Summary string</returns>
        public string GetSummary(int id)
        {
            return _db.GetARecord(id).Summary;
        }
    }
}
