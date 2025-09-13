using Microsoft.EntityFrameworkCore;
using System.Reflection;
using RifqiAmmarR.SuiteHub360.Application.Services.Persistence;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Masters;

using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Inventories;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Users;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Payments;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Bookings;
using RifqiAmmarR.SuiteHub360.Domain.Entities.Transactions.Services;

namespace RifqiAmmarR.SuiteHub360.Infrastructure.Persistence.DataContext
{
    public class ApplicationDbContext : DbContext, ISuiteHub360DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // DbSet properties
        #region Bookins
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<BookingService> BookingServices { get; set; }
        #endregion

        #region Inventories
        public DbSet<InventoryItem> InventoryItems { get; set; }
        public DbSet<ItemReceiving> ItemReceivings { get; set; }
        public DbSet<ItemUsage> ItemUsages { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        #endregion

        #region Master Data
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<ItemCategory> ItemCategories { get; set; }
        public DbSet<ItemUnit> ItemUnits { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        #endregion

        #region Payments
        public DbSet<Payment> Payments { get; set; }
        #endregion

        #region Services
        public DbSet<RoomFacility> RoomFacilities { get; set; }
        #endregion

        #region Users
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<User> UsersDatas { get; set; }
        #endregion

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //  otomatis load semua konfigurasi di assembly 
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
