using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Products.Domain.Common;

namespace Products.Domain.Entities
{
    public class Item : BaseAuditEntity
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        // Navigation Property
        public Product Product { get; set; } = null!;
    }
}