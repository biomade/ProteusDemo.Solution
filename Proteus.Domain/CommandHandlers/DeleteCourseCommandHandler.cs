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
  

    public class DeleteCourseCommandHandler : IRequestHandler<DeleteCourseCommand, bool>
    {
        //add repo
        private readonly ICourseRepository _courseRepository;

        public DeleteCourseCommandHandler(ICourseRepository courseRepository)
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


