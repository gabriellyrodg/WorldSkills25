using System;
using System.IO;

namespace ContadorDeLinhaTXT
{
    class Program
    {
        static void Main()
        {
            string arquivo = "contadordelinha.txt";
            List<string> linhas = new List<string>();

            Console.Write("Digite várias linhas em seu arquivo .txt.\n (Digite 'fim' para encerrar): ");

            string entrada;
            while ((entrada = Console.ReadLine()) != "fim")
            {
                linhas.Add(entrada);
            }

            File.WriteAllLines(arquivo, linhas);
            Console.WriteLine($"\nO arquivo possui {linhas.Count} linha(s).");
        }
    }
}
