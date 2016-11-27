using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;

namespace Schools.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult GoogleMaps()
        {
            return View();
        }

        public IActionResult Index()
        {
            //List<string> addresses = new List<string>();

            //string connectionString =
            //    "data source=COMPUTER-ПК\\SQLEXPRESS;initial catalog=School;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            //Db context =new Db(connectionString);
            //var result = from schoolAddress in context.rbd_SchoolAddress
            //             join school in context.rbd_Schools on schoolAddress.SchoolID equals school.SchoolID
            //             join address in context.rbd_Address on schoolAddress.AddressID equals address.AddressID
            //             join locality in context.rbdc_LocalityTypes on address.LocalityTypeID equals locality.LocalityTypeID
            //             join street in context.rbdc_StreetTypes on address.StreetTypeID equals street.StreetTypeID
            //             join township in context.rbd_Townships on address.TownshipID equals township.TownshipID
            //             join building in context.rbdc_BuildingTypes on address.BuildingTypeID equals building.BuildingTypeID
            //             where schoolAddress.AddressTypeID == 1
            //             select new
            //             {
            //                 ID = address.AddressID,
            //                 Name = school.SchoolName,
            //                 ZipCode = address.ZipCode,
            //                 LocalityName = address.LocalityName,
            //                 StreetName = address.StreetName,
            //                 BuildingNumber = address.BuildingNumber,
            //                 LocalityTypeName = locality.LocalityTypeName,
            //                 StreetTypeName = street.StreetTypeName,
            //                 TownshipName = township.TownshipName,
            //                 BuildingTypeName = building.BuildingTypeName
            //             };

            //int i = 0;
            //foreach (var item in result)
            //{
            //    i++;
            //    addresses.Add(item.TownshipName + ", " + item.LocalityTypeName + " " + item.LocalityName + ", " + item.StreetTypeName + " " + item.StreetName + ", " + item.BuildingNumber);
            //    if (i > 15)
            //    {
            //        break;
            //    }
            //}

            //ViewBag.Addresses = addresses;

            return View();
        }
    }
}
