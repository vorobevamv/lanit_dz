using System;


namespace Lanitlesson
{
    public abstract class Mediator
    {
        public abstract void Start(string message);
    }

    public class ConcreteMediator : Mediator
    {
        public override void Start(string message)
        {

            if (message == "1")
            {
                Console.Clear();
                Konek.Start();
            }
            else if (message == "2")
            {
                Console.Clear();
                UrlToFile.Start();
            }
            else if (message == "3")
            {
                Console.Clear();
                Fibonachchi.Start();
            }
            else if (message == "4")
            {
                Console.Clear();
                Serialization.Start();
            }
            else if (message == "5")
            {
                Console.Clear();
                CRUDSQL.Start();
            }
            else if (message == "6")
            {
                Console.Clear();
                CRUDLINQ.Start();
            }
            
        }
    }
}
