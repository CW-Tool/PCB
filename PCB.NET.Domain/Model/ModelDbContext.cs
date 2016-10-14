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
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelContext"/> class.
        /// </summary>
        public ModelContext()
            : base("name=ModelDbContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        #region Warehouse DbSet
        /// <summary>
        /// Gets or sets the boards.
        /// </summary>
        /// <value>The boards.</value>
        public virtual DbSet<Board> Boards { get; set; }
        /// <summary>
        /// Gets or sets the gas balloons.
        /// </summary>
        /// <value>The gas balloons.</value>
        public virtual DbSet<GasBalloon> GasBalloons { get; set; }
        /// <summary>
        /// Gets or sets the hangings.
        /// </summary>
        /// <value>The hangings.</value>
        public virtual DbSet<Hanging> Hangings { get; set; }
        /// <summary>
        /// Gets or sets the sm ds.
        /// </summary>
        /// <value>The sm ds.</value>
        public virtual DbSet<SMD> SMDs { get; set; }
        /// <summary>
        /// Gets or sets the sizes.
        /// </summary>
        /// <value>The sizes.</value>
        public virtual DbSet<Size> Sizes { get; set; }
        /// <summary>
        /// Gets or sets the packages.
        /// </summary>
        /// <value>The packages.</value>
        public virtual DbSet<Package> Packages { get; set; }
        /// <summary>
        /// Gets or sets the hanging item maps.
        /// </summary>
        /// <value>The hanging item maps.</value>
        public virtual DbSet<HangingItemMap> HangingItemMaps { get; set; }
        /// <summary>
        /// Gets or sets the SMD item maps.
        /// </summary>
        /// <value>The SMD item maps.</value>
        public virtual DbSet<SMDItemMap> SMDItemMaps { get; set; }
        /// <summary>
        /// Gets or sets the items.
        /// </summary>
        /// <value>The items.</value>
        public virtual DbSet<Item> Items { get; set; }
        #endregion

        #region Employee DbSet
        /// <summary>
        /// Gets or sets the done works.
        /// </summary>
        /// <value>The done works.</value>
        public virtual DbSet<DoneWork> DoneWorks { get; set; }
        /// <summary>
        /// Gets or sets the employees.
        /// </summary>
        /// <value>The employees.</value>
        public virtual DbSet<Employee> Employees { get; set; }
        /// <summary>
        /// Gets or sets the positions.
        /// </summary>
        /// <value>The positions.</value>
        public virtual DbSet<Position> Positions { get; set; }
        #endregion

        #region Machine DbSet
        /// <summary>
        /// Gets or sets the DVCS.
        /// </summary>
        /// <value>The DVCS.</value>
        public virtual DbSet<Dvc> Dvcs { get; set; }
        /// <summary>
        /// Gets or sets the ebsos.
        /// </summary>
        /// <value>The ebsos.</value>
        public virtual DbSet<Ebso> Ebsos { get; set; }
        #endregion

        #region Map DbSet
        /// <summary>
        /// Gets or sets the maps.
        /// </summary>
        /// <value>The maps.</value>
        public virtual DbSet<Map> Maps { get; set; }
        /// <summary>
        /// Gets or sets the map boards.
        /// </summary>
        /// <value>The map boards.</value>
        public virtual DbSet<MapBoard> MapBoards { get; set; }

        #endregion
    }
}