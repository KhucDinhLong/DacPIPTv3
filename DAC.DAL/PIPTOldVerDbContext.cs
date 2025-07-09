
using System.Data.Entity;

namespace DAC.DAL.OldVersion
{
    public partial class PIPTOldVerDbContext : DbContext
    {
        public PIPTOldVerDbContext()
            : base("name=PIPTOldVerDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SecGroupAuthorization>().HasKey(obj => new { obj.GroupId, obj.AuthorizationId });
            modelBuilder.Entity<SecGroupUser>().HasKey(obj => new { obj.GroupID, obj.LoginID });
            modelBuilder.Entity<SecMenuGroup>().HasKey(obj => new { obj.GroupID, obj.MenuID });
            modelBuilder.Entity<SecStockUser>().HasKey(obj => new { obj.StockID, obj.LoginID });
        }

        public DbSet<DacAgency> DacAgency { get; set; }
        public DbSet<DacContainer> DacContainer { get; set; }
        public DbSet<DacContainerDetails> DacContainerDetails { get; set; }
        public DbSet<DacDistributeToAgency> DacDistributeToAgency { get; set; }
        public DbSet<DacDistributeToAgencyDetails> DacDistributeToAgencyDetails { get; set; }
        public DbSet<DacDistributeToFactory> DacDistributeToFactory { get; set; }
        public DbSet<DacDistributeToFactoryDetails> DacDistributeToFactoryDetails { get; set; }
        public DbSet<DacDistributeToStore> DacDistributeToStore { get; set; }
        public DbSet<DacDistributeToStoreDetails> DacDistributeToStoreDetails { get; set; }
        public DbSet<DacFactory> DacFactory { get; set; }
        public DbSet<DacInsertToWarehouse> DacInsertToWarehouse { get; set; }
        public DbSet<DacInsertToWarehouseDetails> DacInsertToWarehouseDetails { get; set; }
        public DbSet<DacInventory> DacInventory { get; set; }
        public DbSet<DacLogBook> DacLogBook { get; set; }
        public DbSet<DacPackage> DacPackage { get; set; }
        public DbSet<DacPackageDetails> DacPackageDetails { get; set; }
        public DbSet<DacProduct> DacProduct { get; set; }
        public DbSet<DacRegion> DacRegion { get; set; }
        public DbSet<DacProductCategory> DacProductCategory { get; set; }
        public DbSet<DacProductCode> DacProductCode { get; set; }
        public DbSet<DacProductQuery> DacProductQuery { get; set; }
        public DbSet<DacProductUnit> DacProductUnit { get; set; }
        public DbSet<DacSellCount> DacSellCount { get; set; }
        public DbSet<DacStock> DacStock { get; set; }
        public DbSet<DacStore> DacStore { get; set; }
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
        public DbSet<SecUsers> SecUsers { get; set; }
    }
}
