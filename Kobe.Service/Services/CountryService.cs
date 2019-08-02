using Kobe.Data.Repository;
using Kobe.Domain.Dtos;
using Kobe.Domain.Entities;
using Kobe.Service.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kobe.Service.Services
{
    public class CountryService : ICountryService
    {
        private readonly IEntityBaseRepository<Country> _countryRepository;

        public CountryService(IEntityBaseRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public ResponseViewModel GetCountries()
        {
            ResponseViewModel response = new ResponseViewModel();
            var countries = _countryRepository.GetAll();
            response.responseData = countries;
            response.status = 1;
            response.message = "Data retreived successfully";
            return response;
        }
    }
}
