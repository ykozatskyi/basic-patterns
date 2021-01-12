using Common;
using System;

namespace AbstractFactoryExample
{
    abstract class Smartphone { }
    abstract class Watch { }

    class IPhone : Smartphone { }
    class AppleWatch : Watch { }

    class Galaxy : Smartphone { }
    class GalaxyWatch : Watch { }

    interface IBaseFactory
    {
        Smartphone CreateSmartphone();
        Watch CreateWatch();
    }

    class AppleFactory : IBaseFactory
    {
        public Smartphone CreateSmartphone() => new IPhone();
        public Watch CreateWatch() => new AppleWatch();
    }

    class SamsungFactory : IBaseFactory
    {
        public Smartphone CreateSmartphone() => new Galaxy();
        public Watch CreateWatch() => new GalaxyWatch();
    }

    class Program
    {
        /// <summary>
        /// working with interface, client didn't know anything about a factory type 
        /// </summary>
        private static IBaseFactory _baseFactory;

        static void Main(string[] args)
        {
            if (args.IsNullOrEmpty())
                return;

            Initialize(args[0]);

            var smartphone = _baseFactory.CreateSmartphone();
            var watch = _baseFactory.CreateWatch();

            Console.WriteLine($"{_baseFactory.GetType()} was initialized");
            Console.WriteLine($"1 {smartphone.GetType()} was produced");
            Console.WriteLine($"1 {watch.GetType()} was produced");
        }

        private static void Initialize(string factoryName)
        {
            switch (factoryName)
            {
                case "apple":
                    _baseFactory = new AppleFactory();
                    break;
                case "samsung":
                    _baseFactory = new SamsungFactory();
                    break;
                default:
                    throw new Exception();
            }
        }
    }
}
