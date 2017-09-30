﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Demo1.Controllers
{
    [Route("api/[controller]")]
    public class RealmsController : Controller
    {
        private readonly IBattleNetApi battleNetApi;

        public RealmsController(IBattleNetApi battleNetApi)
        {
            this.battleNetApi = battleNetApi;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var realms = await battleNetApi.GetRealms();

            return Ok(realms);
        }
    }
}