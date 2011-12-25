using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Collections.ObjectModel;
using System.Net;
using System.Security.Permissions;
using System.Web.Security;
using System.Configuration;

/// <summary>
/// Summary description for RealEstateWebService
/// </summary>
[WebService(Namespace = "http://realestatemarket.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.None)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class RealEstateWebService : System.Web.Services.WebService
{

    private RealEstateBusinessLogicObject.AddressBLO address;
    private RealEstateBusinessLogicObject.CityBLO city;
    private RealEstateBusinessLogicObject.CompanyBLO company;
    private RealEstateBusinessLogicObject.CustomerBLO customer;
    private RealEstateBusinessLogicObject.DistrictBLO district;
    private RealEstateBusinessLogicObject.ImageBLO image;
    private RealEstateBusinessLogicObject.NationBLO nation;
    private RealEstateBusinessLogicObject.News_Sale_TypeBLO newsSaleType;
    private RealEstateBusinessLogicObject.News_SaleBLO newsSale;
    private RealEstateBusinessLogicObject.News_TypeBLO newsType;
    private RealEstateBusinessLogicObject.NewsBLO news;
    private RealEstateBusinessLogicObject.Project_TypeBLO projectType;
    private RealEstateBusinessLogicObject.ProjectBLO project;
    private RealEstateBusinessLogicObject.Real_Estate_TypeBLO realEstateType;
    private RealEstateBusinessLogicObject.Real_EstateBLO realEstate;
    private RealEstateBusinessLogicObject.StreetBLO street;
    private RealEstateBusinessLogicObject.Unit_PriceBLO unitPrice;
    private RealEstateBusinessLogicObject.UnitBLO unit;
    private RealEstateBusinessLogicObject.UtilityBLO utility;
    private RealEstateBusinessLogicObject.WardBLO ward;
    private RealEstateBusinessLogicObject.LegalBLO legal;
    private RealEstateBusinessLogicObject.LocationBLO location;
    private RealEstateBusinessLogicObject.ContactBLO contact;

    private RealEstateBusinessLogicObject.Customer_RealEstateBLO cusRealEstate;
    private RealEstateBusinessLogicObject.Count_RealEstateBLO countRealEstate;
    private RealEstateBusinessLogicObject.View_NewsBLO viewNews;
    private RealEstateBusinessLogicObject.ReceiptBLO receipt;

    public RealEstateWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent();

        // Initialize Component
        this.SetConnection(ConfigurationManager.ConnectionStrings["MSSQLConnectString"].ConnectionString);
        address = new RealEstateBusinessLogicObject.AddressBLO();
        city = new RealEstateBusinessLogicObject.CityBLO();
        company = new RealEstateBusinessLogicObject.CompanyBLO();
        customer = new RealEstateBusinessLogicObject.CustomerBLO();
        district = new RealEstateBusinessLogicObject.DistrictBLO();
        image = new RealEstateBusinessLogicObject.ImageBLO();
        nation = new RealEstateBusinessLogicObject.NationBLO();
        newsSaleType = new RealEstateBusinessLogicObject.News_Sale_TypeBLO();
        newsSale = new RealEstateBusinessLogicObject.News_SaleBLO();
        newsType = new RealEstateBusinessLogicObject.News_TypeBLO();
        news = new RealEstateBusinessLogicObject.NewsBLO();
        projectType = new RealEstateBusinessLogicObject.Project_TypeBLO();
        project = new RealEstateBusinessLogicObject.ProjectBLO();
        realEstateType = new RealEstateBusinessLogicObject.Real_Estate_TypeBLO();
        realEstate = new RealEstateBusinessLogicObject.Real_EstateBLO();
        street = new RealEstateBusinessLogicObject.StreetBLO();
        unitPrice = new RealEstateBusinessLogicObject.Unit_PriceBLO();
        unit = new RealEstateBusinessLogicObject.UnitBLO();
        utility = new RealEstateBusinessLogicObject.UtilityBLO();
        ward = new RealEstateBusinessLogicObject.WardBLO();
        legal = new RealEstateBusinessLogicObject.LegalBLO();
        location = new RealEstateBusinessLogicObject.LocationBLO();
        contact = new RealEstateBusinessLogicObject.ContactBLO();

        cusRealEstate = new RealEstateBusinessLogicObject.Customer_RealEstateBLO();
        countRealEstate = new RealEstateBusinessLogicObject.Count_RealEstateBLO();
        viewNews = new RealEstateBusinessLogicObject.View_NewsBLO();
        receipt = new RealEstateBusinessLogicObject.ReceiptBLO();
    }

    /// <summary>
    /// Set Connection String
    /// </summary>
    /// <param name="connection">String for connection</param>
    [WebMethod]
    public void SetConnection(string connection)
    {
        RealEstateDataContext.Utility.WebConfig.MSSQL = connection;
    }

    

    #region Address Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.ADDRESS> GetAllAddresses()
    {
        return new ObservableCollection<RealEstateDataContext.ADDRESS>(address.GetAllRows());
    }

    [WebMethod()]
    public int InsertAddress(int nationID, int cityID, int? districtID, int? wardID, int? streetID, string detail)
    {
        try
        {
            return address.Insert(nationID, cityID, districtID, wardID, streetID, detail);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateAddress(int id, int nationID, int cityID, int? districtID, int? wardID, int? streetID, string detail)
    {
        try
        {
            return address.Update(id, nationID, cityID, districtID, wardID, streetID, detail);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public void DeleteAddress(int id)
    {
        try
        {
            address.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.ADDRESS GetAddress(int id)
    {
        try
        {
            return address.GetARecord(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    #endregion

    #region City Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.CITY> GetAllCities()
    {
        return new ObservableCollection<RealEstateDataContext.CITY>(city.GetAllRows());
    }

    [WebMethod()]
    public int InsertCity(string name, int nationID)
    {
        try
        {
            return city.Insert(name, nationID);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateCity(int id, string name, int nationID)
    {
        try
        {
            return city.Update(id, name, nationID);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public void DeleteCity(int id)
    {
        try
        {
            city.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.CITY GetCity(int id)
    {
        try
        {
            return city.GetARecord(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.DISTRICT> GetDistrictsByCityID(int id)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.DISTRICT>(city.GetDistrictsByCityID(id));
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    #endregion

    #region Company Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.COMPANY> GetAllCompanies()
    {
        return new ObservableCollection<RealEstateDataContext.COMPANY>(company.GetAllRows());
    }

    [WebMethod()]
    public int InsertCompany(string name, int addressID, string phone, string homePhone,
        string fax, string email, string website, DateTime? establishDay,
        decimal? shareCapital, string fieldOfAction, bool businessRegistration,
        string description, int logo)
    {
        try
        {
            return company.Insert(name, addressID, phone, homePhone, fax, email,
                website, establishDay, shareCapital, fieldOfAction, businessRegistration,
                description, logo);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateCompany(int id, string name, int addressID, string phone, string homePhone,
        string fax, string email, string website, DateTime? establishDay,
        decimal? shareCapital, string fieldOfAction, bool businessRegistration,
        string description, int logo)
    {
        try
        {
            return company.Update(id, name, addressID, phone, homePhone, fax, email,
                website, establishDay, shareCapital, fieldOfAction, businessRegistration,
                description, logo);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public void DeleteCompany(int id)
    {
        try
        {
            company.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.COMPANY GetCompany(int id)
    {
        try
        {
            return company.GetARecord(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    #endregion

    #region Customer Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.CUSTOMER> GetAllCustomers()
    {
        return new ObservableCollection<RealEstateDataContext.CUSTOMER>(customer.GetAllRows());
    }

    [WebMethod()]
    public int InsertCustomer(string name, int addressID, string identityCard,
            string phone, string homePhone, string email, string userName)
    {
        try
        {
            return customer.Insert(name, addressID, identityCard, phone, homePhone,
                email, userName);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateCustomer(int id, string name, int addressID, string identityCard,
            string phone, string homePhone, string email, string userName)
    {
        try
        {
            return customer.Update(id, name, addressID, identityCard, phone, homePhone,
                email, userName);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public void DeleteCustomer(int id)
    {
        try
        {
            customer.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.CUSTOMER GetCustomer(int id)
    {
        try
        {
            return customer.GetARecord(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod]
    public RealEstateDataContext.CUSTOMER GetCustomerByUserName(string userName)
    {
        try
        {
            return customer.GetCustomerByUserName(userName);
        }
        catch (Exception e)
        {            
            throw e;
        }
    }

    [WebMethod]
    public void InsertRealEstateToCustomer(int realEstateID, int customerID)
    {
        try
        {
            customer.InsertRealEstateToCustomer(realEstateID, customerID);
        }
        catch (Exception e)
        {            
            throw e;
        }
    }

    //[WebMethod]
    //public ObservableCollection<RealEstateDataContext.REAL_ESTATE_TYPE> GetRealEstateTypeByCustomerID(int customerID)
    //{
    //    try
    //    {
    //        return new ObservableCollection<RealEstateDataContext.REAL_ESTATE_TYPE>(customer.GetRealEstateTypeByCustomer(customerID));
    //    }
    //    catch (Exception e)
    //    {            
    //        throw e;
    //    }
    //}
    #endregion

    #region Contact Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.CONTACT> GetAllContacts()
    {
        return new ObservableCollection<RealEstateDataContext.CONTACT>(contact.GetAllRows());
    }

    [WebMethod()]
    public int InsertContact(string name, string address, string phone, string homePhone,
            string note)
    {
        try
        {
            return contact.Insert(name, address, phone, homePhone,
                note);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateContact(int id, string name, string address, string phone, string homePhone,
            string note)
    {
        try
        {
            return contact.Update(id, name, address, phone, homePhone,
                note);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public void DeleteContact(int id)
    {
        try
        {
            contact.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.CONTACT GetContact(int id)
    {
        try
        {
            return contact.GetARecord(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    #endregion

    #region District Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.DISTRICT> GetAllDistricts()
    {
        return new ObservableCollection<RealEstateDataContext.DISTRICT>(district.GetAllRows());
    }

    [WebMethod()]
    public int InsertDistrict(string name, int cityID)
    {
        try
        {
            return district.Insert(name, cityID);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    /// <summary>
    /// Insert a record to DISTRICT_DETAIL table
    /// </summary>
    /// <param name="districtID">District's ID</param>
    /// <param name="streetID">Street's ID</param>
    /// <returns>ID of record has inserted</returns>
    [WebMethod]
    public int InsertDistrictDetail(int districtID, int streetID)
    {
        try
        {
            return district.InsertDistrictDetail(districtID, streetID);
        }
        catch (Exception e)
        {            
            throw e;
        }
    }
    [WebMethod()]
    public int UpdateDistrict(int id, string name, int cityID)
    {
        try
        {
            return district.Update(id, name, cityID);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public void DeleteDistrict(int id)
    {
        try
        {
            district.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.DISTRICT GetDistrict(int id)
    {
        try
        {
            return district.GetARecord(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.STREET> GetStreetsByDistrictID(int id)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.STREET>(district.GetStreetsByDistrictID(id));
        }
        catch (Exception e)
        {            
            throw e;
        }
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.STREET> GetStreetsNotInDistrict(int id)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.STREET>(district.GetStreetsNotInDistrict(id));
        }
        catch (Exception e)
        {            
            throw e;
        }
    }
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.WARD> GetWardsByDistrictID(int id)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.WARD>(district.GetWardsByDistrictID(id));
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    #endregion

    #region Image Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.IMAGE> GetAllImages()
    {
        return new ObservableCollection<RealEstateDataContext.IMAGE>(image.GetAllRows());
    }

    [WebMethod()]
    public int InsertImage(string name, string path, string description)
    {
        try
        {
            return image.Insert(name, path, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateImage(int id, string name, string path, string description)
    {
        try
        {
            return image.Update(id, name, path, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public void DeleteImage(int id)
    {
        try
        {
            image.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.IMAGE GetImage(int id)
    {
        try
        {
            return image.GetARecord(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    
    #endregion

    #region Legal Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.LEGAL> GetAllLegals()
    {
        return new ObservableCollection<RealEstateDataContext.LEGAL>(legal.GetAllRows());
    }

    [WebMethod()]
    public int InsertLegal(string name, string description)
    {
        try
        {
            return legal.Insert(name, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateLegal(int id, string name, string description)
    {
        try
        {
            return legal.Update(id, name, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public void DeleteLegal(int id)
    {
        try
        {
            legal.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.LEGAL GetLegal(int id)
    {
        try
        {
            return legal.GetARecord(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    #endregion

    #region Location Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.LOCATION> GetAllLocations()
    {
        return new ObservableCollection<RealEstateDataContext.LOCATION>(location.GetAllRows());
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.LOCATION> GetFullLocations()
    {
        ObservableCollection<RealEstateDataContext.LOCATION> result = new ObservableCollection<RealEstateDataContext.LOCATION>(location.GetAllRows());
        result.Remove(new RealEstateBusinessLogicObject.LocationBLO().GetARecord(0));
        return result;
    }

    [WebMethod()]
    public int InsertLocation(string name, string description)
    {
        try
        {
            return location.Insert(name, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateLocation(int id, string name, string description)
    {
        try
        {
            return location.Update(id, name, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public void DeleteLocation(int id)
    {
        try
        {
            location.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.LOCATION GetLocation(int id)
    {
        try
        {
            return location.GetARecord(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    #endregion

    #region Nation Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.NATION> GetAllNations()
    {
        return new ObservableCollection<RealEstateDataContext.NATION>(nation.GetAllRows());
    }

    [WebMethod]
    public int InsertNation(string name, string nationCode)
    {
        try
        {
            return nation.Insert(name, nationCode);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod]
    public int UpdateNation(int id, string name, string nationCode)
    {
        try
        {
            return nation.Update(id, name, nationCode);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod]
    public void DeleteNation(int id)
    {
        try
        {
            nation.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod]
    public RealEstateDataContext.NATION GetNation(int id)
    {
        try
        {
            return nation.GetARecord(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.CITY> GetCitiesByNationID(int id)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.CITY>(nation.GetCitiesByNationID(id));
        }
        catch (Exception e)
        {            
            throw e;
        }
    }
    #endregion

    #region News Sale Type Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.NEWS_SALE_TYPE> GetAllNewsSaleTypes()
    {
        return new ObservableCollection<RealEstateDataContext.NEWS_SALE_TYPE>(newsSaleType.GetAllRows());
    }

    [WebMethod()]
    public int InsertNewsSaleType(string name, string description)
    {
        try
        {
            return newsSaleType.Insert(name, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateNewsSaleType(int id, string name, string description)
    {
        try
        {
            return newsSaleType.Update(id, name, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public void DeleteNewsSaleType(int id)
    {
        try
        {
            newsSaleType.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.NEWS_SALE_TYPE GetNewsSaleType(int id)
    {
        try
        {
            return newsSaleType.GetARecord(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    #endregion

    #region News Sale Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.NEWS_SALE> GetAllNewsSales()
    {
        return new ObservableCollection<RealEstateDataContext.NEWS_SALE>(newsSale.GetAllRows());
    }
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.NEWS_SALE> GetAllNewsSalesPosted()
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.NEWS_SALE>(newsSale.GetAllRowsPosted());
        }
        catch (Exception e)
        {            
            throw e;
        }
    }

    [WebMethod()]
    public int InsertNewsSale(int typeID, string title, string content,
            int realEstateID, int? rate, DateTime updateTime, int status, bool broker)
    {
        try
        {
            return newsSale.Insert(typeID, title, content, realEstateID, rate,
                updateTime, status, broker);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateNewsSale(int id, int typeID, string title, string content,
            int realEstateID, int? rate, DateTime updateTime, int status, bool broker)
    {
        try
        {
            return newsSale.Update(id, typeID, title, content, realEstateID, rate,
                updateTime, status, broker);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod]
    public void UpdateNewsSaleStatus(int id, int status)
    {
        try
        {
            newsSale.UpdateStatus(id, status);
        }
        catch (Exception e)
        {            
            throw e;
        }
    }
    [WebMethod()]
    public void DeleteNewsSale(int id)
    {
        try
        {
            newsSale.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.NEWS_SALE GetNewsSale(int id)
    {
        try
        {
            return newsSale.GetARecord(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.NEWS_SALE> GetNewsSalesByTypeID(int typeID)
    {
        if (typeID == 0)
        {
            return new ObservableCollection<RealEstateDataContext.NEWS_SALE>(newsSale.GetAllRows());
        }
        return new ObservableCollection<RealEstateDataContext.NEWS_SALE>(newsSaleType.GetNewsSalesByTypeID(typeID));
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.NEWS_SALE> GetNewsSalesByRealEstateTypeID(int realEstateTypeID)
    {
        return new ObservableCollection<RealEstateDataContext.NEWS_SALE>(realEstateType.GetNewsSalesByRealEstateTypeID(realEstateTypeID));
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.NEWS_SALE> GetNewsSalesByPrice(decimal from, decimal to)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.NEWS_SALE>(newsSale.GetNewsSalesByPrice(from, to));
        }
        catch (Exception e)
        {            
            throw e;
        }
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.NEWS_SALE> GetNewsSalesByTotalUseArea(double from, double to)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.NEWS_SALE>(newsSale.GetNewsSalesByTotalUseArea(from, to));
        }
        catch (Exception e)
        {            
            throw e;
        }
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.NEWS_SALE> GetNewsSalesByProjectID(int projectID)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.NEWS_SALE>(newsSale.GetNewsSalesByProjectID(projectID));
        }
        catch (Exception e)
        {            
            throw e;
        }
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.NEWS_SALE> GetNewsSalesByRealEstateLocation(int locationID)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.NEWS_SALE>(newsSale.GetNewsSalesByRealEstateLocation(locationID));
        }
        catch (Exception e)
        {            
            throw e;
        }
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.NEWS_SALE> GetNewsSaleByBedRoom(int from, int to)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.NEWS_SALE>(newsSale.GetNewsSaleByBedRoom(from, to));
        }
        catch (Exception e)
        {            
            throw e;
        }
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.NEWS_SALE> GetNewsSaleByDirection(string direction)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.NEWS_SALE>(newsSale.GetNewsSaleByDirection(direction));
        }
        catch (Exception e)
        {            
            throw e;
        }
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.NEWS_SALE> GetNewsSaleByMainOwner()
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.NEWS_SALE>(newsSale.GetNewsSaleByMainOwner());
        }
        catch (Exception e)
        {            
            throw e;
        }
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.NEWS_SALE> SearchNewsSaleByKeyword(string keyword)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.NEWS_SALE>(newsSale.SearchNewsSaleByKeyword(keyword));
        }
        catch (Exception e)
        {            
            throw e;
        }
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.NEWS_SALE> SearchNewsSaleByKeywordInList(string keyword, ObservableCollection<RealEstateDataContext.NEWS_SALE> listNewsSale)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.NEWS_SALE>(newsSale.SearchNewsSaleByKeyword(keyword, listNewsSale));
        }
        catch (Exception e)
        {            
            throw e;
        }
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.NEWS_SALE> SearchNewsSaleByCityID(int cityID, ObservableCollection<RealEstateDataContext.NEWS_SALE> listNewsSale)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.NEWS_SALE>(newsSale.SearchNewsSaleByCityID(cityID, listNewsSale));
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.NEWS_SALE> SearchNewsSaleByTypeID(int typeID, ObservableCollection<RealEstateDataContext.NEWS_SALE> listNewsSale)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.NEWS_SALE>(newsSale.SearchNewsSaleByTypeID(typeID, listNewsSale));
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.NEWS_SALE> SearchNewsSaleByRealEstateTypeID(int realEstateTypeID, ObservableCollection<RealEstateDataContext.NEWS_SALE> listNewsSale)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.NEWS_SALE>(newsSale.SearchNewsSaleByRealEstateTypeID(realEstateTypeID, listNewsSale));
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.NEWS_SALE> SearchNewsSaleByPrice(decimal from, decimal to, ObservableCollection<RealEstateDataContext.NEWS_SALE> listNewsSale)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.NEWS_SALE>(newsSale.SearchNewsSaleByPrice(from, to, listNewsSale));
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    
    #endregion

    #region News Type Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.NEWS_TYPE> GetAllNewsTypes()
    {
        return new ObservableCollection<RealEstateDataContext.NEWS_TYPE>(newsType.GetAllRows());
    }

    [WebMethod()]
    public int InsertNewsType(string name, string description)
    {
        try
        {
            return newsType.Insert(name, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateNewsType(int id, string name, string description)
    {
        try
        {
            return newsType.Update(id, name, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public void DeleteNewsType(int id)
    {
        try
        {
            newsType.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.NEWS_TYPE GetNewsType(int id)
    {
        try
        {
            return newsType.GetARecord(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    #endregion

    #region News Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.NEW> GetAllNews()
    {
        return new ObservableCollection<RealEstateDataContext.NEW>(news.GetAllRows());
    }

    [WebMethod()]
    public ObservableCollection<RealEstateDataContext.NEW> GetAllNewsNum(int from, int number)
    {
        return new ObservableCollection<RealEstateDataContext.NEW>(news.GetRows(from, number));
    }

    [WebMethod()]
    public ObservableCollection<RealEstateDataContext.NEW> GetAllNewsCheck(int from, int number, bool check)
    {
        return new ObservableCollection<RealEstateDataContext.NEW>(news.GetRows(from, number, check));
    }

    [WebMethod()]
    public int InsertNews(int typeID, string title, string descript, string content,
            string author, int? rate, DateTime publishTime, DateTime editTime, int imageID, bool check)
    {
        try
        {
            return news.Insert(typeID, title, descript, content, author, rate,
                publishTime, editTime, imageID, check);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateNews(int id, int typeID, string title, string descript, string content,
            string author, int? rate, DateTime publishTime, DateTime editTime, int imageID, bool check)
    {
        try
        {
            return news.Update(id, typeID, title, descript, content, author, rate,
                publishTime, editTime, imageID, check, 0);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public void DeleteNews(int id)
    {
        try
        {
            news.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.NEW GetNews(int id)
    {
        try
        {
            return news.GetARecord(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod]
    public string GetSummary(int id)
    {
        try
        {
            return news.GetSummary(id);
        }
        catch (Exception e)
        {            
            throw e;
        }
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.NEW> GetNewsByTypeID(int id)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.NEW>(news.GetNewsByTypeID(id));
        }
        catch (Exception e)
        {            
            throw e;
        }
    }

    [WebMethod()]
    public ObservableCollection<RealEstateDataContext.NEW> GetNewsByTypeIDNum(int from, int number, int id)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.NEW>(news.GetNewsByTypeID(from, number, id));
        }
        catch (Exception e)
        {

            throw e;
        }
    }
    [WebMethod()]
    public ObservableCollection<RealEstateDataContext.NEW> GetNewsByTypeIDNumCheck(int from, int number, bool check, int id)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.NEW>(news.GetNewsByTypeID(from, number, check, id));
        }
        catch (Exception e)
        {

            throw e;
        }
    }
    [WebMethod()]
    public int GetNewsByTypeIDCount(int id)
    {
        try
        {
            return news.GetNewsByTypeID(id).Count;
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    [WebMethod()]
    public void UpdateNewsNumView(int id)
    {
        try
        {
            news.IncreaseView(id);
        }
        catch (Exception e)
        {

            throw e;
        }
    }
    [WebMethod()]
    public ObservableCollection<RealEstateDataContext.NEW> GetNewsTopView(int number)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.NEW>(news.GetNewsTopView(number));
        }
        catch (Exception e)
        {

            throw e;
        }
    }
    [WebMethod()]
    public ObservableCollection<RealEstateDataContext.NEW> GetNewsTopPopular(int number)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.NEW>(news.GetNewsTopPopular(number));
        }
        catch (Exception e)
        {

            throw e;
        }
    }
    [WebMethod()]
    public ObservableCollection<RealEstateDataContext.NEW> GetMoreNews(int? oldID, int from, int number, int? typeID)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.NEW>(news.GetMoreNews(oldID, from, number, typeID));
        }
        catch (Exception e)
        {

            throw e;
        }
    }
    [WebMethod()]
    public void UpdateNewsCheck(int id, bool check)
    {
        try
        {
            news.UpdateCheck(id, check);
        }
        catch (Exception e)
        {

            throw e;
        }
    }
    [WebMethod()]
    public ObservableCollection<RealEstateDataContext.NEW> SearchNews(String keyword)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.NEW>(news.SearchNews(keyword));
        }
        catch (Exception e)
        {

            throw e;
        }
    }
    #endregion

    #region Project Type Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.PROJECT_TYPE> GetAllProjectTypes()
    {
        return new ObservableCollection<RealEstateDataContext.PROJECT_TYPE>(projectType.GetAllRows());
    }

    [WebMethod()]
    public int InsertProjectType(string name, string description)
    {
        try
        {
            return projectType.Insert(name, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateProjectType(int id, string name, string description)
    {
        try
        {
            return projectType.Update(id, name, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public void DeleteProjectType(int id)
    {
        try
        {
            projectType.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.PROJECT_TYPE GetProjectType(int id)
    {
        try
        {
            return projectType.GetARecord(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    #endregion

    #region Project Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.PROJECT> GetAllProjects()
    {
        return new ObservableCollection<RealEstateDataContext.PROJECT>(project.GetAllRows());
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.PROJECT> GetFullProjects()
    {
        ObservableCollection<RealEstateDataContext.PROJECT> result = new ObservableCollection<RealEstateDataContext.PROJECT>(project.GetAllRows());
        result.Remove(new RealEstateBusinessLogicObject.ProjectBLO().GetARecord(0));
        return result;
    }

    [WebMethod()]
    public int InsertProject(int typeID, string name, DateTime? beginDay,
        int addressID, string summary, string description, int imageID)
    {
        try
        {
            return project.Insert(typeID, name, beginDay, addressID, summary, description, imageID);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateProject(int id, int typeID, string name, DateTime? beginDay,
        int addressID, string summary, string description, int imageID)
    {
        try
        {
            return project.Update(id, typeID, name, beginDay, addressID, summary, description, imageID);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public void DeleteProject(int id)
    {
        try
        {
            project.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.PROJECT GetProject(int id)
    {
        try
        {
            return project.GetARecord(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.PROJECT> GetProjectsByDistrictID(int districtID)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.PROJECT>(project.GetProjectsByDistrictID(districtID));
        }
        catch (Exception e)
        {            
            throw e;
        }
    }

    [WebMethod]
    public string GetSummaryProject(int id)
    {
        try
        {
            return project.GetSummary(id);
        }
        catch (Exception e)
        {            
            throw e;
        }
    }
    #endregion

    #region Real Estate Type Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.REAL_ESTATE_TYPE> GetAllRealEstateTypes()
    {
        return new ObservableCollection<RealEstateDataContext.REAL_ESTATE_TYPE>(realEstateType.GetAllRows());
    }

    [WebMethod()]
    public int InsertRealEstateType(string name, string description)
    {
        try
        {
            return realEstateType.Insert(name, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateRealEstateType(int id, string name, string description)
    {
        try
        {
            return realEstateType.Update(id, name, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public void DeleteRealEstateType(int id)
    {
        try
        {
            realEstateType.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.REAL_ESTATE_TYPE GetRealEstateType(int id)
    {
        try
        {
            return realEstateType.GetARecord(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    #endregion

    #region Real Estate Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.REAL_ESTATE> GetAllRealEstates()
    {
        return new ObservableCollection<RealEstateDataContext.REAL_ESTATE>(realEstate.GetAllRows());
    }

    [WebMethod()]
    public int InsertRealEstate(int typeID, int addressID, int? livingRoom,
            int? bedRoom, int? bathRoom, int? differentRoom, int? storey, double? totalUseArea,
            double? campusFront, double? campusBehind, double? campusLength,
            double? buildFront, double? buildBehind, double? buildLength,
            int? legalID, string direction, string frontStreet, int? locationID,
            decimal price, int unitID, int unitPriceID, int? projectID, int? contactID)
    {
        try
        {
            return realEstate.Insert(typeID, addressID, livingRoom, bedRoom, bathRoom, differentRoom,
                storey, totalUseArea, campusFront, campusBehind, campusLength,
                buildFront, buildBehind, buildLength, legalID, direction, frontStreet,
                locationID, price, unitID, unitPriceID, projectID, contactID);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateRealEstate(int id, int typeID, int addressID, int? livingRoom,
            int? bedRoom, int? bathRoom, int? differentRoom, int? storey, double? totalUseArea,
            double? campusFront, double? campusBehind, double? campusLength,
            double? buildFront, double? buildBehind, double? buildLength,
            int? legalID, string direction, string frontStreet, int? locationID,
            decimal price, int unitID, int unitPriceID, int? projectID, int? contactID)
    {
        try
        {
            return realEstate.Update(id, typeID, addressID, livingRoom, bedRoom, bathRoom, differentRoom,
                storey, totalUseArea, campusFront, campusBehind, campusLength,
                buildFront, buildBehind, buildLength, legalID, direction, frontStreet,
                locationID, price, unitID, unitPriceID, projectID, contactID);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public void DeleteRealEstate(int id)
    {
        try
        {
            realEstate.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.REAL_ESTATE GetRealEstate(int id)
    {
        try
        {
            return realEstate.GetARecord(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    [WebMethod]
    public void InsertImageToRealEstate(int imageID, int realEstateID)
    {
        try
        {
            realEstate.InsertImageToRealEstate(imageID, realEstateID);
        }
        catch (Exception e)
        {            
            throw e;
        }
    }

    [WebMethod]
    public void InsertUtilityToRealEstate(int utilityID, int realEstateID)
    {
        try
        {
            realEstate.InsertUtilityToRealEstate(utilityID, realEstateID);
        }
        catch (Exception e)
        {            
            throw e;
        }
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.UTILITY> GetUtilitiesByRealEstateID(int realEstateID)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.UTILITY>(realEstate.GetUtilitiesByRealEstateID(realEstateID));
        }
        catch (Exception e)
        {            
            throw e;
        }
    }

    [WebMethod]
    public RealEstateDataContext.CUSTOMER GetCustomerByRealEstateID(int realEstateID)
    {
        try
        {
            return realEstate.GetCustomerByRealEstateID(realEstateID);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod]
    public ObservableCollection<RealEstateDataContext.IMAGE> GetImagesByRealEstateID(int realEstateID)
    {
        try
        {
            return new ObservableCollection<RealEstateDataContext.IMAGE>(realEstate.GetImagesByRealEstateID(realEstateID));
        }
        catch (Exception e) 
        {            
            throw e;
        }
    }

    [WebMethod]
    public RealEstateDataContext.REAL_ESTATE_TYPE GetRealEstateTypeByRealEstateID(int realEstateID)
    {
        try
        {
            return realEstate.GetRealEstateTypeByRealEstateID(realEstateID);
        }
        catch (Exception e)
        {            
            throw e;
        }
    }

    [WebMethod]
    public void RemoveAllUtilitiesByRealEstateID(int realEstateID)
    {
        try
        {
            realEstate.RemoveAllUtilitiesByRealEstateID(realEstateID);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    #endregion
    
    #region Street Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.STREET> GetAllStreets()
    {
        return new ObservableCollection<RealEstateDataContext.STREET>(street.GetAllRows());
    }

    [WebMethod()]
    public int InsertStreet(string name)
    {
        try
        {
            return street.Insert(name);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateStreet(int id, string name)
    {
        try
        {
            return street.Update(id, name);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public void DeleteStreet(int id)
    {
        try
        {
            street.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.STREET GetStreet(int id)
    {
        try
        {
            return street.GetARecord(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    #endregion

    #region Unit Price Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.UNIT_PRICE> GetAllUnitPrices()
    {
        return new ObservableCollection<RealEstateDataContext.UNIT_PRICE>(unitPrice.GetAllRows());
    }

    [WebMethod()]
    public int InsertUnitPrice(string name, string description)
    {
        try
        {
            return unitPrice.Insert(name, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateUnitPrice(int id, string name, string description)
    {
        try
        {
            return unitPrice.Update(id, name, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public void DeleteUnitPrice(int id)
    {
        try
        {
            unitPrice.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.UNIT_PRICE GetUnitPrice(int id)
    {
        try
        {
            return unitPrice.GetARecord(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    #endregion

    #region Unit Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.UNIT> GetAllUnits()
    {
        return new ObservableCollection<RealEstateDataContext.UNIT>(unit.GetAllRows());
    }

    [WebMethod()]
    public int InsertUnit(string name, string description)
    {
        try
        {
            return unit.Insert(name, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateUnit(int id, string name, string description)
    {
        try
        {
            return unit.Update(id, name, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public void DeleteUnit(int id)
    {
        try
        {
            unit.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.UNIT GetUnit(int id)
    {
        try
        {
            return unit.GetARecord(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    #endregion
    
    #region Utility Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.UTILITY> GetAllUtilities()
    {
        return new ObservableCollection<RealEstateDataContext.UTILITY>(utility.GetAllRows());
    }

    [WebMethod()]
    public int InsertUtility(string name, string description)
    {
        try
        {
            return utility.Insert(name, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateUtility(int id, string name, string description)
    {
        try
        {
            return utility.Update(id, name, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public void DeleteUtility(int id)
    {
        try
        {
            utility.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.UTILITY GetUtility(int id)
    {
        try
        {
            return utility.GetARecord(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    #endregion

    #region Ward Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.WARD> GetAllWards()
    {
        return new ObservableCollection<RealEstateDataContext.WARD>(ward.GetAllRows());
    }

    [WebMethod()]
    public int InsertWard(string name, int districtID)
    {
        try
        {
            return ward.Insert(name, districtID);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateWard(int id, string name, int districtID)
    {
        try
        {
            return ward.Update(id, name, districtID);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public void DeleteWard(int id)
    {
        try
        {
            ward.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.WARD GetWard(int id)
    {
        try
        {
            return ward.GetARecord(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }
    #endregion

    #region Parameter Service
    [WebMethod]
    public int GetParameter(string key)
    {
        return Convert.ToInt32(new RealEstateBusinessLogicObject.Parameter().GetARecord(key).Value);
    }
    
    [WebMethod]
    public int GetParameter_MinRate()
    {
        return RealEstateBusinessLogicObject.Parameter.MinRate;
    }

    [WebMethod]
    public int GetParameter_MaxRate()
    {
        return RealEstateBusinessLogicObject.Parameter.MaxRate;
    }

    [WebMethod]
    public int GetParameter_MaxSummaryLength()
    {
        return RealEstateBusinessLogicObject.Parameter.MaxSummaryLength;
    }

    [WebMethod]
    public int GetParameter_StreetHouse()
    {
        return RealEstateBusinessLogicObject.Parameter.StreetHouse;
    }

    [WebMethod]
    public int GetParameter_TempHouse()
    {
        return RealEstateBusinessLogicObject.Parameter.TempHouse;
    }

    [WebMethod]
    public int GetParameter_Villa()
    {
        return RealEstateBusinessLogicObject.Parameter.Villa;
    }

    [WebMethod]
    public int GetParameter_LuxuryApartment()
    {
        return RealEstateBusinessLogicObject.Parameter.LuxuryApartment;
    }

    [WebMethod]
    public int GetParameter_Apartment()
    {
        return RealEstateBusinessLogicObject.Parameter.Apartment;
    }

    [WebMethod]
    public int GetParameter_Office()
    {
        return RealEstateBusinessLogicObject.Parameter.Office;
    }

    [WebMethod]
    public int GetParameter_ProductionLand()
    {
        return RealEstateBusinessLogicObject.Parameter.ProductionLand;
    }

    [WebMethod]
    public int GetParameter_ProjectLand()
    {
        return RealEstateBusinessLogicObject.Parameter.ProjectLand;
    }

    [WebMethod]
    public int GetParameter_ForestLand()
    {
        return RealEstateBusinessLogicObject.Parameter.ForestLand;
    }

    [WebMethod]
    public int GetParameter_AgriculturalLand()
    {
        return RealEstateBusinessLogicObject.Parameter.AgriculturalLand;
    }

    [WebMethod]
    public int GetParameter_StayLand()
    {
        return RealEstateBusinessLogicObject.Parameter.StayLand;
    }

    [WebMethod]
    public int GetParameter_Store()
    {
        return RealEstateBusinessLogicObject.Parameter.Store;
    }

    [WebMethod]
    public int GetParameter_Restaurant()
    {
        return RealEstateBusinessLogicObject.Parameter.Restaurant;
    }

    [WebMethod]
    public int GetParameter_Other()
    {
        return RealEstateBusinessLogicObject.Parameter.Other;
    }

    [WebMethod]
    public int GetParameter_Renting()
    {
        return RealEstateBusinessLogicObject.Parameter.Renting;
    }
    #endregion

    #region Customer Estate Service

    [WebMethod()]
    public ObservableCollection<RealEstateDataContext.CUSTOMER_REALESTATE> GetAllCusReal()
    {
        return new ObservableCollection<RealEstateDataContext.CUSTOMER_REALESTATE>(cusRealEstate.GetAll());
    }

    #endregion

    #region Count Real_Estate Service

    [WebMethod()]
    public ObservableCollection<RealEstateDataContext.COUNT_REALESTATE> GetAllCountReal(int month, int year)
    {
        return new ObservableCollection<RealEstateDataContext.COUNT_REALESTATE>(countRealEstate.GetAllByDate(month, year));
    }

    #endregion

    #region View News Service

    [WebMethod()]
    public ObservableCollection<RealEstateDataContext.VIEW_NEWS> GetAllMostNews()
    {
        return new ObservableCollection<RealEstateDataContext.VIEW_NEWS>(viewNews.GetAll());
    }

    #endregion

    #region Receipt Service

    [WebMethod()]
    public ObservableCollection<RealEstateDataContext.RECEIPT> GetReceiptByDate(int month, int year)
    {
        return new ObservableCollection<RealEstateDataContext.RECEIPT>(receipt.GetAllByDate(month, year));
    }

    #endregion
}
