using System;

// Please note - THIS IS A BAD APPLICATION - DO NOT REPLICATE WHAT IT DOES
// This application was designed to simulate a poorly-built application that
// you need to support. Do not follow any of these practices. This is for 
// demonstration purposes only. You have been warned.
namespace ConsoleUI
{
    class ConsoleAskManager : ITypedAskManager
    {
        private ConsoleAskManager() { }
        private static ConsoleAskManager _instance = null;
        public static ConsoleAskManager Instance { get
            {
                if (_instance == null) { _instance = new ConsoleAskManager(); }
                return _instance;
            } }

        public string Ask(string askLine = null)
        {
            if (askLine != null) Console.WriteLine(askLine);
            return Console.ReadLine();
        }

        public T AskWith<T>(Func<string, T> parser, string askLine = null)
        {
            while (true)
            {
                try
                {
                    return parser(Ask(askLine));
                } catch(FormatException e)
                {
                    Console.WriteLine(e.ToString());
                } catch (ArgumentNullException e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}
