﻿using Proteus.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proteus.Application.Interfaces
{
    public interface ICourseService
    {
        //this VM returns an IEnumerable
        IEnumerable<CourseViewModel> GetCourses();

        CourseViewModel GetCourse(CourseViewModel courseViewModel);
        void Create(CourseViewModel courseViewModel);
        void Update(CourseViewModel courseViewModel);
        void Delete(CourseViewModel courseViewModel);
    }
}
