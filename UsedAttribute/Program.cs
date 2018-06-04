using System;
using System.Collections;
using System.Reflection;
using M6_Attributes;

namespace UsedAttribute
{
    class Program
    {
        static void Main(string[] args)
        {
            string asmName = "M6_Attributes.exe";
            Assembly asm = Assembly.LoadFrom(asmName);

            // ChocolateFactory -- public
            var CFAsm = asm.GetType("M6_Attributes.ChocolateFactory", true, true);

            var flag = CFAsm.GetCustomAttribute(typeof(Flag));

            DisplayMethod(CFAsm, (flag as Flag).Value);

            Console.WriteLine(); // separate display

            // PizzaFactory -- static
            var PFAsm = asm.GetType("M6_Attributes.PizzaFactory", true, true);
            flag = PFAsm.GetCustomAttribute(typeof(Flag));

            DisplayMethod(PFAsm, (flag as Flag).Value);
        }

        public static void DisplayMethod(Type a, FlagValue f)
        {
            Console.Write(a.Name);
            if(f == FlagValue.Public)
                Console.WriteLine(" -- public");
            else if(f == FlagValue.Static)
                Console.WriteLine(" -- static");

            foreach (var meth in a.GetMethods())
            {
                if(f == FlagValue.Static)
                    if(!meth.IsStatic) continue;

                if (f == FlagValue.Public)
                    if (meth.IsStatic) continue;

                Console.Write("public ");
                if (meth.IsStatic) Console.Write("static ");

                Console.Write(meth.ReturnType.Name + " ");
                Console.Write(meth.Name + " (");

                ArrayList paramValue = new ArrayList();
                bool isFirst = true;
                foreach (var param in meth.GetParameters())
                {
                    if (isFirst)
                        isFirst = false;
                    else
                        Console.Write(", ");

                    Console.Write(param.ParameterType.Name + " " + param.Name);

                    if (param.ParameterType == typeof(String))
                        paramValue.Add(GetRandomString(5));

                    if (param.ParameterType == typeof(int))
                        paramValue.Add(GetRandomInt());

                    if (param.ParameterType == typeof(double))
                        paramValue.Add((double)GetRandomInt());

                    if (param.ParameterType == typeof(object))
                        paramValue.Add(null);
                }

                Console.Write(")");
                Console.WriteLine();


                if (meth.ReturnType != typeof(void))
                    if (f == FlagValue.Public)
                        Console.WriteLine("-----Rusult: " + 
                            a.GetMethod(meth.Name).Invoke(
                                Activator.CreateInstance(a), 
                                GetObjParamValue(paramValue)
                            ));
                    else if (f == FlagValue.Static)
                        Console.WriteLine("-----Rusult: " +
                            a.GetMethod(meth.Name).Invoke(
                                a,
                                GetObjParamValue(paramValue)
                            ));
            }
        }

        static string GetRandomString(int n)
        {
            Random r = new Random();
            string a = "";
            for (int i = 0; i < n; i++)
            {
                a += Char.ConvertFromUtf32(r.Next(0, 255));
            }
            return a;
        }

        static int GetRandomInt()
        {
            Random r = new Random();
            return r.Next(0, 500);
        }

        static object[] GetObjParamValue(ArrayList a)
        {
            object[] o = new object[a.Count];
            for(int i =0; i< a.Count; i++)
            {
                o[i] = a[i];
            }
            return o;
        }
    }
}
