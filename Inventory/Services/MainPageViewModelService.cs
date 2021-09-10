using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Inventory.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Services
{
    public interface IMainPageViewModelService
    {
        Task<List<Machine>> GetAll();
        Task<Machine> Create(Machine machine);
        Task Delete(Machine machine);
    }

    public class MainPageViewModelService : IMainPageViewModelService
    {
        protected readonly IRepository<Machine> _machineRepository;

        public MainPageViewModelService(IRepository<Machine> machineRepository)
        {
            this._machineRepository = machineRepository;
        }

        public async Task<List<Machine>> GetAll()
        {
            return await _machineRepository.GetAllListAsync();
        }

        public async Task<Machine> Create(Machine machine)
        {
            return await _machineRepository.InsertAsync(machine);
        }

        public async Task Delete(Machine machine)
        {
            await _machineRepository.DeleteAsync(machine);
        }
    }
}
