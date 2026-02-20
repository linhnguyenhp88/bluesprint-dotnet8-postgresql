using KOI.Blueprint.Domain.Interfaces;
using KOI.Blueprint.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOI.Blueprint.Domain.Entites
{
    public class Device : Entity, IAggregateRoot
    {
        // Identification
        public string DeviceNo { get; private set; } = default!;
        public string? SerialNumber { get; private set; }
        public string? InventoryNumber { get; private set; }
        public string Manufacturer { get; private set; } = default!;
        public string Type { get; private set; } = default!;
        public string? ObjectName { get; private set; }

        // Commercial
        public decimal CalibrationPrice { get; private set; }
        public decimal DiscountPercent { get; private set; }
        public bool HasSceCertificate { get; private set; }

        // Lifecycle
        public DeviceStatus Status { get; private set; }
        public DateTimeOffset IncomingDate { get; private set; }
        public DateTimeOffset? DueDate { get; private set; }
        public DateTimeOffset? OutgoingDate { get; private set; }

        // Notes
        public string? MemoExternal { get; private set; }
        public string? MemoInternal { get; private set; }

        // Relationship
        public Guid CustomerId { get; private set; }

    }
}
