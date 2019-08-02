using Kobe.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Kobe.Domain.Dtos
{
    public class userDetailDTO : BaseEntity
    {
        public userDetailDTO()
        {

        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public Guid Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool IsDeleted { get; set; }
        public string Populationdensity
        {
            get
            {
                return FirstName + "" + LastName;
            }
        }
    }
}
