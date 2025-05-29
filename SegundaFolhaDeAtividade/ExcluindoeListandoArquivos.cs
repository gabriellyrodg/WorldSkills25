using System;
using System.IO;

class Program
{
    static string caminhoDaPasta = @"C:\Users\ezmkn\OneDrive\Documentos\ExclusãoDeArquivos";

    static void Main()
    {
        Console.Write("Digite a quantidade de arquivos que você deseja em sua pasta: ");
        int quantidadeDeArquivo = int.Parse(Console.ReadLine());
        Console.Write("Pressione qualquer tecla para criar os arquivos.");
        Console.ReadKey();

        for (int i = 0; i < quantidadeDeArquivo; i++)
        {
            Console.Clear();
            Console.Write($"Digite o nome do arquivo {i + 1}: ");
            string nomearquivo = Console.ReadLine();

            string caminho = Path.Combine(caminhoDaPasta, $"{nomearquivo}.txt");
            File.Create(caminho).Close();

            Console.WriteLine($"Arquivo '{nomearquivo}' criado com sucesso!");
            Console.Write($"\nDeseja continuar adicionando? ({quantidadeDeArquivo - (i + 1)} restantes)\n| 1 - Sim | 2 - Não |\nOpção escolhida: ");
            int add = int.Parse(Console.ReadLine());

            if (add == 2)
            {
                Console.Clear();
                Console.WriteLine("Você escolheu parar.\nPressione qualquer tecla para começar a excluir.");
                Console.ReadKey();
                break;
            }
        }

        Console.Clear();
        Console.WriteLine("Iniciando processo de exclusão de arquivos...");
        ListarEExcluirArquivos();
    }

    static void ListarEExcluirArquivos()
    {
        while (true)
        {
            if (Directory.Exists(caminhoDaPasta))
            {
                string[] arquivos = Directory.GetFiles(caminhoDaPasta);
                if (arquivos.Length == 0)
                {
                    Console.WriteLine("A pasta está vazia.");
                    break;
                }

                Console.WriteLine("\nArquivos na pasta:");
                foreach (string arquivo in arquivos)
                {
                    Console.WriteLine(" - " + Path.GetFileName(arquivo));
                }

                Console.Write("\nDigite o nome exato do arquivo que deseja excluir (ex: arquivo.txt): ");
                string nomeProcurado = Console.ReadLine().Trim();
                string caminhoDoArquivo = Path.Combine(caminhoDaPasta, nomeProcurado);

                if (File.Exists(caminhoDoArquivo))
                {
                    Console.WriteLine("Arquivo encontrado: " + caminhoDoArquivo);
                    Console.Write("Tem certeza que deseja excluir esse arquivo?\n| 1 - Sim | 2 - Não |\nOpção escolhida: ");
                    int delete = int.Parse(Console.ReadLine());

                    if (delete == 1)
                    {
                        File.Delete(caminhoDoArquivo);
                        Console.WriteLine("Arquivo deletado com sucesso!");
                    }
                    else
                    {
                        Console.WriteLine("Operação cancelada.");
                    }
                }
                else
                {
                    Console.WriteLine("Arquivo não encontrado.");
                }
                Console.Clear();    
                Console.Write("\nDeseja excluir outro arquivo?\n| 1 - Sim | 2 - Voltar ao início | 3 - Sair |\nOpção escolhida: ");
                int opcao = int.Parse(Console.ReadLine());

                if (opcao == 1)
                {
                    Console.Clear();
                    continue;
                }
                else if (opcao == 2)
                {
                    Console.Clear();
                    Main();
                    return;
                }
                else if (opcao == 3)
                {
                    Console.WriteLine("Saindo do programa.");
                    break;
                }
                else
                {
                    Console.WriteLine("Opção inválida. Saindo.");
                    break;
                }
            }
            else
            {
                Console.WriteLine("A pasta não existe.");
                break;
            }
        }

        Console.WriteLine("Pressione qualquer tecla para sair.");
        Console.ReadKey();
    }
}
