using KOI.Blueprint.Domain.Entites;
using KOI.Blueprint.Domain.Interfaces;
using KOI.Blueprint.Infrastructure.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOI.Blueprint.Infrastructure.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly KOISystemContext _context;
        public IUnitOfWork UnitOfWork => _context;

        public DeviceRepository(KOISystemContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AddAsync(Device device)
        {
            if (device == null)
                throw new ArgumentNullException(nameof(Device));

            await _context.AddAsync(device);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Device>> ListAllDevicesAsync()
        {
            var query = await _context.Devices.ToListAsync();
            return query;
        }
    }
}
