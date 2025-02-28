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
            // Definindo o caminho para o arquivo JSON
            string caminhoArquivoJson = "C:\\Users\\Natanael Martins\\OneDrive\\Desktop\\Projetos\\dados.json";

            // Verificando se o arquivo existe
            if (!File.Exists(caminhoArquivoJson))
            {
                Console.WriteLine($"Arquivo não encontrado no caminho: {caminhoArquivoJson}");
                return;
            }

            try
            {
                // Lendo o conteúdo do arquivo JSON
                string textoJson = File.ReadAllText(caminhoArquivoJson);

                // Tentando desserializar o JSON para um array de objetos Faturamento
                var faturamentoDiario = JsonSerializer.Deserialize<Faturamento[]>(
                    textoJson,
                    new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                );

                // Verificando se os dados foram carregados corretamente
                if (faturamentoDiario == null || faturamentoDiario.Length == 0)
                {
                    Console.WriteLine("Arquivo JSON está vazio ou não contém dados válidos.");
                    return;
                }

                // Filtrando os dias com valores de faturamento válidos (maiores que zero)
                var diasComFaturamento = faturamentoDiario.Where(d => d.Valor > 0).ToList();

                // Verificando se há dias com faturamento válido para análise
                if (!diasComFaturamento.Any())
                {
                    Console.WriteLine("Não há faturamento válido para análise.");
                    return;
                }

                // Calculando o menor, maior e a média dos faturamentos válidos
                double menorFaturamento = diasComFaturamento.Min(d => d.Valor);
                double maiorFaturamento = diasComFaturamento.Max(d => d.Valor);
                double mediaMensal = diasComFaturamento.Average(d => d.Valor);

                // Contabilizando os dias com faturamento acima da média mensal
                int diasAcimaDaMedia = diasComFaturamento.Count(d => d.Valor > mediaMensal);

                // Exibindo os resultados para o usuário
                Console.WriteLine($"Menor faturamento: {menorFaturamento:C}");
                Console.WriteLine($"Maior faturamento: {maiorFaturamento:C}");
                Console.WriteLine($"Dias com faturamento acima da média mensal: {diasAcimaDaMedia}");
            }
            catch (Exception ex)
            {
                // Caso venha a ocorrer algum erro durante o processamento, exiba a mensagem de erro
                Console.WriteLine($"Erro ao processar os dados de faturamento: {ex.Message}");
            }
        }
    }

    // Classe que representa os dados de faturamento de um dia específico
    public class Faturamento
    {
        public int Dia { get; set; }
        public double Valor { get; set; }
    }
}
