using KOI.Blueprint.Application.Devices.Commands;
using KOI.Blueprint.Application.Devices.Models;
using KOI.Blueprint.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOI.Blueprint.Application.Devices.Queries
{
    public class ListDevicesQueryHandler : IRequestHandler<ListDevicesQuery, List<DeviceSummary>>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly ILogger<CreateDeviceCommandHandler> _logger;

        public ListDevicesQueryHandler(IDeviceRepository deviceRepository,
           ILogger<CreateDeviceCommandHandler> logger)
        {
            _deviceRepository = deviceRepository ?? throw new ArgumentNullException(nameof(deviceRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<List<DeviceSummary>> Handle(ListDevicesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Listing all devices");

            var devices = await _deviceRepository.ListAllDevicesAsync(cancellationToken);

            // Map Domain Entity -> Application Model
            var result = devices.Select(d => new DeviceSummary
            {
                Id = d.Id,
                DeviceNo = d.DeviceNo,
                SerialNumber = d.SerialNumber,
                InventoryNumber = d.InventoryNumber,
                Manufacturer = d.Manufacturer,
                Type = d.Type,
                ObjectName = d.ObjectName,
                CreatedAt = d.CreatedAt
            }).ToList();

            return result;
        }
    }
}
