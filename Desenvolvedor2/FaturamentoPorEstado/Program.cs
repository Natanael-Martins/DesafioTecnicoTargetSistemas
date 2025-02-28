using System;
using System.Collections.Generic;

namespace FaturamentoPorEstado
{
    public class Program
    {
        static void Main()
        {
            // Dicionário que contém o faturamento por estado
            Dictionary<string, double> faturamentoPorEstado = new Dictionary<string, double>
            {
                {"SP", 67836.43},
                {"RJ", 36678.66},
                {"MG", 29229.88},
                {"ES", 27165.48},
                {"Outros", 19849.53}
            };

            // Variável para armazenar o faturamento total
            double faturamentoTotal = 0;

            // Calculando o total do faturamento somando os valores de cada estado
            foreach (var valor in faturamentoPorEstado.Values)
            {
                faturamentoTotal += valor;
            }

            // Exibindo o percentual de contribuição de cada estado no faturamento total
            Console.WriteLine("Percentual de representação de cada estado no faturamento total:");
            foreach (var estado in faturamentoPorEstado)
            {
                double percentual = (estado.Value / faturamentoTotal) * 100;
                Console.WriteLine($"{estado.Key}: {percentual:F2}%");
            }
        }
    }
}
