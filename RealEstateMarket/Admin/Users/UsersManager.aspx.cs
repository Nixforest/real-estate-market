using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Admin.Users
{
    public partial class UsersManager : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!User.IsInRole("Administrator"))
            {
                Response.Redirect("~/AccessDeny.aspx");
            }

            if (!IsPostBack)
            {
                //UserGridView.DataSource = System.Web.Security.Membership.GetAllUsers();
                //UserGridView.DataBind();
                //RolesGridView.DataSource = System.Web.Security.Roles.GetAllRoles();
                //RolesGridView.DataBind();
                InRoleAddUserDropDownList.DataSource = System.Web.Security.Roles.GetAllRoles();
                InRoleAddUserDropDownList.DataBind();
                InRoleDropDownList.DataSource = System.Web.Security.Roles.GetAllRoles();
                InRoleDropDownList.DataBind();
                
            }
        }

        protected void DeleteUserButton_Click(object sender, EventArgs e)
        {
            try
            {                
                System.Web.Security.Membership.DeleteUser(UserDropDownList.SelectedValue);
                UserGridView.DataBind();
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.ToString();
            }
        }

        protected void AddUserInRoleButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Web.Security.Roles.AddUserToRole(UserDropDownList.SelectedValue, InRoleAddUserDropDownList.SelectedValue);
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = e.ToString();
            }
        }

        protected void AddRoleButton_Click(object sender, EventArgs e)
        {
            if (RoleNameTextBox.Text != "")
            {
                try
                {
                    System.Web.Security.Roles.CreateRole(RoleNameTextBox.Text);
                    RolesGridView.DataBind();
                }
                catch (Exception ex)
                {
                    ErrorLabel.Text = ex.ToString();
                }
            }
        }

        protected void AddUserButton_Click(object sender, EventArgs e)
        {
            try
            {
                System.Web.Security.Membership.CreateUser(UserNameTextBox.Text,
                    PasswordTextBox.Text, EmailTextBox.Text);
                if (InRoleDropDownList.SelectedValue == "Administrator")
                {
                    System.Web.Security.Roles.AddUserToRole(UserNameTextBox.Text, "Administrator");
                    System.Web.Security.Roles.AddUserToRole(UserNameTextBox.Text, "Moderator");
                    System.Web.Security.Roles.AddUserToRole(UserNameTextBox.Text, "Customer");
                    System.Web.Security.Roles.AddUserToRole(UserNameTextBox.Text, "Author");
                }
                if (InRoleDropDownList.SelectedValue == "Moderator")
                {
                    System.Web.Security.Roles.AddUserToRole(UserNameTextBox.Text, "Moderator");
                    System.Web.Security.Roles.AddUserToRole(UserNameTextBox.Text, "Customer");
                    System.Web.Security.Roles.AddUserToRole(UserNameTextBox.Text, "Author");
                }
                if (InRoleDropDownList.SelectedValue == "Customer")
                {
                    System.Web.Security.Roles.AddUserToRole(UserNameTextBox.Text, "Customer");
                }
                if (InRoleDropDownList.SelectedValue == "Author")
                {
                    System.Web.Security.Roles.AddUserToRole(UserNameTextBox.Text, "Customer");
                    System.Web.Security.Roles.AddUserToRole(UserNameTextBox.Text, "Author");
                }
                UserGridView.DataBind();
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = ex.ToString();
            }
        }
    }
}