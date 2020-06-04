using AutoMapper;
using Proteus.Application.ViewModels;
using Proteus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proteus.Application.AutoMapper
{
    public class DomainToViewModelProfile : Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Course, CourseViewModel>();
        }
    }
}
