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
        public bool same;
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
                         orderby Gcoordinates.latitude
                         select new
                         {
                             ID = Ycoordinates.id,
                             Name = school.SchoolName,
                             YLatitude = Ycoordinates.latitude == null ? Ycoordinates.latitude : Math.Round((double)Ycoordinates.latitude, 2),
                             YLongitude = Ycoordinates.longitude == null ? Ycoordinates.longitude : Math.Round((double)Ycoordinates.longitude, 2),
                             GLatitude = Gcoordinates.latitude == null ? Gcoordinates.latitude : Math.Round((double)Gcoordinates.latitude, 2),
                             GLongitude = Gcoordinates.longitude == null ? Gcoordinates.longitude : Math.Round((double)Gcoordinates.longitude, 2),
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
                    address =
                        item.LocalityTypeName + " " + item.LocalityName + " " + item.StreetName + ", " +
                        item.BuildingNumber,
                    id = item.ID,
                    name = item.Name,
                    coordinates = new double?[4]
                    {
                        item.YLatitude,
                        item.YLongitude,
                        item.GLatitude,
                        item.GLongitude
                    },
                    same = item.YLatitude == item.GLatitude && item.GLongitude == item.YLongitude ? true : false,


                });
            }

            ViewBag.Schools = data;
            return View();
        }
    }
}
