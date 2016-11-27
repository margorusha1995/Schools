using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Model;
using Newtonsoft.Json;

namespace Schools.Controllers
{
    public class Structure
    {
        public string address;
        public string id;
        public string name;
        public double[] coorsinates;

        public Structure(string _addess, string _id, string _name)
        {
            address = _addess;
            id = _id;
            coorsinates = new double[2];
            name = _name;
        }
    }

    public class HomeController : Controller
    {
        public IActionResult GoogleMaps()
        {
            return View();
        }

        public IActionResult Index()
        {
            List<Structure> data = new List<Structure>();

            string connectionString =
                "data source=ENVY\\SQLEXPRESS;initial catalog=School;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework";
            Db context =new Db(connectionString);
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
                data.Add(new Structure(
                    item.TownshipName + ", " + item.LocalityTypeName + " " + item.LocalityName + ", " + item.StreetTypeName + " " + item.StreetName + ", " + item.BuildingNumber,
                    item.ID.ToString(), 
                    item.Name));

                if (i > 10)
                {
                    break;
                }
            }

            ViewBag.Addresses = data;

            return View();
        }


        public IActionResult Save(Structure[] name)
        {
           
            return View();
        }
    }
}
