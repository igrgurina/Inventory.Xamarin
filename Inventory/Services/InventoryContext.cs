using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Inventory.Models;
using Microsoft.EntityFrameworkCore;
using Xamarin.Essentials;

namespace Inventory.Services
{
    public class InventoryContext : DbContext
    {
        public DbSet<Machine> Machines { get; set; }

        public InventoryContext()
        {
            // SQLitePCL.Batteries_V2.Init(); // needed for iOS

            this.Database.EnsureCreated();

            if (Machines?.Count() == 0)
            {
                this.Machines.AddRange(
                    new Machine() { MachineName = "PC123", MachineType = MachineType.PC, MachineCPU = "Ryzen", MachineGPU = "GeForce", MachineHDD = "Samsung", MachineRAM = "Corsair", MachineId = 1 },
                    new Machine() { MachineName = "Server123", MachineType = MachineType.Server, MachineCPU = "Threadripper", MachineGPU = "Quadro", MachineHDD = "Seagate", MachineRAM = "Kingston", MachineId = 2 },
                    new Machine() { MachineName = "Laptop123", MachineType = MachineType.Laptop, MachineCPU = "Ryzen", MachineGPU = "Quadro", MachineHDD = "Seagate", MachineRAM = "Kingston", MachineId = 3 }
                );
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "machines.db3");

            optionsBuilder
                .UseSqlite($"Filename={dbPath}");
        }
    }
}
