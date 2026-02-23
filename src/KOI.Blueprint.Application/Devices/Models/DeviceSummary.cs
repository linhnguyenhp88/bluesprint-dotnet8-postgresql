using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOI.Blueprint.Application.Devices.Models
{
    public class DeviceSummary
    {
        public Guid Id { get; init; }
        public string DeviceNo { get; init; } = default!;
        public string? SerialNumber { get; init; }
        public string? InventoryNumber { get; init; }
        public string Manufacturer { get; init; } = default!;
        public string Type { get; init; } = default!;
        public string? ObjectName { get; init; }
        public DateTimeOffset CreatedAt { get; init; }
    }
}
