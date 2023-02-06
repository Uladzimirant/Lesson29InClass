using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ElementAskingBuilder<TimeSheetEntry>(ConsoleAskManager.Instance, asker =>
                new TimeSheetEntry(asker.Ask("Enter what you did: "), asker.AskWith(double.Parse, "How long did you do it for: "))
            );
            while (builder.AskForElement()) { }
            var ents = builder.GetElements();

            var tasks = TaskFactory.GetDefaultTasks();
            tasks.ObjectToPass = ents;
            tasks.RunAll();

            Console.WriteLine();
            Console.Write("Press any key to exit application...");
            Console.ReadKey();
        }
    }
}
