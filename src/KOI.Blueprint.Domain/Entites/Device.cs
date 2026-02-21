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
        public DateTimeOffset CreatedAt { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
