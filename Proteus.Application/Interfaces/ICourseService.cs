using Proteus.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Proteus.Application.Interfaces
{
    public interface ICourseService
    {
        //this VM returns an IEnumerable
        Task<IEnumerable<CourseViewModel>> GetCourses();

        CourseViewModel GetCourse(CourseViewModel courseViewModel);
        void Create(CourseViewModel courseViewModel);
        void Update(CourseViewModel courseViewModel);
        void Delete(CourseViewModel courseViewModel);
    }
}
