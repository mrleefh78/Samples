using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Models;
using WebApplication1.AppDataAccess;
using System.Data;

namespace WebApplication1
{
    public partial class WebFormUserDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(IsPostBack))
            {
                Session["User"] = "Admin";
                string id = Request.QueryString["id"].ToString();

                if (id != "")
                {

                    PopulateData(Convert.ToInt16(id));

                }

              
            }
        }

        private void PopulateData(int id)
        {
            var userDal= new UserDAL();
            var userClass= new UserClass();
            var sourceData = new DataSet();

            userClass.ID = id;

            sourceData = userDal.SelectUserByID(userClass);
            UserID.Value = sourceData.Tables[0].Rows[0][0].ToString();
            UserName.Value = sourceData.Tables[0].Rows[0][1].ToString();
            UserPassword.Value = sourceData.Tables[0].Rows[0][2].ToString();
            LastName.Value = sourceData.Tables[0].Rows[0][3].ToString();
            FirstName.Value = sourceData.Tables[0].Rows[0][4].ToString();
            AccountType.Value = sourceData.Tables[0].Rows[0][5].ToString();
            txtAddress.Value = sourceData.Tables[0].Rows[0][6].ToString();
            txtEmail.Value = sourceData.Tables[0].Rows[0][7].ToString();
            txtContact.Value = sourceData.Tables[0].Rows[0][8].ToString();

        }

        protected void AddData(object sender, EventArgs e)
        {
            SaveData();
            Response.Redirect("WebFormUsers.aspx");
        }
        protected void CloseData(object sender, EventArgs e)
        {
            Response.Redirect("WebFormUsers.aspx");
        }
        private void SaveData()
        {
            string sUserName = Session["User"].ToString();
            var userDal = new UserDAL();
            var userClass = new UserClass();


            userClass.UserName = UserName.Value;
            userClass.UserPassword = UserPassword.Value;
            userClass.LastName = LastName.Value;
            userClass.FirstName = FirstName.Value;
            userClass.AccountType = AccountType.Value;
            userClass.Address = txtAddress.InnerText;
            userClass.Phone = txtContact.Value;
            userClass.Email = txtEmail.Value;

            string id = UserID.Value;
            if (id == "")
            {
                userDal.Insert(userClass, sUserName);
               
            }
            else
            {
                userClass.ID = Convert.ToInt16(id);
                userDal.Update(userClass, sUserName);
              
            }
        }
    }
}