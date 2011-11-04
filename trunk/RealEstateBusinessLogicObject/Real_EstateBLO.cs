using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace RealEstateBusinessLogicObject
{
    public class Real_EstateBLO : BusinessParent<RealEstateDataContext.REAL_ESTATE>
    {
        /// <summary>
        /// Contructor
        /// </summary>
        /// <summary>
        /// Contructor
        /// </summary>
        public Real_EstateBLO()
        {
            _db = new RealEstateDataAccessObject.Real_EstateDAO();
        }

        /// <summary>
        /// Get all row in table REAL_ESTATE
        /// </summary>
        /// <returns>List of entities</returns>
        public override ICollection<RealEstateDataContext.REAL_ESTATE> GetAllRows()
        {
            return base.GetAllRows();
        }

        /// <summary>
        /// Insert a row into REAL_ESTATE table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row has just inserted</returns>
        public override int Insert(RealEstateDataContext.REAL_ESTATE entity)
        {
            entity.ID = _db.CreateID();
            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Insert a row into REAL_ESTATE table
        /// </summary>
        /// <param name="typeID">ID of type</param>
        /// <param name="addressID">ID of address</param>
        /// <param name="livingRoom">Number of living room</param>
        /// <param name="bedRoom">Number of bed room</param>
        /// <param name="bathRoom">Number of bath room</param>
        /// <param name="storey">Number of storey (floor)</param>
        /// <param name="totalUseArea">Total use area</param>
        /// <param name="campusFront">Size in front of campus</param>
        /// <param name="campusBehind">Size in behind of campus</param>
        /// <param name="campusLength">Length of campus</param>
        /// <param name="buildFront">Size in front of build area</param>
        /// <param name="buildBehind">Size in behind of build area</param>
        /// <param name="buildLength">Length of build area</param>
        /// <param name="legal">Real estate's legal</param>
        /// <param name="direction">Real estate's direction</param>
        /// <param name="frontStreet">Front street</param>
        /// <param name="location">Location</param>
        /// <param name="price">Price</param>
        /// <param name="unitID">ID of unit</param>
        /// <param name="unitPriceID">ID of unit price</param>
        /// <param name="projectID">ID of project</param>
        /// <param name="contactID">ID of contact</param>
        /// <returns>ID of row has just inserted</returns>
        public int Insert(int typeID, int addressID, int? livingRoom,
            int? bedRoom, int? bathRoom, int? storey, double? totalUseArea,
            double? campusFront, double? campusBehind, double? campusLength,
            double? buildFront, double? buildBehind, double? buildLength,
            string legal, string direction, string frontStreet, string location,
            decimal price, int unitID, int unitPriceID, int? projectID, int? contactID)
        {
            RealEstateDataContext.REAL_ESTATE entity = new RealEstateDataContext.REAL_ESTATE();
            entity.ID = _db.CreateID();
            entity.TypeID = typeID;
            entity.AddressID = addressID;
            entity.LivingRoom = livingRoom;
            entity.BedRoom = bedRoom;
            entity.BathRoom = bathRoom;
            entity.Storey = storey;
            entity.TotalUseArea = totalUseArea;
            entity.CampusFront = campusFront;
            entity.CampusBehind = campusBehind;
            entity.CampusLength = campusLength;
            entity.BuildFront = buildFront;
            entity.BuildBehind = buildBehind;
            entity.BuildLength = buildLength;
            entity.Legal = legal;
            entity.Direction = direction;
            entity.FrontStreet = frontStreet;
            entity.Location = location;
            entity.Price = price;
            entity.UnitID = unitID;
            entity.UnitPriceID = unitPriceID;
            entity.ProjectID = projectID;
            entity.ContactID = contactID;

            _db.Insert(entity);
            return entity.ID;
        }

        /// <summary>
        /// Update a row in REAL_ESTATE table
        /// </summary>
        /// <param name="entity">Entity</param>
        /// <returns>ID of row has just updated</returns>
        public override int Update(RealEstateDataContext.REAL_ESTATE entity)
        {
            _db.Update(entity);
            return entity.ID;
        }

        /// <summary>
        /// Update a row in REAL_ESTATE table
        /// </summary>
        /// <param name="id">ID of row</param>
        /// <param name="typeID">ID of type</param>
        /// <param name="addressID">ID of address</param>
        /// <param name="livingRoom">Number of living room</param>
        /// <param name="bedRoom">Number of bed room</param>
        /// <param name="bathRoom">Number of bath room</param>
        /// <param name="storey">Number of storey (floor)</param>
        /// <param name="totalUseArea">Total use area</param>
        /// <param name="campusFront">Size in front of campus</param>
        /// <param name="campusBehind">Size in behind of campus</param>
        /// <param name="campusLength">Length of campus</param>
        /// <param name="buildFront">Size in front of build area</param>
        /// <param name="buildBehind">Size in behind of build area</param>
        /// <param name="buildLength">Length of build area</param>
        /// <param name="legal">Real estate's legal</param>
        /// <param name="direction">Real estate's direction</param>
        /// <param name="frontStreet">Front street</param>
        /// <param name="location">Location</param>
        /// <param name="price">Price</param>
        /// <param name="unitID">ID of unit</param>
        /// <param name="unitPriceID">ID of unit price</param>
        /// <param name="projectID">ID of project</param>
        /// <param name="contactID">ID of contact</param>
        /// <returns>ID of row has just updated</returns>
        public int Update(int id, int typeID, int addressID, int? livingRoom,
            int? bedRoom, int? bathRoom, int? storey, double? totalUseAre,
            double? campusFront, double? campusBehind, double? campusLength,
            double? buildFront, double? buildBehind, double? buildLength,
            string legal, string direction, string frontStreet, string location,
            decimal price, int unitID, int unitPriceID, int? projectID, int? contactID)
        {
            RealEstateDataContext.REAL_ESTATE entity = new RealEstateDataContext.REAL_ESTATE();
            entity.ID = id;
            entity.TypeID = typeID;
            entity.AddressID = addressID;
            entity.LivingRoom = livingRoom;
            entity.BedRoom = bedRoom;
            entity.BathRoom = bathRoom;
            entity.Storey = storey;
            entity.TotalUseArea = totalUseAre;
            entity.CampusFront = campusFront;
            entity.CampusBehind = campusBehind;
            entity.CampusLength = campusLength;
            entity.BuildFront = buildFront;
            entity.BuildBehind = buildBehind;
            entity.BuildLength = buildLength;
            entity.Legal = legal;
            entity.Direction = direction;
            entity.FrontStreet = frontStreet;
            entity.Location = location;
            entity.Price = price;
            entity.UnitID = unitID;
            entity.UnitPriceID = unitPriceID;
            entity.ProjectID = projectID;
            entity.ContactID = contactID;

            _db.Update(entity);
            return entity.ID;
        }

        /// <summary>
        /// Delete a row from REAL_ESTATE table
        /// </summary>
        /// <param name="ID">ID of row want to delete</param>
        /// <returns>ID of row has just deleted</returns>
        public override void Delete(int ID)
        {
            _db.Delete(ID);
        }

        /// <summary>
        /// Get a row in REAL_ESTATE table
        /// </summary>
        /// <param name="ID">ID of row</param>
        /// <returns>Entity</returns>
        public override RealEstateDataContext.REAL_ESTATE GetARecord(int ID)
        {
            return _db.GetARecord(ID);
        }

    }
}
