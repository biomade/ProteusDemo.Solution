using Proteus.Domain.Entities;
using Proteus.Domain.Interfaces;
using Proteus.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proteus.Infra.Data.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private ProteusDBContext _ctx;

        public CourseRepository(ProteusDBContext ctx)
        {
            _ctx = ctx;
        }
        public IQueryable<Course> GetCourses()
        {
            return _ctx.Courses;
        }

        public void Add(Course course)
        {
            _ctx.Courses.Add(course);
            _ctx.SaveChanges();
        }
    }
}
