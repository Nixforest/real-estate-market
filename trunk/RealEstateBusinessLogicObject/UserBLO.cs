using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace RealEstateBusinessLogicObject
{
    public class UserBLO: BusinessParent<RealEstateDataContext.USER>
    {
        /// <summary>
        /// Contructor
        /// </summary>
        public UserBLO()
        {
            _db = new RealEstateDataAccessObject.UserDAO();
        }

        /// <summary>
        /// Get all row in table USER
        /// </summary>
        /// <returns>List of entities</returns>
        public override ICollection<RealEstateDataContext.USER> GetAllRows()
        {
            return new ObservableCollection<RealEstateDataContext.USER>(_db.GetAllRows());
        }

        /// <summary>
        /// Insert a row into USER table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row has just inserted</returns>
        public override int Insert(RealEstateDataContext.USER entity)
        {
            entity.ID = _db.CreateID();
            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Insert a row into USER table
        /// </summary>
        /// <param name="username">User name</param>
        /// <param name="password">Password</param>
        /// <param name="email">Email</param>
        /// <param name="phone">Phone</param>
        /// <param name="groupID">ID of group user belong</param>
        /// <returns>ID of row has just inserted</returns>
        public int Insert(string username, string password,
            string email, string phone, int groupID)
        {
            RealEstateDataContext.USER entity = new RealEstateDataContext.USER();
            entity.ID = _db.CreateID();
            entity.Username = username;
            entity.Password = password;
            entity.Email = email;
            entity.Phone = phone;
            entity.GroupID = groupID;

            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Update a row in USER table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row has just updated</returns>
        public override int Update(RealEstateDataContext.USER entity)
        {
            _db.Update(entity);
            return entity.ID;
        }

        /// <summary>
        /// Update a row in USER table
        /// </summary>
        /// <param name="id">ID of row</param>
        /// <param name="username">User name</param>
        /// <param name="password">Password</param>
        /// <param name="email">Email</param>
        /// <param name="phone">Phone</param>
        /// <param name="groupID">ID of group user belong</param>
        /// <returns>ID of row has just updated</returns>
        public int Update(int id, string username, string password,
            string email, string phone, int groupID)
        {
            RealEstateDataContext.USER entity = new RealEstateDataContext.USER();
            entity.ID = id;
            entity.Username = username;
            entity.Password = password;
            entity.Email = email;
            entity.Phone = phone;
            entity.GroupID = groupID;

            _db.Update(entity);
            return entity.ID;
        }

        /// <summary>
        /// Delete a row from USER table
        /// </summary>
        /// <param name="ID">ID of row want to delete</param>
        /// <returns>ID of row has just deleted</returns>
        public override void Delete(int ID)
        {
            _db.Delete(ID);
        }

        /// <summary>
        /// Get a row in USER table
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        public override RealEstateDataContext.USER GetARecord(int ID)
        {
            return _db.GetARecord(ID);
        }
    }
}
