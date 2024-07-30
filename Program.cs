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

            // 3. Получим тип библиотечного класса
            Type randomizerType = libModule.GetType("SimpleRandomizeLib.Randomizer");
            Console.WriteLine($"got randomizer type: {randomizerType.FullName}");

            // 4. Создать объект типа библиотечного класса
            object randomizerInstance = Activator.CreateInstance(randomizerType);
            Console.WriteLine($"Created randomizer instance: {randomizerInstance}");

            // 5. вызвать метод int
            MethodInfo intMethod = randomizerType.GetMethod("Int");
            int intResult = Convert.ToInt32(intMethod.Invoke(randomizerInstance, null));
            Console.WriteLine($"Int result: {intResult}");

            // 6 вызвать метод int
            int n = 100;
            MethodInfo intNMethod = randomizerType.GetMethod("IntN");

            int intNresult = Convert.ToInt32(intNMethod.Invoke(randomizerInstance, new object[] {n}));
            Console.WriteLine($"intN ({n}) result: {intNresult}");

            //7. вызвать метод IntRange
            int min = 10;
            int max = 50;
            MethodInfo intRangeMethod = randomizerType.GetMethod("IntRange");
            int intRangeResult = Convert.ToInt32(intRangeMethod.Invoke(randomizerInstance, new object[] { min, max }));
            Console.WriteLine($"IntRange({min}, {max}) result: {intRangeResult}");

            // 8. Вызвать метод Bool
            MethodInfo boolMethod = randomizerType.GetMethod("Bool");
            bool boolResult = Convert.ToBoolean(boolMethod.Invoke(randomizerInstance, null));
            Console.WriteLine($"Bool result: {boolResult}");


        }
    }
}
