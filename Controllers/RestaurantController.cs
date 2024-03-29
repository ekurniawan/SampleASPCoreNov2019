﻿using System;
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
            if (TempData["pesan"] != null)
            {
                ViewData["pesan"] = TempData["pesan"];
            }

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
        public async Task<ActionResult> Edit(int id)
        {
            var data = await _resto.GetById(id.ToString());
            return View(data);
        }

        // POST: Restaurant/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Restaurant resto)
        {
            try
            {
                var data = await _resto.Update(resto);
                TempData["pesan"] = "<div class='alert alert-success'>Data berhasil diupdate</div>";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewData["pesan"] = $"<div class='alert alert-danger'>data gagal diupdate {ex.Message}</div>";
                return View();
            }
        }

        // GET: Restaurant/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var data = await _resto.GetById(id.ToString());
            return View(data);
        }

        // POST: Restaurant/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeletePost(int id)
        {
            try
            {
                await _resto.Delete(id.ToString());
                TempData["pesan"] = "<div class='alert alert-success'>Data berhasil didelete</div>";
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ViewData["pesan"] = $"<div class='alert alert-danger'>data gagal diupdate {ex.Message}</div>";
                return View();
            }
        }
    }
}