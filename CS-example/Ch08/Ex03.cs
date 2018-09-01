using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch08
{
    class Ex03
    {
        public class Employee
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
            List<Employee> employees = new List<Employee>();
            employees.Add(new Employee("kim", 25));
            employees.Add(new Employee("lee", 30));
            employees.Add(new Employee("jung", 21));
            employees.Add(new Employee("nam", 24));
            employees.Add(new Employee("park", 27));
            employees.Add(new Employee("lim", 43));
            employees.Add(new Employee("woo", 37));
            employees.Add(new Employee("kim", 44));
            employees.Add(new Employee("conan", 31));

            var yList = from e in employees where e.age <= 30 orderby e.age ascending select e;
            foreach(var employee in yList)
            {
                Console.WriteLine("young list : name = {0}, age = {1}", employee.name, employee.age);
            }

            



        }
    }
}
