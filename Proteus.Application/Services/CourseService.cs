using AutoMapper;
using AutoMapper.QueryableExtensions;
using Proteus.Application.Interfaces;
using Proteus.Application.ViewModels;
using Proteus.Domain.Commands;
using Proteus.Domain.Core.Bus;
using Proteus.Domain.Entities;
using Proteus.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proteus.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _CourseRepository;
        private readonly IMediatorHandler _bus;
        private readonly IMapper _autoMapper;

        public CourseService(ICourseRepository courseRepository, IMediatorHandler bus, IMapper autoMapper)
        {
            _CourseRepository = courseRepository;
            _bus = bus;
            _autoMapper = autoMapper;
        }

        public void Create(CourseViewModel courseViewModel)
        {
            _bus.SendCommand(_autoMapper.Map<CreateCourseCommand>(courseViewModel));
        }

        public IEnumerable<CourseViewModel> GetCourses()
        {
            return _CourseRepository.GetCourses().ProjectTo<CourseViewModel>(_autoMapper.ConfigurationProvider);
        }

        public CourseViewModel GetCourse(CourseViewModel courseViewModel)
        {
            var course = _CourseRepository.GetCourse(courseViewModel.Id);
            var coursevm = _autoMapper.Map<CourseViewModel>(course);
            return coursevm;
        }

        public void Update(CourseViewModel courseViewModel)
        {
            //uses mediatr command
           // replaced with automapper
            //var updateCourseCommand = new UpdateCourseCommand(
            //    courseViewModel.Id,
            //    courseViewModel.Name,
            //    courseViewModel.Description,
            //    courseViewModel.ImageUrl
            //    );
            //_bus.SendCommand(updateCourseCommand);
            _bus.SendCommand(_autoMapper.Map<UpdateCourseCommand>(courseViewModel));  
        }

        public void Delete(CourseViewModel courseViewModel)
        {
            _bus.SendCommand(_autoMapper.Map<DeleteCourseCommand>(courseViewModel));
        }

    }
}
