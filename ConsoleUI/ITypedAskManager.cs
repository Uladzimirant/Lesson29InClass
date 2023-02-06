using System;

// Please note - THIS IS A BAD APPLICATION - DO NOT REPLICATE WHAT IT DOES
// This application was designed to simulate a poorly-built application that
// you need to support. Do not follow any of these practices. This is for 
// demonstration purposes only. You have been warned.
namespace ConsoleUI
{
    public interface ITypedAskManager : IAskManager
    {
        T AskWith<T>(Func<string, T> parser, string askLine = null);
    }
}
