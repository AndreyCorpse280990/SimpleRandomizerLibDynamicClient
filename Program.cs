using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SimpleRandomizerLibDynamicClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Загрудить сборку dll-библиоетки в текущий проект
            AssemblyName libAssemlyName = AssemblyName.GetAssemblyName("SimpleRandomizeLib.dll");
            Assembly libAssembly = Assembly.Load(libAssemlyName);
            Console.WriteLine($"Loaded lib assemly: {libAssemlyName.FullName}");

            // 2. Загрузить модуль библиотеки
            Module libModule = libAssembly.GetModule("SimpleRandomizeLib.dll");
            Console.WriteLine($"Loaded lib module: {libModule.Name}");

        }
    }
}
