using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proteus.Application.Interfaces;
using Proteus.Application.ViewModels;

namespace Proteus.UI.Controllers
{
    public class CourseController : Controller
    {
        private ICourseService _courseService;

        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        public async Task<IActionResult> Index()
        {
            return  View(await _courseService.GetCourses());
        }

        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _courseService.GetCourse(new CourseViewModel {Id = (int)id });
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,ImageUrl")] CourseViewModel course)
        {
            if (ModelState.IsValid)
            {
                await _courseService.Create(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _courseService.GetCourse(new CourseViewModel { Id = (int)id });
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,ImageUrl")] CourseViewModel course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               await _courseService.Update(course);                
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses2/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var course =await _courseService.GetCourse(new CourseViewModel { Id = (int)id });
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            await _courseService.Delete(new CourseViewModel { Id = (int)id });
            return RedirectToAction(nameof(Index));
        }
    }
}