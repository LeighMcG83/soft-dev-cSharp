using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase_Connection
{
    public abstract class DbConnection
    {
        //attr
        protected string _conncectionString;
        protected TimeSpan _timeout;

        public string ConnectionString
        {
            get { return _conncectionString; }
            set
            {
                if (String.IsNullOrEmpty(value))
                    throw new Exception("Connection is invalid. Could not resolve connection string");
                else
                    _conncectionString = value; 
            }
        }

        public TimeSpan TimeOut
        {
            get { return _timeout; }
            set { _timeout = value; }
        }


        //ctors
        public DbConnection(string connectionString)
        {
            _conncectionString = connectionString;
            _timeout = new TimeSpan(300000000);
        }

        //methods
        public abstract void OpenConnection();

        public abstract void CloseConnection();

        //implementation dfor the above classes will be in derived classes 

        

    }//END: DbConnection class
}
