using Proteus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proteus.Domain.Commands
{
    public class DeleteCourseCommand: CourseCommand
    {
        public DeleteCourseCommand(int id)
        {
            Id = id;
        }
    }
}
