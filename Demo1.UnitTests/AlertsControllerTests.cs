using System.Collections.Generic;
using System.Threading.Tasks;
using Demo1.Controllers;
using Demo1.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Demo1.UnitTests
{
    public class AlertsControllerTests
    {
        [Fact]
        public async Task Post_RealmFound_AlertCreated()
        {
            var repository = new Mock<IAlertRepository>();
            var battleNetApi = new Mock<IBattleNetApi>();

            battleNetApi
                .Setup(b => b.GetRealms())
                .ReturnsAsync(new List<Realm> { new Realm { Name = "TestRealm" } });

            var sut = new AlertsController(repository.Object, battleNetApi.Object);

            var alert = new Alert { AlertType = "Email", RealmName = "TestRealm" };

            var result = await sut.Post(alert);

            repository.Verify(r => r.InsertAlert(alert), Times.Once());

            Assert.IsType<OkResult>(result);
        }
    }
}