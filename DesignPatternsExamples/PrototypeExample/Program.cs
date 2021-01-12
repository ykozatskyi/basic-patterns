using System;
using System.Runtime.InteropServices;

namespace PrototypeExample
{
    class Person : ICloneable
    {
        public string Name { get; set; }
        public Company Work { get; set; }

        /// <summary>
        /// Doing a deep copy of this object
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Company company = new Company();
            return new Person
            {
                Name = this.Name,
                Work = company
            };
        }

        //primitives only
        //return this.MemberwiseClone();
    }

    class Company
    {
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Person person1 = new Person()
            {
                Name = "Naruto",
                Work = new Company() { Name = "Konoha" }
            };

            Person person2 = (Person)person1.Clone();

            #region UI
            GCHandle person1GC = GCHandle.Alloc(person1, GCHandleType.Normal);
            var person1PointerObject = GCHandle.ToIntPtr(person1GC).ToInt64();
            Console.WriteLine($"Object {nameof(person1)} has address \t{person1PointerObject}");
            GCHandle person2GC = GCHandle.Alloc(person2, GCHandleType.Normal);
            var person2PointerObject = GCHandle.ToIntPtr(person2GC).ToInt64();
            Console.WriteLine($"Object {nameof(person2)} has address \t{person2PointerObject}");
            #endregion
        }
    }
}
