using System;
using System.Xml;
using System.IO;
using System.Data;

namespace Mathml
{
    class Program
    {
        static void Main(string[] args)
        {
            MathFunctions math = new MathFunctions();
            XmlTextReader reader = new XmlTextReader("math.xml");

            string description;
            string name;
            string operationName;
            string operationSign;
            int val1 = 1;
            int val2;
            int result;

            while (reader.Read())
            {
                if (reader.IsStartElement())
                {
                    switch (reader.Name.ToString())
                    {
                        case "Add":
                            reader.ReadToDescendant("Description");
                            description = reader.ReadString();
                            name = GetName(description);
                            operationName = GetOperation(description);
                            operationSign = "+";

                            reader.ReadToNextSibling("Value1");
                            try { val1 = int.Parse(reader.ReadString()); }
                            catch (Exception e)
                            {
                                Console.WriteLine("Value1 is not a number: " + e.Message);
                                val1 = 0; 
                            }

                            reader.ReadToNextSibling("Value2");
                            val2 = int.Parse(reader.ReadString());
                            result = math.Add(val1, val2);

                            Console.WriteLine(ReturnResult(name, operationName, operationSign, val1, val2, result));
                            break;
                        case "Subtract":
                            reader.ReadToDescendant("Description");
                            description = reader.ReadString();
                            name = GetName(description);
                            operationName = GetOperation(description);
                            operationSign = "-";
                            reader.ReadToNextSibling("Value1");
                            val1 = int.Parse(reader.ReadString());
                            reader.ReadToNextSibling("Value2");
                            val2 = int.Parse(reader.ReadString());
                            result = math.Subtract(val1, val2);
                            Console.WriteLine(ReturnResult(name, operationName, operationSign, val1, val2, result));
                            break;
                        case "Multiply":
                            reader.ReadToDescendant("Description");
                            description = reader.ReadString();
                            name = GetName(description);
                            operationName = GetOperation(description);
                            operationSign = "*";
                            reader.ReadToNextSibling("Value1");
                            val1 = int.Parse(reader.ReadString());
                            reader.ReadToNextSibling("Value2");
                            val2 = int.Parse(reader.ReadString());
                            result = math.Multiply(val1, val2);
                            Console.WriteLine(ReturnResult(name, operationName, operationSign, val1, val2, result));
                            break;
                        case "Divide":
                            reader.ReadToDescendant("Description");
                            description = reader.ReadString();
                            name = GetName(description);
                            operationName = GetOperation(description);
                            operationSign = "/";
                            reader.ReadToNextSibling("Value1");
                            //Console.WriteLine("Value of Value1: " + reader.ReadString());
                            val1 = int.Parse(reader.ReadString());
                            reader.ReadToNextSibling("Value2");
                            val2 = int.Parse(reader.ReadString());
                            result = math.Divide(val1, val2);
                            Console.WriteLine(ReturnResult(name, operationName, operationSign, val1, val2, result));
                            break;
                    }
                }
                
            }
            Console.ReadLine();
        }

        static string ReturnResult(string name, string operationName, string operationSign, int val1, int val2, int result)
        {
            return name + " - " + operationName + " - " + val1 + " " + operationSign + " " + val2 + " = " + result;
        }

        static string GetName(string value) 
        {
            string[] name = value.Split(';');
            return name[0]; 
        }

        static string GetOperation(string value)
        {
            string[] name = value.Split(';');
            return name[1];
        }
    }

    class MathFunctions
    {
        public int Add (int x, int y) { return x + y; }

        public int Subtract (int x, int y) { return x - y; }

        public int Multiply (int x, int y) { return x * y; }

        public int Divide (int x, int y) { return x / y; }
    }
}
