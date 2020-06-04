using Microsoft.EntityFrameworkCore;
using Proteus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proteus.Infra.Data.Context
{
    public class ProteusDBContext : DbContext
    {
        public ProteusDBContext(DbContextOptions options) : base(options)
        {
            //constructor
        }

        //domain entities
        public DbSet<Course> Courses { get; set; }
    }
}
