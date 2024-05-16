using System;
using System.Collections.Generic;

namespace NewKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            //Pet class doesn't have parameterless constructor
            //var lazyPet = new NewConstraint.LazyInitializer<Pet>(); //so this does not work! 

            var lazyList = new NewConstraint.LazyInitializer<List<int>>(); //this does work - List has a parameterless ctor!

            Console.ReadKey();
        }
    }

    class NewConstraint
    {
        //without this constraint, the "new T()" below would not work
        public class LazyInitializer<T> where T: new() //this is constraint - we ensure by so that any type we use as T will have a parameterless ctor
            //it only constructs the object it holds when it is accessed for the first time 
        {
            private T value;

            public T Get()
            {
                if(value == null)
                {
                    //we try to use parameterless ctor while calling new T()
                    //but we don't know the type yet - it's generic 
                    //so it can have no parameterless ctor!
                    value = new T(); //this now can work 
                }
                return value;
            }
        }
    }

    class Pet
    {
        string Name;

        public Pet(string name)
        {
            Name = name;
        }
    }
}
