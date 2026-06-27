using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Products.Domain.Common;

namespace Products.Domain.Entities
{
    public class RefreshToken : BaseAuditEntity
    {
        public string Token { get; set; } = string.Empty;

        public DateTime Expires { get; set; }

        public DateTime Created { get; set; }

        public DateTime? Revoked { get; set; }

        public bool IsExpired => DateTime.UtcNow >= Expires;

        public bool IsActive => Revoked == null && !IsExpired;

        public int UserId { get; set; }

        // Navigation Property
        public User User { get; set; } = null!;
    }
}
