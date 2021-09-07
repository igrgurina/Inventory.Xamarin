using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Inventory.Enumerations;
using Inventory.Models;

namespace Inventory.Services
{
    public sealed partial class InventoryContext
    {
        partial void Seed()
        {
            if (Machines?.Count() == 0)
            {
                this.Machines.AddRange(
                    new Machine() { MachineName = "PC123", MachineType = MachineType.PC, MachineCPU = "Ryzen", MachineGPU = "GeForce", MachineHDD = "Samsung", MachineRAM = "Corsair", MachineId = 1 },
                    new Machine() { MachineName = "Server123", MachineType = MachineType.Server, MachineCPU = "Threadripper", MachineGPU = "Quadro", MachineHDD = "Seagate", MachineRAM = "Kingston", MachineId = 2 },
                    new Machine() { MachineName = "Laptop123", MachineType = MachineType.Laptop, MachineCPU = "Ryzen", MachineGPU = "Quadro", MachineHDD = "Seagate", MachineRAM = "Kingston", MachineId = 3 }
                );
            }
        }


    }
}
