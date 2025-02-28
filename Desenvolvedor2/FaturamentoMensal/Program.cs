using System;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace FaturamentoMensal
{
    public class Program
    {
        static void Main()
        {
            string jsonPath = "C:\\Users\\Natanael Martins\\OneDrive\\Desktop\\Projetos\\dados.json";

            if (!File.Exists(jsonPath))
            {
                Console.WriteLine($"Arquivo não encontrado no caminho: {jsonPath}");
                return;
            }

            try
            {
                string jsonText = File.ReadAllText(jsonPath);
                var faturamentoDiario = JsonSerializer.Deserialize<Faturamento[]>(
                    jsonText,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                if (faturamentoDiario == null || faturamentoDiario.Length == 0)
                {
                    Console.WriteLine("Arquivo JSON está vazio ou inválido.");
                    return;
                }

                var diasComFaturamento = faturamentoDiario.Where(d => d.Valor > 0).ToList();

                if (!diasComFaturamento.Any())
                {
                    Console.WriteLine("Não há faturamento válido para análise.");
                    return;
                }

                double menorValor = diasComFaturamento.Min(d => d.Valor);
                double maiorValor = diasComFaturamento.Max(d => d.Valor);
                double mediaMensal = diasComFaturamento.Average(d => d.Valor);
                int diasAcimaMedia = diasComFaturamento.Count(d => d.Valor > mediaMensal);

                Console.WriteLine($"Menor faturamento: {menorValor:C}");
                Console.WriteLine($"Maior faturamento: {maiorValor:C}");
                Console.WriteLine($"Dias com faturamento acima da média mensal: {diasAcimaMedia}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao processar o faturamento: {ex.Message}");
            }
        }
    }

    public class Faturamento
    {
        public int Dia { get; set; }
        public double Valor { get; set; }
    }
}
