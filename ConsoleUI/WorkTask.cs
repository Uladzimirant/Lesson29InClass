using System;
using System.Collections.Generic;


namespace ConsoleUI
{
    public class WorkTask : ITask<List<TimeSheetEntry>>
    {
        private readonly Func<double, double> _billRate;
        private readonly Predicate<TimeSheetEntry> _condition;
        public string Description { get; }

        public WorkTask(string description, Func<double, double> billRate, Predicate<TimeSheetEntry> condition = null)
        {
            _billRate = billRate;
            _condition = condition ?? (e => true);
            Description = description;
        }

        public double GetTotalHours(List<TimeSheetEntry> ents)
        {
            return GetTotalHoursByCondition(ents, e => true);
        }
        public double GetTotalHoursByCondition(List<TimeSheetEntry> ents, Predicate<TimeSheetEntry> condition)
        {
            double totalHours = 0;
            foreach (var ent in ents)
            {
                if (condition(ent))
                {
                    totalHours += ent.HoursWorked;
                }
            }
            return totalHours;
        }

        public void Run(List<TimeSheetEntry> ents)
        {
            double totalHours = GetTotalHoursByCondition(ents, _condition);
            Console.WriteLine(Description);
            Console.WriteLine("Your bill is $" + _billRate(totalHours) + " for the hours worked.");
        }
    }
}
