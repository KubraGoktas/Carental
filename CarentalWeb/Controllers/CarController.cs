using CarentalLibrary.DataAcces.Context;
using CarentalLibrary.DataAcces.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarentalWeb.Controllers
{
    public class CarController : Controller
    {
        private readonly CarentalContext _CarentalContext;
        public CarController(CarentalContext CarentalContext)
        {
            _CarentalContext = CarentalContext;
        }
        public IActionResult Index()
        {
            //Car newcar = new Car
            //{
            //    Model="A3",
            //    Brand="Audi",
            //    Color="Siyah",
            //    GearType=1,
            //    ProYear=2020,
            //    Price=200.00m
            //};
            //_CarentalContext.cars.Add(newcar);
            //_CarentalContext.SaveChanges();
            return View();

        }

        public IActionResult ListCars()
        {
            var CarList = _CarentalContext.cars.ToList();
            List<Car> templist = CarList.Cast<Car>().ToList();
            var RentalList = _CarentalContext.rentals.ToList();
            List<Rental> templist2 = RentalList.Cast<Rental>().ToList();
            int idler;
            List<int> idlist = new List<int>();
            for (int i = 0; i < RentalList.Count(); i++)
            {
                var rentaledlist = templist.Where(x => x.Id == templist2[i].CarId);
                idler = rentaledlist.ElementAt(0).Id;
                var item = templist.Find(y => y.Id == idler);
                templist.Remove(item);
                idlist.Add(idler);
            }
            var customers = _CarentalContext.customers.ToList();
            ViewBag.customers = customers;
            ViewBag.CarList = templist;
            ViewBag.RentalList = RentalList;

            return View();
        }


        [HttpPost]
        public JsonResult RentalModal(int carid)
        {
            Car RentalFormMdal = _CarentalContext.cars.ToList().Find(x => x.Id == carid);

            return Json(RentalFormMdal);
        }
    }
}
