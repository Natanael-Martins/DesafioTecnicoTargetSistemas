using System;

namespace InversaoString
{
    public class Program
    {
        static void Main()
        {
            Console.Write("Digite uma string para inverter: ");
            string input = Console.ReadLine();
            string inverted = InverterString(input);

            Console.WriteLine($"String invertida: {inverted}");
        }

        static string InverterString(string str)
        {
            char[] chars = new char[str.Length];

            for (int i = 0; i < str.Length; i++)
            {
                chars[i] = str[str.Length - 1 - i];
            }

            return new string(chars);
        }
    }
}
