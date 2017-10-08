using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;
using RealmMonitor.Models;
using Microsoft.Extensions.Configuration;

namespace RealmMonitor
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
            return null; // TODO: implement!
        }

        public async Task InsertAlert(Alert alert)
        {
            // TODO: implement!
        }
    }
}