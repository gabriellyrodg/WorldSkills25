using System;
using System.IO;

namespace ExclusaoDeArquivos
{
    class Program
    {
        static string Excluindo()
        {
            string pastacaminho = "C:\\Users\\ezmkn\\OneDrive\\Documentos\\ExclusãoDeArquivos";

            if (Directory.Exists(pastacaminho))
            {
                Console.Clear();
                Console.Write("Digite o nome do arquivo que deseja excluir (ex: arquivo.txt): ");
                string nomeProcurado = Console.ReadLine().Trim();
                string caminhoDoArquivo = Path.Combine(pastacaminho, nomeProcurado);

                if (File.Exists(caminhoDoArquivo))
                {
                    Console.WriteLine("Arquivo encontrado: " + caminhoDoArquivo);
                    Console.Write("Tem certeza que deseja excluir esse arquivo?\n|       1 - Sim     |       2 - Não       \nOpção Escolhida: ");
                    int delete = int.Parse(Console.ReadLine());

                    if (delete == 1)
                    {
                        File.Delete(caminhoDoArquivo);
                        Console.WriteLine("Arquivo deletado com sucesso!");
                        Console.Write("Digite 1 para continuar apagando, 2 para ir para o inicio ou 3 para sair: ");
                        int continuar = int.Parse(Console.ReadLine());
                        if (continuar == 1)
                        {
                            Excluindo();
                        }
                        else if (continuar == 2)
                        {
                            Console.Clear();
                            Main();
                        }
                        else if (continuar == 3)
                        {
                            Console.Clear();
                            Console.WriteLine("Saindo do programa. Pressione qualquer tecla para fechar.");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Opção inválida. Pressione qualquer tecla para sair.");
                            Console.ReadKey();
                            Environment.Exit(0);
                        }

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
            }
            return pastacaminho;
        }


        static void Main()
        {
                string caminhoDaPasta = "C:\\Users\\ezmkn\\OneDrive\\Documentos\\ExclusãoDeArquivos";
                Console.Write("Digite a quantidade de arquivos que voce deseja em sua pasta: ");
                int quantidadedearquivo = int.Parse(Console.ReadLine());
                Console.Write($"Pressione qualquer tecla para criar os {quantidadedearquivo} arquivos.");
                Console.ReadKey();

                for (int i = 0; i < quantidadedearquivo; i++)
                {
                    Console.Clear();
                    Console.Write($"Digite o nome do arquivo {i + 1}: ");
                    string nomearquivo = Console.ReadLine();

                    string caminho = Path.Combine(caminhoDaPasta, $"{nomearquivo}.txt");
                    File.Create(caminho).Close();

                    Console.WriteLine($"Arquivo {nomearquivo} criado com sucesso!");
                    Console.Write($"\nDeseja continuar adicionando até o limite de quantidade de arquivos ({quantidadedearquivo - 1})? \n|    1 - Sim  |  2 - Não     |\n Opção Escolhida:  ");
                    int add = int.Parse(Console.ReadLine());
                    if (add == 1)
                    {
                        i = i;
                    }
                    else if (add == 2)
                    {
                        Console.Clear();
                        Console.WriteLine("Você escolheu não adicionar mais arquivos.\nPressione qualquer tecla para começar a excluir.");
                        Console.ReadKey();
                        Excluindo();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Opção inválida. Por favor, escolha 1 ou 2.\nPressione qualquer tecla para voltar.");
                        i--;
                    }
                }
                Console.Clear();
                Console.WriteLine("Limite de arquivos atingido! \nPressione qualquer tecla para começar a excluir.");
                Console.ReadLine();
                Excluindo();

            }
        }
    }
