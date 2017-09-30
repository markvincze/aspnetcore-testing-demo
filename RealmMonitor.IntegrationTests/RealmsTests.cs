using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration.Memory;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Linq;
using Xunit;

namespace RealmMonitor.IntegrationTests
{
    public class RealmsTests
    {
        [Fact]
        public async Task Get_RetrievesRealms()
        {
            using (var server = new TestServer(WebHost.CreateDefaultBuilder().UseStartup<Startup>()))
            using (var client = server.CreateClient())
            {
                var result = await client.GetAsync("/api/realms");

                Assert.Equal(HttpStatusCode.OK, result.StatusCode);

                var responseString = await result.Content.ReadAsStringAsync();

                var json = JArray.Parse(responseString);

                Assert.Contains(json, j => j["name"].Value<string>() == "Antonidas");
            }
        }
    }
}
