﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RealEstateBusinessLogicObject
{
    [DataObject(true)]
    public class CustomerBLO : BusinessParent<RealEstateDataContext.CUSTOMER>
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public CustomerBLO()
        {
            _db = new RealEstateDataAccessObject.CustomerDAO();
        }

        /// <summary>
        /// Get all row in table CUSTOMER
        /// </summary>
        /// <returns>List of entities</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public override ICollection<RealEstateDataContext.CUSTOMER> GetAllRows()
        {
            return new ObservableCollection<RealEstateDataContext.CUSTOMER>(_db.GetAllRows());
        }

        /// <summary>
        /// Insert a row into CUSTOMER table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row have just inserted</returns>
        /// <exception cref="AddressIDException: ID not exist in ADDRESS table"></exception>
        /// <exception cref="UserIDException: ID not exist in USER table"></exception>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public override int Insert(RealEstateDataContext.CUSTOMER entity)
        {
            if (new RealEstateDataAccessObject.AddressDAO().ValidationID(entity.AddressID))
            {
                entity.ID = this.CreateNewID();
                _db.Insert(entity);
                return entity.ID;
            }
            else throw new RealEstateDataContext.Utility.AddressIDException();
        }

        /// <summary>
        /// Insert a row into CUSTOMER table
        /// </summary>
        /// <param name="name">Customer's full name</param>
        /// <param name="addressID">ID of address</param>
        /// <param name="identityCard">Customer's identity card</param>
        /// <param name="phone">Customer's phone</param>
        /// <param name="homePhone">Customer's home phone</param>
        /// <param name="email">Customer's email</param>
        /// <param name="userID">Customer's user name</param>
        /// <returns>ID of row have just inserted</returns>
        /// <exception cref="AddressIDException: ID not exist in ADDRESS table"></exception>
        /// <exception cref="UserIDException: ID not exist in USER table"></exception>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int Insert(string name, int addressID, string identityCard,
            string phone, string homePhone, string email, string userName)
        {
            if (new RealEstateDataAccessObject.AddressDAO().ValidationID(addressID))
            {
                RealEstateDataContext.CUSTOMER entity = new RealEstateDataContext.CUSTOMER();
                entity.ID           = this.CreateNewID();
                entity.Name         = name;
                entity.AddressID    = addressID;
                entity.IdentityCard = identityCard;
                entity.Phone        = phone;
                entity.HomePhone    = homePhone;
                entity.Email        = email;
                entity.UserName     = userName;

                _db.Insert(entity);
                return entity.ID;
            }
            else throw new RealEstateDataContext.Utility.AddressIDException();
        }

        /// <summary>
        /// Update a row in CUSTOMER table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row have just updated</returns>
        /// <exception cref="CustomerIDException: ID not exist in CUSTOMER table"></exception>
        /// <exception cref="AddressIDException: ID not exist in ADDRESS table"></exception>
        /// <exception cref="UserIDException: ID not exist in USER table"></exception>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public override int Update(RealEstateDataContext.CUSTOMER entity)
        {
            if (ValidationID(entity.ID))
            {
                if (new RealEstateDataAccessObject.AddressDAO().ValidationID(entity.AddressID))
                {
                    _db.Update(entity);
                    return entity.ID;
                }
                else throw new RealEstateDataContext.Utility.AddressIDException();
            }
            else throw new RealEstateDataContext.Utility.CustomerIDException();
        }

        /// <summary>
        /// Update a row in CUSTOMER table
        /// </summary>
        /// <param name="id">ID of row</param>
        /// <param name="name">Customer's full name</param>
        /// <param name="addressID">ID of address</param>
        /// <param name="identityCard">Customer's identity card</param>
        /// <param name="phone">Customer's phone</param>
        /// <param name="homePhone">Customer's home phone</param>
        /// <param name="email">Customer's email</param>
        /// <param name="userID">Customer's user name</param>
        /// <returns>ID of row have just updated</returns>
        /// <exception cref="CustomerIDException: ID not exist in CUSTOMER table"></exception>
        /// <exception cref="AddressIDException: ID not exist in ADDRESS table"></exception>
        /// <exception cref="UserIDException: ID not exist in USER table"></exception>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public int Update(int id, string name, int addressID, string identityCard,
            string phone, string homePhone, string email, string userName)
        {
            if (ValidationID(id))
            {
                if (new RealEstateDataAccessObject.AddressDAO().ValidationID(addressID))
                {
                    RealEstateDataContext.CUSTOMER entity = new RealEstateDataContext.CUSTOMER();
                    entity.ID           = id;
                    entity.Name         = name;
                    entity.AddressID    = addressID;
                    entity.IdentityCard = identityCard;
                    entity.Phone        = phone;
                    entity.HomePhone    = homePhone;
                    entity.Email        = email;
                    entity.UserName     = userName;

                    _db.Update(entity);
                    return entity.ID;
                }
                else throw new RealEstateDataContext.Utility.AddressIDException();
            }
            else throw new RealEstateDataContext.Utility.CustomerIDException();
        }

        /// <summary>
        /// Delete a row from CUSTOMER table
        /// </summary>
        /// <param name="ID">ID of row want to delete</param>
        /// <returns>ID of row just delete</returns>
        /// <exception cref="CustomerIDException: ID not exist in CUSTOMER table"></exception>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public override void Delete(int ID)
        {
            if (ValidationID(ID))
            {
                _db.Delete(ID);
            }
            else throw new RealEstateDataContext.Utility.CustomerIDException();
        }

        /// <summary>
        /// Get a row in CUSTOMER table
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        /// <exception cref="CustomerIDException: ID not exist in CUSTOMER table"></exception>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public override RealEstateDataContext.CUSTOMER GetARecord(int ID)
        {
            if (ValidationID(ID))
            {
                return _db.GetARecord(ID);
            }
            else throw new RealEstateDataContext.Utility.CustomerIDException();
        }

        /// <summary>
        /// Get a Customer by Username
        /// </summary>
        /// <param name="userName">UserName</param>
        /// <returns>CUSTOMER</returns>
        public RealEstateDataContext.CUSTOMER GetCustomerByUserName(string userName)
        {
            foreach (RealEstateDataContext.CUSTOMER entity in _db.GetAllRows())
            {
                if (entity.UserName.Equals(userName))
                {
                    return entity;
                }
            }
            return new RealEstateDataContext.CUSTOMER();
        }

        /// <summary>
        /// Insert Property for Customer
        /// </summary>
        /// <param name="realEstate">Real Estate</param>
        /// <param name="customer">Customer</param>
        public void InsertRealEstateToCustomer(RealEstateDataContext.REAL_ESTATE realEstate, RealEstateDataContext.CUSTOMER customer)
        {
            RealEstateDataContext.PROPERTY_CUSTOMER entity = new RealEstateDataContext.PROPERTY_CUSTOMER();
            entity.CustomerID   = customer.ID;
            entity.RealEstateID = realEstate.ID;
            new RealEstateDataAccessObject.Property_CustomerDAO().Insert(entity);
        }

        /// <summary>
        /// Insert Property for Customer
        /// </summary>
        /// <param name="realEstate">Real Estate ID</param>
        /// <param name="customer">Customer ID</param>
        public void InsertRealEstateToCustomer(int realEstateID, int customerID)
        {
            RealEstateDataContext.PROPERTY_CUSTOMER entity = new RealEstateDataContext.PROPERTY_CUSTOMER();
            entity.CustomerID   = customerID;
            entity.RealEstateID = realEstateID;
            new RealEstateDataAccessObject.Property_CustomerDAO().Insert(entity);
        }

        //public ICollection<RealEstateDataContext.REAL_ESTATE_TYPE> GetRealEstateTypeByCustomer(int customerID)
        //{
        //    ObservableCollection<RealEstateDataContext.REAL_ESTATE_TYPE> listRealEstateType = new ObservableCollection<RealEstateDataContext.REAL_ESTATE_TYPE>();
        //    foreach (RealEstateDataContext.PROPERTY_CUSTOMER item in _db.GetARecord(customerID).PROPERTY_CUSTOMERs)
        //    {
        //        listRealEstateType.Add(new RealEstateDataAccessObject.Real_EstateDAO().GetARecord(item.RealEstateID).REAL_ESTATE_TYPE);
        //    }
        //    return listRealEstateType;
        //}
    }
}
