using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using WebApplication1.AppCommon;
using WebApplication1.Models;
using System.Data;

namespace WebApplication1.AppDataAccess
{
    public class UserDAL : BaseDAL
    {
        private DataConnectionClass myConnection;
        private MySqlConnection myCon;
        private string strSql;

        private static string TABLE_NAME = "users";
        private static string COLUMN_USER_ID = "ID";
        private static string COLUMN_LAST_NAME = "last_name";
        private static string COLUMN_FIRST_NAME = "first_name";
        private static string COLUMN_USER_NAME = "user_name";
        private static string COLUMN_USER_PASSWORD = "user_password";
        private static string COLUMN_ACCOUNT_TYPE = "account_type";
        private static string COLUMN_ADDRESS = "address";
        private static string COLUMN_PHONE = "phone";
        private static string COLUMN_EMAIL = "email";

        private static string COLUMN_EMPNO = "employee_id";

        public UserDAL()
        {
            myConnection = new DataConnectionClass();
        }


        public DataSet SelectAllUsers()
        {
            strSql = "SELECT * " +
                     " FROM " + TABLE_NAME +
                     " ORDER By " + COLUMN_USER_ID + " asc ";

            return Select(strSql);
        }

        public DataSet SelectUserByID(UserClass oClass)
        {
            string strSql;
            strSql = "SELECT * " +
                     "FROM " + TABLE_NAME + " " +
                     "WHERE " + COLUMN_USER_ID + " = '" + oClass.ID + "' ";

            DataSet myDataset = new DataSet();

            try
            {
                if (myConnection.OpenConnection())
                {
                    myCon = myConnection.ConnectionObject;
                    myDataAdapter = new MySqlDataAdapter(strSql, myCon);
                    myDataAdapter.Fill(myDataset);
                    return myDataset;
                }
                else
                {
                    return null;
                }
            }
            catch
            {
                return null;
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                myDataAdapter = null;
            }
        }

        public void Insert(UserClass oClass, string currUser)
        {
            MySqlCommand cmd = new MySqlCommand();
            string strSql;

            strSql = "INSERT INTO " + TABLE_NAME + " (" +
                        COLUMN_LAST_NAME + ", " +
                        COLUMN_FIRST_NAME + ", " +
                        COLUMN_USER_NAME + ", " +
                        COLUMN_USER_PASSWORD + ", " +
                        COLUMN_ACCOUNT_TYPE + ", " +
                        COLUMN_ADDRESS + ", " +
                        COLUMN_PHONE + ", " +
                        COLUMN_EMAIL+ ", " +
                         "created_by, created_date, updated_by, updated_date) ";

            strSql = strSql + "values ('" +
                     oClass.LastName + "', '" +
                    oClass.FirstName + "', '" +
                    oClass.UserName + "', '" +
                    oClass.UserPassword + "', '" +
                    oClass.AccountType + "', '" +
                    oClass.Address + "', '" +
                    oClass.Phone + "', '" +
                    oClass.Email + "', '" +
                    currUser + "', '" +
                     DateTime.Today.ToString("yyyy-MM-dd HH:MM:ss") + "', '" +
                    currUser + "', '" +
                   DateTime.Today.ToString("yyyy-MM-dd HH:MM:ss") + "' " +
                    ") ";
            try
            {
                if (myConnection.OpenConnection())
                {
                    myCon = myConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;

                    cmd.ExecuteNonQuery();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }


        public void Update(UserClass oClass, string currUser)
        {
            MySqlCommand cmd = new MySqlCommand();
            string strSql;

            strSql = "UPDATE " + TABLE_NAME + " SET " +
                COLUMN_LAST_NAME + " = '" + oClass.LastName + "', " +
                COLUMN_FIRST_NAME + " = '" + oClass.FirstName + "', " +
                COLUMN_USER_NAME + " = '" + oClass.UserName + "', " +
                COLUMN_USER_PASSWORD + " = '" + oClass.UserPassword + "', " +
                COLUMN_ACCOUNT_TYPE + " = '" + oClass.AccountType + "', " +
                COLUMN_ADDRESS + " = '" + oClass.Address + "', " +
                COLUMN_PHONE + " = '" + oClass.Phone + "', " +
                COLUMN_EMAIL + " = '" + oClass.Email + "', " +
                "updated_by" + " = '" + currUser + "', " +
                "updated_date" + " = '" + DateTime.Today.ToString("yyyy-MM-dd HH:MM:ss") + "' " +
                " WHERE " + COLUMN_USER_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (myConnection.OpenConnection())
                {
                    myCon = myConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }

        public void Delete(UserClass oClass)
        {
            MySqlCommand cmd = new MySqlCommand();
            string strSql;

            strSql = "DELETE  FROM " + TABLE_NAME + " " +
                    " WHERE " + COLUMN_USER_ID + " = '" + oClass.ID + "' ";

            try
            {
                if (myConnection.OpenConnection())
                {
                    myCon = myConnection.ConnectionObject;
                    cmd.Connection = myCon;
                    cmd.CommandText = strSql;
                    // cmd.Parameters.AddWithValue(@COLUMN_USER_ID, oClass.UserID );
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                if (myCon.State == ConnectionState.Open)
                {
                    myCon.Close();
                }
                myCon.Dispose();
                cmd.Dispose();
            }
        }
    }
}