using AutoMapper;
using Proteus.Application.ViewModels;
using Proteus.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proteus.Application.AutoMapper
{
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<CourseViewModel, CreateCourseCommand>()
                .ConvertUsing(c => new CreateCourseCommand(c.Name, c.Description, c.ImageUrl));
           

            //one for each viewmodel
        }
    }
}
