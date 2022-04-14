using System;


namespace Lanitlesson
{
    public class ConcreteMediator : IMediator
    {
        public Homework hKonek;
        public Homework hFibonachchi;
        public Homework hUrlToFile;
        public Homework hSerialization;
        public Homework hCRUDSQL;
        public Homework hCRUDLINQ;

        public void Activate(Homework homework)
        {
          homework.Start();
        }
    }
}