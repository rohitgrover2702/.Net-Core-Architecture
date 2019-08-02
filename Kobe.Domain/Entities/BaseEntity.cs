using System;
using System.Collections.Generic;
using System.Text;

namespace Kobe.Domain.Entities
{
    public interface BaseEntity
    {
        Guid Id { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid? CreatedBy { get; set; }
        bool IsDeleted { get; set; }
    }
}
