using CarentalLibrary.DataAcces.Context;
using CarentalLibrary.DataAcces.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarentalWeb.Controllers
{
    public class RentalController : Controller
    {
        private readonly CarentalContext _CarentalContext;
        public RentalController(CarentalContext CarentalContext)
        {
            _CarentalContext = CarentalContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DeleteRental(int Id)
        {
            Rental deleteRental = _CarentalContext.rentals.SingleOrDefault(x => x.Id == Id);
            _CarentalContext.rentals.Remove(deleteRental);
            var result = _CarentalContext.SaveChanges();
            //var returnUrl = Url.Action("GetCustomerView", "Customer", new {id = Id });
            //return RedirectToAction("GetCustomerView(+''+)", "Customer", new { Id = Id });
            var customerId = deleteRental.CustomerId;
            if (deleteRental != null)
            {
                if (result > 0)
                {
                    List<Rental> rentallist = _CarentalContext.rentals.ToList().FindAll(x => x.CustomerId == customerId);
                    ViewBag.custProList = rentallist;
                    TempData["Succes"] = "kayıt silindi";

                }
                else
                {

                    return null;

                }
            }
            else
            {
                TempData["Error"] = "bu numara ile müşteri bulunamadı";
            }
            return View("ListProcess");

        }

        public IActionResult UpdateRental(Rental rental)
        {
            int updateid = rental.Id;
            Rental updateRental = _CarentalContext.rentals.SingleOrDefault(x => x.Id == updateid);
            updateRental.Id = rental.Id;
            updateRental.CarId = rental.CarId;
            updateRental.CustomerId = rental.CustomerId;
            updateRental.RentBegin = rental.RentBegin;
            updateRental.RentEnd = rental.RentEnd;
            updateRental.TotalPrice = rental.TotalPrice;
            _CarentalContext.rentals.Update(updateRental);
            var result = _CarentalContext.SaveChanges();
            var customerId = updateRental.CustomerId;
            if (updateRental != null)
            {
                if (result > 0)
                {
                    List<Rental> rentallist = _CarentalContext.rentals.ToList().FindAll(x => x.CustomerId == customerId);
                    ViewBag.custProList = rentallist;
                    TempData["Succes"] = "kayıt güncellendi";

                }
                else
                {

                    return null;

                }
            }
            else
            {
                TempData["Error"] = "bu numara ile kayıt bulunamadı";
            }
            return View("ListProcess");
        }

        public JsonResult GetRental(int rentalid)
        {
            Rental rentalUpdate = _CarentalContext.rentals.SingleOrDefault(x => x.Id == rentalid);
            var newcar = _CarentalContext.cars.SingleOrDefault(x => x.Id == rentalUpdate.CarId);
            ViewBag.car = newcar;
            float price = newcar.Price;
            return Json(new { Result = rentalUpdate, Price = price });
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult RentalCar(Rental Rental)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _CarentalContext.rentals.Add(Rental);
                    _CarentalContext.SaveChanges();
                    TempData["RentSucces"] = "işlem Başarıyla Kaydedildi";
                    

                }
                catch (Exception e)
                {
                    TempData["RentError"] = e;
                }

            }
            return RedirectToAction("ListCars", "Car");
        }
    }
}
