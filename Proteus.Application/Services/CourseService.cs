using AutoMapper;
using AutoMapper.QueryableExtensions;
using Proteus.Application.Interfaces;
using Proteus.Application.ViewModels;
using Proteus.Domain.Commands;
using Proteus.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Proteus.Domain.Queries;
using Proteus.Domain.Entities;

namespace Proteus.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _CourseRepository;
        private readonly IMapper _autoMapper;
        private readonly IMediator _mediator;

        public CourseService(ICourseRepository courseRepository, IMediator mediator, IMapper autoMapper)
        {
            _CourseRepository = courseRepository;
            _autoMapper = autoMapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<CourseViewModel>> GetCourses()
        {
            CourseViewModel vm = new CourseViewModel();
            IEnumerable<Course> result = (IEnumerable<Course>)await _mediator.Send(_autoMapper.Map<GetCoursesQuery>(vm));
            //convert back to view models
            return await Task.FromResult(_autoMapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(result));
        }

        public async Task<CourseViewModel> GetCourse(CourseViewModel courseViewModel)
        {
            //convert 
            var q = _autoMapper.Map<GetCourseByIdQuery>(courseViewModel);
            var course = _mediator.Send(q);
            //var course = _CourseRepository.GetCourse(courseViewModel.Id);
            CourseViewModel result = _autoMapper.Map<CourseViewModel>(course.Result);
            return await Task.FromResult<CourseViewModel>(result); 
        }


        public async Task Create(CourseViewModel courseViewModel)
        {
            await _mediator.Send(_autoMapper.Map<CreateCourseCommand>(courseViewModel));            
        }


        public async Task Update(CourseViewModel courseViewModel)
        {
            //uses mediatr command
           // replaced with automapper
            //var updateCourseCommand = new UpdateCourseCommand(
            //    courseViewModel.Id,
            //    courseViewModel.Name,
            //    courseViewModel.Description,
            //    courseViewModel.ImageUrl
            //    );
            await _mediator.Send(_autoMapper.Map<UpdateCourseCommand>(courseViewModel));
        }

        public async Task Delete(CourseViewModel courseViewModel)
        {
            await _mediator.Send(_autoMapper.Map<DeleteCourseCommand>(courseViewModel));
        }

    }
}
