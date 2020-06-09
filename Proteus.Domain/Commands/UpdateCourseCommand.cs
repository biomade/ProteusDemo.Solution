using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proteus.Domain.Commands
{
    public class UpdateCourseCommand : IRequest<bool>
    {

        public int Id { get; protected set; }
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public string ImageUrl { get; protected set; }
        public UpdateCourseCommand(int id, string name, string description, string imageUrl)
        {
            Id = id;
            Name = name;
            Description = description;
            ImageUrl = imageUrl;

        }
    }
}
