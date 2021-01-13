using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Data;
using WebApplication1.AppCommon;

namespace WebApplication1.AppDataAccess
{
    public class BaseDAL
    {
        private DataConnectionClass myConnection;
        private MySqlConnection myCon;
        public MySqlDataAdapter myDataAdapter;

        public BaseDAL()
        {
            myConnection = new DataConnectionClass();
        }

        public DataSet Select(string strSql)
        {
            DataSet myDataset = new DataSet();

            try
            {
                if (myConnection.OpenConnection())
                {
                    myCon = myConnection.ConnectionObject;
                    MySqlDataAdapter myDataAdapter = new MySqlDataAdapter(strSql, myCon);
                    myDataAdapter.Fill(myDataset);
                    return myDataset;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
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

        //Insert only
        public void SaveData(string strSql)
        {
            MySqlCommand cmd = new MySqlCommand();

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

                //System.Windows.Forms.MessageBox.Show(ex.Message);
                //Console.WriteLine(ex.Message);
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

        //insert and return ID
        public int SaveDataReturn(string strSql)
        {
            MySqlCommand cmd = new MySqlCommand();
            int returnValue = 0;
            try
            {
                if (myConnection.OpenConnection())
                {

                    myCon = myConnection.ConnectionObject;

                    cmd.Connection = myCon;
                    cmd.CommandText = strSql + " SELECT LAST_INSERT_ID(); ";
                    cmd.ExecuteNonQuery();
                    returnValue = (int)cmd.LastInsertedId;
                    // returnValue = (int)returnParameter.Value;
                }



            }
            catch (Exception ex)
            {

                //System.Windows.Forms.MessageBox.Show(ex.Message);
                //Console.WriteLine(ex.Message);
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

            return returnValue;
        }
    }
}