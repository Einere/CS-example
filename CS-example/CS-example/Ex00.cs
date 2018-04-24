using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;


namespace CS_example
{
    class Ex00
    {
        public void main()
        {
            char val1 = 'a';
            char val2 = '\x0041';
            char val3 = (char)65;
            char val4 = '\u0041';

            Console.WriteLine(val1);
            Console.WriteLine(val2);
            Console.WriteLine(val3);
            Console.WriteLine(val4);
        }
    }

    class Ex01
    {
        public void main()
        {
            int age = 22;
            string str1 = "hello, my age is ";
            string str2 = "인 레후~";

            Console.WriteLine("{0}{1}{2}", str1, age, str2);

        }
    }

    class Ex02
    {
        public void main()
        {
            string str1 = " hello ";
            string str2 = " asp.net ";
            string str3 = " world ";

            string all = str1 + str2 + str3;

            Console.WriteLine("len : {0}", all.Length);
            Console.WriteLine("str : {0}", all);
            Console.WriteLine("trim : {0}", all.Trim());
            Console.WriteLine("not asp : {0}", all.Remove(8, 3));
            Console.WriteLine("net to kor : {0}", all.Replace(".net", "닷넷"));
            Console.WriteLine(".net extract : {0}", all.Substring(11, 4));
            Console.WriteLine("to upper case : {0}", all.ToUpper());
            Console.WriteLine("to lower case : {0}", all.ToLower());
        }
    }

    class Ex03
    {
        public void main()
        {
            ArrayList al = new ArrayList();
            al.Add("hello");
            al.Add("world");
            al.Add("!");
            Console.Write("values : ");
            pv(al);
        }

        public static void pv(ArrayList list)
        {
            foreach (string text in list)
            {
                Console.Write("\t{0}", text);
            }
            Console.WriteLine();
        }
    }

    class Ex04
    {
        public void main()
        {
            String str = null;
            try
            {
                Console.WriteLine(str.ToString());
                Console.WriteLine("program terminated");
            }
            catch (NullReferenceException e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }

    class Ex05
    {
        public void main()
        {
            int[] arr1 = { 1, 11, 22, 33 };
            int[] arr2 = { 0, 1, 2 };
            for (int i = 0; i < arr1.Length; i++)
            {
                try
                {
                    Console.WriteLine(arr1[i] + "/" + arr2[i] + "=" + arr1[i] / arr2[i]);
                }
                catch (DivideByZeroException e)
                {
                    Console.WriteLine("can't divide");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }

    class Ex06
    {
        public void main()
        {
            int[] arr1 = new int[5] { 3, 5, 7, 4, 1 };
            int[] arr2 = (int[])arr1.Clone();
            arr1[0] = 0;
            arr1[1] = 1;
            foreach (int nick in arr2)
            {
                Console.WriteLine("{0}", nick);
            }
        }

        public void main1()
        {
            int[] arr1 = new int[5] { 3, 5, 7, 4, 1 };
            int[] arr2 = new int[5] { 9, 3, 6, 5, 2 };
            int[] arr3 = new int[10];
            arr1.CopyTo(arr3, 0);
            arr2.CopyTo(arr3, 5);
            foreach (int element in arr3)
            {
                Console.WriteLine("{0}", element);
            }
        }

        public void main2()
        {
            int[,] arr = new int[2, 5] { { 3, 5, 7, 4, 1 }, { 4, 5, 7, 8, 9 } };
            Console.WriteLine("{0}", arr.GetLength(0));
            Console.WriteLine("{0}", arr.GetLength(1));
            Console.WriteLine("{0}", arr.Length);
            Console.WriteLine("{0}" + "dimension", arr.Rank);
        }
    }

    interface Iemployee
    {
        string Name
        {
            get;
            set;
        }
        int Counter
        {
            get;
        }
    }
    class Employee : Iemployee
    {
        public static int num_employee;
        private int counter;
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Counter
        {
            get { return counter; }
        }

        public Employee()
        {
            counter += num_employee;
        }
    }
    class Ex07
    {
        public void main()
        {
            Console.Write("enter number of employee : ");
            string s = Console.ReadLine();
            Employee.num_employee = int.Parse(s);

            Employee e1 = new Employee();
            Console.Write("enter name : ");
            e1.Name = Console.ReadLine();

            Console.WriteLine("number : {0}", e1.Counter);
            Console.WriteLine("name : {0}", e1.Name);
        }
    }

    class indexer
    {
        private string[] data = new string[5];
        public string this[int index]
        {
            get { return data[index]; }
            set { data[index] = value; }
        }
    }
    class Ex08
    {
        public void main()
        {
            indexer myIndexer = new indexer();

            myIndexer[0] = "seoul";
            myIndexer[1] = "nowon";
            myIndexer[2] = "kwangwoon";
            myIndexer[3] = "-read 20";
            myIndexer[4] = "kw university";

            Console.WriteLine("{0}, {1}, {2}, {3}, {4}", myIndexer[0], myIndexer[1], myIndexer[2], myIndexer[3], myIndexer[4]);
        }
    }

    class Hw00
    {
        public void main()
        {
            void func(ref int refParam)
            {
                refParam += 10;
            }

            int a = 10;

            func(ref a);

            Console.WriteLine("a = {0}", a);
        }
    }

    class Hw01
    {
        public void main()
        {
            string str = "1234";

            if (Int32.TryParse(str, out int num))
            {
                Console.WriteLine($"str = {str}, num = {num}");
            }
            else
            {
                Console.WriteLine($"parse failed {str}...");
            }
        }
    }

    class Hw02
    {
        delegate double MathAction(double num);

        static double Double(double input)
        {
            return input * 2;
        }

        public void main()
        {
            MathAction ma = Double;

            double multByTwo = ma(4.5);
            Console.WriteLine("multByTwo: {0}", multByTwo);

            MathAction ma2 = delegate (double input)
            {
                return input * input;
            };

            double square = ma2(4);
            Console.WriteLine("square: {0}", square);

            MathAction ma3 = s => s * s * s;
            double cube = ma3(10);

            Console.WriteLine("cube: {0}", cube);
        }
    }

    class Hw03
    {
        delegate void TestDelegate(string s);

        static void M(string s)
        {
            Console.WriteLine(s);
        }

        public void main()
        {
            // initialization with a named method.
            TestDelegate testDelA = new TestDelegate(M);

            // C# 2.0: A delegate can be initialized with inline code, called an "anonymous method." 
            // This method takes a string as an input parameter.
            TestDelegate testDelB = delegate (string s) { Console.WriteLine(s); };

            // C# 3.0. A delegate can be initialized with a lambda expression. 
            // The lambda also takes a string as an input parameter (x). The type of x is inferred by the compiler.
            TestDelegate testDelC = (x) => { Console.WriteLine(x); };

            // Invoke the delegates.
            testDelA("Hello. My name is M and I write lines.");
            testDelB("That's nothing. I'm anonymous and ");
            testDelC("I'm a famous author.");
        }
    }

    class Hw04
    {
        // type parameter T in angle brackets
        public class GenericList<T>
        {
            // The nested class is also generic on T.
            private class Node
            {
                // T used in non-generic constructor.
                public Node(T t)
                {
                    next = null;
                    data = t;
                }

                private Node next;
                public Node Next
                {
                    get { return next; }
                    set { next = value; }
                }

                // T as private member data type.
                private T data;

                // T as return type of property.
                public T Data
                {
                    get { return data; }
                    set { data = value; }
                }
            }

            private Node head;

            // constructor
            public GenericList()
            {
                head = null;
            }

            // T as method parameter type:
            public void AddHead(T t)
            {
                Node n = new Node(t);
                n.Next = head;
                head = n;
            }

            public IEnumerator<T> GetEnumerator()
            {
                Node current = head;

                while (current != null)
                {
                    yield return current.Data;
                    current = current.Next;
                }
            }
        }

        public void main()
        {
            // int is the type argument
            GenericList<int> list = new GenericList<int>();

            for (int x = 0; x < 10; x++)
            {
                list.AddHead(x);
            }

            foreach (int i in list)
            {
                System.Console.Write(i + " ");
            }
            System.Console.WriteLine("\nDone");
        }
    }

    class Hw05
    {
        public void main()
        {
            int? num1 = 10;
            int? num2 = null;
            if (num1 >= num2)
            {
                Console.WriteLine("num1 is greater than or equal to num2");
            }
            else
            {
                // This clause is selected, but num1 is not less than num2.
                Console.WriteLine("num1 >= num2 returned false (but num1 < num2 also is false)");
            }

            if (num1 < num2)
            {
                Console.WriteLine("num1 is less than num2");
            }
            else
            {
                // The else clause is selected again, but num1 is not greater than
                // or equal to num2.
                Console.WriteLine("num1 < num2 returned false (but num1 >= num2 also is false)");
            }

            if (num1 != num2)
            {
                // This comparison is true, num1 and num2 are not equal.
                Console.WriteLine("Finally, num1 != num2 returns true!");
            }

            // Change the value of num1, so that both num1 and num2 are null.
            num1 = null;
            if (num1 == num2)
            {
                // The equality comparison returns true when both operands are null.
                Console.WriteLine("num1 == num2 returns true when the value of each is null");
            }
        }
    }

    class Hw06
    {
        public void main()
        {
            int input = Convert.ToInt32(Console.ReadLine());
            string classify;

            // if-else construction.  
            if (input > 0)
                classify = "positive";
            else
                classify = "negative";

            // ?: conditional operator.  
            classify = (input > 0) ? "positive" : "negative";
        }
    }

    class Hw07
    {
        int? GetNullableInt()
        {
            return null;
        }

        string GetStringValue()
        {
            return null;
        }

        public void main()
        {
            int? x = null;

            // Set y to the value of x if x is NOT null; otherwise,
            // if x == null, set y to -1.
            int y = x ?? -1;

            // Assign i to return value of the method if the method's result
            // is NOT null; otherwise, if the result is null, set i to the
            // default value of int.
            int i = GetNullableInt() ?? default(int);

            string s = GetStringValue();
            // Display the value of s if s is NOT null; otherwise, 
            // display the string "Unspecified".
            Console.WriteLine(s ?? "Unspecified");
        }
    }

    class Hw08
    {
        [Flags]
        enum Days
        {
            None = 0x0,
            Sunday = 0x1,
            Monday = 0x2,
            Tuesday = 0x4,
            Wednesday = 0x8,
            Thursday = 0x10,
            Friday = 0x20,
            Saturday = 0x40
        }

        public void main()
        {

            // Initialize with two flags using bitwise OR.
            Days meetingDays = Days.Tuesday | Days.Thursday;

            // Set an additional flag using bitwise OR.
            meetingDays = meetingDays | Days.Friday;

            Console.WriteLine("Meeting days are {0}", meetingDays);
            // Output: Meeting days are Tuesday, Thursday, Friday

            // Remove a flag using bitwise XOR.
            meetingDays = meetingDays ^ Days.Tuesday;
            Console.WriteLine("Meeting days are {0}", meetingDays);
            // Output: Meeting days are Thursday, Friday

            // Test value of flags using bitwise AND.
            bool test = (meetingDays & Days.Thursday) == Days.Thursday;
            Console.WriteLine("Thursday {0} a meeting day.", test == true ? "is" : "is not");
            // Output: Thursday is a meeting day.


        }
    }

    class Hw09
    {
        public void main()
        {
            /*
            // Example #1: var is optional because
            // the select clause specifies a string
            string[] words = { "apple", "strawberry", "grape", "peach", "banana" };
            var wordQuery = from word in words
                            where word[0] == 'g'
                            select word;

            // Because each element in the sequence is a string, 
            // not an anonymous type, var is optional here also.
            foreach (string s in wordQuery)
            {
                Console.WriteLine(s);
            }

            // Example #2: var is required because
            // the select clause specifies an anonymous type
            var custQuery = from cust in customers
                            where cust.City == "Phoenix"
                            select new { cust.Name, cust.Phone };

            // var must be used because each item 
            // in the sequence is an anonymous type
            foreach (var item in custQuery)
            {
                Console.WriteLine("Name={0}, Phone={1}", item.Name, item.Phone);
            }
            */
        }
    }

    class Hw10
    {
        class Test
        {
            public static void myPrint()
            {
                Console.WriteLine("static method called");
            }
        }

        public void main()
        {
            Test.myPrint();
        }
    }
}
