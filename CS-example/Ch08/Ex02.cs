using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch08
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    class HistoryAttribute : Attribute
    {
        private string programmer;
        public double version;
        public string changes;

        public HistoryAttribute(string programmer)
        {
            this.programmer = programmer;
            this.version = 1.0;
            this.changes = "first release";
        }

        public string getProgrammer()
        {
            return this.programmer;
        }
    }
    [History("kim", version = 0.1, changes = "2018-06-07 Create class")]
    [History("lee", version = 0.2, changes = "2018-06-08 Add Func()")]
    class TargetClass
    {
        public void Func()
        {
            Console.WriteLine("Func() called");
        }
    }

    class Ex02
    {
        public void main()
        {
            Type type = typeof(TargetClass);
            Attribute[] atts = Attribute.GetCustomAttributes(type);
            Console.WriteLine("Target Class Change History");

            foreach (Attribute att in atts)
            {
                HistoryAttribute h = att as HistoryAttribute;
                if (h != null)
                {
                    Console.WriteLine("programmner : {0}, version : {1}, change : {2}", h.version, h.version, h.changes);
                }
            }

        }
    }
}
