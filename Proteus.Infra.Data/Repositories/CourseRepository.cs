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

        public Course GetCourse(int id)
        {
            return _ctx.Courses.Where(c => c.Id == id).FirstOrDefault();
        }

        public void UpdateCourse(Course course)
        {
            _ctx.Courses.Update(course);
            _ctx.SaveChanges();
        }

        public void DeleteCourse(int id)
        {
            Course course = new Course()
            {
                Id = id
            };
            _ctx.Courses.Remove(course);
            _ctx.SaveChanges();
        }
    }
}
