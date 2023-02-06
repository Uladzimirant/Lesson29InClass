namespace ConsoleUI
{
    public interface ITask<T>
    {
        void Run(T toPass);
    }
}
