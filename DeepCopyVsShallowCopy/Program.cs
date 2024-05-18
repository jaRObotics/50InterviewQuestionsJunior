using System;

namespace DeepCopyVsShallowCopy
{
    class Pet
    {
        public string Name;
        public int Age;

        public Pet(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }

    class Person
    {
        public string Name; //reference type 
        public int Height; //value type 
        public Pet Pet; //reference type 

        public Person(string name, int height, Pet pet)
        {
            Name = name;
            Height = height;
            Pet = pet;
        }

        public Person ShallowCopy()
        {
            return (Person)MemberwiseClone(); //built-in method of Object class 
            //it just does a shallow copy of a class 
        }

        public Person DeepCopy()
        {
            return new Person(Name, Height, new Pet(Pet.Name, Pet.Age));
        }

        //MemberwiseClone does something like this
        //public object MemberwiseClone()
        //{
        //    return new Person
        //    {
        //        Name = this.Name,
        //        Height = this.Height,
        //        Pet = this.Pet,
        //    };
        //}
    }

    class Program
    {
        static void Main(string[] args)
        {
            //1. SHALLOW COPY
            var john = new Person("John", 175, new Pet("Lucky", 5));
            var johnShallowCopy = john.ShallowCopy();
            //175 value copied, but only address to Pet is copied 
            johnShallowCopy.Pet.Age = 123; //accessed via address - so it changes the original value 5 -> 10 
            //john.Pet.Age = 13; //the same effect as above
            Console.WriteLine($"John's pet age: {john.Pet.Age}");
            Console.WriteLine($"John's shallow copy's pet age: {johnShallowCopy.Pet.Age}\n");

            johnShallowCopy.Height = 1502; //value type
            Console.WriteLine($"John's height: {john.Height}");
            Console.WriteLine($"John's shallow copy's height: {johnShallowCopy.Height}\n");

            //WHY THIS WORKS AS VALUE TYPE (string is a reference type!)
            johnShallowCopy.Name = "jaro"; //value type
            Console.WriteLine($"John's height: {john.Name}");
            Console.WriteLine($"John's shallow copy's height: {johnShallowCopy.Name}\n");

            //2. DEEP COPY
            var mary = new Person("Mary", 165, new Pet("Tiger", 7));
            var maryDeepCopy = mary.DeepCopy();
            maryDeepCopy.Pet.Age = 11; //it's a new value and reference here 
            Console.WriteLine($"Mary's pet age: {mary.Pet.Age}");
            Console.WriteLine($"Mary's shallow copy's pet age: {maryDeepCopy.Pet.Age}\n");

            //3. NOT A COPY (shallow, deep) BUT AN ASSIGNMENT! 
            var person = new Person("Alex", 183, null);
            var person2 = person; //assignment by reference!
            person2.Height = 160;
            Console.WriteLine($"person's height: {person.Height}");
            Console.WriteLine($"person2's height: {person2.Height}\n");

            Console.ReadKey();
        }
    }
}
