using Proteus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proteus.Domain.Interfaces
{
    public interface ICourseRepository
    {
        IQueryable<Course> GetCourses();

        //create a base repo that has the add, update, delete methods
        void Add(Course course);
        Course GetCourse(int id);
        void UpdateCourse(Course course);
        void DeleteCourse(int id);

    }
}
