using System;
using ClosedXML.Excel;

class Program
{
    static void Main()
    {
        try
        {
            using var workbook = new XLWorkbook();

            var worksheet = workbook.Worksheets.Add("PlanilhaInfo");

            List<string> nomes = new List<string>();
            List<int> idades = new List<int>();
            List<string> cursos = new List<string>();

            for (int i = 0; i < 3; i++) 
            {
                Console.WriteLine($"Digite o nome do Aluno {i + 1}: ");
                nomes.Add(Console.ReadLine());
                Console.WriteLine($"Digite a idade do Aluno {i + 1}: ");
                idades.Add(int.Parse(Console.ReadLine()));
                Console.WriteLine($"Digite o curso do Aluno {i + 1}: ");
                cursos.Add(Console.ReadLine());
            }

            worksheet.Cell("A1").Value = "Nome";
            worksheet.Cell("B1").Value = "Idade";
            worksheet.Cell("C1").Value = "Curso";

            worksheet.Cell("A2").InsertData(nomes);
            worksheet.Cell("B2").InsertData(idades);
            worksheet.Cell("C2").InsertData(cursos);



            workbook.SaveAs("planilha.xlsx");

            Console.WriteLine("Arquivo 'planilha.xlsx' criado com sucesso!");
        }
        catch (Exception ex)
        {
            Console.WriteLine("Erro ao criar planilha: " + ex.Message);
        }

        Console.ReadLine();
    }
}