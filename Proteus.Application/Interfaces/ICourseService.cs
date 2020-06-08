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

        Task<CourseViewModel> GetCourse(CourseViewModel courseViewModel);
        Task Create(CourseViewModel courseViewModel);
        Task Update(CourseViewModel courseViewModel);
        Task Delete(CourseViewModel courseViewModel);
    }
}
