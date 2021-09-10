using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Models;
using Microsoft.EntityFrameworkCore;
using Xamarin.Essentials;

namespace Inventory.Services
{
    public sealed partial class InventoryContext : DbContext
    {
        public DbSet<Machine> Machines { get; set; }

        public InventoryContext()
        {
            // SQLitePCL.Batteries_V2.Init(); // needed for iOS

            this.Database.EnsureCreated();

            Seed();
        }

        partial void Seed();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "machines.db3");

            optionsBuilder
                .UseSqlite($"Filename={dbPath}");
        }
    }

    public interface IDbContextProvider<out TDbContext>
    {
        TDbContext GetDbContext();
    }

    public sealed class SimpleDbContextProvider<TDbContext> : IDbContextProvider<TDbContext>
        where TDbContext : DbContext
    {
        public TDbContext DbContext { get; }

        public SimpleDbContextProvider(TDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public TDbContext GetDbContext()
        {
            return DbContext;
        }

        public Task<TDbContext> GetDbContextAsync()
        {
            return Task.FromResult(DbContext);
        }
    }
}
