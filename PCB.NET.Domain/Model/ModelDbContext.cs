namespace PCB.NET.Domain.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Warehouse;

    public class ModelDbContext : DbContext
    {
        public ModelDbContext()
            : base("name=ModelDbContext")
        {
        }

        public virtual DbSet<Board> Boards { get; set; }
        public virtual DbSet<GasBalloon> GasBalloons { get; set; }
        public virtual DbSet<Hanging> Hangings { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<RatedItem> RatedItems { get; set; }
        public virtual DbSet<SMD> SMDs { get; set; }
        public virtual DbSet<SMDSize> SMDSizes { get; set; }


    }

}