using KOI.Blueprint.Application.Devices.Dtos;
using KOI.Blueprint.Application.Exceptions;
using KOI.Blueprint.Domain.Entites;
using KOI.Blueprint.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOI.Blueprint.Application.Devices.Commands
{
    public class CreateDeviceCommandHandler : IRequestHandler<CreateDeviceCommand, DeviceDto>
    {
        private readonly IDeviceRepository _deviceRepository;
        private readonly ILogger<CreateDeviceCommandHandler> _logger;

        public CreateDeviceCommandHandler(IDeviceRepository deviceRepository,
           ILogger<CreateDeviceCommandHandler> logger)
        {
            _deviceRepository = deviceRepository ?? throw new ArgumentNullException(nameof(deviceRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<DeviceDto> Handle(CreateDeviceCommand request, CancellationToken cancellationToken)
        {     
            var device = new Device
            {             
                Id = Guid.NewGuid(),
                DeviceNo = request.DeviceNo,
                InventoryNumber = request.InventoryNumber,
                Manufacturer = request.Manufacturer,
                ObjectName = request.ObjectName,
                SerialNumber = request.SerialNumber,
                Type = request.Type,
                UpdatedDate = DateTime.UtcNow,
                CreatedAt = DateTimeOffset.UtcNow
            };

            _logger.LogInformation($"Creating Device with Id :  {device.Id}");

            await _deviceRepository.AddAsync(device);
            return new DeviceDto { DeviceId = device.Id };
        }
    }
}
