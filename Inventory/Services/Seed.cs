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
                    new Machine() { MachineName = "Fractal Design", MachineType = MachineType.PC, MachineCPU = "Ryzen", MachineGPU = "Radeon", MachineHDD = "Samsung", MachineRAM = "Corsair", MachineId = 1 },
                    new Machine() { MachineName = "Corsair", MachineType = MachineType.Server, MachineCPU = "Threadripper", MachineGPU = "Quadro", MachineHDD = "Seagate", MachineRAM = "Kingston", MachineId = 2 },
                    new Machine() { MachineName = "Lenovo ThinkPad", MachineType = MachineType.Laptop, MachineCPU = "Ryzen", MachineGPU = "GeForce", MachineHDD = "Toshiba", MachineRAM = "Crucial", MachineId = 3 }
                );
            }
        }


    }
}
