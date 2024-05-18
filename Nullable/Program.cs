using System;
using System.Collections.Generic;
using System.Linq;

namespace Nullable
{
    class NullableSample
    {
        //this doesnt work because string is already nullable (as reference type)
        Nullable<string> nullableString;

        Nullable<int> nullableInt; //default is null
        int? alsoNullableInt; //shorter syntax
        int nonNullableInt; //default is zero

        public void SomeMethod()
        {
            nullableInt = null; //ok
            nullableInt = 5;
            nonNullableInt = 5;

            if (nullableInt.HasValue) //.HasValue in use (because we use Nullable<int>)
            {
                Console.WriteLine($"Value is {nullableInt.Value}"); //.Value in use (because we use Nullable<int>)
            }
            else
            {
                Console.WriteLine("Value is not present");
            }
        }
    }

    class Person
    {
        public int Height;
        public string Name;

        public Person(string name, int height)
        {
            Name = name;
            Height = height;
        }
    }

    class PersonWithNullableHeight
    {
        public int? Height; //nullable
        public string Name;

        public PersonWithNullableHeight(string name)
        {
            Name = name;
            Height = null; //ok
        }

        public PersonWithNullableHeight(string name, int? height) //HA!
        {
            Name = name;
            Height = height;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var people = new List<Person>
            {
                new Person("Jon", 160),
                new Person("Anna", -1),
                new Person("Monica", 185),
                new Person("Sebastian", -1),
                new Person("Alice", 170),
            };

            Console.WriteLine($"Average height is {people.Average(person => person.Height)}");

            var peopleWithNullableHeight = new List<PersonWithNullableHeight>
            {
                new PersonWithNullableHeight("Jon", 160),
                new PersonWithNullableHeight("Anna"),
                new PersonWithNullableHeight("Monica", null), //HA!
                new PersonWithNullableHeight("Sebastian"),
                new PersonWithNullableHeight("Alice", 170),
            };

            Console.WriteLine($"[NULLABLE] Average height is {peopleWithNullableHeight.Average(person => person.Height)}");

            Console.ReadKey();
        }
    }
}
