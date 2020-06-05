using System;
using System.Collections.Generic;
using System.Text;

namespace Proteus.Domain.Commands
{
    public class UpdateCourseCommand : CourseCommand
    {
        public UpdateCourseCommand(int id, string name, string description, string imageUrl)
        {
            Id = id;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;

        }
    }
}
