using System;
using System.Collections.Generic;

namespace NullOperators
{
    //1. coalescing operator (??)
    //2. coalescing assignment operator (??=)
    //3. conditional operator {?.)


    class Greeter
    {
        public static string Greet(string name)
        {
            //1. coalescing operator way;
            return $"Hello, {name ?? "Stranger"}!"; //!null ?? null 
        }
    }

    static class ListExtensions
    {
        //3. 
        public static int GetAtIndex(this List<int?> numbers, int index) //"this" added for Extension purposes
                                                                         //why List<int?> ?
        {
            return numbers?[index] ??
                throw new ArgumentException($"Index {index} not found " +
                $"in the list or value is null.");
        }

        //3. 
        public static void ClearIfNotNull(this List<int?> numbers)
        {
            numbers?.Clear();
        }
    }

    class Program
    {
        //2. the common way: 
        private static List<int> _numbers; //NOTE: this is not initialized! 
        //private static List<int> _numbers2 = new List<int>();

        static void AddNumbers(int number)
        {
            if(_numbers == null)
            {
                _numbers = new List<int>();
            }
            _numbers.Add(number);
        }

        //3. common way:
        static void ClearIfNotNullCommon(List<int> numbers)
        {
            numbers.Clear(); //this will throw error if list already null
            numbers?.Clear(); //this will only be called when the *? parameter is not null 
        }

        //3. common way:
        static int GetAtIndexCommon(List<int?> numbers, int index)
        {
            if(numbers != null) //if numbers is not null
            { 
                if (numbers[index] != null) //if numbers at the given index is not null
                {
                    return numbers[index].Value;
                }
            }
            throw new ArgumentException(
                @$"Wrong index: {index} or the \list \is \null");
        }

        static void Main(string[] args)
        {
            //1. 
            Greeter.Greet(null);
            Greeter.Greet("jaro");

            //2. 
            (_numbers ??= new List<int>()).Add(5); //note the breackets here!
            //if null -> (_number = new List<int>()).Add(5)
            //if !null -> _number.Add(5)

            //3. 
            ClearIfNotNullCommon(null);
            ClearIfNotNullCommon(_numbers);





        }
    }
}

