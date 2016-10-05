namespace PCB.NET.Domain.Model
{
    using System.Data.Entity;
    using Warehouse.WorkshopPCB;

    public class ModelDbContext : DbContext
    {
        public ModelDbContext()
            : base("name=ModelDbContext")
        {
        }

        public virtual DbSet<Board> Boards { get; set; }
        public virtual DbSet<GasBalloon> GasBalloons { get; set; }
        public virtual DbSet<Hanging> Hangings { get; set; }
        public virtual DbSet<SMD> SMDs { get; set; }
        public virtual DbSet<Size> Sizes { get; set; }

    }
}