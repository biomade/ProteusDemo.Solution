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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task Create(CourseViewModel courseViewModel)
        {
           await  _bus.SendCommand(_autoMapper.Map<CreateCourseCommand>(courseViewModel));
        }

        public async Task<IEnumerable<CourseViewModel>> GetCourses()
        {
            var result = _CourseRepository.GetCourses().ProjectTo<CourseViewModel>(_autoMapper.ConfigurationProvider);
            return await Task.FromResult<IEnumerable<CourseViewModel>>(result); 
        }

        public async Task<CourseViewModel> GetCourse(CourseViewModel courseViewModel)
        {
            var course = _CourseRepository.GetCourse(courseViewModel.Id);
            CourseViewModel result = _autoMapper.Map<CourseViewModel>(course);
            return await Task.FromResult<CourseViewModel>(result); 
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
            //_bus.SendCommand(updateCourseCommand);
            await _bus.SendCommand(_autoMapper.Map<UpdateCourseCommand>(courseViewModel));  
        }

        public async Task Delete(CourseViewModel courseViewModel)
        {
            await _bus.SendCommand(_autoMapper.Map<DeleteCourseCommand>(courseViewModel));
        }

    }
}
