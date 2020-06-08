using Proteus.Domain.Core.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proteus.Domain.Queries
{
    public abstract class CourseQuery : Query
    {
        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string ImageUrl { get; protected set; }
    }
}
