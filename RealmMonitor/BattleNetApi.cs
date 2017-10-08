using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using RealmMonitor.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Linq;

namespace RealmMonitor
{
    public class BattleNetApi : IBattleNetApi
    {
        private readonly IConfiguration configuration;
        private readonly DummyOptions dummyOptions;

        public BattleNetApi(IConfiguration configuration, IOptions<DummyOptions> dummyOptions)
        {
            this.configuration = configuration;
            this.dummyOptions = dummyOptions.Value;
        }

        public async Task<IEnumerable<Realm>> GetRealms()
        {
            // TODO: implement!
        }
    }
}
