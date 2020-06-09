using MediatR;
using Proteus.Domain.Entities;
using Proteus.Domain.Interfaces;
using Proteus.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proteus.Domain.QueryHandlers
{
    public class GetCourseByIdQueryHandler : IRequestHandler<GetCourseByIdQuery, Course>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCourseByIdQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public Task<Course> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            Course courses = _courseRepository.GetCourse(request.Id);
            return Task.FromResult(courses);
        }
    }
}
