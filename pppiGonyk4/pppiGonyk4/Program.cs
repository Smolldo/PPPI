using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace pppiGonyk4
{
    public class Person
    {
        private string name;
        private int age;
        public string occupation;
        protected string address;
        public bool isEmployed;

        public Person(string name, int age, string occupation, string address, bool isEmployed)
        {
            this.name = name;
            this.age = age;
            this.occupation = occupation;
            this.address = address;
            this.isEmployed = isEmployed;
        }

        public void Move(string newAddress)
        {
            address = newAddress;
            Console.WriteLine("{0} moved to {1}", name, address);
        }

        public int GetAge()
        {
            return age;
        }

        public string GetOccupation()
        {
            return occupation;
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            //Type typeInfo
            Person person = new Person("Misha", 24, "Developer", "3 South", true);
            Type type = person.GetType();
            TypeInfo typeInfo = type.GetTypeInfo();
            Console.WriteLine();
            Console.WriteLine("Type name: {0}", type.Name);
            Console.WriteLine("Type namespace: {0}", type.Namespace);
            Console.WriteLine("Is class: {0}", type.IsClass);
            Console.WriteLine("Is public: {0}", type.IsPublic);

            Console.WriteLine("Is class: {0}", typeInfo.IsClass);
            Console.WriteLine("Is abstract: {0}", typeInfo.IsAbstract);
            Console.WriteLine("Is sealed: {0}", typeInfo.IsSealed);

           
            //MemberInfo
            MemberInfo[] members = type.GetMembers();
            Console.WriteLine();
            Console.WriteLine("Member Info:");
            foreach (MemberInfo member in members)
            {
                Console.WriteLine("{0} ({1})", member.Name, member.MemberType);
            }

            
            //FieldInfo
            FieldInfo[] fields = type.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            Console.WriteLine();
            Console.WriteLine("Field Info:");
            foreach (FieldInfo field in fields)
            {
                Console.WriteLine("{0} ({1}): {2}", field.Name, field.FieldType, field.GetValue(person));
            }

           
            //GetMethod
            MethodInfo method = type.GetMethod("Move");


            Console.WriteLine();
            Console.WriteLine("GetMethod:");
            if (method != null)
            {
                object[] parameters = new object[] { "25 Seashore" };
                method.Invoke(person, parameters);
            }

            Console.ReadLine();
        }
    }
}
