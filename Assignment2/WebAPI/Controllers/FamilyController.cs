﻿using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class FamilyController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}