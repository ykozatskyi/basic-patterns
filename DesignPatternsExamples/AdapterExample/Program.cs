using System;

namespace AdapterExample
{
    class Program
    {
        /// <summary>
        /// Entry point
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //working with interface
            ISomeClass someClass = new SomeClassAdapter();
            someClass.DoWork(new char[] { 'H', 'e', 'l', 'l', 'o' });
        }
    }

    /// <summary>
    /// Class which is closed for modifications 
    /// or class which is coming from .dll
    /// has no interface
    /// </summary>
    class SomeClass
    {
        /// <summary>
        /// Doing some specififc work
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public object DoSomeWork(string input)
        {
            Console.WriteLine($"Json input: {input}");
            return default;
        }
    }

    /// <summary>
    /// Common interface
    /// </summary>
    interface ISomeClass
    {
        object DoWork(char[] input);
    }

    /// <summary>
    /// SomeClass adapter without changing code inside SomeClass
    /// </summary>
    class SomeClassAdapter : SomeClass, ISomeClass
    {
        public object DoWork(char[] input)
        {
            //adapting things
            var validInput = new string(input);
            return DoSomeWork(validInput);
        }
    }
}
