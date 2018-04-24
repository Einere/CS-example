using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace CS_example
{
    class Ch07
    {
        public void main()
        {
            List<string> salmons = new List<string>();
            salmons.Add("chinook");
            salmons.Add("coho");
            salmons.Add("pink");
            salmons.Add("sockeye");

            foreach(string salmon in salmons)
            {
                Console.WriteLine(salmon + ", ");
            }
        }
    }
    
    class Ch07_Ex02
    {
        public void main()
        {
            ArrayList myAL = new ArrayList();
            myAL.Add("hello");
            myAL.Add("world");
            myAL.Add("!");

            Console.WriteLine("count = {0}", myAL.Count);
            Console.WriteLine("capacity = {0}", myAL.Capacity);
            Console.Write("values : ");
            printValues(myAL);
        }

        public static void printValues(IEnumerable myList)
        {
            foreach(Object obj in myList)
            {
                Console.Write("{0}", obj);
            }
        }
    }


    class Ch07_Ex03
    {
        public class Person
        {
            public string firstName;
            public string lastName;

            public Person(string fName, string lName)
            {
                this.firstName = fName;
                this.lastName = lName;
            }
        }

        public class People : IEnumerable
        {
            private Person[] _people;

            public People(Person[] pArray)
            {
                _people = new Person[pArray.Length];

                for (int i = 0; i < pArray.Length; i++)
                {
                    _people[i] = pArray[i];
                }
            }

            public IEnumerator GetEnumerator()
            {
                return new PeopleEnum(_people);
            }
        }

        public class PeopleEnum : IEnumerator
        {
            public Person[] _people;
            int position = -1;

            public PeopleEnum(Person[] list)
            {
                _people = list;
            }

            public bool MoveNext()
            {
                position++;
                return (position < _people.Length);
            }

            public void Reset()
            {
                position = -1;
            }

            public object Current
            {
                get
                {
                    try
                    {
                        return _people[position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }

        public void main()
        {
            Person[] pa = new Person[3]
            {
                new Person("john", "smith"),
                new Person("jim", "johnson"),
                new Person("sue", "rabon")
            };

            People pl = new People(pa);
            foreach (Person p in pl) Console.WriteLine(p.firstName + " " + p.lastName);

        }
    }
    
}
