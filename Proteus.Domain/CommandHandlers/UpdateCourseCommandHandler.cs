using MediatR;
using Proteus.Domain.Commands;
using Proteus.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proteus.Domain.CommandHandlers
{

    public class UpdateCourseCommandHandler : IRequestHandler<UpdateCourseCommand, bool>
    {
        //add repo
        private readonly ICourseRepository _courseRepository;

        public UpdateCourseCommandHandler(ICourseRepository courseRepository)
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
}
