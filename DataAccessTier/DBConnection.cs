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
        public string m_ConnectionString = "Data Source=WHITEFANGPC\\SANGPC;Initial Catalog=QL_ANHNGU;Integrated Security=True;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";

        public DBConnection()
        {
            try
            {
                connection = new SqlConnection(m_ConnectionString);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
