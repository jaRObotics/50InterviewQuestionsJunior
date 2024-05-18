namespace LINQ
{
    public class Person
    {
        public string Name;
        public string LastName;
        public int YearOfBirth;

        public Person(string name, string lastName, int yearOfBirth)
        {
            Name = name;
            LastName = lastName;
            YearOfBirth = yearOfBirth;
        }

        public override string ToString() //check on this - learn it!!!
        {
            return $"{Name} {LastName} born in {YearOfBirth}";
        }
    }
}
