using System;

namespace SequenciaFibonacci
{
    public class Program
    {
        static void Main()
        {
            // Solicitando ao usuário que digite um número para verificar na sequência de Fibonacci
            Console.Write("Digite um número para verificar se ele pertence à sequência de Fibonacci: ");
            int numero = int.Parse(Console.ReadLine());

            // Verificando se o número pertence à sequência de Fibonacci
            if (PertenceAFibonacci(numero))
                Console.WriteLine($"{numero} pertence à sequência de Fibonacci.");
            else
                Console.WriteLine($"{numero} não pertence à sequência de Fibonacci.");
        }

        // Método para verificar se um número pertence à sequência de Fibonacci
        static bool PertenceAFibonacci(int numero)
        {
            int primeiro = 0, segundo = 1, proximo;

            // Calculando os números da sequência de Fibonacci até encontrar o número ou ultrapassá-lo
            while (segundo < numero)
            {
                proximo = primeiro + segundo;
                primeiro = segundo;
                segundo = proximo;
            }

            // Verificando se o número é igual ao último valor calculado ou se é zero
            return segundo == numero || numero == 0;
        }
    }
}
