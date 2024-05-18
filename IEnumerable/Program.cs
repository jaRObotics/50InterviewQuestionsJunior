using System;
using System.Collections;
using System.Linq;

namespace IEnumerable
{
    class CustomCollection //this does not use IEnumerable interface 
    {
        public string[] Words { get; }

        public CustomCollection(string[] words)
        {
            Words = words;
        }
    }

    class WordsCollection : System.Collections.IEnumerable //our own implementation 
    {
        private string[] _words;

        public WordsCollection(string[] words)
        {
            _words = words;
        }

        public IEnumerator GetEnumerator()
        {
            return new WordsEnumerator(_words);
        }
    }

    class WordsEnumerator : IEnumerator
    {
        private string[] _words;
        private int _position = -1;

        public WordsEnumerator(string[] words)
        {
            _words = words;
        }

        public object Current
        {
            get
            {
                try
                {
                    return _words[_position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException("Collection end reached");
                }
            }
        }

        public bool MoveNext()
        {
            _position++;
            return _position < _words.Length;
        }

        public void Reset()
        {
            _position = -1;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var words = new[] { "a", "little", "duck" };

            foreach (var word in words)
            {
                Console.WriteLine(word);
            }

            //this doesn't work because CustomCollection does not implement IEnumerable
            var customCollection = new CustomCollection(words);
            foreach (var word in customCollection)
            {
                Console.WriteLine(word);
            }

            //foreach is translated by the compilator to the below (under the hood):
            IEnumerator wordsEnumerator = words.GetEnumerator();
            string currentWord;
            while (wordsEnumerator.MoveNext())
            {
                currentWord = (string)wordsEnumerator.Current;
                Console.WriteLine(currentWord);
            }


            // WordsCollection implements IEnumerable
            Console.WriteLine("\nCustom WordsCollection implementing IEnumerable:");
            var wordsCollection = new WordsCollection(words);
            foreach (var word in wordsCollection)
            {
                Console.WriteLine(word);
            }

            Console.ReadKey();
        }
    }
}
