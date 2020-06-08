using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Proteus.Application.Interfaces;
using Proteus.Application.Services;
using Proteus.Domain.CommandHandlers;
using Proteus.Domain.Commands;
using Proteus.Domain.Entities;
using Proteus.Domain.Interfaces;
using Proteus.Domain.Queries;
using Proteus.Domain.QueryHandlers;
using Proteus.Infra.Data.Context;
using Proteus.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proteus.Infra.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Domain Command Handlers
            services.AddScoped<IRequestHandler<CreateCourseCommand, bool>, CreateCourseCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateCourseCommand, bool>, UpdateCourseCommandHandler>();
            services.AddScoped<IRequestHandler<DeleteCourseCommand, bool>, DeleteCourseCommandHandler>();

            //Domain Query Handlers
            services.AddScoped<IRequestHandler<GetCoursesQuery, IEnumerable<Course>>, GetCoursesQueryHandler>();

            //application layer
            services.AddScoped<ICourseService, CourseService>();

            //Infra.Data layer
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ProteusDBContext>();

        }
    }
}
