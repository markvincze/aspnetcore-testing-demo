using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using Demo1.Models;
using Microsoft.Extensions.Configuration;

namespace Demo1
{
    public class AlertRepository : IAlertRepository
    {
        private readonly IConfiguration configuration;
        public AlertRepository(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public async Task<IEnumerable<Alert>> List()
        {
            using (var conn = new SqlConnection(configuration["ConnectionString"]))
            {
                return await conn.QueryAsync<Alert>("SELECT * FROM Alert");
            }
        }

        public async Task InsertAlert(Alert alert)
        {
            using (var conn = new SqlConnection(configuration["ConnectionString"]))
            {
                await conn.ExecuteAsync(
                    "INSERT INTO Alert (RealmName, AlertType) VALUES (@RealmName, @AlertType)",
                    new { RealmName = alert.RealmName, AlertType = alert.AlertType });
            }
        }
    }
}