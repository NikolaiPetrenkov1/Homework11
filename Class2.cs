using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw11
{
    public class PeopleComparer : IComparer<Employee>
    {
        public int Compare(Employee emp1, Employee emp2)
        {
            return String.Compare(emp1.LastName, emp2.LastName);

        }
    }
}
