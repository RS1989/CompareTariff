using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TariffCompare.services;

namespace TariffCompare.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/tariff")]
    [ApiController]
    public class TariffController : ControllerBase
    {
        private readonly ITariffService _tariffService;

        public TariffController(ITariffService tariffService)
        {
            _tariffService = tariffService;
        }

        [HttpGet("{consumption}")]
        public IActionResult Get(double consumption)
        {
            try
            {
                var result = _tariffService.GetTariff(consumption);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}