using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using RealEstateDataContext;

namespace RealEstateMarket
{
    public partial class TestPage : System.Web.UI.Page
    {

        private RealEstateServiceReference.RealEstateWebServiceSoapClient nation;
        protected void Page_Load(object sender, EventArgs e)
        {
            //RealEstateDataContext.Utility.WebConfig.MSSQL = @"Data Source=.\SQLEXPRESS;Initial Catalog=RealEstate;Integrated Security=True";
            nation = new RealEstateServiceReference.RealEstateWebServiceSoapClient();
            nation.SetConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=RealEstate;Integrated Security=True");

            nationGridView.DataSource = nation.GetAllRows();
            nationGridView.DataBind();
         
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            //if (Insert.Text.Equals("Insert"))
            //{
            //    if (txbName.Text != "" && txbCode.Text != "")
            //    {
            //        _db.Insert(txbName.Text, txbCode.Text);
            //        this.Page_Load(sender, e);
            //    }
            //}
            
        }

        protected void listNationX_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //int index = e.RowIndex;
            //intIndex = Convert.ToInt32(listNationX.Rows[index].Cells[1].Text);
            //try
            //{
            //    _db.Update(intIndex,txbName.Text, txbCode.Text); 
            //}
            //catch (Exception)
            //{
                
            //    throw;
            //}
        }

        protected void listNationX_RowEditing(object sender, GridViewEditEventArgs e)
        {
            //Insert.Text = "Update";
            //int index = e.NewEditIndex;
            //intIndex = Convert.ToInt32(listNationX.Rows[index].Cells[1].Text);
            //Note.Text = intIndex.ToString();
            //try
            //{
            //    txbID.Text = intIndex.ToString();
            //    txbName.Text = _db.GetARecord(intIndex).Name;
            //    txbCode.Text = _db.GetARecord(intIndex).NationCode;
            //}
            //catch (RealEstateDataContext.Utility.NationIDException)
            //{
                
            //}
        }

        void NationDataSource_OnInserted(object sender, ObjectDataSourceStatusEventArgs e)
        {
            //NationGridView.DataBind();
        }

        void NationDataSource_OnUpdated(object sender, ObjectDataSourceStatusEventArgs e)
        {
        }

        void NationDataSource_OnDeleted(object sender, ObjectDataSourceStatusEventArgs e)
        {
        }

        protected void delete_Click(object sender, EventArgs e)
        {
            //_db.Delete(2);
        }

        protected void Insert_Click(object sender, EventArgs e)
        {
            //RealEstateServiceReference.NATION entity = new RealEstateServiceReference.NATION();
            //entity.Name = textboxName.Text;
            //entity.NationCode = textboxNationCode.Text;
            if (textboxName.Text != "" && textboxNationCode.Text != "")
            {

                nation.Insert(textboxName.Text, textboxNationCode.Text);
                nationGridView.DataSource = nation.GetAllRows();
                nationGridView.DataBind();
            }

            //nation.Delete(5);
        }
    }
}