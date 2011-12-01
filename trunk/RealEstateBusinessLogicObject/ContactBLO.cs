using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace RealEstateBusinessLogicObject
{
    [DataObject(true)]
    public class ContactBLO : BusinessParent<RealEstateDataContext.CONTACT>
    {
         /// <summary>
        /// Contructor
        /// </summary>
        public ContactBLO()
        {
            _db = new RealEstateDataAccessObject.ContactDAO();
        }

        /// <summary>
        /// Get all row in table CONTACT
        /// </summary>
        /// <returns>List of entities</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public override ICollection<RealEstateDataContext.CONTACT> GetAllRows()
        {
            return new ObservableCollection<RealEstateDataContext.CONTACT>(_db.GetAllRows());
        }

        /// <summary>
        /// Insert a row into CONTACT table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row have just inserted</returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public override int Insert(RealEstateDataContext.CONTACT entity)
        {
            entity.ID = this.CreateNewID();
            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Insert a row to CONTACT table
        /// </summary>
        /// <param name="name">Contact's Name</param>
        /// <param name="addressID">Address ID</param>
        /// <param name="phone">Phone</param>
        /// <param name="homePhone">HomePhone</param>
        /// <param name="note">Note</param>
        /// <returns>ID of row have just inserted</returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public int Insert(string name, int addressID, string phone, string homePhone,
            string note)
        {
            RealEstateDataContext.CONTACT entity = new RealEstateDataContext.CONTACT();
            entity.ID = this.CreateNewID();
            entity.Name = name;
            entity.AddressID = addressID;
            entity.Phone = phone;
            entity.HomePhone = homePhone;
            entity.Note = note;

            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Update a row in CONTACT table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row have just updated</returns>
        /// <exception cref="ContactIDException"></exception>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public override int Update(RealEstateDataContext.CONTACT entity)
        {
            if (ValidationID(entity.ID))
            {
                _db.Update(entity);
                return entity.ID;
            }
            else throw new RealEstateDataContext.Utility.ContactIDException();
        }

        /// <summary>
        /// Update a row in CONTACT table
        /// </summary>
        /// <param name="id">ID of row</param>
        /// <param name="name">Contact's Name</param>
        /// <param name="addressID">Address ID</param>
        /// <param name="phone">Phone</param>
        /// <param name="homePhone">HomePhone</param>
        /// <param name="note">Note</param>
        /// <exception cref="ContactIDException"></exception>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public int Update(int id, string name, int addressID, string phone, string homePhone,
            string note)
        {
            if (ValidationID(id))
            {
                RealEstateDataContext.CONTACT entity = new RealEstateDataContext.CONTACT();
                entity.ID = id;
                entity.Name = name;
                entity.AddressID = addressID;
                entity.Phone = phone;
                entity.HomePhone = homePhone;
                entity.Note = note;

                _db.Update(entity);
                return entity.ID;
            }
            else throw new RealEstateDataContext.Utility.ContactIDException();
        }

        /// <summary>
        /// Delete a row from CONTACT table
        /// </summary>
        /// <param name="ID">ID of row want to delete</param>
        /// <returns>ID of row just delete</returns>
        /// <exception cref="GroupIDException"></exception>
        [DataObjectMethod(DataObjectMethodType.Delete)]
        public override void Delete(int ID)
        {
            if (ValidationID(ID))
            {
                _db.Delete(ID);
            }
            else throw new RealEstateDataContext.Utility.ContactIDException();
        }

        /// <summary>
        /// Get a row in CONTACTCONTACT table
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        /// <exception cref="ContactIDException"></exception>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public override RealEstateDataContext.CONTACT GetARecord(int ID)
        {
            if (ValidationID(ID))
            {
                return _db.GetARecord(ID);
            }
            else throw new RealEstateDataContext.Utility.ContactIDException();
        }
    }
}
