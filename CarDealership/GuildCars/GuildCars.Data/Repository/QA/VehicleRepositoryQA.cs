using GuildCars.Data.Interface;
using GuildCars.Models.Query;
using GuildCars.Models.Table;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuildCars.Data.Repository.QA
{
    public class VehicleRepositoryQA : IVehicleRepository
    {
        private static List<Vehicle> _vehicles = new List<Vehicle>
        {
            new Vehicle {VehicleId=1,MakeId=1,ModelId=1,TypeId=1,BodyStyleId=1,TransId=1,ColorIntId=1,ColorExId=6,
                VIN="ABCDEFGH000000001",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=25000.00M,MSRP=26000.00M,
                Mileage=0,Description="4 Cylinder with 30 City / 37 Hwy Fuel Efficiency",Picture="inventory-1.jpg",Featured=false,IsDeleted=true},

            new Vehicle {VehicleId=2,MakeId=1,ModelId=1,TypeId=1,BodyStyleId=1,TransId=2,ColorIntId=1,ColorExId=3,
                VIN="ABCDEFGH000000002",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=26000.00M,MSRP=27000.00M,
                Mileage=0,Description="4 Cylinder with 33 City / 42 Hwy Fuel Efficiency",Picture="inventory-2.jpg",Featured=true,IsDeleted=false},

            new Vehicle {VehicleId=3,MakeId=1,ModelId=1,TypeId=1,BodyStyleId=1,TransId=2,ColorIntId=1,ColorExId=1,
                VIN="ABCDEFGH000000003",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=28000.00M,MSRP=29000.00M,
                Mileage=0,Description="4 Cylinder with 31 City / 39 Hwy Fuel Efficiency",Picture="inventory-3.jpg",Featured=false,IsDeleted=false},

            new Vehicle {VehicleId=4,MakeId=1,ModelId=2,TypeId=1,BodyStyleId=1,TransId=1,ColorIntId=1,ColorExId=1,
                VIN="ABCDEFGH000000004",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=29000.00M,MSRP=30000.00M,
                Mileage=0,Description="4 Cylinder with 29 City / 35 Hwy Fuel Efficiency",Picture="inventory-4.jpg",Featured=false,IsDeleted=false},

            new Vehicle {VehicleId=5,MakeId=1,ModelId=2,TypeId=1,BodyStyleId=1,TransId=2,ColorIntId=1,ColorExId=3,
                VIN="ABCDEFGH000000005",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=35000.00M,MSRP=36000.00M,
                Mileage=0,Description="4 Cylinder with 22 City / 32 Hwy Fuel Efficiency",Picture="inventory-5.jpg",Featured=true,IsDeleted=false},

            new Vehicle {VehicleId=6,MakeId=1,ModelId=2,TypeId=1,BodyStyleId=1,TransId=2,ColorIntId=2,ColorExId=6,
                VIN="ABCDEFGH000000006",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=27000.00M,MSRP=28000.00M,
                Mileage=0,Description="4 Cylinder with 30 City / 38 Hwy Fuel Efficiency",Picture="inventory-6.jpg",Featured=false,IsDeleted=false},

            new Vehicle {VehicleId=7,MakeId=2,ModelId=3,TypeId=1,BodyStyleId=4,TransId=2,ColorIntId=1,ColorExId=5,
                VIN="ABCDEFGH000000007",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=55000.00M,MSRP=57000.00M,
                Mileage=0,Description="6 Cylinder with 19 City / 26 Hwy Fuel Efficiency",Picture="inventory-7.jpg",Featured=false,IsDeleted=true},

            new Vehicle {VehicleId=8,MakeId=2,ModelId=3,TypeId=1,BodyStyleId=4,TransId=1,ColorIntId=3,ColorExId=2,
                VIN="ABCDEFGH000000008",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=58000.00M,MSRP=60000.00M,
                Mileage=0,Description="6 Cylinder with 19 City / 26 Hwy Fuel Efficiency",Picture="inventory-8.jpg",Featured=false,IsDeleted=false},

            new Vehicle {VehicleId=9,MakeId=2,ModelId=3,TypeId=1,BodyStyleId=4,TransId=2,ColorIntId=1,ColorExId=4,
                VIN="ABCDEFGH000000009",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=56000.00M,MSRP=58000.00M,
                Mileage=0,Description="6 Cylinder with 19 City / 26 Hwy Fuel Efficiency",Picture="inventory-9.jpg",Featured=true,IsDeleted=false},

            new Vehicle {VehicleId=10,MakeId=2,ModelId=4,TypeId=1,BodyStyleId=1,TransId=1,ColorIntId=1,ColorExId=4,
                VIN="ABCDEFGH000000010",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=50000.00M,MSRP=52000.00M,
                Mileage=0,Description="6 Cylinder with 20 City / 27 Hwy Fuel Efficiency",Picture="inventory-10.jpg",Featured=false,IsDeleted=true},

            new Vehicle {VehicleId=11,MakeId=2,ModelId=4,TypeId=1,BodyStyleId=2,TransId=2,ColorIntId=2,ColorExId=6,
                VIN="ABCDEFGH000000011",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=52000.00M,MSRP=54000.00M,
                Mileage=0,Description="6 Cylinder with 20 City / 27 Hwy Fuel Efficiency",Picture="inventory-11.jpg",Featured=true,IsDeleted=false},

            new Vehicle {VehicleId=12,MakeId=2,ModelId=4,TypeId=1,BodyStyleId=2,TransId=2,ColorIntId=1,ColorExId=3,
                VIN="ABCDEFGH000000012",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=51000.00M,MSRP=53000.00M,
                Mileage=0,Description="6 Cylinder with 20 City / 27 Hwy Fuel Efficiency",Picture="inventory-12.jpg",Featured=false,IsDeleted=false},

            new Vehicle {VehicleId=13,MakeId=3,ModelId=5,TypeId=1,BodyStyleId=4,TransId=2,ColorIntId=1,ColorExId=4,
                VIN="ABCDEFGH000000013",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=30000.00M,MSRP=31000.00M,
                Mileage=0,Description="4 Cylinder with 24 City / 30 Hwy Fuel Efficiency",Picture="inventory-13.jpg",Featured=false,IsDeleted=false},

            new Vehicle {VehicleId=14,MakeId=3,ModelId=5,TypeId=1,BodyStyleId=4,TransId=2,ColorIntId=1,ColorExId=1,
                VIN="ABCDEFGH000000014",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=27000.00M,MSRP=28000.00M,
                Mileage=0,Description="4 Cylinder with 24 City / 30 Hwy Fuel Efficiency",Picture="inventory-14.jpg",Featured=false,IsDeleted=true},

            new Vehicle {VehicleId=15,MakeId=3,ModelId=5,TypeId=1,BodyStyleId=4,TransId=1,ColorIntId=2,ColorExId=6,
                VIN="ABCDEFGH000000015",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=30000.00M,MSRP=31000.00M,
                Mileage=0,Description="4 Cylinder with 24 City / 30 Hwy Fuel Efficiency",Picture="inventory-15.jpg",Featured=true,IsDeleted=false},

            new Vehicle {VehicleId=16,MakeId=3,ModelId=6,TypeId=1,BodyStyleId=1,TransId=2,ColorIntId=3,ColorExId=1,
                VIN="ABCDEFGH000000016",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=35000.00M,MSRP=36000.00M,
                Mileage=0,Description="4 Cylinder with 23 City / 31 Hwy Fuel Efficiency",Picture="inventory-16.jpg",Featured=true,IsDeleted=false},

            new Vehicle {VehicleId=17,MakeId=3,ModelId=6,TypeId=1,BodyStyleId=1,TransId=2,ColorIntId=3,ColorExId=6,
                VIN="ABCDEFGH000000017",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=35000.00M,MSRP=36000.00M,
                Mileage=0,Description="4 Cylinder with 23 City / 31 Hwy Fuel Efficiency",Picture="inventory-17.jpg",Featured=false,IsDeleted=false},

            new Vehicle {VehicleId=18,MakeId=3,ModelId=6,TypeId=1,BodyStyleId=1,TransId=1,ColorIntId=3,ColorExId=1,
                VIN="ABCDEFGH000000018",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=34000.00M,MSRP=35000.00M,
                Mileage=0,Description="4 Cylinder with 23 City / 31 Hwy Fuel Efficiency",Picture="inventory-18.jpg",Featured=false,IsDeleted=true},

            new Vehicle {VehicleId=19,MakeId=4,ModelId=7,TypeId=1,BodyStyleId=4,TransId=2,ColorIntId=1,ColorExId=4,
                VIN="ABCDEFGH000000019",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=44000.00M,MSRP=46000.00M,
                Mileage=0,Description="4 Cylinder with 20 City / 26 Hwy Fuel Efficiency",Picture="inventory-19.jpg",Featured=false,IsDeleted=false},

            new Vehicle {VehicleId=20,MakeId=4,ModelId=7,TypeId=1,BodyStyleId=4,TransId=2,ColorIntId=3,ColorExId=2,
                VIN="ABCDEFGH000000020",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=44000.00M,MSRP=46000.00M,
                Mileage=0,Description="4 Cylinder with 20 City / 26 Hwy Fuel Efficiency",Picture="inventory-20.jpg",Featured=false,IsDeleted=true},

            new Vehicle {VehicleId=21,MakeId=4,ModelId=7,TypeId=1,BodyStyleId=4,TransId=2,ColorIntId=2,ColorExId=4,
                VIN="ABCDEFGH000000021",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=38000.00M,MSRP=39000.00M,
                Mileage=0,Description="4 Cylinder with 20 City / 26 Hwy Fuel Efficiency",Picture="inventory-21.jpg",Featured=false,IsDeleted=false},

            new Vehicle {VehicleId=22,MakeId=4,ModelId=8,TypeId=1,BodyStyleId=3,TransId=2,ColorIntId=1,ColorExId=1,
                VIN="ABCDEFGH000000022",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=35000.00M,MSRP=36000.00M,
                Mileage=0,Description="4 Cylinder with 26 City / 33 Hwy Fuel Efficiency",Picture="inventory-22.jpg",Featured=false,IsDeleted=false},

            new Vehicle {VehicleId=23,MakeId=4,ModelId=8,TypeId=1,BodyStyleId=3,TransId=1,ColorIntId=1,ColorExId=2,
                VIN="ABCDEFGH000000023",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=30000.00M,MSRP=31000.00M,
                Mileage=0,Description="4 Cylinder with 26 City / 33 Hwy Fuel Efficiency",Picture="inventory-23.jpg",Featured=false,IsDeleted=false},

            new Vehicle {VehicleId=24,MakeId=4,ModelId=8,TypeId=1,BodyStyleId=3,TransId=2,ColorIntId=2,ColorExId=6,
                VIN="ABCDEFGH000000024",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=34000.00M,MSRP=35000.00M,
                Mileage=0,Description="4 Cylinder with 26 City / 33 Hwy Fuel Efficiency",Picture="inventory-24.jpg",Featured=true,IsDeleted=false},

            new Vehicle {VehicleId=25,MakeId=5,ModelId=9,TypeId=1,BodyStyleId=1,TransId=2,ColorIntId=1,ColorExId=6,
                VIN="ABCDEFGH000000025",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=34000.00M,MSRP=35000.00M,
                Mileage=0,Description="4 Cylinder with 25 City / 34 Hwy Fuel Efficiency",Picture="inventory-25.jpg",Featured=false,IsDeleted=true},

            new Vehicle {VehicleId=26,MakeId=5,ModelId=9,TypeId=1,BodyStyleId=1,TransId=1,ColorIntId=1,ColorExId=1,
                VIN="ABCDEFGH000000026",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=35000.00M,MSRP=36000.00M,
                Mileage=0,Description="4 Cylinder with 25 City / 34 Hwy Fuel Efficiency",Picture="inventory-26.jpg",Featured=true,IsDeleted=false},

            new Vehicle {VehicleId=27,MakeId=5,ModelId=9,TypeId=1,BodyStyleId=1,TransId=2,ColorIntId=1,ColorExId=1,
                VIN="ABCDEFGH000000027",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=34000.00M,MSRP=35000.00M,
                Mileage=0,Description="4 Cylinder with 25 City / 34 Hwy Fuel Efficiency",Picture="inventory-27.jpg",Featured=false,IsDeleted=false},

            new Vehicle {VehicleId=28,MakeId=5,ModelId=10,TypeId=1,BodyStyleId=4,TransId=2,ColorIntId=1,ColorExId=1,
                VIN="ABCDEFGH000000028",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=43000.00M,MSRP=45000.00M,
                Mileage=0,Description="4 Cylinder with 20 City / 27 Hwy Fuel Efficiency",Picture="inventory-28.jpg",Featured=false,IsDeleted=false},

            new Vehicle {VehicleId=29,MakeId=5,ModelId=10,TypeId=1,BodyStyleId=4,TransId=2,ColorIntId=1,ColorExId=3,
                VIN="ABCDEFGH000000029",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=46000.00M,MSRP=48000.00M,
                Mileage=0,Description="4 Cylinder with 20 City / 27 Hwy Fuel Efficiency",Picture="inventory-29.jpg",Featured=false,IsDeleted=true},

            new Vehicle {VehicleId=30,MakeId=5,ModelId=10,TypeId=1,BodyStyleId=4,TransId=1,ColorIntId=2,ColorExId=3,
                VIN="ABCDEFGH000000030",Year=new DateTime(2022, 01, 01, 00, 00, 00),SalePrice=44000.00M,MSRP=46000.00M,
                Mileage=0,Description="4 Cylinder with 20 City / 27 Hwy Fuel Efficiency",Picture="inventory-30.jpg",Featured=false,IsDeleted=false},

            new Vehicle {VehicleId=31,MakeId=5,ModelId=10,TypeId=2,BodyStyleId=4,TransId=2,ColorIntId=1,ColorExId=2,
                VIN="ABCDEFGH000000031",Year=new DateTime(2018, 01, 01, 00, 00, 00),SalePrice=39000.00M,MSRP=40000.00M,
                Mileage=45889,Description="4 Cylinder with 20 City / 26 Hwy Fuel Efficiency",Picture="inventory-31.jpg",Featured=false,IsDeleted=false},

            new Vehicle {VehicleId=32,MakeId=1,ModelId=1,TypeId=2,BodyStyleId=1,TransId=2,ColorIntId=1,ColorExId=3,
                VIN="ABCDEFGH000000032",Year=new DateTime(2016, 01, 01, 00, 00, 00),SalePrice=17500.00M,MSRP=18000.00M,
                Mileage=121151,Description="4 Cylinder with 31 City / 42 Hwy Fuel Efficiency",Picture="inventory-32.jpg",Featured=false,IsDeleted=false},

            new Vehicle {VehicleId=33,MakeId=3,ModelId=5,TypeId=2,BodyStyleId=4,TransId=2,ColorIntId=1,ColorExId=3,
                VIN="ABCDEFGH000000033",Year=new DateTime(2014, 01, 01, 00, 00, 00),SalePrice=15500.00M,MSRP=16000.00M,
                Mileage=130769,Description="4 Cylinder with 24 City / 30 Hwy Fuel Efficiency",Picture="inventory-33.jpg",Featured=false,IsDeleted=false},

            new Vehicle {VehicleId=34,MakeId=1,ModelId=2,TypeId=2,BodyStyleId=1,TransId=1,ColorIntId=1,ColorExId=2,
                VIN="ABCDEFGH000000034",Year=new DateTime(2016, 01, 01, 00, 00, 00),SalePrice=17500.00M,MSRP=18000.00M,
                Mileage=144726,Description="4 Cylinder with 27 City / 37 Hwy Fuel Efficiency",Picture="inventory-34.jpg",Featured=false,IsDeleted=true},

            new Vehicle {VehicleId=35,MakeId=2,ModelId=3,TypeId=2,BodyStyleId=4,TransId=2,ColorIntId=1,ColorExId=4,
                VIN="ABCDEFGH000000035",Year=new DateTime(2019, 01, 01, 00, 00, 00),SalePrice=40000.00M,MSRP=42000.00M,
                Mileage=32153,Description="6 Cylinder with 19 City / 26 Hwy Fuel Efficiency",Picture="inventory-35.jpg",Featured=false,IsDeleted=false},

            new Vehicle {VehicleId=36,MakeId=3,ModelId=6,TypeId=2,BodyStyleId=1,TransId=2,ColorIntId=1,ColorExId=4,
                VIN="ABCDEFGH000000036",Year=new DateTime(2019, 01, 01, 00, 00, 00),SalePrice=24000.00M,MSRP=25000.00M,
                Mileage=25128,Description="4 Cylinder with 26 City / 35 Hwy Fuel Efficiency",Picture="inventory-36.jpg",Featured=false,IsDeleted=false},

            new Vehicle {VehicleId=37,MakeId=5,ModelId=10,TypeId=2,BodyStyleId=4,TransId=2,ColorIntId=1,ColorExId=3,
                VIN="ABCDEFGH000000037",Year=new DateTime(2020, 01, 01, 00, 00, 00),SalePrice=40000.00M,MSRP=42000.00M,
                Mileage=10280,Description="4 Cylinder with 20 City / 27 Hwy Fuel Efficiency",Picture="inventory-37.jpg",Featured=false,IsDeleted=false},

            new Vehicle {VehicleId=38,MakeId=2,ModelId=4,TypeId=2,BodyStyleId=1,TransId=1,ColorIntId=1,ColorExId=1,
                VIN="ABCDEFGH000000038",Year=new DateTime(2019, 01, 01, 00, 00, 00),SalePrice=39000.00M,MSRP=40000.00M,
                Mileage=23507,Description="6 Cylinder with 20 City / 27 Hwy Fuel Efficiency",Picture="inventory-38.jpg",Featured=false,IsDeleted=false},

            new Vehicle {VehicleId=39,MakeId=4,ModelId=8,TypeId=2,BodyStyleId=3,TransId=2,ColorIntId=2,ColorExId=5,
                VIN="ABCDEFGH000000039",Year=new DateTime(2017, 01, 01, 00, 00, 00),SalePrice=22000.00M,MSRP=23000.00M,
                Mileage=91552,Description="4 Cylinder with 25 City / 32 Hwy Fuel Efficiency",Picture="inventory-39.jpg",Featured=false,IsDeleted=true},

            new Vehicle {VehicleId=40,MakeId=4,ModelId=7,TypeId=2,BodyStyleId=4,TransId=2,ColorIntId=1,ColorExId=1,
                VIN="ABCDEFGH000000040",Year=new DateTime(2021, 01, 01, 00, 00, 00),SalePrice=43000.00M,MSRP=45000.00M,
                Mileage=7701,Description="4 Cylinder with 20 City / 26 Hwy Fuel Efficiency",Picture="inventory-40.jpg",Featured=false,IsDeleted=false}
        };
        
        public List<AddEditVehicleRequestItem> AdminGetAll()
        {
            var vehiclesRequest = new List<AddEditVehicleRequestItem>();
            var makeRepo = new MakeRepositoryQA();
            var modelRepo = new ModelRepositoryQA();
            var bodyStyleRepo = new BodyStyleRepositoryQA();
            var colorIntRepo = new ColorIntRepositoryQA();
            var colorExRepo = new ColorExRepositoryQA();
            var transRepo = new TransRepositoryQA();
            var typeRepo = new TypeRepositoryQA();

            var vehicles = _vehicles.Where(m => m.IsDeleted == false).OrderByDescending(m => m.MSRP).ToList();

            foreach (var vehicle in vehicles)
            {
                var make = makeRepo.GetAll().FirstOrDefault(m => m.MakeId == vehicle.MakeId);
                var model = modelRepo.GetAll().FirstOrDefault(m => m.ModelId == vehicle.ModelId);
                var bodyStyle = bodyStyleRepo.GetAll().FirstOrDefault(m => m.BodyStyleId == vehicle.BodyStyleId);
                var colorInt = colorIntRepo.GetAll().FirstOrDefault(m => m.ColorIntId == vehicle.ColorIntId);
                var colorEx = colorExRepo.GetAll().FirstOrDefault(m => m.ColorExId == vehicle.ColorExId);
                var trans = transRepo.GetAll().FirstOrDefault(m => m.TransId == vehicle.TransId);
                var type = typeRepo.GetAll().FirstOrDefault(m => m.TypeId == vehicle.TypeId);

                var newVehicle = new AddEditVehicleRequestItem();
                newVehicle.VehicleId = vehicle.VehicleId;
                newVehicle.MakeName = make.MakeName;
                newVehicle.ModelName = model.ModelName;
                newVehicle.Year = vehicle.Year;
                newVehicle.MSRP = vehicle.MSRP;
                newVehicle.Picture = vehicle.Picture;
                newVehicle.BodyStyleName = bodyStyle.BodyStyleName;
                newVehicle.ColorIntName = colorInt.ColorIntName;
                newVehicle.SalePrice = vehicle.SalePrice;
                newVehicle.TransName = trans.TransName;
                newVehicle.Mileage = vehicle.Mileage;
                newVehicle.ColorExName = colorEx.ColorExName;
                newVehicle.VIN = vehicle.VIN;
                newVehicle.Description = vehicle.Description;
                newVehicle.IsDeleted = vehicle.IsDeleted;
                newVehicle.TypeName = type.TypeName;

                vehiclesRequest.Add(newVehicle);
            }

            vehiclesRequest = vehiclesRequest.OrderByDescending(m => m.MSRP).ToList();

            return vehiclesRequest;
        }

        public List<InventoryReportRequestItem> AdminGetNewInventoryReport()
        {
            var newVehicles = new List<SearchVehicleRequestItem>();
            var makeRepo = new MakeRepositoryQA();
            var modelRepo = new ModelRepositoryQA();
            var bodyStyleRepo = new BodyStyleRepositoryQA();
            var colorIntRepo = new ColorIntRepositoryQA();
            var colorExRepo = new ColorExRepositoryQA();
            var transRepo = new TransRepositoryQA();

            var vehicles = _vehicles.Where(m => m.IsDeleted == false && m.TypeId == 1).OrderByDescending(m => m.MSRP).ToList();

            foreach (var vehicle in vehicles)
            {
                var make = makeRepo.GetAll().FirstOrDefault(m => m.MakeId == vehicle.MakeId);
                var model = modelRepo.GetAll().FirstOrDefault(m => m.ModelId == vehicle.ModelId);
                var bodyStyle = bodyStyleRepo.GetAll().FirstOrDefault(m => m.BodyStyleId == vehicle.BodyStyleId);
                var colorInt = colorIntRepo.GetAll().FirstOrDefault(m => m.ColorIntId == vehicle.ColorIntId);
                var colorEx = colorExRepo.GetAll().FirstOrDefault(m => m.ColorExId == vehicle.ColorExId);
                var trans = transRepo.GetAll().FirstOrDefault(m => m.TransId == vehicle.TransId);


                var newVehicle = new SearchVehicleRequestItem();
                newVehicle.VehicleId = vehicle.VehicleId;
                newVehicle.MakeName = make.MakeName;
                newVehicle.ModelName = model.ModelName;
                newVehicle.Year = vehicle.Year;
                newVehicle.MSRP = vehicle.MSRP;
                newVehicle.Picture = vehicle.Picture;
                newVehicle.BodyStyleName = bodyStyle.BodyStyleName;
                newVehicle.ColorIntName = colorInt.ColorIntName;
                newVehicle.SalePrice = vehicle.SalePrice;
                newVehicle.TransName = trans.TransName;
                newVehicle.Mileage = vehicle.Mileage;
                newVehicle.ColorExName = colorEx.ColorExName;
                newVehicle.VIN = vehicle.VIN;
                newVehicle.Description = vehicle.Description;
                newVehicle.IsDeleted = vehicle.IsDeleted;

                newVehicles.Add(newVehicle);
            }

            newVehicles = newVehicles.OrderByDescending(m => m.MSRP).ToList();

            var queryGroups = from v in newVehicles
                        group v by new { v.Year, v.MakeName, v.ModelName} into q
                        orderby q.Key.Year descending,
                                q.Key.MakeName,
                                q.Key.ModelName
                        select new
                        {
                            q.Key.Year,
                            q.Key.MakeName,
                            q.Key.ModelName,
                            Count = q.Count()
                        };

            var report = new List<InventoryReportRequestItem>();

            foreach (var q in queryGroups)
            {
                var reportItem = new InventoryReportRequestItem();
                reportItem.Year = q.Year;
                reportItem.MakeName = q.MakeName;
                reportItem.ModelName = q.ModelName;
                reportItem.Count = q.Count;
                
                foreach (var v in newVehicles)
                {
                    if (v.Year == q.Year && v.MakeName == q.MakeName && v.ModelName == q.ModelName)
                    {
                        reportItem.StockValue += v.MSRP;
                    }
                }

                report.Add(reportItem);
            }

            report = report.OrderByDescending(m => m.Year).ThenBy(m => m.MakeName).ThenBy(m => m.ModelName).ToList();

            return report;
        }

        public List<InventoryReportRequestItem> AdminGetUsedInventoryReport()
        {
            var usedVehicles = new List<SearchVehicleRequestItem>();
            var makeRepo = new MakeRepositoryQA();
            var modelRepo = new ModelRepositoryQA();
            var bodyStyleRepo = new BodyStyleRepositoryQA();
            var colorIntRepo = new ColorIntRepositoryQA();
            var colorExRepo = new ColorExRepositoryQA();
            var transRepo = new TransRepositoryQA();

            var vehicles = _vehicles.Where(m => m.IsDeleted == false && m.TypeId == 2).OrderByDescending(m => m.MSRP).ToList();

            foreach (var vehicle in vehicles)
            {
                var make = makeRepo.GetAll().FirstOrDefault(m => m.MakeId == vehicle.MakeId);
                var model = modelRepo.GetAll().FirstOrDefault(m => m.ModelId == vehicle.ModelId);
                var bodyStyle = bodyStyleRepo.GetAll().FirstOrDefault(m => m.BodyStyleId == vehicle.BodyStyleId);
                var colorInt = colorIntRepo.GetAll().FirstOrDefault(m => m.ColorIntId == vehicle.ColorIntId);
                var colorEx = colorExRepo.GetAll().FirstOrDefault(m => m.ColorExId == vehicle.ColorExId);
                var trans = transRepo.GetAll().FirstOrDefault(m => m.TransId == vehicle.TransId);


                var usedVehicle = new SearchVehicleRequestItem();
                usedVehicle.VehicleId = vehicle.VehicleId;
                usedVehicle.MakeName = make.MakeName;
                usedVehicle.ModelName = model.ModelName;
                usedVehicle.Year = vehicle.Year;
                usedVehicle.MSRP = vehicle.MSRP;
                usedVehicle.Picture = vehicle.Picture;
                usedVehicle.BodyStyleName = bodyStyle.BodyStyleName;
                usedVehicle.ColorIntName = colorInt.ColorIntName;
                usedVehicle.SalePrice = vehicle.SalePrice;
                usedVehicle.TransName = trans.TransName;
                usedVehicle.Mileage = vehicle.Mileage;
                usedVehicle.ColorExName = colorEx.ColorExName;
                usedVehicle.VIN = vehicle.VIN;
                usedVehicle.Description = vehicle.Description;
                usedVehicle.IsDeleted = vehicle.IsDeleted;

                usedVehicles.Add(usedVehicle);
            }

            usedVehicles = usedVehicles.OrderByDescending(m => m.MSRP).ToList();

            var queryGroups = from v in usedVehicles
                              group v by new { v.Year, v.MakeName, v.ModelName } into q
                              orderby q.Key.Year descending,
                                      q.Key.MakeName,
                                      q.Key.ModelName
                              select new
                              {
                                  q.Key.Year,
                                  q.Key.MakeName,
                                  q.Key.ModelName,
                                  Count = q.Count()
                              };

            var report = new List<InventoryReportRequestItem>();

            foreach (var q in queryGroups)
            {
                var reportItem = new InventoryReportRequestItem();
                reportItem.Year = q.Year;
                reportItem.MakeName = q.MakeName;
                reportItem.ModelName = q.ModelName;
                reportItem.Count = q.Count;

                foreach (var v in usedVehicles)
                {
                    if (v.Year == q.Year && v.MakeName == q.MakeName && v.ModelName == q.ModelName)
                    {
                        reportItem.StockValue += v.MSRP;
                    }
                }

                report.Add(reportItem);
            }

            report = report.OrderByDescending(m => m.Year).ThenBy(m => m.MakeName).ThenBy(m => m.ModelName).ToList();

            return report;
        }

        public AddEditVehicleRequestItem AdminGetVehicleById(int vehicleId)
        {
            var vehiclesRequest = new List<AddEditVehicleRequestItem>();
            var makeRepo = new MakeRepositoryQA();
            var modelRepo = new ModelRepositoryQA();
            var bodyStyleRepo = new BodyStyleRepositoryQA();
            var colorIntRepo = new ColorIntRepositoryQA();
            var colorExRepo = new ColorExRepositoryQA();
            var transRepo = new TransRepositoryQA();
            var typeRepo = new TypeRepositoryQA();

            var vehicle = _vehicles.FirstOrDefault(m => m.VehicleId == vehicleId);

            var make = makeRepo.GetAll().FirstOrDefault(m => m.MakeId == vehicle.MakeId);
            var model = modelRepo.GetAll().FirstOrDefault(m => m.ModelId == vehicle.ModelId);
            var bodyStyle = bodyStyleRepo.GetAll().FirstOrDefault(m => m.BodyStyleId == vehicle.BodyStyleId);
            var colorInt = colorIntRepo.GetAll().FirstOrDefault(m => m.ColorIntId == vehicle.ColorIntId);
            var colorEx = colorExRepo.GetAll().FirstOrDefault(m => m.ColorExId == vehicle.ColorExId);
            var trans = transRepo.GetAll().FirstOrDefault(m => m.TransId == vehicle.TransId);
            var type = typeRepo.GetAll().FirstOrDefault(m => m.TypeId == vehicle.TypeId);

            var vehicleRequest = new AddEditVehicleRequestItem();
            vehicleRequest.VehicleId = vehicle.VehicleId;
            vehicleRequest.MakeName = make.MakeName;
            vehicleRequest.ModelName = model.ModelName;
            vehicleRequest.Year = vehicle.Year;
            vehicleRequest.MSRP = vehicle.MSRP;
            vehicleRequest.Picture = vehicle.Picture;
            vehicleRequest.BodyStyleName = bodyStyle.BodyStyleName;
            vehicleRequest.ColorIntName = colorInt.ColorIntName;
            vehicleRequest.SalePrice = vehicle.SalePrice;
            vehicleRequest.TransName = trans.TransName;
            vehicleRequest.Mileage = vehicle.Mileage;
            vehicleRequest.ColorExName = colorEx.ColorExName;
            vehicleRequest.VIN = vehicle.VIN;
            vehicleRequest.Description = vehicle.Description;
            vehicleRequest.IsDeleted = vehicle.IsDeleted;
            vehicleRequest.TypeName = type.TypeName;

            return vehicleRequest;
        }

        public void CreateVehicle(Vehicle vehicle)
        {
            vehicle.VehicleId = _vehicles.Max(m => m.VehicleId) + 1;
            _vehicles.Add(vehicle);
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            vehicle = _vehicles.FirstOrDefault(m=>m.VehicleId == vehicle.VehicleId);
            vehicle.IsDeleted = true;
        }

        public List<Vehicle> GetAll()
        {
            return _vehicles;
        }

        public List<Vehicle> GetAllAvailable()
        {
            var vehicles = _vehicles.Where(m => m.IsDeleted == false).OrderByDescending(m=>m.MSRP).ToList();
            vehicles = vehicles.Take(20).ToList();
            return vehicles;
        }

        public List<FeaturedVehicleRequestItem> GetAllFeatured()
        {
            var featuredVehicles = new List<FeaturedVehicleRequestItem>();
            var makeRepo = new MakeRepositoryQA();
            var modelRepo = new ModelRepositoryQA();

            var vehicles = _vehicles.Where(m => m.Featured == true).OrderByDescending(m => m.MSRP).ToList();

            foreach(var vehicle in vehicles)
            {
                var make = makeRepo.GetAll().FirstOrDefault(m => m.MakeId == vehicle.MakeId);
                var model = modelRepo.GetAll().FirstOrDefault(m => m.ModelId == vehicle.ModelId);


                var featuredVehicle = new FeaturedVehicleRequestItem();
                featuredVehicle.VehicleId = vehicle.VehicleId;
                featuredVehicle.MakeName = make.MakeName;
                featuredVehicle.ModelName = model.ModelName;
                featuredVehicle.Year = vehicle.Year;
                featuredVehicle.MSRP = vehicle.MSRP;
                featuredVehicle.Picture = vehicle.Picture;

                featuredVehicles.Add(featuredVehicle);
            }

            featuredVehicles = featuredVehicles.OrderByDescending(m => m.MSRP).ToList();

            return featuredVehicles;
        }

        public List<SearchVehicleRequestItem> GetAllNew()
        {
            var newVehicles = new List<SearchVehicleRequestItem>();
            var makeRepo = new MakeRepositoryQA();
            var modelRepo = new ModelRepositoryQA();
            var bodyStyleRepo = new BodyStyleRepositoryQA();
            var colorIntRepo = new ColorIntRepositoryQA();
            var colorExRepo = new ColorExRepositoryQA();
            var transRepo = new TransRepositoryQA();

            var vehicles = _vehicles.Where(m => m.IsDeleted == false).Where(m => m.TypeId == 1).OrderByDescending(m => m.MSRP).ToList();

            foreach (var vehicle in vehicles)
            {
                var make = makeRepo.GetAll().FirstOrDefault(m => m.MakeId == vehicle.MakeId);
                var model = modelRepo.GetAll().FirstOrDefault(m => m.ModelId == vehicle.ModelId);
                var bodyStyle = bodyStyleRepo.GetAll().FirstOrDefault(m => m.BodyStyleId == vehicle.BodyStyleId);
                var colorInt = colorIntRepo.GetAll().FirstOrDefault(m => m.ColorIntId == vehicle.ColorIntId);
                var colorEx = colorExRepo.GetAll().FirstOrDefault(m => m.ColorExId == vehicle.ColorExId);
                var trans = transRepo.GetAll().FirstOrDefault(m => m.TransId == vehicle.TransId);


                var newVehicle = new SearchVehicleRequestItem();
                newVehicle.VehicleId = vehicle.VehicleId;
                newVehicle.MakeName = make.MakeName;
                newVehicle.ModelName = model.ModelName;
                newVehicle.Year = vehicle.Year;
                newVehicle.MSRP = vehicle.MSRP;
                newVehicle.Picture = vehicle.Picture;
                newVehicle.BodyStyleName = bodyStyle.BodyStyleName;
                newVehicle.ColorIntName = colorInt.ColorIntName;
                newVehicle.SalePrice = vehicle.SalePrice;
                newVehicle.TransName = trans.TransName;
                newVehicle.Mileage = vehicle.Mileage;
                newVehicle.ColorExName = colorEx.ColorExName;
                newVehicle.VIN = vehicle.VIN;
                newVehicle.Description = vehicle.Description;
                newVehicle.IsDeleted = vehicle.IsDeleted;

                newVehicles.Add(newVehicle);
            }

            newVehicles = newVehicles.OrderByDescending(m => m.MSRP).ToList();
            newVehicles = newVehicles.Take(20).ToList();

            return newVehicles;
        }

        public List<Vehicle> GetAllSold()
        {
            var vehicles = _vehicles.Where(m => m.IsDeleted == true).ToList();
            return vehicles;
        }

        public List<SearchVehicleRequestItem> GetAllToSell()
        {
            var newVehicles = new List<SearchVehicleRequestItem>();
            var makeRepo = new MakeRepositoryQA();
            var modelRepo = new ModelRepositoryQA();
            var bodyStyleRepo = new BodyStyleRepositoryQA();
            var colorIntRepo = new ColorIntRepositoryQA();
            var colorExRepo = new ColorExRepositoryQA();
            var transRepo = new TransRepositoryQA();

            var vehicles = _vehicles.Where(m => m.IsDeleted == false).OrderByDescending(m => m.MSRP).ToList();

            foreach (var vehicle in vehicles)
            {
                var make = makeRepo.GetAll().FirstOrDefault(m => m.MakeId == vehicle.MakeId);
                var model = modelRepo.GetAll().FirstOrDefault(m => m.ModelId == vehicle.ModelId);
                var bodyStyle = bodyStyleRepo.GetAll().FirstOrDefault(m => m.BodyStyleId == vehicle.BodyStyleId);
                var colorInt = colorIntRepo.GetAll().FirstOrDefault(m => m.ColorIntId == vehicle.ColorIntId);
                var colorEx = colorExRepo.GetAll().FirstOrDefault(m => m.ColorExId == vehicle.ColorExId);
                var trans = transRepo.GetAll().FirstOrDefault(m => m.TransId == vehicle.TransId);


                var newVehicle = new SearchVehicleRequestItem();
                newVehicle.VehicleId = vehicle.VehicleId;
                newVehicle.MakeName = make.MakeName;
                newVehicle.ModelName = model.ModelName;
                newVehicle.Year = vehicle.Year;
                newVehicle.MSRP = vehicle.MSRP;
                newVehicle.Picture = vehicle.Picture;
                newVehicle.BodyStyleName = bodyStyle.BodyStyleName;
                newVehicle.ColorIntName = colorInt.ColorIntName;
                newVehicle.SalePrice = vehicle.SalePrice;
                newVehicle.TransName = trans.TransName;
                newVehicle.Mileage = vehicle.Mileage;
                newVehicle.ColorExName = colorEx.ColorExName;
                newVehicle.VIN = vehicle.VIN;
                newVehicle.Description = vehicle.Description;
                newVehicle.IsDeleted = vehicle.IsDeleted;

                newVehicles.Add(newVehicle);
            }

            newVehicles = newVehicles.OrderByDescending(m => m.MSRP).ToList();

            return newVehicles;
        }

        public List<SearchVehicleRequestItem> GetAllUsed()
        {
            var usedVehicles = new List<SearchVehicleRequestItem>();
            var makeRepo = new MakeRepositoryQA();
            var modelRepo = new ModelRepositoryQA();
            var bodyStyleRepo = new BodyStyleRepositoryQA();
            var colorIntRepo = new ColorIntRepositoryQA();
            var colorExRepo = new ColorExRepositoryQA();
            var transRepo = new TransRepositoryQA();

            var vehicles = _vehicles.Where(m => m.IsDeleted == false).Where(m => m.TypeId == 2).OrderByDescending(m => m.MSRP).ToList();

            foreach (var vehicle in vehicles)
            {
                var make = makeRepo.GetAll().FirstOrDefault(m => m.MakeId == vehicle.MakeId);
                var model = modelRepo.GetAll().FirstOrDefault(m => m.ModelId == vehicle.ModelId);
                var bodyStyle = bodyStyleRepo.GetAll().FirstOrDefault(m => m.BodyStyleId == vehicle.BodyStyleId);
                var colorInt = colorIntRepo.GetAll().FirstOrDefault(m => m.ColorIntId == vehicle.ColorIntId);
                var colorEx = colorExRepo.GetAll().FirstOrDefault(m => m.ColorExId == vehicle.ColorExId);
                var trans = transRepo.GetAll().FirstOrDefault(m => m.TransId == vehicle.TransId);


                var usedVehicle = new SearchVehicleRequestItem();
                usedVehicle.VehicleId = vehicle.VehicleId;
                usedVehicle.MakeName = make.MakeName;
                usedVehicle.ModelName = model.ModelName;
                usedVehicle.Year = vehicle.Year;
                usedVehicle.MSRP = vehicle.MSRP;
                usedVehicle.Picture = vehicle.Picture;
                usedVehicle.BodyStyleName = bodyStyle.BodyStyleName;
                usedVehicle.ColorIntName = colorInt.ColorIntName;
                usedVehicle.SalePrice = vehicle.SalePrice;
                usedVehicle.TransName = trans.TransName;
                usedVehicle.Mileage = vehicle.Mileage;
                usedVehicle.ColorExName = colorEx.ColorExName;
                usedVehicle.VIN = vehicle.VIN;
                usedVehicle.Description = vehicle.Description;
                usedVehicle.IsDeleted = vehicle.IsDeleted;

                usedVehicles.Add(usedVehicle);
            }

            usedVehicles = usedVehicles.OrderByDescending(m => m.MSRP).ToList();
            usedVehicles = usedVehicles.Take(20).ToList();

            return usedVehicles;
        }

        public Vehicle GetVehicleById(int vehicleId)
        {
            var vehicle = _vehicles.FirstOrDefault(m => m.VehicleId == vehicleId);
            return vehicle;
        }

        public List<SearchVehicleRequestItem> SearchAllAvailableToSell(SearchVehicleParameters parameters)
        {
            var vehiclesToSell = new List<SearchVehicleRequestItem>();
            var makeRepo = new MakeRepositoryQA();
            var modelRepo = new ModelRepositoryQA();
            var bodyStyleRepo = new BodyStyleRepositoryQA();
            var colorIntRepo = new ColorIntRepositoryQA();
            var colorExRepo = new ColorExRepositoryQA();
            var transRepo = new TransRepositoryQA();

            var vehicles = _vehicles.Where(m => m.IsDeleted == false).OrderByDescending(m => m.MSRP).ToList();

            foreach (var vehicle in vehicles)
            {
                var make = makeRepo.GetAll().FirstOrDefault(m => m.MakeId == vehicle.MakeId);
                var model = modelRepo.GetAll().FirstOrDefault(m => m.ModelId == vehicle.ModelId);
                var bodyStyle = bodyStyleRepo.GetAll().FirstOrDefault(m => m.BodyStyleId == vehicle.BodyStyleId);
                var colorInt = colorIntRepo.GetAll().FirstOrDefault(m => m.ColorIntId == vehicle.ColorIntId);
                var colorEx = colorExRepo.GetAll().FirstOrDefault(m => m.ColorExId == vehicle.ColorExId);
                var trans = transRepo.GetAll().FirstOrDefault(m => m.TransId == vehicle.TransId);


                var vehicleToSell = new SearchVehicleRequestItem();
                vehicleToSell.VehicleId = vehicle.VehicleId;
                vehicleToSell.MakeName = make.MakeName;
                vehicleToSell.ModelName = model.ModelName;
                vehicleToSell.Year = vehicle.Year;
                vehicleToSell.MSRP = vehicle.MSRP;
                vehicleToSell.Picture = vehicle.Picture;
                vehicleToSell.BodyStyleName = bodyStyle.BodyStyleName;
                vehicleToSell.ColorIntName = colorInt.ColorIntName;
                vehicleToSell.SalePrice = vehicle.SalePrice;
                vehicleToSell.TransName = trans.TransName;
                vehicleToSell.Mileage = vehicle.Mileage;
                vehicleToSell.ColorExName = colorEx.ColorExName;
                vehicleToSell.VIN = vehicle.VIN;
                vehicleToSell.Description = vehicle.Description;
                vehicleToSell.IsDeleted = vehicle.IsDeleted;

                vehiclesToSell.Add(vehicleToSell);
            }

            vehiclesToSell = vehiclesToSell.OrderByDescending(m => m.MSRP).ToList();

            if (!string.IsNullOrEmpty(parameters.SearchString))
            {
                vehiclesToSell = vehiclesToSell.Where(m => 
                    m.MakeName.StartsWith(parameters.SearchString, StringComparison.InvariantCultureIgnoreCase) 
                    || m.ModelName.StartsWith(parameters.SearchString, StringComparison.InvariantCultureIgnoreCase) 
                    || m.Year.ToString().StartsWith(parameters.SearchString, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }

            if (parameters.MinPrice.HasValue)
            {
                vehiclesToSell = vehiclesToSell.Where(m => m.MSRP >= parameters.MinPrice).ToList();
            }

            if (parameters.MaxPrice.HasValue)
            {
                vehiclesToSell = vehiclesToSell.Where(m => m.MSRP <= parameters.MaxPrice).ToList();
            }

            if (!string.IsNullOrEmpty(parameters.MinYear))
            {
                var result = int.TryParse(parameters.MinYear, out int minYear);
                vehiclesToSell = vehiclesToSell.Where(m => m.Year.Year >= minYear).ToList();
            }

            if (!string.IsNullOrEmpty(parameters.MaxYear))
            {
                var result = int.TryParse(parameters.MaxYear, out int maxYear);
                vehiclesToSell = vehiclesToSell.Where(m => m.Year.Year <= maxYear).ToList();
            }

            return vehiclesToSell;
        }

        public List<SearchVehicleRequestItem> SearchNew(SearchVehicleParameters parameters)
        {
            var newVehicles = new List<SearchVehicleRequestItem>();
            var makeRepo = new MakeRepositoryQA();
            var modelRepo = new ModelRepositoryQA();
            var bodyStyleRepo = new BodyStyleRepositoryQA();
            var colorIntRepo = new ColorIntRepositoryQA();
            var colorExRepo = new ColorExRepositoryQA();
            var transRepo = new TransRepositoryQA();

            var vehicles = _vehicles.Where(m => m.IsDeleted == false && m.TypeId == 1).OrderByDescending(m => m.MSRP).ToList();

            foreach (var vehicle in vehicles)
            {
                var make = makeRepo.GetAll().FirstOrDefault(m => m.MakeId == vehicle.MakeId);
                var model = modelRepo.GetAll().FirstOrDefault(m => m.ModelId == vehicle.ModelId);
                var bodyStyle = bodyStyleRepo.GetAll().FirstOrDefault(m => m.BodyStyleId == vehicle.BodyStyleId);
                var colorInt = colorIntRepo.GetAll().FirstOrDefault(m => m.ColorIntId == vehicle.ColorIntId);
                var colorEx = colorExRepo.GetAll().FirstOrDefault(m => m.ColorExId == vehicle.ColorExId);
                var trans = transRepo.GetAll().FirstOrDefault(m => m.TransId == vehicle.TransId);


                var newVehicle = new SearchVehicleRequestItem();
                newVehicle.VehicleId = vehicle.VehicleId;
                newVehicle.MakeName = make.MakeName;
                newVehicle.ModelName = model.ModelName;
                newVehicle.Year = vehicle.Year;
                newVehicle.MSRP = vehicle.MSRP;
                newVehicle.Picture = vehicle.Picture;
                newVehicle.BodyStyleName = bodyStyle.BodyStyleName;
                newVehicle.ColorIntName = colorInt.ColorIntName;
                newVehicle.SalePrice = vehicle.SalePrice;
                newVehicle.TransName = trans.TransName;
                newVehicle.Mileage = vehicle.Mileage;
                newVehicle.ColorExName = colorEx.ColorExName;
                newVehicle.VIN = vehicle.VIN;
                newVehicle.Description = vehicle.Description;
                newVehicle.IsDeleted = vehicle.IsDeleted;

                newVehicles.Add(newVehicle);
            }

            newVehicles = newVehicles.OrderByDescending(m => m.MSRP).ToList();

            if (!string.IsNullOrEmpty(parameters.SearchString))
            {
                newVehicles = newVehicles.Where(m =>
                    m.MakeName.StartsWith(parameters.SearchString, StringComparison.InvariantCultureIgnoreCase)
                    || m.ModelName.StartsWith(parameters.SearchString, StringComparison.InvariantCultureIgnoreCase)
                    || m.Year.ToString().StartsWith(parameters.SearchString, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }

            if (parameters.MinPrice.HasValue)
            {
                newVehicles = newVehicles.Where(m => m.MSRP >= parameters.MinPrice).ToList();
            }

            if (parameters.MaxPrice.HasValue)
            {
                newVehicles = newVehicles.Where(m => m.MSRP <= parameters.MaxPrice).ToList();
            }

            if (!string.IsNullOrEmpty(parameters.MinYear))
            {
                var result = int.TryParse(parameters.MinYear, out int minYear);
                newVehicles = newVehicles.Where(m => m.Year.Year >= minYear).ToList();
            }

            if (!string.IsNullOrEmpty(parameters.MaxYear))
            {
                var result = int.TryParse(parameters.MaxYear, out int maxYear);
                newVehicles = newVehicles.Where(m => m.Year.Year <= maxYear).ToList();
            }

            return newVehicles;
        }

        public List<SearchVehicleRequestItem> SearchUsed(SearchVehicleParameters parameters)
        {
            var usedVehicles = new List<SearchVehicleRequestItem>();
            var makeRepo = new MakeRepositoryQA();
            var modelRepo = new ModelRepositoryQA();
            var bodyStyleRepo = new BodyStyleRepositoryQA();
            var colorIntRepo = new ColorIntRepositoryQA();
            var colorExRepo = new ColorExRepositoryQA();
            var transRepo = new TransRepositoryQA();

            var vehicles = _vehicles.Where(m => m.IsDeleted == false && m.TypeId == 2).OrderByDescending(m => m.MSRP).ToList();

            foreach (var vehicle in vehicles)
            {
                var make = makeRepo.GetAll().FirstOrDefault(m => m.MakeId == vehicle.MakeId);
                var model = modelRepo.GetAll().FirstOrDefault(m => m.ModelId == vehicle.ModelId);
                var bodyStyle = bodyStyleRepo.GetAll().FirstOrDefault(m => m.BodyStyleId == vehicle.BodyStyleId);
                var colorInt = colorIntRepo.GetAll().FirstOrDefault(m => m.ColorIntId == vehicle.ColorIntId);
                var colorEx = colorExRepo.GetAll().FirstOrDefault(m => m.ColorExId == vehicle.ColorExId);
                var trans = transRepo.GetAll().FirstOrDefault(m => m.TransId == vehicle.TransId);


                var usedVehicle = new SearchVehicleRequestItem();
                usedVehicle.VehicleId = vehicle.VehicleId;
                usedVehicle.MakeName = make.MakeName;
                usedVehicle.ModelName = model.ModelName;
                usedVehicle.Year = vehicle.Year;
                usedVehicle.MSRP = vehicle.MSRP;
                usedVehicle.Picture = vehicle.Picture;
                usedVehicle.BodyStyleName = bodyStyle.BodyStyleName;
                usedVehicle.ColorIntName = colorInt.ColorIntName;
                usedVehicle.SalePrice = vehicle.SalePrice;
                usedVehicle.TransName = trans.TransName;
                usedVehicle.Mileage = vehicle.Mileage;
                usedVehicle.ColorExName = colorEx.ColorExName;
                usedVehicle.VIN = vehicle.VIN;
                usedVehicle.Description = vehicle.Description;
                usedVehicle.IsDeleted = vehicle.IsDeleted;

                usedVehicles.Add(usedVehicle);
            }

            usedVehicles = usedVehicles.OrderByDescending(m => m.MSRP).ToList();

            if (!string.IsNullOrEmpty(parameters.SearchString))
            {
                usedVehicles = usedVehicles.Where(m =>
                    m.MakeName.StartsWith(parameters.SearchString, StringComparison.InvariantCultureIgnoreCase)
                    || m.ModelName.StartsWith(parameters.SearchString, StringComparison.InvariantCultureIgnoreCase)
                    || m.Year.ToString().StartsWith(parameters.SearchString, StringComparison.InvariantCultureIgnoreCase)).ToList();
            }

            if (parameters.MinPrice.HasValue)
            {
                usedVehicles = usedVehicles.Where(m => m.MSRP >= parameters.MinPrice).ToList();
            }

            if (parameters.MaxPrice.HasValue)
            {
                usedVehicles = usedVehicles.Where(m => m.MSRP <= parameters.MaxPrice).ToList();
            }

            if (!string.IsNullOrEmpty(parameters.MinYear))
            {
                var result = int.TryParse(parameters.MinYear, out int minYear);
                usedVehicles = usedVehicles.Where(m => m.Year.Year >= minYear).ToList();
            }

            if (!string.IsNullOrEmpty(parameters.MaxYear))
            {
                var result = int.TryParse(parameters.MaxYear, out int maxYear);
                usedVehicles = usedVehicles.Where(m => m.Year.Year <= maxYear).ToList();
            }

            return usedVehicles;
        }

        public SearchVehicleRequestItem SearchVehicleById(int vehicleId)
        {
            var makeRepo = new MakeRepositoryQA();
            var modelRepo = new ModelRepositoryQA();
            var bodyStyleRepo = new BodyStyleRepositoryQA();
            var colorIntRepo = new ColorIntRepositoryQA();
            var colorExRepo = new ColorExRepositoryQA();
            var transRepo = new TransRepositoryQA();

            var vehicle = _vehicles.FirstOrDefault(m => m.VehicleId == vehicleId);

            var make = makeRepo.GetAll().FirstOrDefault(m => m.MakeId == vehicle.MakeId);
            var model = modelRepo.GetAll().FirstOrDefault(m => m.ModelId == vehicle.ModelId);
            var bodyStyle = bodyStyleRepo.GetAll().FirstOrDefault(m => m.BodyStyleId == vehicle.BodyStyleId);
            var colorInt = colorIntRepo.GetAll().FirstOrDefault(m => m.ColorIntId == vehicle.ColorIntId);
            var colorEx = colorExRepo.GetAll().FirstOrDefault(m => m.ColorExId == vehicle.ColorExId);
            var trans = transRepo.GetAll().FirstOrDefault(m => m.TransId == vehicle.TransId);

            var newVehicle = new SearchVehicleRequestItem();
            newVehicle.VehicleId = vehicle.VehicleId;
            newVehicle.MakeName = make.MakeName;
            newVehicle.ModelName = model.ModelName;
            newVehicle.Year = vehicle.Year;
            newVehicle.MSRP = vehicle.MSRP;
            newVehicle.Picture = vehicle.Picture;
            newVehicle.BodyStyleName = bodyStyle.BodyStyleName;
            newVehicle.ColorIntName = colorInt.ColorIntName;
            newVehicle.SalePrice = vehicle.SalePrice;
            newVehicle.TransName = trans.TransName;
            newVehicle.Mileage = vehicle.Mileage;
            newVehicle.ColorExName = colorEx.ColorExName;
            newVehicle.VIN = vehicle.VIN;
            newVehicle.Description = vehicle.Description;
            newVehicle.IsDeleted = vehicle.IsDeleted;

            return newVehicle;
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            var vehicleToUpdate = _vehicles.FirstOrDefault(m => m.VehicleId == vehicle.VehicleId);
            vehicleToUpdate = vehicle;
        }
    }
}
