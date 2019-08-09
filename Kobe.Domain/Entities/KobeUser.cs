using System;
using System.Collections.Generic;
using System.Text;

namespace Kobe.Domain.Entities
{
    public class KobeUser : BaseEntity
    {
        public int Id { get; set; }
        public Guid KeyId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public byte[] HashedPassword { get; set; }
        public byte[] Salt { get; set; }
        public string Token { get; set; }
        public DateTime? TokenExpiryDate { get; set; }
        public bool IsLocked { get; set; }
        public bool IsDeactivated { get; set; }
        // Common Columns
        public DateTime? CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? CreatedBy { get; set; }
        public bool IsDeleted { get; set; }        
    }
}
