﻿using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db= db;
        }

        public IActionResult Index()
        {
            HomeVM homeVM = new HomeVM
            {
                Services = _db.Services.ToList(),
                Sliders = _db.Sliders.ToList(),
                Courses = _db.Courses.ToList(),
                NoticeBoards = _db.NoticeBoards.ToList(),
                About = _db.Abouts.First(),
                FeedBack = _db.FeedBacks.First()
            };
              return View(homeVM);
        }

        

        public IActionResult Error()
        {
            return View();
        }
    }
}
