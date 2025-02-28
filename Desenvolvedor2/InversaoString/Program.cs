using System;

namespace InversaoString
{
    public class Program
    {
        static void Main()
        {
            // Solicitando ao usuário que digite uma string
            Console.Write("Digite a string que deseja inverter: ");
            string entrada = Console.ReadLine();

            // Chamando o método para inverter a string
            string invertida = InverterString(entrada);

            // Exibindo o resultado
            Console.WriteLine($"A string invertida é: {invertida}");
        }

        // Método responsável por inverter a string
        static string InverterString(string str)
        {
            // Cria um array de caracteres do mesmo tamanho da string
            char[] caracteresInvertidos = new char[str.Length];

            // Preenche o array com os caracteres da string de forma invertida
            for (int i = 0; i < str.Length; i++)
            {
                caracteresInvertidos[i] = str[str.Length - 1 - i];
            }

            // Fazendo um return com a string invertida
            return new string(caracteresInvertidos);
        }
    }
}
