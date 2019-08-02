using System;
using System.Collections.Generic;
using System.Text;

namespace Kobe.Domain.Entities
{
    public class Country : BaseEntity
    {
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool IsDeleted { get; set; }

        public string Name { get; set; }
        public int Population { get; set; }
        public decimal Area { get; set; }
        public string ISO3166 { get; set; }
        public string DrivingSide { get; set; }
        public string Capital { get; set; }
    }
}
