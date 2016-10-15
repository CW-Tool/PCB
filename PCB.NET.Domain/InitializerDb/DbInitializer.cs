using System;
using System.Collections.Generic;
using System.Data.Entity;
using PCB.NET.Domain.Model;
using PCB.NET.Domain.Model.WorkshopPCB.Warehouse;
using PCB.NET.Domain.Model.WorkshopPCB.Machine;
using PCB.NET.Domain.Model.WorkshopPCB.Map;
using PCB.NET.Domain.Model.WorkshopPCB.Employee;

namespace PCB.NET.Domain.InitializerDb
{
    /// <summary>
    /// Class DbInitializer.
    /// </summary>
    /// <seealso cref="System.Data.Entity.DropCreateDatabaseAlways{PCB.NET.Domain.Model.ModelContext}" />
    public class DbInitializer : System.Data.Entity.DropCreateDatabaseAlways<ModelContext>
    {
        protected override void Seed(PCB.NET.Domain.Model.ModelContext context)
        {
            #region WarehouseInitializer
            var board = new List<Board>
                {
                    new Board { BoardId = 1, NameBlock = "058-01", Make = "028", CountBoard = 20, Description = "Это простое описание платы 058-01", LastUpdate = DateTime.Now },
                    new Board { BoardId = 2, NameBlock = "048", Make = "029", CountBoard = 25, Description = "Это простое описание платы 048", LastUpdate = DateTime.Now },
                    new Board { BoardId = 3, NameBlock = "053", Make = "Трель-1", CountBoard = 40, Description = "Это простое описание платы 053", LastUpdate = DateTime.Now },
                    new Board { BoardId = 4, NameBlock = "064", Make = "033", CountBoard = 20, Description = "Это простое описание платы 064", LastUpdate = DateTime.Now },
                };
            board.ForEach(m => context.Boards.Add(m));
            context.SaveChanges();


            var size = new List<Size>
            {
                new Size {SizeId = 1, Sizes = "null" },
                new Size {SizeId = 2, Sizes = "8*12 мм" },
                new Size {SizeId = 3, Sizes = "10 мм" },
                new Size {SizeId = 4, Sizes = "2.54 мм" },
                new Size {SizeId = 5, Sizes = "1.35 мм" },
                new Size {SizeId = 6, Sizes = "5 мм" },
            };
            size.ForEach(m => context.Sizes.Add(m));
            context.SaveChanges();


            var package = new List<Package>
            {
                new Package {PackagesId = 1, Packs = "RE-0603" },
                new Package {PackagesId = 2, Packs = "RE-0805" },
                new Package {PackagesId = 3, Packs = "RE-1206" },
                new Package {PackagesId = 4, Packs = "RE-2010" },
                new Package {PackagesId = 5, Packs = "CACE-0603" },
                new Package {PackagesId = 6, Packs = "CACE-0805" },
                new Package {PackagesId = 7, Packs = "CACE-1206" },
                new Package {PackagesId = 8, Packs = "CACE-2010" },
                new Package {PackagesId = 9, Packs = "SOT-23" },
                new Package {PackagesId = 10, Packs = "SOD-80" }
            };
            package.ForEach(m => context.Packages.Add(m));
            context.SaveChanges();


            var item = new List<Item>
            {
                new Item { ItemId = 1, NameItem = "Резистор", DescriptionItem = "Резистор - это Резистор!" },
                new Item { ItemId = 2, NameItem = "Варистор", DescriptionItem =  "Варистор - это Варистор!" },
                new Item { ItemId = 3, NameItem = "Гнездо", DescriptionItem =  "Гнездо - это Гнездо!" },
                new Item { ItemId = 4, NameItem = "Диод", DescriptionItem =  "Диод - это Диод!" },
                new Item { ItemId = 5, NameItem = "Диодный Мост", DescriptionItem =  "Диодный Мост - это Диодный Мост!" },
                new Item { ItemId = 6, NameItem = "Дроссель", DescriptionItem =  "Дроссель - это Дроссель!" },
                new Item { ItemId = 7, NameItem = "Клеммник", DescriptionItem =  "Клеммник - это Клеммник!" },
                new Item { ItemId = 8, NameItem = "Конденсатор", DescriptionItem =  "Конденсатор - это Конденсатор!" },
                new Item { ItemId = 9, NameItem = "Предохранитель", DescriptionItem =  "Предохранитель - это Предохранитель!" },
                new Item { ItemId = 10, NameItem = "Стабилитрон", DescriptionItem =  "Стабилитрон - это Стабилитрон!" },
                new Item { ItemId = 11, NameItem = "Транзистор", DescriptionItem =  "Транзистор - это Транзистор!" }
            };
            item.ForEach(m => context.Items.Add(m));
            context.SaveChanges();


            var smd = new List<SMD>
            {
                new SMD { SMDId = 1, ValueItem = "LL4148", DescriptionItem = "0.15A, 75V", Feeder = 21, CountItem = 12000, LastUpdate = DateTime.Now, ItemId = 4, PackagesId = 8 },
                new SMD { SMDId = 2, ValueItem = "0.15", RatedItem = RatedItem.mkF, DescriptionItem = "70V", Feeder = 32, CountItem = 3000, LastUpdate = DateTime.Now, ItemId = 8, PackagesId = 6 },
                new SMD { SMDId = 3, ValueItem = "20", RatedItem = RatedItem.kOm, DescriptionItem = "просто резистор", Feeder = 23, CountItem = 800, LastUpdate = DateTime.Now, ItemId = 1, PackagesId = 2 },
                new SMD { SMDId = 4, ValueItem = "10", RatedItem = RatedItem.kOm, DescriptionItem = "просто резистор", Feeder = 28, CountItem = 4000, LastUpdate = DateTime.Now, ItemId = 1, PackagesId = 2 },
                new SMD { SMDId = 5, ValueItem = "1", RatedItem = RatedItem.MOm, DescriptionItem = "просто резистор", Feeder = 24, CountItem = 1250, LastUpdate = DateTime.Now, ItemId = 1, PackagesId = 2 },
                new SMD { SMDId = 6, ValueItem = "330", RatedItem = RatedItem.kOm, DescriptionItem = "просто резистор", Feeder = 25, CountItem = 8970, LastUpdate = DateTime.Now, ItemId = 1, PackagesId = 2 },
                new SMD { SMDId = 7, ValueItem = "12", RatedItem = RatedItem.V, DescriptionItem = "0.15 Вт", Feeder = 32, CountItem = 1500, LastUpdate = DateTime.Now, ItemId = 10, PackagesId = 10 },
                new SMD { SMDId = 8, ValueItem = "BC846B", DescriptionItem = "просто транзистор", Feeder = 36, CountItem = 6000, LastUpdate = DateTime.Now, ItemId = 11, PackagesId = 9 }
            };
            smd.ForEach(m => context.SMDs.Add(m));
            context.SaveChanges();


            var hanging = new List<Hanging>
            {
                new Hanging { HangingId = 1, ValueItem = "10D275K", DescriptionItem = "275V ", CountItem = 2000, LastUpdate = DateTime.Now, ItemId = 2, SizeId = 3 },
                new Hanging { HangingId = 2, ValueItem = "PBS-4", DescriptionItem = "1x4 для пайки на плату", CountItem = 300, LastUpdate = DateTime.Now, ItemId = 3, SizeId = 4 },
                new Hanging { HangingId = 3, ValueItem = "FR307", DescriptionItem = "3A - 1000V, корпус DO-201AD", CountItem = 500, LastUpdate = DateTime.Now, ItemId = 4, SizeId = 1 },
                new Hanging { HangingId = 4, ValueItem = "KBL10", DescriptionItem = "4.0A - 1000V", CountItem = 4300, LastUpdate = DateTime.Now, ItemId = 5, SizeId = 5 },
                new Hanging { HangingId = 5, ValueItem = "ЮЛИГ.671342.001", DescriptionItem = "либо ДФСИ.671142.001", CountItem = 2300, LastUpdate = DateTime.Now, ItemId = 6, SizeId = 1  },
                new Hanging { HangingId = 6, ValueItem = "DG129-5.0-02P", DescriptionItem = "Degson", CountItem = 2500, LastUpdate = DateTime.Now, ItemId = 7, SizeId = 6 },
                new Hanging { HangingId = 7, ValueItem = "4.7", RatedItem  = RatedItem.mkF, DescriptionItem = "Конденсатор электролитическийб 160В (8х12Х5) +/-20% 105С", CountItem = 255, LastUpdate = DateTime.Now, ItemId = 8, SizeId = 6 },
                new Hanging { HangingId = 8, ValueItem = "FRV055-240F", DescriptionItem = "Предохранитель самовосстонавливаемый, 0.55А, 240В", CountItem = 1000, LastUpdate = DateTime.Now, ItemId = 9, SizeId = 1  },
                new Hanging { HangingId = 9, ValueItem = "3362-X-205 2.0", RatedItem  = RatedItem.MOm, DescriptionItem = "Резистор подстроечный", CountItem = 13000, LastUpdate = DateTime.Now, ItemId = 1, SizeId = 1  },
                new Hanging { HangingId = 10, ValueItem = "IRF740 N-CHANNEL MOSFET", DescriptionItem = "Транзистор корпус ТО-220", CountItem = 24000, LastUpdate = DateTime.Now, ItemId = 11, SizeId = 1  }

            };
            hanging.ForEach(m => context.Hangings.Add(m));
            context.SaveChanges();


            var hangingItemMap = new List<HangingItemMap>
            {
                new HangingItemMap { HangingItemId = 1, NameItem = "V1", BoardId = 2, HangingId = 1 },
                new HangingItemMap { HangingItemId = 2, NameItem = "X2", BoardId = 2, HangingId = 2 },
                new HangingItemMap { HangingItemId = 3, NameItem = "VD4", BoardId = 2, HangingId = 3 },
                new HangingItemMap { HangingItemId = 4, NameItem = "VD5", BoardId = 2, HangingId = 3 },
                new HangingItemMap { HangingItemId = 5, NameItem = "VD6", BoardId = 2, HangingId = 4 },
                new HangingItemMap { HangingItemId = 6, NameItem = "L1", BoardId = 2, HangingId = 5 },
                new HangingItemMap { HangingItemId = 7, NameItem = "X1", BoardId = 2, HangingId = 6 },
                new HangingItemMap { HangingItemId = 8, NameItem = "C2", BoardId = 2, HangingId = 7 },
                new HangingItemMap { HangingItemId = 9, NameItem = "F1", BoardId = 2, HangingId = 8 },
                new HangingItemMap { HangingItemId = 10, NameItem = "R7", BoardId = 2, HangingId = 9 },
                new HangingItemMap { HangingItemId = 11, NameItem = "VT3", BoardId = 2, HangingId = 10 },

                new HangingItemMap { HangingItemId = 12, NameItem = "V1", BoardId = 1, HangingId = 1 },
                new HangingItemMap { HangingItemId = 13, NameItem = "X2", BoardId = 1, HangingId = 2 },
                new HangingItemMap { HangingItemId = 14, NameItem = "VD4", BoardId = 1, HangingId = 3 },
                new HangingItemMap { HangingItemId = 15, NameItem = "VD5", BoardId = 1, HangingId = 3 },
                new HangingItemMap { HangingItemId = 16, NameItem = "VD6", BoardId = 1, HangingId = 4 },
                new HangingItemMap { HangingItemId = 17, NameItem = "L1", BoardId = 1, HangingId = 5 },
                new HangingItemMap { HangingItemId = 18, NameItem = "X1", BoardId = 1, HangingId = 6 },
                new HangingItemMap { HangingItemId = 19, NameItem = "C2", BoardId = 1, HangingId = 7 },
                new HangingItemMap { HangingItemId = 20, NameItem = "F1", BoardId = 1, HangingId = 8 },
                new HangingItemMap { HangingItemId = 21, NameItem = "R7", BoardId = 1, HangingId = 9 },
                new HangingItemMap { HangingItemId = 22, NameItem = "VT3", BoardId = 1, HangingId = 10 },

                new HangingItemMap { HangingItemId = 23, NameItem = "V1", BoardId = 3, HangingId = 1 },
                new HangingItemMap { HangingItemId = 24, NameItem = "X2", BoardId = 3, HangingId = 2 },
                new HangingItemMap { HangingItemId = 25, NameItem = "VD4", BoardId = 3, HangingId = 3 },
                new HangingItemMap { HangingItemId = 26, NameItem = "VD5", BoardId = 3, HangingId = 3 },
                new HangingItemMap { HangingItemId = 27, NameItem = "VD6", BoardId = 3, HangingId = 4 },
                new HangingItemMap { HangingItemId = 28, NameItem = "L1", BoardId = 3, HangingId = 5 },
                new HangingItemMap { HangingItemId = 29, NameItem = "X1", BoardId = 3, HangingId = 6 },
                new HangingItemMap { HangingItemId = 30, NameItem = "C2", BoardId = 3, HangingId = 7 },
                new HangingItemMap { HangingItemId = 31, NameItem = "F1", BoardId = 3, HangingId = 8 },
                new HangingItemMap { HangingItemId = 32, NameItem = "R7", BoardId = 3, HangingId = 9 },
                new HangingItemMap { HangingItemId = 33, NameItem = "VT3", BoardId = 3, HangingId = 10 },

                new HangingItemMap { HangingItemId = 34, NameItem = "V1", BoardId = 4, HangingId = 1 },
                new HangingItemMap { HangingItemId = 35, NameItem = "X2", BoardId = 4, HangingId = 2 },
                new HangingItemMap { HangingItemId = 36, NameItem = "VD4", BoardId = 4, HangingId = 3 },
                new HangingItemMap { HangingItemId = 37, NameItem = "VD5", BoardId = 4, HangingId = 3 },
                new HangingItemMap { HangingItemId = 38, NameItem = "VD6", BoardId = 4, HangingId = 4 },
                new HangingItemMap { HangingItemId = 39, NameItem = "L1", BoardId = 4, HangingId = 5 },
                new HangingItemMap { HangingItemId = 40, NameItem = "X1", BoardId = 4, HangingId = 6 },
                new HangingItemMap { HangingItemId = 41, NameItem = "C2", BoardId = 4, HangingId = 7 },
                new HangingItemMap { HangingItemId = 42, NameItem = "F1", BoardId = 4, HangingId = 8 },
                new HangingItemMap { HangingItemId = 43, NameItem = "R7", BoardId = 4, HangingId = 9 },
                new HangingItemMap { HangingItemId = 44, NameItem = "VT3", BoardId = 4, HangingId = 10 },
            };
            hangingItemMap.ForEach(m => context.HangingItemMaps.Add(m));
            context.SaveChanges();


            var smdItemMap = new List<SMDItemMap>
            {
                new SMDItemMap { SMDItemId = 1, NameItem = "VD2", BoardId = 1, SmdId = 1 },
                new SMDItemMap { SMDItemId = 2, NameItem = "VD3", BoardId = 1, SmdId = 1 },
                new SMDItemMap { SMDItemId = 3, NameItem = "VD7", BoardId = 1, SmdId = 1 },
                new SMDItemMap { SMDItemId = 4, NameItem = "VD8", BoardId = 1, SmdId = 1 },
                new SMDItemMap { SMDItemId = 5, NameItem = "C1", BoardId = 1, SmdId = 2 },
                new SMDItemMap { SMDItemId = 6, NameItem = "C3", BoardId = 1, SmdId = 2 },
                new SMDItemMap { SMDItemId = 7, NameItem = "R1", BoardId = 1, SmdId = 3 },
                new SMDItemMap { SMDItemId = 8, NameItem = "R2", BoardId = 1, SmdId = 4 },
                new SMDItemMap { SMDItemId = 9, NameItem = "R6", BoardId = 1, SmdId = 4 },
                new SMDItemMap { SMDItemId = 10, NameItem = "R3", BoardId = 1, SmdId = 5 },
                new SMDItemMap { SMDItemId = 11, NameItem = "R5", BoardId = 1, SmdId = 5 },
                new SMDItemMap { SMDItemId = 12, NameItem = "R4", BoardId = 1, SmdId = 6 },
                new SMDItemMap { SMDItemId = 13, NameItem = "VD1", BoardId = 1, SmdId = 7 },
                new SMDItemMap { SMDItemId = 14, NameItem = "VT1", BoardId = 1, SmdId = 8 },
                new SMDItemMap { SMDItemId = 15, NameItem = "VT2", BoardId = 1, SmdId = 8 },
                new SMDItemMap { SMDItemId = 16, NameItem = "VT4", BoardId = 1, SmdId = 8 },

                new SMDItemMap { SMDItemId = 17, NameItem = "VD2", BoardId = 2, SmdId = 1 },
                new SMDItemMap { SMDItemId = 18, NameItem = "VD3", BoardId = 2, SmdId = 1 },
                new SMDItemMap { SMDItemId = 19, NameItem = "VD7", BoardId = 2, SmdId = 1 },
                new SMDItemMap { SMDItemId = 20, NameItem = "VD8", BoardId = 2, SmdId = 1 },
                new SMDItemMap { SMDItemId = 21, NameItem = "C1", BoardId = 2, SmdId = 2 },
                new SMDItemMap { SMDItemId = 22, NameItem = "C3", BoardId = 2, SmdId = 2 },
                new SMDItemMap { SMDItemId = 23, NameItem = "R1", BoardId = 2, SmdId = 3 },
                new SMDItemMap { SMDItemId = 24, NameItem = "R2", BoardId = 2, SmdId = 4 },
                new SMDItemMap { SMDItemId = 25, NameItem = "R6", BoardId = 2, SmdId = 4 },
                new SMDItemMap { SMDItemId = 26, NameItem = "R3", BoardId = 2, SmdId = 5 },
                new SMDItemMap { SMDItemId = 27, NameItem = "R5", BoardId = 2, SmdId = 5 },
                new SMDItemMap { SMDItemId = 28, NameItem = "R4", BoardId = 2, SmdId = 6 },
                new SMDItemMap { SMDItemId = 29, NameItem = "VD1", BoardId = 2, SmdId = 7 },
                new SMDItemMap { SMDItemId = 30, NameItem = "VT1", BoardId = 2, SmdId = 8 },
                new SMDItemMap { SMDItemId = 31, NameItem = "VT2", BoardId = 2, SmdId = 8 },
                new SMDItemMap { SMDItemId = 32, NameItem = "VT4", BoardId = 2, SmdId = 8 },

                new SMDItemMap { SMDItemId = 33, NameItem = "VD2", BoardId = 3, SmdId = 1 },
                new SMDItemMap { SMDItemId = 34, NameItem = "VD3", BoardId = 3, SmdId = 1 },
                new SMDItemMap { SMDItemId = 35, NameItem = "VD7", BoardId = 3, SmdId = 1 },
                new SMDItemMap { SMDItemId = 36, NameItem = "VD8", BoardId = 3, SmdId = 1 },
                new SMDItemMap { SMDItemId = 37, NameItem = "C1", BoardId = 3, SmdId = 2 },
                new SMDItemMap { SMDItemId = 38, NameItem = "C3", BoardId = 3, SmdId = 2 },
                new SMDItemMap { SMDItemId = 39, NameItem = "R1", BoardId = 3, SmdId = 3 },
                new SMDItemMap { SMDItemId = 40, NameItem = "R2", BoardId = 3, SmdId = 4 },
                new SMDItemMap { SMDItemId = 41, NameItem = "R6", BoardId = 3, SmdId = 4 },
                new SMDItemMap { SMDItemId = 42, NameItem = "R3", BoardId = 3, SmdId = 5 },
                new SMDItemMap { SMDItemId = 43, NameItem = "R5", BoardId = 3, SmdId = 5 },
                new SMDItemMap { SMDItemId = 44, NameItem = "R4", BoardId = 3, SmdId = 6 },
                new SMDItemMap { SMDItemId = 45, NameItem = "VD1", BoardId = 3, SmdId = 7 },
                new SMDItemMap { SMDItemId = 46, NameItem = "VT1", BoardId = 3, SmdId = 8 },
                new SMDItemMap { SMDItemId = 47, NameItem = "VT2", BoardId = 3, SmdId = 8 },
                new SMDItemMap { SMDItemId = 48, NameItem = "VT4", BoardId = 3, SmdId = 8 },

                new SMDItemMap { SMDItemId = 49, NameItem = "VD2", BoardId = 4, SmdId = 1 },
                new SMDItemMap { SMDItemId = 50, NameItem = "VD3", BoardId = 4, SmdId = 1 },
                new SMDItemMap { SMDItemId = 51, NameItem = "VD7", BoardId = 4, SmdId = 1 },
                new SMDItemMap { SMDItemId = 52, NameItem = "VD8", BoardId = 4, SmdId = 1 },
                new SMDItemMap { SMDItemId = 53, NameItem = "C1", BoardId = 4, SmdId = 2 },
                new SMDItemMap { SMDItemId = 54, NameItem = "C3", BoardId = 4, SmdId = 2 },
                new SMDItemMap { SMDItemId = 55, NameItem = "R1", BoardId = 4, SmdId = 3 },
                new SMDItemMap { SMDItemId = 56, NameItem = "R2", BoardId = 4, SmdId = 4 },
                new SMDItemMap { SMDItemId = 57, NameItem = "R6", BoardId = 4, SmdId = 4 },
                new SMDItemMap { SMDItemId = 58, NameItem = "R3", BoardId = 4, SmdId = 5 },
                new SMDItemMap { SMDItemId = 59, NameItem = "R5", BoardId = 4, SmdId = 5 },
                new SMDItemMap { SMDItemId = 60, NameItem = "R4", BoardId = 4, SmdId = 6 },
                new SMDItemMap { SMDItemId = 61, NameItem = "VD1", BoardId = 4, SmdId = 7 },
                new SMDItemMap { SMDItemId = 62, NameItem = "VT1", BoardId = 4, SmdId = 8 },
                new SMDItemMap { SMDItemId = 63, NameItem = "VT2", BoardId = 4, SmdId = 8 },
                new SMDItemMap { SMDItemId = 64, NameItem = "VT4", BoardId = 4, SmdId = 8 },
            };
            smdItemMap.ForEach(m => context.SMDItemMaps.Add(m));
            context.SaveChanges();


            var otherStore = new List<OtherStore>
            {
                new OtherStore { OtherStoreId = 1, DescriptionItemOne = "Припой", DescriptionItemTwo = "Палки", CountItem = 20, LastUpdate = DateTime.Now, ItemId = 8 },
                new OtherStore { OtherStoreId = 2, DescriptionItemOne = "Паста", DescriptionItemTwo = "Банки", CountItem = 24, LastUpdate = DateTime.Now, ItemId = 9 },

            };
            otherStore.ForEach(m => context.OtherStores.Add(m));
            context.SaveChanges();


            var gasBalloon = new List<GasBalloon>
            {
                new GasBalloon { GasBalloonId = 1, BalloonNumber = "86299", DateNextModified = "03.20", LastUpdate = DateTime.Now },
                new GasBalloon { GasBalloonId = 2, BalloonNumber = "221495", DateNextModified = "08.17", LastUpdate = DateTime.Now },
            };
            gasBalloon.ForEach(m => context.GasBalloons.Add(m));
            context.SaveChanges();

            #endregion

            #region EmployeeInitializer
            var position = new List<Position>
            {
                new Position { Id = 1 , PositionEmp = "Инженер по автоматизации систем управления на предприятии" },
                new Position { Id = 2, PositionEmp = "Монтажник 2-го разряда" }
            };
            position.ForEach(m => context.Positions.Add(m));
            context.SaveChanges();

            var employee = new List<Employee>
                {
                new Employee { Id = 1, FirstName = "Владимир", MidName = "Владимирович", LastName = "Макаревич", DailyWorkComplete = DateTime.Now, PositionId = 1 },
                new Employee { Id = 2, FirstName = "Александр", MidName = "Владимирович", LastName = "Жигалов", DailyWorkComplete = DateTime.Now, PositionId = 2 }
                };
            employee.ForEach(m => context.Employees.Add(m));
            context.SaveChanges();



            var doneWork = new List<DoneWork>
            {
                new DoneWork { DoneId = 1, Count = 200, DateTime = DateTime.Parse("10-13-2016"), Description = "Простое описание 1", EmployeeId = 1, BoardId = 1 },
                new DoneWork { DoneId = 2, Count = 100, DateTime = DateTime.Parse("10-13-2016"), Description = "Простое описание 2", EmployeeId = 2, BoardId = 2 },
                new DoneWork { DoneId = 3, Count = 500, DateTime = DateTime.Parse("10-14-2016"), Description = "Простое описание 3", EmployeeId = 1, BoardId = 3 },
                new DoneWork { DoneId = 4, Count = 1000, DateTime = DateTime.Parse("10-14-2016"), Description = "Простое описание 4", EmployeeId = 2, BoardId = 4 }
            };
            doneWork.ForEach(m => context.DoneWorks.Add(m));
            context.SaveChanges();
            #endregion

            #region MachineInitializer
            var ebso = new List<Ebso>
                {
                    new Ebso { Id = 1, TimeSecond = 600, Description = "Простое описание машины EBSO №1" }
                };
            ebso.ForEach(m => context.Ebsos.Add(m));
            context.SaveChanges();

            var dvc = new List<Dvc>
            {
                new Dvc { Id = 1, TimeSecond = 230, Description = "Простое описание машины DVC №1" }
            };
            dvc.ForEach(m => context.Dvcs.Add(m));
            #endregion

            #region MapInitializer
            var map = new List<Map>
                {
                    new Map { MapId = 1, Date = Month.October, Modified = DateTime.Now }
                };
            map.ForEach(m => context.Maps.Add(m));
            context.SaveChanges();

            var mapBoard = new List<MapBoard>
                {
                    new MapBoard { SingleMapBoardId = 1, CountBoard = 1008, CountHanging = 1008, CountDvc = 440, CountEbso = 220, CountPreComplete = 220, CountReadyDone = 0, BoardId = 1, MapId = 1 },
                    new MapBoard { SingleMapBoardId = 2, CountBoard = 252, CountHanging = 102, CountDvc = 252, CountEbso = 102, CountPreComplete = 102, CountReadyDone = 0, BoardId = 2, MapId = 1 },
                    new MapBoard { SingleMapBoardId = 3, CountBoard = 2016, CountHanging =2016, CountDvc = 1725, CountEbso = 1725, CountPreComplete = 925, CountReadyDone = 925, BoardId = 3, MapId = 1 },
                    new MapBoard { SingleMapBoardId = 4, CountBoard = 216, CountHanging = 116, CountDvc = 116, CountEbso = 116, CountPreComplete = 100, CountReadyDone = 50, BoardId = 4, MapId = 1 },

                };
            mapBoard.ForEach(m => context.MapBoards.Add(m));
            context.SaveChanges();
            #endregion
        }
    }
}