using System;

public static class SuporteTecnico
{
    public static string Suporte()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("|     Suporte Técnico       |\n--------------------------------------------");
        Console.Write("Digite o seu problema ou dúvida: ");
        string problema = Console.ReadLine();
        Console.WriteLine($"Seu problema foi registrado: {problema}. Um atendente entrará em contato em breve");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Caso urgente entre em contato em: www.suportetecnico.com");
        Menu.back();
        return "";
    }
}
