namespace PCB.NET.Domain.Model
{
    using System.Data.Entity;
    using System.Data.Entity.ModelConfiguration.Conventions;
    using WorkshopPCB.Employee;
    using WorkshopPCB.Machine;
    using WorkshopPCB.Map;
    using WorkshopPCB.Warehouse;

    /// <summary>
    /// Class ModelContext.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DbContext" />
    public class ModelContext : DbContext
    {
        public ModelContext()
            : base("name=ModelDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        #region Warehouse DbSet
        public virtual DbSet<Board> Boards { get; set; }
        public virtual DbSet<GasBalloon> GasBalloons { get; set; }
        public virtual DbSet<Hanging> Hangings { get; set; }
        public virtual DbSet<SMD> SMDs { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }
        public virtual DbSet<Package> Packages { get; set; }
        public virtual DbSet<HangingItemMap> HangingItemMaps { get; set; }
        public virtual DbSet<SMDItemMap> SMDItemMaps { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        #endregion

        #region Employee DbSet
        public virtual DbSet<DoneWork> DoneWorks { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Position> Positions { get; set; }
        #endregion

        #region Machine DbSet
        public virtual DbSet<Dvc> Dvcs { get; set; }
        public virtual DbSet<Ebso> Ebsos { get; set; }
        #endregion

        #region Map DbSet
        public virtual DbSet<Map> Maps { get; set; }
        public virtual DbSet<MapBoard> MapBoards { get; set; }

        #endregion
    }
}