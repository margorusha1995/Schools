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
        public string id;
        public string name;
        public double[] coorsinates;
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


        public IActionResult Save([FromBody]Structure[] name)
        {
           
            return View();
        }

        public IActionResult Stations()
        {
            List<Structure> data = new List<Structure>();

            string connectionString =
                "data source=COMPUTER-ПК\\SQLEXPRESS;initial catalog=School;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            Db context = new Db(connectionString);
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
                data.Add(new Structure(
                    item.Addess,
                    item.ID.ToString(),
                    item.Name));

                if (i > 10)
                {
                    break;
                }
            }

            ViewBag.Addresses = data;

            return View("Index");
        }
    }
}
