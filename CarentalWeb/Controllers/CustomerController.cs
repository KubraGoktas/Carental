using CarentalLibrary.DataAcces.Context;
using CarentalLibrary.DataAcces.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarentalWeb.Controllers
{
    public class CustomerController : Controller
    {
        private readonly CarentalContext _CarentalContext;
        public CustomerController(CarentalContext CarentalContext)
        {
            _CarentalContext = CarentalContext;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult GetCustomerView(int customerId)
        {
            Customer customer = _CarentalContext.customers.ToList().Find(x => x.Id == customerId);
            if (customer != null)
            {

                List<Rental> rentallist = _CarentalContext.rentals.ToList().FindAll(x => x.CustomerId == customerId);
                ViewBag.custProList = rentallist;
                return View("ListProcess");

            }
            else
            {
                TempData["AccError"] = "bu ıd ile müşteri bulunamadı";
                return RedirectToAction("Account", "Home");
            }

        }



        public JsonResult GetCustomer(int customerId)
        {
            if (customerId != 0)
            {

                Customer customer = _CarentalContext.customers.ToList().Find(x => x.Id == customerId);
                if (customer != null)
                {
                    return Json(customer);
                }
                else
                {
                    return Json(new { success = false, responseText = "bu Id ile kullanıcı bulunamadı." });
                }




            }
            else
            {
                return Json(new { success = false, responseText = "bu Id ile kullanıcı bulunamadı." });
            }





        }

        public IActionResult AddCustomer()
        {

            return View();
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult AddCustomer(Customer customer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _CarentalContext.customers.Add(customer);
                    var result = _CarentalContext.SaveChanges();
                    TempData["RentSucces"] = "işlem başarılı";

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    TempData["RentError"] = "işlem başarısız";
                }
            }


            return View();

        }
    }
}
