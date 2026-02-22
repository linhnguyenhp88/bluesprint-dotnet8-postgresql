using FluentValidation;
using KOI.Blueprint.Application.Devices.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOI.Blueprint.Application.Devices.Validations
{
    public class CreateDeviceValidator : AbstractValidator<CreateDeviceCommand>
    {
        public CreateDeviceValidator()
        {
            RuleFor(x => x.DeviceNo)
                 .NotEmpty();

            RuleFor(x => x.Manufacturer)
                .NotEmpty()
                .MaximumLength(200);

            RuleFor(x => x.InventoryNumber)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Type)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
