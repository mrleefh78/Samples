using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebApplication1.Models;
using WebApplication1.AppDataAccess;
using System.Web.UI.HtmlControls;

namespace WebApplication1
{
    public partial class WebFormUsers : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                Session["User"] = "Admin";
                PopulateGrid();

            }
        }

        private void PopulateGrid()
        {
            var userDAL = new UserDAL();
            var sourceData = new DataSet();

            sourceData = userDAL.SelectAllUsers();

            if (sourceData != null)
            {
                gvList.DataSource = sourceData.Tables[0];
                gvList.DataBind();
            }

        }
        protected void gvList_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvList.PageIndex = e.NewPageIndex;

            PopulateGrid();
        }

        protected void AddClick(object sender, EventArgs e)
        {
            Response.Redirect(String.Format("WebFormUserDetail.aspx?id={0}", ""));
        }

        protected void UpdateClick(object sender, EventArgs e)
        {

            HtmlButton btndetails = sender as HtmlButton;
            GridViewRow gvrow = (GridViewRow)btndetails.NamingContainer;

            string id = gvList.Rows[gvrow.RowIndex].Cells[0].Text;
            Response.Redirect(String.Format("WebFormUserDetail.aspx?id={0}", id, ""));
        }

        protected void gvList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteCommand")

            {
                GridViewRow row = (GridViewRow)(((Control)e.CommandSource).NamingContainer);
                HiddenField id = row.FindControl("hfID") as HiddenField;
                HiddenField itemName = row.FindControl("hfItem") as HiddenField;

                lblSelectedItem.Text = itemName.Value;
                HiddenFieldItem.Value = id.Value;
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "ShowDeleteModal();", true);

            }
        }

        protected void DeleteButtonClick(object sender, EventArgs e)
        {
            string UserName = Session["User"].ToString();
            int ID = Convert.ToInt32(HiddenFieldItem.Value);

            var userDAL = new UserDAL();
            var userClass = new UserClass();
            var sourceData = new DataSet();
            
          
            userClass.ID = ID;
            userDAL.Delete(userClass);
            PopulateGrid();
        }
    }
}