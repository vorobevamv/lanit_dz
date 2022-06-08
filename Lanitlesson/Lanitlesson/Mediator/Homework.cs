using System;

namespace Lanitlesson
{
    public abstract class Homework
    {
        protected IMediator mediator;

        public Homework(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public virtual void Activate()
        { 
            mediator.Activate (this);
        }

        public abstract void Start();
    }
}
