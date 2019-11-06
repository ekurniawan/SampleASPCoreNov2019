using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SampleASPCore.Data;
using SampleASPCore.Models;
using SampleASPCore.Models.ViewModels;

namespace SampleASPCore.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantData _resto;
        public RestaurantController(IRestaurantData resto)
        {
            _resto = resto;
        }

        // GET: Restaurant
        public async Task<ActionResult> Index()
        {
            var models = await _resto.GetAll();
            return View(models);
        }

        public async Task<ActionResult> GetRestoWithCust()
        {
            RestaurantViewModel restoViewModel = new RestaurantViewModel
            {
                Restaurant = await _resto.GetAll(),
                Customer = new Customer
                {
                    CustID=1,
                    CustName="Erick Kurniawan"
                }
            };

            return View(restoViewModel);
        }

        // GET: Restaurant/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var model = await _resto.GetById(id.ToString());
            return View(model);
        }

        // GET: Restaurant/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Restaurant/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(RestoViewModel resto)
        {
            var model = new Restaurant
            {
                Name = resto.Name,
                Address = resto.Address
            };

            try
            {
                var data = await _resto.Insert(model);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurant/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Restaurant/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Restaurant/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}