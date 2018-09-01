using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch08
{
    class Ex01
    {
        public class Person
        {
            public string name;
            public int age;

            public Person(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
        }

        public class People : IEnumerable
        {
            private Person[] _people;

            public People(Person[] pArr)
            {
                _people = new Person[pArr.Length];

                for (int i = 0; i < pArr.Length; i++) _people[i] = pArr[i];
            }

            public IEnumerator GetEnumerator()
            {
                return new PeopleEnum(_people);
            }
        }

        public class PeopleEnum : IEnumerator
        {
            public Person[] _people;
            private int position = -1;

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
            Person[] peopleArr = new Person[3]
            {
                new Person("kim", 20),
                new Person("lee", 22),
                new Person("park", 24)
            };

            People peopleList = new People(peopleArr);
            foreach(Person person in peopleList)
            {
                Console.WriteLine(person.name + ", " + person.age);
            }

            
        }
       
    }
}
