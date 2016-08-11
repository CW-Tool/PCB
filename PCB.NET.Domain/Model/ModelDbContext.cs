namespace PCB.NET.Domain.Model
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ModelDbContext : DbContext
    {
        public ModelDbContext()
            : base("name=ModelDbContext")
        {
        }

        public virtual DbSet<Warehouse> MyEntities { get; set; }
    }

}