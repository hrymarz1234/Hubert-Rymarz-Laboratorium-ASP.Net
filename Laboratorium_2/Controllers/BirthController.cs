﻿using Laboratorium_2.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Laboratorium_2.Controllers
{
    public class BirthController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Greet(Birth model)
        {
            if (model.IsValid())
            {
                return View(model);
            }
            else
            {
                return View("Error");
            }
        }
    }
}