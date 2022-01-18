using System;
using System.Collections.Generic;
using System.Text;

namespace Composition_Enum.Entities
{
    class Contract
    {
        public DateTime Date { get; set; }
        public double ValuePerWour { get; set; }
        public int Hours { get; set; }

        public Contract()
        {
        }

        public Contract(DateTime date, double valuePerWour, int hours)
        {
            Date = date;
            ValuePerWour = valuePerWour;
            Hours = hours;
        }

        public double TotalHours()
        {
            return ValuePerWour * Hours;
        }
    }
}
