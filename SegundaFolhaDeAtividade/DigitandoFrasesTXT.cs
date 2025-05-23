using System;
using System.IO;

class Program
{
    static void Main()
    {
        int contador = 1;

        while (true)
        {
            Console.Write("Digite uma frase (ou 'sair' para encerrar): ");
            string frase = Console.ReadLine();

            if (frase.ToLower() == "sair")
                break;

            string nomeArquivo = $"frase{contador}.txt";

            File.WriteAllText(nomeArquivo, frase);
            Console.WriteLine($"Frase salva em '{nomeArquivo}'");

            contador++;
        }
    }
}
