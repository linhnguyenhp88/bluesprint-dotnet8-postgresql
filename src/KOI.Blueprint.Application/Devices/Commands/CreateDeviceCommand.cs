using KOI.Blueprint.Application.Devices.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOI.Blueprint.Application.Devices.Commands
{
    public class CreateDeviceCommand : IRequest<DeviceDto>
    {
        public string DeviceNo { get; set; } 
        public string? SerialNumber { get; set; }
        public string? InventoryNumber { get; set; }
        public string Manufacturer { get; set; } 
        public string Type { get; set; }
        public string? ObjectName { get; set; }
    }
}
