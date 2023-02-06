using System.Collections.Generic;


namespace ConsoleUI
{
    public class TaskManager<TPassingObject> : List<ITask<TPassingObject>>
    {
        public TPassingObject ObjectToPass { get; set; }

        public TaskManager()
        {
        }

        public TaskManager(int capacity) : base(capacity)
        {
        }

        public TaskManager(IEnumerable<ITask<TPassingObject>> collection) : base(collection)
        {
        }

        public void RunAll()
        {
            this.ForEach(e => e.Run(ObjectToPass));
        }
    }
}
