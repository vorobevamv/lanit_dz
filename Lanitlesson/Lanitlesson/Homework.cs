using System;

namespace Lanitlesson
{
    public abstract class Homework
    {
        protected Mediator mediator;

        protected Homework(Mediator mediator)
        {
            this.mediator = mediator;
        }
    }
}
