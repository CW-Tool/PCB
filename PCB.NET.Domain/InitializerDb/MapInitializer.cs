using PCB.NET.Domain.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCB.NET.Domain.InitializerDb
{
    /// <summary>
    /// Class MapInitializer.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DropCreateDatabaseIfModelChanges{PCB.NET.Domain.Model.ModelContext}" />
    public class MapInitializer : DropCreateDatabaseIfModelChanges<ModelContext>
    {
        protected override void Seed(ModelContext context)
        {
            ////TODO: Something
            //var something = new List<Something>
            //    {
            //    new Something { Name = "ЮЛИГ.301471.053ПЭ3", CountBoard = 40, Description = "это описание",
            //        LastUpdate = DateTime.Parse("2016-08-12")},
            //    };
            //something.ForEach(s => context.Something.Add(s));
            context.SaveChanges();
        }
    }
}
