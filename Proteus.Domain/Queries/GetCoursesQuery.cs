using MediatR;
using Proteus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Text;

namespace Proteus.Domain.Queries
{
    public class GetCoursesQuery: IRequest<IEnumerable<Course>>
    {
        //we want them all so nothing is passed in
        public GetCoursesQuery()
        {
            //we want them all so nothing is passed in
        }
    }

}
