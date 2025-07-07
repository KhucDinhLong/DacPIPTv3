using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PIPTWeb.Shared.Models;

namespace PIPTWeb.Shared.Data
{
    public class PIPTDbContext : IdentityDbContext<SecUsers, SecRoles, string>
    {
        public PIPTDbContext(DbContextOptions<PIPTDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            foreach (var entityType in builder.Model.GetEntityTypes())
            {
                var tableName = entityType.GetTableName();
                if (tableName.StartsWith("AspNet"))
                {
                    entityType.SetTableName("Sec" + tableName.Substring(6));
                }
            }

            builder.Entity<SecGroupAuthorization>().HasKey(ga => new { ga.GroupID, ga.AuthorizationID });
            builder.Entity<SecGroupUser>().HasKey(gu => new { gu.GroupID, gu.LoginID });
            builder.Entity<SecMenuGroup>().HasKey(mg => new { mg.GroupID, mg.MenuID });
            builder.Entity<SecStockUser>().HasKey(su => new { su.StockID, su.LoginID });
        }
        public DbSet<DacAgency> DacAgency { get; set; }
        public DbSet<DacContainer> DacContainer { get; set; }
        public DbSet<DacContainerDetails> DacContainerDetails { get; set; }
        public DbSet<DacDistributeToAgency> DacDistributeToAgency { get; set; }
        public DbSet<DacDistributeToAgencyDetails> DacDistributeToAgencyDetails { get; set; }
        public DbSet<DacDistributeToFactory> DacDistributeToFactory { get; set; }
        public DbSet<DacDistributeToFactoryDetails> DacDistributeToFactoryDetails { get; set; }
        public DbSet<DacFactory> DacFactory { get; set; }
        public DbSet<DacInsertToWarehouse> DacInsertToWarehouse { get; set; }
        public DbSet<DacInsertToWarehouseDetails> DacInsertToWarehouseDetails { get; set; }
        public DbSet<DacInventory> DacInventory { get; set; }
        public DbSet<DacLogBook> DacLogBook { get; set; }
        public DbSet<DacPackage> DacPackage { get; set; }
        public DbSet<DacPackageDetails> DacPackageDetails { get; set; }
        public DbSet<DacProduct> DacProduct { get; set; }
        public DbSet<DacProductCategory> DacProductCategory { get; set; }
        public DbSet<DacProductCode> DacProductCode { get; set; }
        public DbSet<DacProductQuery> DacProductQuery { get; set; }
        public DbSet<DacProductUnit> DacProductUnit { get; set; }
        public DbSet<DacRegion> DacRegion { get; set; }
        public DbSet<DacSellCount> DacSellCount { get; set; }
        public DbSet<DacStock> DacStock { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Nationality> Nationality { get; set; }
        public DbSet<Province> Province { get; set; }
        public DbSet<SecAuthorizations> SecAuthorizations { get; set; }
        public DbSet<SecConfig> SecConfig { get; set; }
        public DbSet<SecGroupAuthorization> SecGroupAuthorization { get; set; }
        public DbSet<SecGroups> SecGroups { get; set; }
        public DbSet<SecGroupUser> SecGroupUser { get; set; }
        public DbSet<SecMenu> SecMenu { get; set; }
        public DbSet<SecMenuGroup> SecMenuGroup { get; set; }
        public DbSet<SecModules> SecModules { get; set; }
        public DbSet<SecStockUser> SecStockUser { get; set; }
        public DbSet<SecFormUsers> SecFormUsers { get; set; }
        public DbSet<SecUsers> SecUsers { get; set; }
        public DbSet<Customers> Customers { get; set; }
        public DbSet<SecRoleMenu> SecRoleMenus { get; set; }
        public DbSet<SysMenu> SysMenus { get; set; }

    }
}

