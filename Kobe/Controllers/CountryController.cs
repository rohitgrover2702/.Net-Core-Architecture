using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Kobe.Domain.Dtos;
using Kobe.Domain.Entities;
using Kobe.Service.Abstract;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost]
        [Route("addCountry")]
        public IActionResult AddCountry([FromBody] KobeCountry country)
        {
            try
            {
                // Country country = new Country();
                var objCountry = countryService.Post(country);
                // logger.LogInformation("Record added " + country.Id.ToString());
                //  return new CreatedAtRouteResult("CountryCreated", new { id = objCountry.Id }, objCountry);
                return Ok(objCountry);
            }
            catch (ArgumentNullException)
            {
                return NotFound("Country does not exist");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        [Route("getCountryById")]
        public IActionResult GetCountryById(int? countryId)
        {
            try
            {
                var objCountry = countryService.getCountryById(countryId);
                return Ok(objCountry);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        [Route("deleteCountryById")]
        public IActionResult deleteCountryById(KobeCountry country)
        {
            try
            {
                countryService.deleteCountryById(country);
                return Ok("Record deleted");
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
        [HttpPost]
        [Route("UpdateCountry")]
        public IActionResult UpdateCountryById(KobeCountry country)
        {
            try
            {
                var oldCountryObj = countryService.getCountryById(country.Id);
                if (oldCountryObj != null)
                    return Ok(countryService.updateCountryById(oldCountryObj, country));
                else
                    return BadRequest(Constants.Error);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}