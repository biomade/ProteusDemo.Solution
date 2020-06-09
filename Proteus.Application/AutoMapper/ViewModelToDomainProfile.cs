using AutoMapper;
using Proteus.Application.ViewModels;
using Proteus.Domain.Commands;
using Proteus.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proteus.Application.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            //one for each viewmodel
            CreateMap<CourseViewModel, CreateCourseCommand>()
                .ConvertUsing(c => new CreateCourseCommand(c.Name, c.Description, c.ImageUrl));
            
            CreateMap<CourseViewModel, UpdateCourseCommand>()
               .ConvertUsing(c => new UpdateCourseCommand(c.Id, c.Name, c.Description, c.ImageUrl));

            CreateMap<CourseViewModel, DeleteCourseCommand>()
               .ConvertUsing(c => new DeleteCourseCommand(c.Id));

            CreateMap<CourseViewModel, GetCoursesQuery>()
              .ConvertUsing(c => new GetCoursesQuery());

            CreateMap<CourseViewModel, GetCourseByIdQuery>()
             .ConvertUsing(c => new GetCourseByIdQuery(c.Id));
        }
    }
}
