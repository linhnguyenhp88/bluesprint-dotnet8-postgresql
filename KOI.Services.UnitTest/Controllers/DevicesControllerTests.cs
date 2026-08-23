using FluentAssertions;
using KOI.Blueprint.API.Controllers;
using KOI.Blueprint.Application.Devices.Commands;
using KOI.Blueprint.Application.Devices.Dtos;
using KOI.Blueprint.Application.Devices.Models;
using KOI.Blueprint.Application.Devices.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOI.Services.UnitTest.Controllers
{
    public class DevicesControllerTests
    {
        private readonly Mock<IMediator> _mediatorMock;
        private readonly DevicesController _devicesController;
        public DevicesControllerTests()
        {
            _mediatorMock = new Mock<IMediator>();
            _devicesController = new DevicesController(_mediatorMock.Object);
        }

        [Fact]
        public void Constructor_WhenMediatorIsNull_ShouldThrowArgumentNullException()
        {
            
            Action _action = () => new DevicesController(null);
            // Act & Assert
            _action.Should().Throw<ArgumentNullException>()
                .WithParameterName("mediator");
        }

        [Fact]
        public async Task GetAllDevices_ShouldReturnOkWithDevices()
        {
            var expected = new List<DeviceSummary>
            {
                new DeviceSummary
                {
                    Id = Guid.NewGuid(),
                    DeviceNo = "Device1",
                    SerialNumber = "SN123",
                    InventoryNumber = "INV123",
                    Manufacturer = "Manufacturer1",
                    Type = "Type1",
                    ObjectName = "Object1",
                    CreatedAt = DateTimeOffset.UtcNow
                },
            };

            _mediatorMock
                .Setup(m => m.Send(It.IsAny<ListDevicesQuery>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(expected);

            var result =  await _devicesController.GetAllDevices();

            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;

            _mediatorMock.Verify(
                x => x.Send(It.IsAny<ListDevicesQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }

        [Fact]
        public async Task Create_ShouldReturnOkWithDevice()
        {
            var command = new CreateDeviceCommand
            {
                DeviceNo = "Device1",
                SerialNumber = "SN123",
                InventoryNumber = "INV123",
                Manufacturer = "Manufacturer1",
                Type = "Type1",
                ObjectName = "Object1"
            };
            var expectedDevice = new DeviceDto
            {
                DeviceId = Guid.NewGuid()              
            };

            _mediatorMock
                .Setup(x => x.Send(command, It.IsAny<CancellationToken>()))
                .ReturnsAsync(expectedDevice);

            var result = await _devicesController.Create(command);

            var okResult = result.Should().BeOfType<OkObjectResult>().Subject;
            okResult.Value.Should().BeEquivalentTo(expectedDevice);

            _mediatorMock.Verify(
                x => x.Send(command, It.IsAny<CancellationToken>()), Times.Once);

        }
    }
}
