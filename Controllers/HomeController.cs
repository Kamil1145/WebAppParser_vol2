using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebAppParser.Models;
using System.Web;
using WebAppParser.Database;

namespace WebAppParser.Controllers
{
    public class HomeController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }



        [HttpGet]
        public ViewResult Form()
        {
            return View();
        }

        [Route("Property")]
        [HttpPost]
        public ActionResult Index(string message)
        {
            return View("Property");
        }

        [HttpPost]
        public ActionResult Form(string message)
        {
            ParseManager parseManager = new ParseManager();
            var property = parseManager.Selector(message);
            return View("Property", property);
        }

        [HttpPost]
        public ActionResult SetProperty(Property property)
        {
            MongoDb.MongoConnect(property);


            return View("SetProperty", property);
        }

        [HttpPut]
        public ViewResult Property()
        {
            return View();
        }

        public ActionResult SetProperty(string Prize, string Content, string Floor, string Area, string Address, 
            string Phone, string Title, string Development, string Bathrooms, string Parking, string Furnitured, string Rooms)
        {

            Property property = new Property();
            property.Title = Title;
            property.Prize = Prize;
            property.Content = Content;
            property.Floor = Floor;
            property.Area = Area;
            property.Address = Address;
            property.PhoneNumber = Phone;
            property.Development = Development;
            property.Bathrooms = Bathrooms;
            property.Parking = Parking;
            property.Furnitured = Furnitured;
            property.Rooms = Rooms;
            
            return View("SetProperty",property);
        }



    }
}
 