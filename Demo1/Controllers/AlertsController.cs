using System.Linq;
using System.Threading.Tasks;
using Demo1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    [Route("api/[controller]")]
    public class AlertsController : Controller
    {
        private readonly IAlertRepository alertRepository;
        private readonly IBattleNetApi battleNetApi;

        public AlertsController(IAlertRepository alertRepository, IBattleNetApi battleNetApi)
        {
            this.alertRepository = alertRepository;
            this.battleNetApi = battleNetApi;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var alerts = await alertRepository.List();

            return Ok(alerts);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Alert alert)
        {
            var realms = await battleNetApi.GetRealms();

            if (!realms.Any(r => r.Name == alert.RealmName))
            {
                return BadRequest();
            }

            await alertRepository.InsertAlert(alert);

            return Ok();
        }
    }
}