using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Proteus.Application.Interfaces;
using Proteus.Application.Services;
using Proteus.Domain.CommandHandlers;
using Proteus.Domain.Commands;
using Proteus.Domain.Core.Bus;
using Proteus.Domain.Interfaces;
using Proteus.Infra.Bus;
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
            //Domain InMemoryBus with MediatR
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            //Domain Handlers
            services.AddScoped<IRequestHandler<CreateCourseCommand, bool>, CourseCommandHandler>();

            //application layer
            services.AddScoped<ICourseService, CourseService>();

            //Infra.Data layer
            services.AddScoped<ICourseRepository, CourseRepository>();
            services.AddScoped<ProteusDBContext>();

        }
    }
}
