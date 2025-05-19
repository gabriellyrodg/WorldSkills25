using System;

class Program
{
    static void Main()
    {
        string[] nomes = new string[5];
        for (int i = 0; i < 5; i++)
        {
            Console.Write($"Digite o nome {i}:");
            nomes[i] = Console.ReadLine();
        }
        Console.WriteLine("Sua lista de nomes é:" + string.Join(", ", nomes));
        Console.Write("Agora digite a Inicial dos nomes que voce quer exibir:");
        char inicial = Console.ReadLine()[0];
        foreach(string nome in nomes)
        {
            if (nome.StartsWith(inicial))
            {
                Console.WriteLine($"O nome que começa com {inicial} na sua lista é {nome}");
            }
        }

    }
}