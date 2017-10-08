using System.Linq;
using System.Threading.Tasks;
using RealmMonitor.Models;
using Microsoft.AspNetCore.Mvc;

namespace RealmMonitor.Controllers
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
            return null; // TODO: implement!
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Alert alert)
        {
            return null; // TODO: implement!
        }
    }
}