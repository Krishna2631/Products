using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Products.Domain.Common;

namespace Products.Domain.Entities
{
    public class Product : BaseAuditEntity
    {
        public string ProductName { get; set; } = string.Empty;

        // Navigation Property
        public ICollection<Item> Items { get; set; } = new List<Item>();
    }
}
