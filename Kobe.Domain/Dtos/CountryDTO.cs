using Kobe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kobe.Domain.Dtos
{
   public class CountryDTO : BaseEntity
    {
        public string Name { get; set; }
        public string Capital { get; set; }
        public decimal Area { get; set; }
        public int Population { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
    }
}
