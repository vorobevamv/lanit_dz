using System;

namespace Lanitlesson
{
    internal class Parent
    {
        public string City { get; set; }
        public int Income { get; set; }
        public bool IsFree { get; set; }
        public DateTime WasBorn { get; set; }
        public Child ChildType { get; set; }

        public Parent(string city, int income, bool isFree, DateTime wasBorn, Child childType)
        {
            City = city;
            Income = income;
            IsFree = isFree;
            WasBorn = wasBorn;
            ChildType = childType;
        }
    }
}
