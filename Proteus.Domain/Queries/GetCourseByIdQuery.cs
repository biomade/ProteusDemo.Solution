using MediatR;
using Proteus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proteus.Domain.Queries
{
    public class GetCourseByIdQuery : IRequest<Course>
    {
        public int Id { get; protected set; }
        public GetCourseByIdQuery(int id)
        {
            Id = id;
        }
    }
}
