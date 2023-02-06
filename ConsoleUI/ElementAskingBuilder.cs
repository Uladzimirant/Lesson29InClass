using System;
using System.Collections.Generic;

// Please note - THIS IS A BAD APPLICATION - DO NOT REPLICATE WHAT IT DOES
// This application was designed to simulate a poorly-built application that
// you need to support. Do not follow any of these practices. This is for 
// demonstration purposes only. You have been warned.
namespace ConsoleUI
{
    public class ElementAskingBuilder<T>
    {
        private List<T> _elements;
        private ITypedAskManager _askM;
        private Func<ITypedAskManager, T> _buildFunction;

        public ElementAskingBuilder(ITypedAskManager askM, Func<ITypedAskManager, T> buildFunction)
        {
            _askM = askM;
            _buildFunction = buildFunction;
            _elements = new List<T>();
        }

        public bool AskForElement()
        {
            _elements.Add(_buildFunction(_askM));
            return _askM.AskWith(e => e.ToLower() == "yes", "Do you want to enter more time (yes/no): ");
        }

        public List<T> GetElements()
        {
            var temp = _elements;
            _elements = new List<T>();
            return temp;
        }
    }
}
