using System;
using System.Collections.Generic;
using System.Text;

namespace DataBase_Connection
{
    public class SQLconnection : DbConnection
    {
        //ctors
        public SQLconnection(string connectionString) : base(connectionString)
        {

        }

        //methods
        //these methods contain the implementation for the base class' abstract members
        public override void OpenConnection()
        {
            throw new NotImplementedException();
        }

        public override void CloseConnection()
        {
            throw new NotImplementedException();
        }
    }
}
