using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hw11
{
    class Program
    {
        static void Main(string[] args)
        {
            int num;

            while (true)
            {
                Console.Write("Введите кол-во сотрудников: ");
                bool f = int.TryParse(Console.ReadLine(), out num);

                if (f)
                    break;
                else
                    Console.WriteLine("Error");
            }

            Employee[] emp = new Employee[num];

            for (int i = 0; i < num; i++)
            {
                Console.Write("Введите имя сотрудника: ");
                emp[i].Name = Console.ReadLine();

                Console.Write("Введите фамилию сотрудника: ");
                emp[i].LastName = Console.ReadLine();

                Console.Write("Введите вакансию сотрудника (Manager, Boss, Clerk, Salesman): ");
                emp[i].Vacancy = (Vacancies)Enum.Parse(typeof(Vacancies), Console.ReadLine());

                Console.Write("Введите зарплату сотрудника: ");
                emp[i].Salary = int.Parse(Console.ReadLine());

                int[] arr = new int[3];
                Console.Write("Введите число месяца начала работы: ");
                arr[0] = int.Parse(Console.ReadLine());
                Console.Write("Введите номер месяца начала работы: ");
                arr[1] = int.Parse(Console.ReadLine());
                Console.Write("Введите год начала работы: ");
                arr[2] = int.Parse(Console.ReadLine());
                emp[i].DateStart = arr;
            }
            Console.WriteLine();
            Console.WriteLine();

            
            Array.Sort(emp, new PeopleComparer());

            
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Имя сотрудника {0}: {1}", i + 1, emp[i].Name);
                Console.WriteLine("Фамилия сотрудника {0}: {1}", i + 1, emp[i].LastName);
                Console.WriteLine("Вакансия сотрудника {0}: {1}", i + 1, emp[i].Vacancy);
                Console.WriteLine("Зарплата сотрудника {0}: {1}", i + 1, emp[i].Salary);
                Console.WriteLine("Дата начала работы сотрудника {0}: {1}.{2}.{3}", i + 1, emp[i].DateStart[0], emp[i].DateStart[1], emp[i].DateStart[2]);
            }

           
            int sum = 0;
            int count = 0;
            for (int i = 0; i < num; i++)
            {
                if (emp[i].Vacancy == Vacancies.Clerk)
                {
                    sum = sum + emp[i].Salary;
                    count++;
                }
            }
            int averageSalaryClerk = sum / count;

            for (int i = 0; i < num; i++)
            {
                if (emp[i].Vacancy == Vacancies.Manager && emp[i].Salary > averageSalaryClerk)
                {
                    Console.WriteLine("Имя сотрудника {0}: {1}", i + 1, emp[i].Name);
                    Console.WriteLine("Фамилия сотрудника {0}: {1}", i + 1, emp[i].LastName);
                    Console.WriteLine("Вакансия сотрудника {0}: {1}", i + 1, emp[i].Vacancy);
                    Console.WriteLine("Зарплата сотрудника {0}: {1}", i + 1, emp[i].Salary);
                    Console.WriteLine("Дата начала работы сотрудника {0}: {1}.{2}.{3}", i + 1, emp[i].DateStart[0], emp[i].DateStart[1], emp[i].DateStart[2]);
                }
            }

            
            int indexBoss = 0;
            for (int i = 0; i < num; i++)
            {
                if (emp[i].Vacancy == Vacancies.Boss)
                {
                    indexBoss = i;
                    break;
                }
            }

            for (int i = 0; i < num; i++)
            {
                
                if ((emp[i].DateStart[2] < emp[indexBoss].DateStart[2]) || ((emp[i].DateStart[2] == emp[indexBoss].DateStart[2]) && (emp[i].DateStart[1] < emp[indexBoss].DateStart[1])) || ((emp[i].DateStart[2] == emp[indexBoss].DateStart[2]) && (emp[i].DateStart[1] == emp[indexBoss].DateStart[1]) && (emp[i].DateStart[0] < emp[indexBoss].DateStart[0])))
                {
                    Console.WriteLine("Имя сотрудника {0}: {1}", i + 1, emp[i].Name);
                    Console.WriteLine("Фамилия сотрудника {0}: {1}", i + 1, emp[i].LastName);
                    Console.WriteLine("Вакансия сотрудника {0}: {1}", i + 1, emp[i].Vacancy);
                    Console.WriteLine("Зарплата сотрудника {0}: {1}", i + 1, emp[i].Salary);
                    Console.WriteLine("Дата начала работы сотрудника {0}: {1}.{2}.{3}", i + 1, emp[i].DateStart[0], emp[i].DateStart[1], emp[i].DateStart[2]);
                }
            }
        }
    }
}
