using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Account
{
    public partial class Register : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            RegisterUser.ContinueDestinationPageUrl = Request.QueryString["ReturnUrl"];
        }

        protected void RegisterUser_CreatedUser(object sender, EventArgs e)
        {
            FormsAuthentication.SetAuthCookie(RegisterUser.UserName, false /* createPersistentCookie */);
            
            // Address
            int nationID = Convert.ToInt32(Address.Attributes["NationID"]);
            int cityID = Convert.ToInt32(Address.Attributes["CityID"]);
            int districtID = Convert.ToInt32(Address.Attributes["DistrictID"]);
            int wardID = Convert.ToInt32(Address.Attributes["WardID"]);
            int streetID = Convert.ToInt32(Address.Attributes["StreetID"]);
            string detail = Address.Attributes["Detail"];
            int addressID = RealEstateMarket._Default.db.InsertAddress(nationID, cityID, districtID, wardID, streetID, detail);

            RealEstateMarket._Default.db.InsertCustomer(FullNameTextBox.Text, addressID,
                IdentityCardTextBox.Text, PhoneTextBox.Text, HomePhoneTextBox.Text,
                RegisterUser.Email, RegisterUser.UserName);
            System.Web.Security.Roles.AddUserToRole(RegisterUser.UserName, "Customer");
            string continueUrl = RegisterUser.ContinueDestinationPageUrl;
            if (String.IsNullOrEmpty(continueUrl))
            {
                continueUrl = "~/";
            }
            Response.Redirect(continueUrl);
        }

    }
}
