using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proteus.Application.Interfaces;

namespace Proteus.UI.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public IActionResult Index()
        {
            //changed for automapper
            //CourseViewModel model = _courseService.GetCourses();
            //return View(model);

            return View(_courseService.GetCourses());
        }
    }
}