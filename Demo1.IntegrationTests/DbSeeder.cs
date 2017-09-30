using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using Dapper;
using Newtonsoft.Json.Linq;

namespace Demo1.IntegrationTests
{
    public static class DbSeeder
    {
        public static void InitDb()
        {
            var jsonConfig = JObject.Parse(File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "appsettings.json")));

            using (var conn = new SqlConnection(jsonConfig["ConnectionString"].Value<string>()))
            {
                conn.Execute("DELETE FROM Alert");
            }
        }
    }
}
