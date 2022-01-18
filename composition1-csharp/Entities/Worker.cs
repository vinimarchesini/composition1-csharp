using System;
using System.Collections.Generic;
using System.Text;
using Composition_Enum.Entities.Enums;

namespace Composition_Enum.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Departament { get; set; }
        public List<Contract> Contracts { get; private set; } = new List<Contract>();

        public Worker()
        {
        }

        public Worker(string name, WorkerLevel level, double baseSalary, Department departament)
        {
            Name = name;
            Level = level;
            BaseSalary = baseSalary;
            Departament = departament;
        }

        public void AddContract(Contract contract)
        {
            Contracts.Add(contract);
        }

        public void RemoveContract(Contract contract)
        {
            Contracts.Remove(contract);
        }

        public double Income(int year, int month)
        {
            double sum = BaseSalary;
            foreach (Contract s in Contracts)
            {
                if (s.Date.Year == year && s.Date.Month == month)
                {
                    sum += s.TotalHours();
                }
            }
            return sum;
        }
    }

}
