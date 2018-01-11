using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CS_example
{
    public class Ch02
    {
        public void main()
        {
            ArrayList al = new ArrayList();
            al.Add("hello");
            al.Add("world");
            al.Add("!");
            Console.Write("Valuse:");
            printValues(al);
        }

        public void printValues(ArrayList mylist)
        {
            foreach(string text in mylist)
            {
                Console.Write("\t{0}", text);
            }
            Console.WriteLine();
        }
    }

    public class Ch02_Ex02
    {
        public void main()
        {
            int[] arr1 = { 1, 11, 22, 33 };
            int[] arr2 = { 0, 1, 2 };

            for(int i = 0; i < arr1.Length; i++)
            {
                try
                {
                    Console.WriteLine(arr1[i] + "/" + arr2[i] + "=" + arr1[i] / arr2[i]);
                }
                catch (DivideByZeroException)
                {
                    Console.WriteLine("can't divide");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
                
            }
        }
    }

    public class Ch02_Ex03
    {
        public void main()
        {
            int[,] arr = new int[2, 5] { { 1, 2, 3, 4, 5 }, { 6,7,8,9,10 } };
            Console.WriteLine("{0}", arr.GetLength(0));
            Console.WriteLine("{0}", arr.GetLength(1));
        }
    }

    public class Test1
    {
        public void view()
        {
            Console.WriteLine("test1 class's function");
        }
        public void view1()
        {
            Console.WriteLine("test1 class's view1 function");
        }
    }

    public class Test2 : Test1
    {
        public void view()
        {
            Console.WriteLine("test2 class's fuction");
        }
        public void view2()
        {
            Console.WriteLine("test2 class's view2 function");
        }
    }

    public class Ch02_Ex04
    {
        public void main()
        {
            Test2 test2 = new Test2();
            test2.view();
            test2.view1();
            test2.view2();

            Test1 test1 = new Test2();
            test1.view();
            test1.view1();
            //test1.view2();
        }
    }
    
    public class IndexerTest
    {
        private Hashtable favarite = new Hashtable();

        public string this[string key]
        {
            get { return (string)favarite[key]; }
            set { favarite[key] = value; }
        }
    }

    public class Ch02_Ex05
    {
        public void main()
        {
            IndexerTest it = new IndexerTest();

            it["fruit"] = "apple";
            it["color"] = "red";

            Console.WriteLine(it["fruit"]);
            Console.WriteLine(it["color"]);
        }
    }

}
