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
        public string? DeviceNo { get; set; } 
        public string? SerialNumber { get; set; }
        public string? InventoryNumber { get; set; }
        public string? Manufacturer { get; set; }
        public string? Type { get; set; } 
        public string? ObjectName { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
