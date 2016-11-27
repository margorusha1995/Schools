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
            int i = 0;
            foreach (var item in result)
            {
                i++;
                data.Add(new Structure()
                {
                    address = item.TownshipName + ", " + item.LocalityTypeName + " " + item.LocalityName + ", " + item.StreetTypeName + " " + item.StreetName + ", " + item.BuildingNumber,
                    id = item.ID.ToString(),
                    name = item.Name
                });

                if (i > 10)
                {
                    break;
                }
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
            int i = 0;
            foreach (var item in result)
            {
                i++;
                data.Add(new Structure()
                {
                    address = item.TownshipName + ", " + item.LocalityTypeName + " " + item.LocalityName + ", " + item.StreetTypeName + " " + item.StreetName + ", " + item.BuildingNumber,
                    id = item.ID,
                    name = item.Name
                });

                if (i > 10)
                {
                    break;
                }
            }

            ViewBag.Addresses = data;

            return View();
        }


        public IActionResult Save([FromBody]Structure[] name)
        {
            foreach (var item in name)
            {
                if (item.coordinates != null)
                {
                    context.YandexCoordinates.Add(new YandexCoordinates()
                    {
                        id = Guid.NewGuid(),
                        longitude = item.coordinates[0],
                        latitude = item.coordinates[1],
                        placeID = item.id,
                    });
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
            int i = 0;
            foreach (var item in result)
            {
                i++;
                data.Add(new Structure()
                { address=item.Addess,
                    id=item.ID,
                    name=item.Name });

                if (i > 10)
                {
                    break;
                }
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
                         join coordinates in context.YandexCoordinates on address.AddressID equals coordinates.placeID 
                         where schoolAddress.AddressTypeID == 1
                         select new
                         {
                             ID = coordinates.id,
                             Name = school.SchoolName,
                             Latitude = coordinates.latitude,
                             Longitude = coordinates.longitude,
                             ZipCode = address.ZipCode,
                             LocalityName = address.LocalityName,
                             StreetName = address.StreetName,
                             BuildingNumber = address.BuildingNumber,
                             LocalityTypeName = locality.LocalityTypeName,
                             StreetTypeName = street.StreetTypeName,
                             TownshipName = township.TownshipName,
                             BuildingTypeName = building.BuildingTypeName

                         };

            int i = 0;
            foreach (var item in result)
            {
                if (item.Latitude != null & item.Longitude != null)
                {
                    i++;
                    data.Add(new Structure()
                    {
                        address = item.LocalityName,
                        id = item.ID,
                        name = item.Name,
                        coordinates = new double?[2] { item.Latitude, item.Longitude }
                    });

                    if (i > 10)
                    {
                        break;
                    }
                }
            }

            ViewBag.Schools = data;
            return View();
        }
    }
}
