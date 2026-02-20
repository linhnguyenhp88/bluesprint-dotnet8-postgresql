using KOI.Blueprint.Domain.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KOI.Blueprint.Infrastructure.EntityFrameworkCore
{
    public class DeviceEntityTypeConfiguration : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> deviceConfiguration)
        {
            deviceConfiguration.ToTable("Device", KOISystemContext.DEFAULT_SCHEMA);
            deviceConfiguration.HasKey(o => o.Id);

            
            deviceConfiguration
                .Property<string>("DeviceNo")
                .HasColumnName("DeviceNo")
                .HasMaxLength(100)
                .IsRequired();

            deviceConfiguration
                .Property<string>("SerialNumber")
                .HasColumnName("SerialNumber")
                .HasMaxLength(100)
                .IsRequired(false);

            deviceConfiguration
               .Property<string>("InventoryNumber")
               .HasColumnName("InventoryNumber")
               .HasMaxLength(100)
               .IsRequired(false);

            deviceConfiguration
               .Property<string>("Manufacturer")
               .HasColumnName("Manufacturer")         
               .IsRequired();

            deviceConfiguration
               .Property<string>("Type")
               .HasColumnName("Type")
               .HasMaxLength(100)
               .IsRequired();

            deviceConfiguration
              .Property<string>("ObjectName")
              .HasColumnName("ObjectName")
              .HasMaxLength(250)
              .IsRequired(false);

            deviceConfiguration
                .Property<DateTimeOffset>("CreatedAt")
                .HasColumnName("CreatedAt")
                .IsRequired();

            deviceConfiguration
                .Property<DateTime>("UpdatedDate")
                .HasColumnName("UpdatedDate")
                .IsRequired();
        }
    }
}
