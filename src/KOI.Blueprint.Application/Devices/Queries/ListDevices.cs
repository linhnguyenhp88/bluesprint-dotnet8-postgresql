using KOI.Blueprint.Application.Devices.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOI.Blueprint.Application.Devices.Queries
{
    public class ListDevicesQuery() : IRequest<List<DeviceSummary>>
    {

    }
}
