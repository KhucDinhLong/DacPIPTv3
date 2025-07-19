using System.Data.Entity;

namespace DAC.DAL
{
    public partial class PIPTDbContext : DbContext
    {
        public PIPTDbContext()
            : base("name=PIPTDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SecGroupAuthorization>().HasKey(obj => new { obj.GroupId, obj.AuthorizationId });
            modelBuilder.Entity<SecGroupUser>().HasKey(obj => new { obj.GroupId, obj.LoginId });
            modelBuilder.Entity<SecMenuGroup>().HasKey(obj => new { obj.GroupId, obj.MenuId });
            modelBuilder.Entity<SecStockUser>().HasKey(obj => new { obj.StockId, obj.LoginId });
        }

        public DbSet<DacCustomer> DacCustomer { get; set; }
        public DbSet<DacContainer> DacContainer { get; set; }
        public DbSet<DacContainerDetails> DacContainerDetails { get; set; }
        public DbSet<DacExport> DacExport { get; set; }
        public DbSet<DacExportDetail> DacExportDetail { get; set; }
        public DbSet<DacExport1> DacExport1 { get; set; }
        public DbSet<DacExportDetail1> DacExportDetail1 { get; set; }
        public DbSet<DacExport2> DacExport2 { get; set; }
        public DbSet<DacExportDetail2> DacExportDetail2 { get; set; }
        public DbSet<DacExport3> DacExport3 { get; set; }
        public DbSet<DacExportDetail3> DacExportDetail3 { get; set; }
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
