using Proteus.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proteus.Domain.Core.Queries
{
    public abstract class Query : Message
    {
        public DateTime TimeStamp { get; protected set; }

        protected Query()
        {
            TimeStamp = DateTime.Now;
        }
    }
}
