using System;
using System.Linq;
using System.Collections.Generic;
using Csla.Core;
using ManagementSystem.BusinessLogicLayer;
using Csla;
using Csla.DataPortalClient;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ManagementSystem.DataAccessLayer
{
    //[Serializable]
    public class LookupDAL : ILookupDAL
    {


        public Dictionary<string, string> Fetch(string tableName, string idField, string description)
        {
            Dictionary<string, string> resultlist = new Dictionary<string, string>();

            using (SqlConnection connection = new SqlConnection(@"Data Source=hermes;Initial Catalog=StudentManagement;Integrated Security=True;TrustServerCertificate=True;Trusted_Connection=True"))
            {
                connection.Open();

                // Build a standard SQL query, not a stored procedure
                string query = $"SELECT {idField}, {description} FROM {tableName}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            while (reader.Read())
                            {
                                int key = reader.GetInt32(0); 
                                string value = reader.GetString(1);
                                resultlist.Add(key.ToString(), value);
                            }
                        }
                    }
                }
            }

            return resultlist;
        }

    }
      
       
}
