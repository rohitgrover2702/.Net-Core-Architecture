using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Kobe.Domain.Entities
{
    public class KobeCountry : BaseEntity
    {
        public int Id { get; set; }      
        public Guid KeyId { get; set; }
        public string Name { get; set; }
        public string Capital { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool IsDeleted { get; set; }        
    }
}
