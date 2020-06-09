﻿using MediatR;
using Proteus.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proteus.Domain.Commands
{
    public class DeleteCourseCommand:  IRequest<bool>
    {

        public int Id { get; protected set; }
       
        public DeleteCourseCommand(int id)
        {
            Id = id;
        }
    }
}
