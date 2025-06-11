using System;
using System.IO;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using OfficeOpenXml.Drawing.Chart;

class Program
{
    static void Main()
    {
        string situacao = "";
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

        var arquivo = "alunos.txt";

        Console.Clear();
        Console.WriteLine("Sistema de Alunos .txt\n Pressione qualquer tecla para entrar...");
        Console.ReadKey();

        for (int i = 0; i < 10; i++)
        {
            Console.Clear();
            Console.Write($"Digite o nome do Aluno {i + 1}: ");
            string nome = Console.ReadLine();
            Console.Write($"Digite a nota do Aluno {i + 1}: ");
            int nota = int.Parse(Console.ReadLine());
            Console.Write($"Qual o Curso do Aluno {i + 1}? ");
            string curso = Console.ReadLine();

            if (nota < 6)
                situacao = "Reprovado.";
            else if (nota == 6)
                situacao = "Aprovado Na Média.";
            else
                situacao = "Aprovado";

            File.AppendAllText(arquivo, $"{nome},{nota},{curso},{situacao}\n");

            Console.WriteLine("Adicionado com sucesso!");
            Console.WriteLine("Deseja continuar? 1 - Sim  |  2 - Não\n Resposta: ");
            int stop = int.Parse(Console.ReadLine());
            if (stop == 2)
            {
                Console.WriteLine("Até Mais!");
                break;
            }
        }

        var caminhoExcel = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "planilha_alunos.xlsx");
        var linhas = File.ReadAllLines(arquivo);

        using (var pacote = new ExcelPackage())
        {
            var planilha = pacote.Workbook.Worksheets.Add("Alunos");

            planilha.Cells[1, 1].Value = "NOME";
            planilha.Cells[1, 2].Value = "NOTA";
            planilha.Cells[1, 3].Value = "CURSO";
            planilha.Cells[1, 4].Value = "SITUAÇÃO";

            planilha.Column(1).Width = 21;
            planilha.Column(2).Width = 21;
            planilha.Column(3).Width = 21;
            planilha.Column(4).Width = 21;

            planilha.Row(1).Height = 30;

            var cabecalho = planilha.Cells[1, 1, 1, 4];
            cabecalho.Style.Font.Bold = true;
            cabecalho.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
            cabecalho.Style.VerticalAlignment = ExcelVerticalAlignment.Center;

            int linhaAtual = 2;
            foreach (var linha in linhas)
            {
                var partes = linha.Split(',');
                planilha.Cells[linhaAtual, 1].Value = partes[0];
                planilha.Cells[linhaAtual, 2].Value = int.Parse(partes[1]);
                planilha.Cells[linhaAtual, 3].Value = partes[2];
                planilha.Cells[linhaAtual, 4].Value = partes[3];
                linhaAtual++;
            }

            // Adicionando gráfico de barras
            var grafico = (ExcelBarChart)planilha.Drawings.AddChart("graficoNotas", eChartType.BarClustered);
            grafico.SetPosition(1, 0, 5, 0); // Linha 1, Coluna 5
            grafico.SetSize(600, 400);
            grafico.Title.Text = "Notas dos Alunos";

            var intervaloNotas = planilha.Cells[2, 2, linhaAtual - 1, 2];       // Coluna B (NOTA)
            var intervaloNomes = planilha.Cells[2, 1, linhaAtual - 1, 1];       // Coluna A (NOME)

            grafico.Series.Add(intervaloNotas, intervaloNomes);

            pacote.SaveAs(new FileInfo(caminhoExcel));
            Console.WriteLine("\nPlanilha com gráfico criada com sucesso na área de trabalho.");
        }
    }
}
