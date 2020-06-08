using MediatR;
using Proteus.Domain.Entities;
using Proteus.Domain.Interfaces;
using Proteus.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Proteus.Domain.QueryHandlers
{
    public class GetCoursesQueryHandler : IRequestHandler<GetCoursesQuery, IEnumerable<Course>>
    {
        private readonly ICourseRepository _courseRepository;

        public GetCoursesQueryHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public Task<IEnumerable<Course>> Handle(GetCoursesQuery request, CancellationToken cancellationToken)
        {

            IEnumerable<Course> courses = _courseRepository.GetCourses();
            return Task.FromResult(courses); 
        }
    }
}
