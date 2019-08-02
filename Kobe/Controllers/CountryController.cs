using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kobe.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kobe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ICountryService countryService;

        public CountryController(ICountryService countryService)
        {
            this.countryService = countryService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                var countries = countryService.GetCountries();
                return Ok(countries);
            }
            catch (Exception ex)
            {
                // logger.LogError("Something went wrong, message description:" + ex.Message);
                return BadRequest(ex);
            }
        }
    }
}