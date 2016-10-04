using System;
using System.Collections.Generic;
using System.Data.Entity;
using PCB.NET.Domain.Model;
using PCB.NET.Domain.Model.Warehouse.WorkshopPCB;

namespace PCB.NET.Domain.InitializerDb
{
    public class WarehouseInitializer : DropCreateDatabaseIfModelChanges<ModelDbContext>
    {
        protected override void Seed(ModelDbContext context)
        {
            //TODO: SMD and Hanging
            var board = new List<Board>
                {
                new Board { Name = "ЮЛИГ.301471.053ПЭ3", CountBoard = 40, Description = "это описание",
                    LastUpdate = DateTime.Parse("2016-08-12")},
                };
            board.ForEach(s => context.Boards.Add(s));
            context.SaveChanges();

            //TODO:
            var gasBalloon = new List<GasBalloon>
                {
                new GasBalloon { GasBalloonId = 1, BalloonNumber = "A81-61520, N387465, Y.65-71 P-150",
                    LastUpdate = DateTime.Parse("2016-08-11") }
                };
            gasBalloon.ForEach(s => context.GasBalloons.Add(s));
            context.SaveChanges();

            //TODO:
            var hanging = new List<Hanging>
                {
                new Hanging { HangingId = 1, CountItem = 4321, LastUpdate = DateTime.Parse("2005-09-01")},
                };
            hanging.ForEach(s => context.Hangings.Add(s));
            context.SaveChanges();

            //TODO:
            //var item = new List<Item>
            //    {
            //    new Item { ItemId = 1, NameItem = "Варистор"},
            //    new Item { ItemId = 2, NameItem = "Клеммник" },
            //    new Item { ItemId = 3, NameItem = "Конденсатор" },
            //    new Item { ItemId = 4, NameItem = "Микросхема" },
            //    new Item { ItemId = 5, NameItem = "Резистор" },
            //    new Item { ItemId = 6, NameItem = "Светодиод" }
            //    };
            //item.ForEach(s => context.Items.Add(s));
            //context.SaveChanges();

            //TODO:
            //var ratedItem = new List<RatedItem>
            //    {
            //    new RatedItem { RatedItemId = 1, NomValue = "Om" },
            //    new RatedItem { RatedItemId = 2, NomValue = "kOm" },
            //    new RatedItem { RatedItemId = 3, NomValue = "MOm" },
            //    new RatedItem { RatedItemId = 4, NomValue = "mkF" },
            //    new RatedItem { RatedItemId = 5, NomValue = "pkF" }
            //    };
            //ratedItem.ForEach(s => context.RatedItems.Add(s));
            //context.SaveChanges();

            //TODO:
            var smd = new List<SMD>
                {
                new SMD { SMDId = 1, Value = 0.1, DescriptionItem = "описание какое то",
                    Packages = "CASE1206", Feeder = 64, CountItem = 1234,
                    LastUpdate = DateTime.Parse("2016-07-23")},
                };
            smd.ForEach(s => context.SMDs.Add(s));
            context.SaveChanges();

            //TODO:
            var smdSize = new List<Size>
                {
                new Size { SizeId = 1, SizeItem = 0603 },
                new Size { SizeId = 2, SizeItem = 0805 },
                new Size { SizeId = 3, SizeItem = 1206 },
                new Size { SizeId = 4, SizeItem = 2010 },
                new Size { SizeId = 5, SizeItem = 2512 }
                };
            smdSize.ForEach(s => context.Sizes.Add(s));
            context.SaveChanges();
        }
    }
}