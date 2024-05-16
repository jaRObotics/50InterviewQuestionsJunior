using System;
using System.Collections.Generic;

namespace StaticKeyword
{
    class Box
    {
        public static int MaxCount = 50;
        private List<string> elements = new List<string>();

        public void Add(string element)
        {
            if(elements.Count < MaxCount)
            {
                elements.Add(element);
            }
        }

        //can't be made static as it refers
        //to non-static elements field
        public int GetCurrentCount() //this belongs to a specific instance of a class
        {
            var jaro = MaxCount; // accessing static members in non-static method is OK 
            return elements.Count; //so it can see a specific-class members 
        }

        public static string FormatMaxCount()
            //static method doesn't know about instance specific data
            //it sees only other static data 
        {
            return $"The max count for this Box is {MaxCount}"; //this refers to static member 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var box1 = new Box();
            var box2 = new Box();
            //var invalidMaxCount = box1.MaxCount; //this does not compile as we try to access static field on instance
            var maxCount = Box.MaxCount;
            var elementsCount = box2.GetCurrentCount();
            var maxCountFormatted = Box.FormatMaxCount();

            Console.ReadKey();
        }
    }
}
