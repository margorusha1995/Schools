using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;

namespace Schools.Controllers
{
    public class Structure
    {
        public string address;
        public Guid id;
        public string name;
        public double?[] coordinates;
    }

    public class HomeController : Controller
    {
        Db context;
        public HomeController(Db db)
        {
            context = db;
        }

        public IActionResult GoogleMaps()
        {
            List<Structure> data = new List<Structure>();
            var result = from schoolAddress in context.rbd_SchoolAddress
                         join school in context.rbd_Schools on schoolAddress.SchoolID equals school.SchoolID
                         join address in context.rbd_Address on schoolAddress.AddressID equals address.AddressID
                         join locality in context.rbdc_LocalityTypes on address.LocalityTypeID equals locality.LocalityTypeID
                         join street in context.rbdc_StreetTypes on address.StreetTypeID equals street.StreetTypeID
                         join township in context.rbd_Townships on address.TownshipID equals township.TownshipID
                         join building in context.rbdc_BuildingTypes on address.BuildingTypeID equals building.BuildingTypeID
                         where schoolAddress.AddressTypeID == 1
                         select new
                         {
                             ID = address.AddressID,
                             Name = school.SchoolName,
                             ZipCode = address.ZipCode,
                             LocalityName = address.LocalityName,
                             StreetName = address.StreetName,
                             BuildingNumber = address.BuildingNumber,
                             LocalityTypeName = locality.LocalityTypeName,
                             StreetTypeName = street.StreetTypeName,
                             TownshipName = township.TownshipName,
                             BuildingTypeName = building.BuildingTypeName
                         };

            foreach (var item in result)
            {
                data.Add(new Structure()
                {
                    address = item.TownshipName + ", " + item.LocalityTypeName + " " + item.LocalityName + ", " + item.StreetTypeName + " " + item.StreetName + ", " + item.BuildingNumber,
                    id = item.ID,
                    name = item.Name
                });

            }

            ViewBag.Addresses = data;

            return View(); 
        }

        public IActionResult Index()
        {
            List<Structure> data = new List<Structure>();

            var result = from schoolAddress in context.rbd_SchoolAddress
                         join school in context.rbd_Schools on schoolAddress.SchoolID equals school.SchoolID
                         join address in context.rbd_Address on schoolAddress.AddressID equals address.AddressID
                         join locality in context.rbdc_LocalityTypes on address.LocalityTypeID equals locality.LocalityTypeID
                         join street in context.rbdc_StreetTypes on address.StreetTypeID equals street.StreetTypeID
                         join township in context.rbd_Townships on address.TownshipID equals township.TownshipID
                         join building in context.rbdc_BuildingTypes on address.BuildingTypeID equals building.BuildingTypeID
                         where schoolAddress.AddressTypeID == 1
                         select new
                         {
                             ID = address.AddressID,
                             Name = school.SchoolName,
                             ZipCode = address.ZipCode,
                             LocalityName = address.LocalityName,
                             StreetName = address.StreetName,
                             BuildingNumber = address.BuildingNumber,
                             LocalityTypeName = locality.LocalityTypeName,
                             StreetTypeName = street.StreetTypeName,
                             TownshipName = township.TownshipName,
                             BuildingTypeName = building.BuildingTypeName
                         };

            foreach (var item in result)
            {
                data.Add(new Structure()
                {
                    address = item.TownshipName + ", " + item.LocalityTypeName + " " + item.LocalityName + ", " + item.StreetTypeName + " " + item.StreetName + ", " + item.BuildingNumber,
                    id = item.ID,
                    name = item.Name
                });
            }

            ViewBag.Addresses = data;

            return View();
        }


        public IActionResult Save(string type, [FromBody]Structure[] name)
        {
            if (type == "Y")
            {
                foreach (var item in name)
                {
                    YandexCoordinates obj = new YandexCoordinates()
                    {
                        id = Guid.NewGuid(),
                        placeID = item.id,
                    };

                    if (item.coordinates != null)
                    {
                        obj.longitude = item.coordinates[0];
                        obj.latitude = item.coordinates[1];
                    }
                    else
                    {
                        obj.longitude = null;
                        obj.latitude = null;
                    }

                    context.YandexCoordinates.Add(obj);
                }
            }
            else if (type == "G")
            {
                foreach (var item in name)
                {
                    GoogleCoordinates obj = new GoogleCoordinates()
                    {
                        id = Guid.NewGuid(),
                        placeID = item.id,
                    };

                    if (item.coordinates != null)
                    {
                        obj.longitude = item.coordinates[0];
                        obj.latitude = item.coordinates[1];
                    }
                    else
                    {
                        obj.longitude = null;
                        obj.latitude = null;
                    }

                    context.GoogleCoordinates.Add(obj);
                }
            }
        
            context.SaveChanges();

            return View("Save");
        }

        public IActionResult Stations()
        {
            List<Structure> data = new List<Structure>();
            
            var result = from stations in context.rbd_Stations
                         select new
                         {
                             ID = stations.StationID,
                             Name = stations.StationName,
                             Addess = stations.StationAddress,

                         };
            foreach (var item in result)
            {
                data.Add(new Structure()
                { address=item.Addess,
                    id=item.ID,
                    name=item.Name });
            }
             
            ViewBag.Addresses = data;

            return View("Index");
        }

        public ActionResult Merdge()
        {
            List<Structure> data = new List<Structure>();

            var result = from schoolAddress in context.rbd_SchoolAddress
                         join school in context.rbd_Schools on schoolAddress.SchoolID equals school.SchoolID
                         join address in context.rbd_Address on schoolAddress.AddressID equals address.AddressID
                         join locality in context.rbdc_LocalityTypes on address.LocalityTypeID equals locality.LocalityTypeID
                         join street in context.rbdc_StreetTypes on address.StreetTypeID equals street.StreetTypeID
                         join township in context.rbd_Townships on address.TownshipID equals township.TownshipID
                         join building in context.rbdc_BuildingTypes on address.BuildingTypeID equals building.BuildingTypeID
                         join Ycoordinates in context.YandexCoordinates on address.AddressID equals Ycoordinates.placeID
                         join Gcoordinates in context.GoogleCoordinates on address.AddressID equals Gcoordinates.placeID
                         where schoolAddress.AddressTypeID == 1
                         select new
                         {
                             ID = Ycoordinates.id,
                             Name = school.SchoolName,
                             YLatitude = Ycoordinates.latitude,
                             YLongitude = Ycoordinates.longitude,
                             GLatitude = Gcoordinates.latitude,
                             GLongitude = Gcoordinates.longitude,
                             ZipCode = address.ZipCode,
                             LocalityName = address.LocalityName,
                             StreetName = address.StreetName,
                             BuildingNumber = address.BuildingNumber,
                             LocalityTypeName = locality.LocalityTypeName,
                             StreetTypeName = street.StreetTypeName,
                             TownshipName = township.TownshipName,
                             BuildingTypeName = building.BuildingTypeName

                         };

            foreach (var item in result)
            {
                data.Add(new Structure()
                {
                    address = item.LocalityTypeName + " " + item.LocalityName + " " + item.StreetName + ", " + item.BuildingNumber,
                    id = item.ID,
                    name = item.Name,
                    coordinates = new double?[4] { item.YLatitude, item.YLongitude, item.GLatitude, item.GLongitude }
                });
            }

            ViewBag.Schools = data;
            return View();
        }
    }
}
