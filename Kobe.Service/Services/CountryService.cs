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
        private readonly IEntityBaseRepository<KobeCountry> _countryRepository;

        public CountryService(IEntityBaseRepository<KobeCountry> countryRepository)
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

        public KobeCountry Post(KobeCountry country)
        {
            // Validate(country, Activator.CreateInstance<V>());

            _countryRepository.Add(country);
            return country;
        }

        public KobeCountry getCountryById(int? id)
        {
            return _countryRepository.GetById(id);
        }

        public void deleteCountryById(KobeCountry country)
        {
            _countryRepository.SoftDelete(country);
        }

        public KobeCountry updateCountryById(KobeCountry oldCountry, KobeCountry newCountry)
        {
           return _countryRepository.Edit(oldCountry, newCountry);
        }
    }
}
