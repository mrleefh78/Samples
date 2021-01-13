using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace WebApplication1.AppCommon
{
    public class DataConnectionClass
    {
        public DataConnectionClass()
        {

        }

        private MySqlConnection mycon;

        public MySqlConnection ConnectionObject
        {
            get
            {
                return mycon;
            }
            set
            {
                mycon = value;
            }
        }

        public bool OpenConnection()
        {
            string connection_str = "server=" + ConfigurationManager.AppSettings["Server"] + ";uid=" +
                                           ConfigurationManager.AppSettings["User ID"] + ";pwd=" +
                                           ConfigurationManager.AppSettings["Password"] + ";database=" +
                                           ConfigurationManager.AppSettings["Database Name"];


            MySqlConnection mycon = new MySqlConnection(connection_str + "; Allow User Variables=True;");

            mycon.Open();
            ConnectionObject = mycon;
            return true;
        }

        public Boolean CloseConnection()
        {
            mycon.Close();
            ConnectionObject = mycon;
            return true;
        }
    }
}