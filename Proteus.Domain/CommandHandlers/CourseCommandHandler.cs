using MediatR;
using Proteus.Domain.Commands;
using Proteus.Domain.Entities;
using Proteus.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proteus.Domain.CommandHandlers
{
    //one for each CRUD opperation and update the Proteus.Infra.IoC.DependencyContainer to register it!!
    public class CourseCreateCommandHandler : IRequestHandler<CreateCourseCommand, bool>
    {
        //add repo
        private readonly ICourseRepository _courseRepository;

        public CourseCreateCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }
        public Task<bool> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = new Course()
            {
                Name = request.Name,
                Description = request.Description,
                ImageUrl = request.ImageUrl
                //add timestamp if column exists
            };

            //additional business logic goes here about who to notify that a course was added
            _courseRepository.Add(course);

            return Task.FromResult(true);
        }

        public Task<bool> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var existingItem = _courseRepository.GetCourse(request.Id);
            //NOW UPDATE
            existingItem.Description = request.Description;
            existingItem.Name = request.Name;
            existingItem.ImageUrl = request.ImageUrl;

            //additional business logic goes here about who to notify that a course was added
            _courseRepository.UpdateCourse(existingItem);

            return Task.FromResult(true);
        }
    }

    public class CourseUpdateCommandHandler : IRequestHandler<UpdateCourseCommand, bool>
    {
        //add repo
        private readonly ICourseRepository _courseRepository;

        public CourseUpdateCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public Task<bool> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var existingItem = _courseRepository.GetCourse(request.Id);
            //NOW UPDATE
            existingItem.Description = request.Description;
            existingItem.Name = request.Name;
            existingItem.ImageUrl = request.ImageUrl;

            //additional business logic goes here about who to notify that a course was added
            _courseRepository.UpdateCourse(existingItem);

            return Task.FromResult(true);
        }
    }

    public class CourseDeleteCommandHandler : IRequestHandler<DeleteCourseCommand, bool>
    {
        //add repo
        private readonly ICourseRepository _courseRepository;

        public CourseDeleteCommandHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public Task<bool> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            //additional business logic goes here about who to notify that a course was added
            _courseRepository.DeleteCourse(request.Id);

            return Task.FromResult(true);
        }
    }


}


