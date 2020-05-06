using System;
using System.Reflection;

namespace MoodAnalyzer
{
    class Program
    {
        /// <summary>
        /// Using reflection we get all the information like class name,method name,constructor etc etc about any project,
        /// Assemble is used to load the .dll file.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Mood Analyzer Program!");
            string path = @"C:\Users\HP\source\repos\UserRegistrationC#\UserRegistrationMain\UserRegistration\bin\Debug\netcoreapp3.1\UserRegistration.dll";
            ////read the file path and load into the assembly type          
            Assembly assembly = Assembly.LoadFile(path);
            ////Getting All types Whatever we use as class name in that project array type
            Type[] types = assembly.GetTypes();
            foreach (var type in types)
            {
                Console.WriteLine("Class:" + type.Name);
                ////Getting all method name in same class
                MethodInfo[] methods = type.GetMethods();
                foreach (var method in methods)
                {
                    Console.WriteLine("Methods: " + method.Name);
                    ////Getting all parameter name in same class
                    ParameterInfo[] parameters = method.GetParameters();
                    foreach (var param in parameters)
                    {
                        Console.WriteLine("Parameter: " + param.Name);
                        Console.WriteLine("Type of Parameter: " + param.ParameterType);
                    }
                }
            }
        }
    }
}
