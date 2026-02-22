using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOI.Blueprint.Application.Devices.Dtos
{
    public class DeviceDto
    {
        public DeviceDto() 
        {
            DeviceId = Guid.NewGuid();
        }

        public Guid DeviceId { get; set; }
    }
}
