using System;

namespace CalculoDeSoma
{
    public class Program
    {
        static void Main()
        {
            // Definindo o limite de iteração e a variável para armazenar a soma
            int indice = 13;
            int soma = 0;
            int contador = 1;

            // Loop para calcular a soma dos números de 1 até o limite
            while (contador <= indice)
            {
                soma += contador;
                contador++;
            }

            // Exibir o resultado final da soma
            Console.WriteLine($"A soma dos números de 1 até {indice} é: {soma}");
        }
    }
}
