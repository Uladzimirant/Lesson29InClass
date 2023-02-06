using System.Collections.Generic;


namespace ConsoleUI
{
    public static class TaskFactory
    {
        public static TaskManager<List<TimeSheetEntry>> GetDefaultTasks() => new TaskManager<List<TimeSheetEntry>>()
            {
                new WorkTask("Simulating Sending email to Acme", totalHours => totalHours * 150, e => e.WorkDone.ToLower().Contains("acme")),
                new WorkTask("Simulating Sending email to Abc", totalHours => totalHours * 125, e => e.WorkDone.ToLower().Contains("abc")),
                new WorkTask("Simulating Sending email to self", totalHours => {
                if (totalHours > 40)
                {
                    return (((totalHours - 40) * 15) + (40 * 10));
                }
                else
                {
                    return totalHours * 10;
                }
                })
            };

    }
}
