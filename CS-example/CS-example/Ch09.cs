using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace CS_example
{
    class Ch09
    {
        public void main()
        {
            int a = 0;
            Type type = a.GetType();

            PrintInterface(type);
            PrintField(type);
            PrintMethod(type);
            PrintProperty(type);
        }

        public void PrintInterface(Type type)
        {
            Console.WriteLine("-------------------- interface --------------------");
            Type[] interfaces = type.GetInterfaces();
            
            foreach(Type i in interfaces)
            {
                Console.WriteLine("name : {0}", i.Name);
            }
            Console.WriteLine();
        }

        public void PrintField(Type type)
        {
            Console.WriteLine("-------------------- field --------------------");
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);

            foreach(FieldInfo i in fields)
            {
                String accessLevel = "protected";
                if (i.IsPublic) accessLevel = "public";
                else if (i.IsPrivate) accessLevel = "private";

                Console.WriteLine("access level : {0}, type : {1}, name : {2}", accessLevel, i.FieldType.Name, i.Name);
            }
            Console.WriteLine();
        }

        public void PrintMethod(Type type)
        {
            Console.WriteLine("-------------------- method --------------------");
            MethodInfo[] methods = type.GetMethods();

            foreach(MethodInfo i in methods)
            {
                Console.Write("return type : {0}, name : {1}, input parameter : ", i.ReturnType.Name, i.Name);
                ParameterInfo[] args = i.GetParameters();

                for (int j = 0; j < args.Length; j++)
                {
                    Console.Write("{0}", args[j].ParameterType.Name);
                    if (j < args.Length - 1) Console.Write(", ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void PrintProperty(Type type)
        {
            Console.WriteLine("-------------------- property --------------------");
            PropertyInfo[] properties = type.GetProperties();

            foreach(PropertyInfo i in properties)
            {
                Console.WriteLine("type : {0}, name {1}", i.PropertyType.Name, i.Name);
            }
            Console.WriteLine();

        }
    }

    class Profile
    {
        public string Name { get; set; }
        public string Phone { get; set; }

        public void Print()
        {
            Console.WriteLine("{0}, {1}", Name, Phone);
        }
    }

    class Ch09_Ex02
    {
        public void main()
        {
            Type type = typeof(Profile);
            Object obj = Activator.CreateInstance(type);

            PropertyInfo name = type.GetProperty("Name");
            PropertyInfo phone = type.GetProperty("Phone");

            name.SetValue(obj, "jake", null);
            phone.SetValue(obj, "000-0000", null);

            Console.WriteLine("{0}, {1}", name.GetValue(obj, null), phone.GetValue(obj, null));


            Profile profile = (Profile)Activator.CreateInstance(type);

            profile.Name = "finn";
            profile.Phone = "123-4567";

            MethodInfo met = type.GetMethod("Print");
            met.Invoke(profile, null);
        }
    }

    class Ch09_Ex03
    {
        class Employee
        {
            public string name;
            public int age;

            public Employee(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
        }

        public void main()
        {
            List<Employee> eList = new List<Employee>();

            eList.Add(new Employee("kim", 25));
            eList.Add(new Employee("lee", 30));
            eList.Add(new Employee("jung", 21));
            eList.Add(new Employee("nam", 24));
            eList.Add(new Employee("park", 27));
            eList.Add(new Employee("lim", 43));
            eList.Add(new Employee("woo", 37));
            eList.Add(new Employee("kim", 44));
            eList.Add(new Employee("conan", 31));

            /*
            List<Employee> young = new List<Employee>();
            foreach(Employee e in eList)
            {
                if (e.age <= 30) young.Add(e);
            }
            */

            var young = from e in eList where e.age <= 30 select e;

            foreach(Employee e in young)
            {
                Console.WriteLine("name : {0}, age : {1}", e.name, e.age);
            }
        }
    }

    class Ch09_Ex04
    {
        public void main()
        {
            string[] words = { "aPPle", "BlUeBeRry", "cHERry" };

            var trans = from w in words select new { Upper = w.ToUpper(), Lower = w.ToLower() };

            foreach (var ul in trans) Console.WriteLine("ul : {0}, upper : {1}, lower : {2}", ul.ToString(), ul.Upper, ul.Lower);
        }
    }

    class Ch09_Ex05
    {
        internal class Student
        {
            public string First { get; set; }
            public string Last { get; set; }
            public int ID { get; set; }
            public List<int> Scores;
        }

        public static List<Student> GetStudents()
        {
            List<Student> students = new List<Student> {
                new Student { First = "Svet", Last = "Omel", ID=111, Scores = new List<int> {97,72, 81, 60 } },
                new Student { First = "Claire", Last = "O'donel", ID=112, Scores = new List<int> {75, 84, 91, 39 } },
                new Student { First = "Sven", Last = "Mort", ID=113, Scores = new List<int>{99, 89, 91, 95 } }
            };

            return students;
        }

        public void main()
        {
            List<Student> students = GetStudents();

            var q = from student in students group student by student.Scores.Average() >= 80;
            //var q = from student in students where student.Scores.Average() >= 80 select student;

            foreach(var group in q)
            {
                Console.WriteLine(group.Key == true ? "high" : "low");
                //Console.WriteLine(group.ToString());
                foreach(var student in group)
                {
                    Console.WriteLine("{0}, {1} : {2}", student.Last, student.First, student.Scores.Average());
                    //Console.WriteLine(student.ToString());
                }
            }
        }
        
    }

    class Ch09_Ex06
    {
        class Person
        {
            public string First { get; set; }
            public string Last { get; set; }
        }

        class Pet
        {
            public string Name { get; set; }
            public Person Owner { get; set; }
        }

        public void main()
        {
            Person magnus = new Person { First = "magnus", Last = "hed" };
            Person terry = new Person { First = "terry", Last = "adam" };
            Person rui = new Person { First = "rui", Last = "rapo" };

            Pet bar = new Pet { Name = "bar", Owner = terry };
            Pet blue = new Pet { Name = "blue", Owner = rui };
            Pet dai = new Pet { Name = "dai", Owner = magnus };

            List<Person> people = new List<Person> { magnus, terry, rui };
            List<Pet> pets = new List<Pet> { bar, blue, dai };

            var quary = from person in people join pet in pets on person equals pet.Owner select new { OwnerName = person.First, petName = pet.Name };

            foreach(var set in quary)
            {
                Console.WriteLine("{0} is owned by {1}", set.petName, set.OwnerName);
            }
        }
    }

    class Ch09_Ex07
    {
        public void main()
        {
            DataSet1 dataset = new DataSet1();
            dataset.Tables["Person"].Rows.Add(new object[] { 1, "kim", 30 });
            dataset.Tables["Person"].Rows.Add(new object[] { 2, "kong", 35 });
            dataset.Tables["Person"].Rows.Add(new object[] { 3, "park", 20 });
            dataset.Tables["Person"].Rows.Add(new object[] { 4, "lee", 22 });

            

        }
    }
}
