using MediatR;
using Proteus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Text;

namespace Proteus.Domain.Queries
{
    public class GetCoursesQuery:IRequest<IEnumerable<Course>>
    {
    }

}
