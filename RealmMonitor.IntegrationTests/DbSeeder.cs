using System;
using System.Data.SqlClient;
using System.IO;
using Dapper;
using Newtonsoft.Json.Linq;

namespace RealmMonitor.IntegrationTests
{
    public static class DbSeeder
    {
        public static void InitDb()
        {
            var jsonConfig = JObject.Parse(
                File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "appsettings.json")));

            using (var conn = new SqlConnection(jsonConfig["ConnectionString"].Value<string>()))
            {
                conn.Execute("DELETE FROM Alert");
            }
        }
    }
}
