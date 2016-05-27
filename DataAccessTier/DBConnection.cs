using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace DataAccessTier
{
    class DBConnection
    {
        protected SqlConnection connection;
        //public string mConnectionString = "Data Source=WHITEFANGPC\\SANGPC;Initial Catalog=QL_ANHNGU;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        public string mConnectionString = "Data Source=desktop-0up9cpe;Initial Catalog=QL_ANHNGU;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

        public DBConnection()
        {
            try
            {
                connection = new SqlConnection(mConnectionString);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
