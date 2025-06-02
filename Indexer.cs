using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnCSharp
{
    internal class Employee
    {
        public string Name { get; set; }
    }

    internal class EmployeeViewModel
    {
        private readonly List<Employee> _employees;

        public EmployeeViewModel()
        {
            _employees =
            [
                new Employee { Name = "Mayank" },
                new Employee { Name = "Dinesh" },
                new Employee { Name = "Abhishek" },
            ];
        }

        public Employee? this[int index]
        {
            get
            {
                if (index > -1 && index < _employees.Count)
                {
                    return _employees[index];
                }

                return null;
            }
        }
    }
}
