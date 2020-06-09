using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proteus.Domain.Commands
{
    public class CreateCourseCommand :  IRequest<bool>
    {

        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string ImageUrl { get; protected set; }

        public CreateCourseCommand(string name, string description, string imageUrl)
        {
            Name = name;
            Description = description;
            ImageUrl = imageUrl;
        }
    }
}
