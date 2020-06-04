using AutoMapper;
using AutoMapper.QueryableExtensions;
using Proteus.Application.Interfaces;
using Proteus.Application.ViewModels;
using Proteus.Domain.Commands;
using Proteus.Domain.Core.Bus;
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
            //uses mediatr command
            //replaced with automapper
            //var createCourseCommand = new CreateCourseCommand(
            //    courseViewModel.Name,
            //    courseViewModel.Descrption,
            //    courseViewModel.ImageUrl
            //    );
            // _bus.SendCommand(createCourseCommand);


            _bus.SendCommand(_autoMapper.Map<CreateCourseCommand>(courseViewModel));
        }

        public IEnumerable<CourseViewModel> GetCourses()
        {
            //NOTE: use Automapper to simplify this
            //var courses = _CourseRepository.GetCourses();
            //CourseViewModel coursesVM = (CourseViewModel)courses;
            //return coursesVM;

            //replaced with automapper
            //return new CourseViewModel()
            //{
            //    Courses = _CourseRepository.GetCourses()
            //};

            return _CourseRepository.GetCourses().ProjectTo<CourseViewModel>(_autoMapper.ConfigurationProvider);
        }

    }
}
