using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Products.Domain.Common;

public abstract class BaseAuditEntity
{
    public int Id { get; set; }

    public long? CreatedBy { get; set; }

    public DateTime CreatedOn { get; set; }

    public long? UpdatedBy { get; set; }

    public DateTime? UpdatedOn { get; set; }

    public bool IsActive { get; set; } = true;
}
