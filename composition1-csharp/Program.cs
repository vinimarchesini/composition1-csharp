using System;
using System.Globalization;
using Composition_Enum.Entities;
using Composition_Enum.Entities.Enums;

namespace Composition_Enum
{
    class Program
    {
        static void Main(string[] args)
        {
            //Let's get all informations we need
            Console.Write("Enter departament's name: ");
            string dep = Console.ReadLine();
            Department departament = new Department(dep);
            Console.WriteLine("Enter Worker Data:");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level(Junior, Midlevel, Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("How Many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());

            //instance the Worker
            Worker worker = new Worker(name, level, baseSalary, departament);

            //For all contracts, read contracts informations and add to worker
            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine("Enter #" + i + " contract data:");
                Console.Write("Date: DD/MM/YYYY ");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per Hour: ");
                double valueperHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration(Hours): ");
                int duration = int.Parse(Console.ReadLine());
                Contract c = new Contract(date, valueperHour, duration);
                worker.AddContract(c);
            }

            //Now, we gonna get the month/year to add the value of contracts in this period (if has):
            Console.Write("Enter month and year to calculate income (mm/yyyy): ");
            string[] vet = Console.ReadLine().Split("/");
            int month = int.Parse(vet[0]);
            int year = int.Parse(vet[1]);
            double income = worker.Income(year, month);

            //Print informations
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Departament: " + worker.Departament);
            Console.WriteLine("Income for " + month + "/" + year + " : R$ " + income);
        }
    }
}
