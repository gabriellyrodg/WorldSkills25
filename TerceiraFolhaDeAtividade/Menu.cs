using System;

public static class Menu
{
    public static int MenuPrincipal(int opcao)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("|    Menu Principal   |\n--------------------------------------\n0. Encerrar Conversa\n1. Informações Sobre Os Produtos\n2. Suporte Técnico\n3. Falar Com Atendente Automatico\n---------------------\nOpção Escolhida: ");
        opcao = int.Parse(Console.ReadLine());
        switch (opcao)
        {
            case 0:
                Console.WriteLine("Encerrando a conversa...");
                Environment.Exit(0);
                break;
            case 1:
                Console.WriteLine("Você escolheu Informações Sobre Os Produtos.");
                InfoProdutos.MostrarInfo();
                break;
            case 2:
                Console.WriteLine("Você escolheu Suporte Técnico.");
                SuporteTecnico.Suporte();
                break;
            case 3:
                Console.WriteLine("Você escolheu Falar Com Atendente.");
                Atendente.FalarComAtendente();
                break;
            default:
                Console.WriteLine("Opção inválida. Tente novamente.");
                break;
        }
        return opcao = Convert.ToInt32(Console.ReadLine());
    }

    public static void back()
    {
        Console.WriteLine("\n\nPressione qualquer tecla para voltar ao menu principal...");
        Console.ReadKey();
        MenuPrincipal(1);
    }
}
