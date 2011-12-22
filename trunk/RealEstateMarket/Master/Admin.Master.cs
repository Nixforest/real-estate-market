using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RealEstateMarket.Master
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            List<MenuItem> listMenu = new List<MenuItem>();

            listMenu.Add(new MenuItem("Home", "", "", "~/Pages/Home/Default.aspx"));
            listMenu.Add(new MenuItem("Tin tức và trải nghiệm", "", "", "~/Pages/News/AllNews.aspx"));
            listMenu.Add(new MenuItem("Siêu thị Địa ốc", "", "", "~/Pages/NewsSale/NewsSales.aspx"));
            listMenu.Add(new MenuItem("Dự án", "", "", "~/Pages/Project/ListProjects.aspx"));
            if (Page.User.IsInRole("Moderator"))
            {
                listMenu.Add(new MenuItem("Trang quản lý", "", "", "~/Admin/AdminPage.aspx"));
            }
            if (Page.User.IsInRole("Customer"))
            {
                listMenu.Add(new MenuItem("Trang cá nhân", "", "", "~/Member/MemberInformation.aspx"));
            }
            foreach (MenuItem item in listMenu)
            {
                NavigationMenu.Items.Add(item);
            }
        }
    }
}