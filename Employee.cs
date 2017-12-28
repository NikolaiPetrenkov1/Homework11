using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw11
{
    public struct Employee
    {
        private int[] _dateStart;
        public string LastName { get; set; }

        public string Name { get; set; }
        public Vacancies Vacancy { get; set; }
        public int Salary { get; set; }
        public int[] DateStart
        {
            get
            {
                return _dateStart;
            }

            set
            {
                _dateStart = new int[3];
                _dateStart = value;
            }
        }
    }
}
