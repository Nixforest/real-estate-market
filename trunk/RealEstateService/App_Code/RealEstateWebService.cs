using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Collections.ObjectModel;
using System.Net;

/// <summary>
/// Summary description for RealEstateWebService
/// </summary>
[WebService(Namespace = "http://realestatemarket.com/")]
[WebServiceBinding(ConformsTo = WsiProfiles.None)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class RealEstateWebService : System.Web.Services.WebService
{

    private RealEstateBusinessLogicObject.AddressBLO address;
    private RealEstateBusinessLogicObject.CityBLO city;
    private RealEstateBusinessLogicObject.CompanyBLO company;
    private RealEstateBusinessLogicObject.CustomerBLO customer;
    private RealEstateBusinessLogicObject.DistrictBLO district;
    private RealEstateBusinessLogicObject.GroupBLO group;
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
    private RealEstateBusinessLogicObject.RuleBLO rule;
    private RealEstateBusinessLogicObject.StreetBLO street;
    private RealEstateBusinessLogicObject.Unit_PriceBLO unitPrice;
    private RealEstateBusinessLogicObject.UnitBLO unit;
    private RealEstateBusinessLogicObject.UserBLO user;
    private RealEstateBusinessLogicObject.UtilityBLO utility;
    private RealEstateBusinessLogicObject.WardBLO ward;
    private RealEstateBusinessLogicObject.LegalBLO legal;
    private RealEstateBusinessLogicObject.LocationBLO location;

    public RealEstateWebService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent();

        // Initialize Component
        address = new RealEstateBusinessLogicObject.AddressBLO();
        city = new RealEstateBusinessLogicObject.CityBLO();
        company = new RealEstateBusinessLogicObject.CompanyBLO();
        customer = new RealEstateBusinessLogicObject.CustomerBLO();
        district = new RealEstateBusinessLogicObject.DistrictBLO();
        group = new RealEstateBusinessLogicObject.GroupBLO();
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
        rule = new RealEstateBusinessLogicObject.RuleBLO();
        street = new RealEstateBusinessLogicObject.StreetBLO();
        unitPrice = new RealEstateBusinessLogicObject.Unit_PriceBLO();
        unit = new RealEstateBusinessLogicObject.UnitBLO();
        user = new RealEstateBusinessLogicObject.UserBLO();
        utility = new RealEstateBusinessLogicObject.UtilityBLO();
        ward = new RealEstateBusinessLogicObject.WardBLO();
        legal = new RealEstateBusinessLogicObject.LegalBLO();
        location = new RealEstateBusinessLogicObject.LocationBLO();
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
            string phone, string homePhone, string email, int? userID)
    {
        try
        {
            return customer.Insert(name, addressID, identityCard, phone, homePhone,
                email, userID);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateCustomer(int id, string name, int addressID, string identityCard,
            string phone, string homePhone, string email, int? userID)
    {
        try
        {
            return customer.Update(id, name, addressID, identityCard, phone, homePhone,
                email, userID);
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
            city.Delete(id);
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

    #region Group Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.GROUP> GetAllGroups()
    {
        return new ObservableCollection<RealEstateDataContext.GROUP>(group.GetAllRows());
    }

    [WebMethod()]
    public int InsertGroup(string name, string description)
    {
        try
        {
            return group.Insert(name, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateGroup(int id, string name, string description)
    {
        try
        {
            return group.Update(id, name, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public void DeleteGroup(int id)
    {
        try
        {
            group.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.GROUP GetGroup(int id)
    {
        try
        {
            return group.GetARecord(id);
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

    [WebMethod()]
    public int InsertNewsSale(int typeID, string title, string content,
            int realEstateID, int? rate, DateTime updateTime)
    {
        try
        {
            return newsSale.Insert(typeID, title, content, realEstateID, rate,
                updateTime);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateNewsSale(int id, int typeID, string title, string content,
            int realEstateID, int? rate, DateTime updateTime)
    {
        try
        {
            return newsSale.Update(id, typeID, title, content, realEstateID, rate,
                updateTime);
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
    public int InsertNews(int typeID, string title, string content,
            string author, int? rate, DateTime publishTime, int imageID)
    {
        try
        {
            return news.Insert(typeID, title, content, author, rate,
                publishTime, imageID);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateNews(int id, int typeID, string title, string content,
            string author, int? rate, DateTime publishTime, int imageID)
    {
        try
        {
            return news.Update(id, typeID, title, content, author, rate,
                publishTime, imageID);
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

    [WebMethod()]
    public int InsertProject(int typeID, string name, DateTime? beginDay,
        int addressID, string description)
    {
        try
        {
            return project.Insert(typeID, name, beginDay, addressID, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateProject(int id, int typeID, string name, DateTime? beginDay,
        int addressID, string description)
    {
        try
        {
            return project.Update(id, typeID, name, beginDay, addressID, description);
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
            int? bedRoom, int? bathRoom, int? storey, double? totalUseArea,
            double? campusFront, double? campusBehind, double? campusLength,
            double? buildFront, double? buildBehind, double? buildLength,
            string legal, string direction, string frontStreet, string location,
            decimal price, int unitID, int unitPriceID, int? projectID, int? contactID)
    {
        try
        {
            return realEstate.Insert(typeID, addressID, livingRoom, bedRoom, bathRoom,
                storey, totalUseArea, campusFront, campusBehind, campusLength,
                buildFront, buildBehind, buildLength, legal, direction, frontStreet,
                location, price, unitID, unitPriceID, projectID, contactID);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateRealEstate(int id, int typeID, int addressID, int? livingRoom,
            int? bedRoom, int? bathRoom, int? storey, double? totalUseArea,
            double? campusFront, double? campusBehind, double? campusLength,
            double? buildFront, double? buildBehind, double? buildLength,
            string legal, string direction, string frontStreet, string location,
            decimal price, int unitID, int unitPriceID, int? projectID, int? contactID)
    {
        try
        {
            return realEstate.Update(id, typeID, addressID, livingRoom, bedRoom, bathRoom,
                storey, totalUseArea, campusFront, campusBehind, campusLength,
                buildFront, buildBehind, buildLength, legal, direction, frontStreet,
                location, price, unitID, unitPriceID, projectID, contactID);
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
    #endregion

    #region Rule Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.RULE> GetAllRules()
    {
        return new ObservableCollection<RealEstateDataContext.RULE>(rule.GetAllRows());
    }

    [WebMethod()]
    public int InsertRule(string name, string description)
    {
        try
        {
            return rule.Insert(name, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateRule(int id, string name, string description)
    {
        try
        {
            return rule.Update(id, name, description);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public void DeleteRule(int id)
    {
        try
        {
            rule.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.RULE GetRule(int id)
    {
        try
        {
            return rule.GetARecord(id);
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

    #region User Service
    [WebMethod]
    public ObservableCollection<RealEstateDataContext.USER> GetAllUsers()
    {
        return new ObservableCollection<RealEstateDataContext.USER>(user.GetAllRows());
    }

    [WebMethod()]
    public int InsertUser(string username, string password,
            string email, string phone, int? groupID)
    {
        try
        {
            return user.Insert(username, password, email, phone, groupID);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public int UpdateUser(int id, string username, string password,
            string email, string phone, int? groupID)
    {
        try
        {
            return user.Update(id, username, password, email, phone, groupID);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public void DeleteUser(int id)
    {
        try
        {
            user.Delete(id);
        }
        catch (Exception e)
        {
            throw e;
        }
    }

    [WebMethod()]
    public RealEstateDataContext.USER GetUser(int id)
    {
        try
        {
            return user.GetARecord(id);
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
}
