using Kobe.Domain.Dtos;
using Kobe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kobe.Service.Abstract
{
    public interface ICountryService
    {
        ResponseViewModel GetCountries();
        KobeCountry Post(KobeCountry country);
        KobeCountry getCountryById(int? id);

        void deleteCountryById(KobeCountry country);

        KobeCountry updateCountryById(KobeCountry countryOld, KobeCountry countryNew);
    }
}
