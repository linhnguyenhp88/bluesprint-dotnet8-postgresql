using KOI.Blueprint.Domain.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOI.Blueprint.Domain.Interfaces
{
    public interface IDeviceRepository : IRepository<Device>
    {
        Task AddAsync(Device device);
        Task<List<Device>> ListAllDevicesAsync(CancellationToken cancellationToken = default);
    }
}
