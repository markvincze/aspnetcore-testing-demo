using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration.Memory;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Stubbery;
using Xunit;

namespace Demo1.IntegrationTests
{
    public class AlertsTest
    {
        private ApiStub StartStub()
        {
            DbSeeder.InitDb();

            var stub = new ApiStub();

            stub.Start();

            return stub;
        }

        private TestServer StartSut(ApiStub stub)
        {
            var builder = WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .ConfigureAppConfiguration((ctx, b) =>
                {
                    b.Add(new MemoryConfigurationSource
                    {
                        InitialData = new Dictionary<string, string>
                        {
                            ["BattleNetApiUrl"] = stub.Address
                        }
                    });
                });

            return new TestServer(builder);
        }

        [Fact]
        public async Task Post_RealmNotFound_BadRequestReturned()
        {
            using (var stub = StartStub())
            using (var server = StartSut(stub))
            using (var client = server.CreateClient())
            {
                stub.Get(
                    "wow/realm/status",
                    (req, args) =>
                        JsonConvert.SerializeObject(new
                        {
                            realms = new object[]
                            {
                                new
                                {
                                    name = "Foo",
                                    status = true
                                }
                            }
                        }));

                var response = await client.PostAsync(
                    "/api/alerts",
                    new StringContent(
                        JsonConvert.SerializeObject(
                            new
                            {
                                RealmName = "Bar",
                                AlertType = "Email"
                            }), Encoding.UTF8, "application/json"));

                Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
            }
        }

        [Fact]
        public async Task Post_RealmFound_AlertCreated()
        {
            using (var stub = StartStub())
            using (var server = StartSut(stub))
            using (var client = server.CreateClient())
            {
                stub.Get(
                    "wow/realm/status",
                    (req, args) =>
                        JsonConvert.SerializeObject(new
                        {
                            realms = new object[]
                            {
                                new
                                {
                                    name = "TestRealm",
                                    status = true
                                }
                            }
                        }));

                var response = await client.PostAsync(
                    "/api/alerts",
                    new StringContent(
                        JsonConvert.SerializeObject(
                            new
                            {
                                RealmName = "TestRealm",
                                AlertType = "Email"
                            }), Encoding.UTF8, "application/json"));

                Assert.Equal(HttpStatusCode.OK, response.StatusCode);

                response = await client.GetAsync("/api/alerts");

                var alertsJson = JArray.Parse(await response.Content.ReadAsStringAsync());

                Assert.Equal(1, alertsJson.Count);
            }
        }
    }
}
