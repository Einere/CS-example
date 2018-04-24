using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS_example
{
    class Ch01
    {
        static void Main(string[] args)
        {

            //char var1 = 'A';
            //char var2 = '\x0041';
            //char var3 = (char)65;
            //char var4 = '\u0041';

            //Console.WriteLine("문자 표현 : {0}", var1);
            //Console.WriteLine("hexa : {0}", var2);
            //Console.WriteLine("ascii : {0}", var3);
            //Console.WriteLine("unicode : {0}", var4);

            Ch06 tmp = new Ch06();
            tmp.main();
        }
    }

    class Ch01_Ex02
    {
        public void main()
        {
            int age = 22;
            string str1 = "hello, my age is ";
            string str2 = ", thank you.";

            Console.WriteLine("{0}{1}{2}", str1, age, str2);
        }
    }

    class Ch01_Ex03
    {
        public void main()
        {
            int n1 = 2, n2 = 7;
            Console.WriteLine("n1 = {0}, n2 = {1}", n1, n2);
            Console.WriteLine("n1 + n2 = {0}", n1 + n2);
            Console.WriteLine("n1 - n2 = {0}", n1 - n2);
            Console.WriteLine("n1 * n2 = {0}", n1 * n2);
            Console.WriteLine("n1 / n2 = {0}", n1 / n2);
            Console.WriteLine("n1 % n2 = {0}", n1 % n2);
        }
    }

    class Ch01_Ex04
    {
        public void main()
        {
            int n1 = 10;
            int n2 = 20;
            int max = 0;

            max = n1 > n2 ? n1 : n2;

            Console.WriteLine("n1 = {0}, n2 ={1}", n1, n2);
            Console.WriteLine("max is {0}", max);
        }
    }

    class Ch01_Ex05
    {
        public void main()
        {
            string str1 = " Hello ";
            string str2 = " ASP.NET ";
            string str3 = " Wrold ";

            string all = str1 + str2 + str3;

            Console.WriteLine("all length = {0}.", all.Length);
            Console.WriteLine("all = {0}.", all);
            Console.WriteLine("remove space = {0}.", all.Trim());
            Console.WriteLine("remove ASP = {0}", all.Remove(8, 3));
            Console.WriteLine(".NET -> 닷넷  = {0}", all.Replace(".NET", "닷넷"));
            Console.WriteLine(".NET extraction = {0}", all.Substring(11, 4));
            Console.WriteLine("to upper = {0}", all.ToUpper());
            Console.WriteLine("to lower = {0}", all.ToLower());
        }
    }

    class Ch01_Ex06
    {
        public void main()
        {
            string name;
            Console.Write("what's your name? : ");
            name = Console.ReadLine();

            Console.WriteLine("Hello, {0}!", name);
        }
    }

    class Ch01_Ex07
    {
        class Student
        {
            public int number;
            public int score;

            public Student(int number, int score)
            {
                this.number = number;
                this.score = score;
            }
        }
        public void main()
        {
            int total = 0;
            double average = 0;
            Array record = Array.CreateInstance(typeof(Student), 5);

            Console.WriteLine("insert 1 to 5 scores.");

            for(int i = 0; i < 5; i++)
            {
                string tmp_score = Console.ReadLine();
                record.SetValue(new Student(i + 1, Convert.ToInt32(tmp_score)), i);
                total += ((Student)record.GetValue(i)).score;
            }

            Console.WriteLine("scores 1 to 5");

            for(int i = 0; i < record.Length; i++)
            {
                int score = ((Student)record.GetValue(i)).score;
                string grade = "F";

                switch (score / 10)
                {
                    case 10:
                    case 9: grade = "A"; break;
                    case 8: grade = "B"; break;
                    case 7: grade = "C"; break;
                    case 6: grade = "D"; break;
                    default: grade = "F"; break;
                }
                Console.WriteLine("{0} student score : {1}, grade : {2}.", i + 1, score, grade);
            }

            average = (double)total / record.Length;
            Console.WriteLine("all : {0}, average : {1}", total, average);
        }
    }
}
