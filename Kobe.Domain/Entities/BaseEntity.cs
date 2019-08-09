using System;
using System.Collections.Generic;
using System.Text;

namespace Kobe.Domain.Entities
{
    public interface BaseEntity
    {
        int Id { get; set; }
        Guid KeyId { get; set; }
        DateTime? CreatedDate { get; set; }
        DateTime? ModifiedDate { get; set; }
        Guid? CreatedBy { get; set; }
        bool IsDeleted { get; set; }
    }
}
