using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.ObjectModel;

namespace RealEstateMarket.CustomControl
{
    public partial class TopNewsControl : System.Web.UI.UserControl
    {
        List<RealEstateServiceReference.NEW> listNews = RealEstateMarket._Default.db.GetAllNewsCheck(0, 10, true).ToList();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                img1.Src = listNews[0].IMAGE.Path;
                img2.Src = listNews[1].IMAGE.Path;
                img3.Src = listNews[2].IMAGE.Path;
                img4.Src = listNews[3].IMAGE.Path;
                img5.Src = listNews[4].IMAGE.Path;
                img6.Src = listNews[5].IMAGE.Path;
                img7.Src = listNews[6].IMAGE.Path;
                img8.Src = listNews[7].IMAGE.Path;

                label1.InnerText = listNews[0].Title;
                label2.InnerText = listNews[1].Title;
                label3.InnerText = listNews[2].Title;
                label4.InnerText = listNews[3].Title;
                label5.InnerText = listNews[4].Title;
                label6.InnerText = listNews[5].Title;
                label7.InnerText = listNews[6].Title;
                label8.InnerText = listNews[7].Title;
                label9.InnerText = listNews[8].Title;
                label10.InnerText = listNews[9].Title;

                spanimg1.Src = listNews[0].IMAGE.Path;
                spanimg2.Src = listNews[1].IMAGE.Path;
                spanimg3.Src = listNews[2].IMAGE.Path;
                spanimg4.Src = listNews[3].IMAGE.Path;
                spanimg5.Src = listNews[4].IMAGE.Path;
                spanimg6.Src = listNews[5].IMAGE.Path;
                spanimg7.Src = listNews[6].IMAGE.Path;
                spanimg8.Src = listNews[7].IMAGE.Path;
                spanimg9.Src = listNews[8].IMAGE.Path;
                spanimg10.Src = listNews[9].IMAGE.Path;
                
                atag1.HRef = String.Format("http://{0}:{1}/Pages/News/ReadNews.aspx?id={2}&cid={3}",
                        Page.Request.Url.Host, Page.Request.Url.Port, listNews[0].ID, listNews[0].TypeID);
                atag2.HRef = String.Format("http://{0}:{1}/Pages/News/ReadNews.aspx?id={2}&cid={3}",
                        Page.Request.Url.Host, Page.Request.Url.Port, listNews[1].ID, listNews[1].TypeID);
                atag3.HRef = String.Format("http://{0}:{1}/Pages/News/ReadNews.aspx?id={2}&cid={3}",
                        Page.Request.Url.Host, Page.Request.Url.Port, listNews[2].ID, listNews[2].TypeID);
                atag4.HRef = String.Format("http://{0}:{1}/Pages/News/ReadNews.aspx?id={2}&cid={3}",
                        Page.Request.Url.Host, Page.Request.Url.Port, listNews[3].ID, listNews[3].TypeID);
                atag5.HRef = String.Format("http://{0}:{1}/Pages/News/ReadNews.aspx?id={2}&cid={3}",
                        Page.Request.Url.Host, Page.Request.Url.Port, listNews[4].ID, listNews[4].TypeID);
                atag6.HRef = String.Format("http://{0}:{1}/Pages/News/ReadNews.aspx?id={2}&cid={3}",
                        Page.Request.Url.Host, Page.Request.Url.Port, listNews[5].ID, listNews[5].TypeID);
                atag7.HRef = String.Format("http://{0}:{1}/Pages/News/ReadNews.aspx?id={2}&cid={3}",
                        Page.Request.Url.Host, Page.Request.Url.Port, listNews[6].ID, listNews[6].TypeID);
                atag8.HRef = String.Format("http://{0}:{1}/Pages/News/ReadNews.aspx?id={2}&cid={3}",
                        Page.Request.Url.Host, Page.Request.Url.Port, listNews[7].ID, listNews[7].TypeID);
                atag9.HRef = String.Format("http://{0}:{1}/Pages/News/ReadNews.aspx?id={2}&cid={3}",
                        Page.Request.Url.Host, Page.Request.Url.Port, listNews[8].ID, listNews[8].TypeID);
                atag10.HRef = String.Format("http://{0}:{1}/Pages/News/ReadNews.aspx?id={2}&cid={3}",
                        Page.Request.Url.Host, Page.Request.Url.Port, listNews[9].ID, listNews[9].TypeID);
            }
        }
    }
}