using System;

namespace SequenciaFibonacci
{
    public class Program
    {
        static void Main()
        {
            Console.Write("Digite um número para verificar à sequência de Fibonacci: ");
            int num = int.Parse(Console.ReadLine());

            if (IsFibonacci(num))
                Console.WriteLine($"{num} pertence à sequência de Fibonacci.");
            else
                Console.WriteLine($"{num} não pertence à sequência de Fibonacci.");
        }

        static bool IsFibonacci(int num)
        {
            int a = 0, b = 1, temp;

            while (b < num)
            {
                temp = a + b;
                a = b;
                b = temp;
            }

            return b == num || num == 0;
        }
    }
}
