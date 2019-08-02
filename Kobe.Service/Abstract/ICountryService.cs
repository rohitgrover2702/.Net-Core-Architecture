using Kobe.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kobe.Service.Abstract
{
    public interface ICountryService
    {
        ResponseViewModel GetCountries();
    }
}
