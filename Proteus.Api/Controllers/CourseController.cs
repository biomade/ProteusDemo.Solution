using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Proteus.Application.Interfaces;
using Proteus.Application.ViewModels;

namespace Proteus.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly ILogger<CourseController> _logger;


        public CourseController(ICourseService courseService, ILogger<CourseController> logger)
        {
            _courseService = courseService;
            _logger = logger;
            _logger.LogDebug(1, "NLog injected into CourseController");
        }

        // GET: api/<CourseController>
        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            //IEnumerable<CourseViewModel> courseViewModel = (IEnumerable<CourseViewModel>)_courseService.GetCourses();
            return Ok(await _courseService.GetCourses());
        }

        // GET api/<CourseController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCourse(int id)
        {

            return Ok(await _courseService.GetCourse(new CourseViewModel { Id = (int)id }));
        }

        // POST api/<CourseController>
        [HttpPost]
        public async Task<ActionResult> CreateCourse(CourseViewModel courseViewModel)
        {
            await _courseService.Create(courseViewModel);
            return NoContent();
        }

        // PUT api/<CourseController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCourseDetails(int id, [Bind("Id,Name,Description,ImageUrl")] CourseViewModel courseViewModel)
        {
            if (id != courseViewModel.Id)
            {
                return BadRequest();
            }

             await _courseService.Update(courseViewModel);

            return NoContent();
        }

        // DELETE api/<CourseController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCourse(int id)
        {
            await _courseService.Delete(new CourseViewModel { Id = (int)id });

            return NoContent();
        }
    }
}
