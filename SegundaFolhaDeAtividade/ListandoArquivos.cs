using System;
using System.IO;

namespace ListandoArquivos{

    class Program
    {
        public static int MenuDeOpcoes(int opcao)
        {
            Console.Clear();
            Console.WriteLine("|    MENU DE OPÇÕES   |\n1. - Criar Pasta & Arquivos\n2. - Listar Arquivos\n3. - Excluir Arquivos\n4. - Abrir Arquivos\n5. - Escrever Em Arquivo\n6. - Sair\n----------------------------------------------------------");
            Console.Write("- Opção Escolhida: ");
            opcao = int.Parse(Console.ReadLine());
            return opcao;
        }

        public static string CriarPasta(string nomepasta, int quantidadedearquivo, string nomearquivo)
        {
            Console.Clear();
            Console.Write("Digite o nome da pasta que voce deseja criar: ");
            nomepasta = Console.ReadLine();

            string caminhoDaPasta = $"C:\\Users\\ezmkn\\OneDrive\\Área de Trabalho\\{nomepasta}";
            Directory.CreateDirectory(caminhoDaPasta);

            Console.Write("\nPasta Criada Com Sucesso!\nDigite a quantidade de arquivos que voce deseja em sua pasta: ");
            quantidadedearquivo = int.Parse(Console.ReadLine());
            Console.Write($"Pressione qualquer tecla para criar os {quantidadedearquivo} arquivos.");
            Console.ReadKey();

            for (int i = 0; i < quantidadedearquivo; i++)
            {
                Console.Clear();
                Console.Write($"Digite o nome do arquivo {i + 1}: ");
                nomearquivo = Console.ReadLine();

                string caminho = Path.Combine(caminhoDaPasta, $"{nomearquivo}.txt");
                File.Create(caminho).Close();

                Console.WriteLine($"Arquivo {nomearquivo} criado com sucesso!");
                Console.Write($"\nDeseja continuar adicionando até o limite de quantidade de arquivos ({quantidadedearquivo -  1})? \n|    1 - Sim  |  2 - Não     |\n Opção Escolhida:  ");
                int add = int.Parse(Console.ReadLine());
                if (add == 1)
                {
                    i = i;
                }
                else
                {
                    MenuDeOpcoes(0);
                }
            }

            Console.Clear();
            Console.WriteLine("Limite de arquivos atingido!");
            Console.Write("Pressione qualquer tecla para voltar ao menu ");
            Console.ReadKey();
            MenuDeOpcoes(0);

            return caminhoDaPasta;
        }

        public static string ListarArquivos()
        {
            Console.Clear();
            Console.WriteLine("Digite o nome da pasta cujo deseja listar os arquivos: ");
            string nomepasta = Console.ReadLine();
            string caminhoDaPasta = $"C:\\Users\\ezmkn\\OneDrive\\Área de Trabalho\\{nomepasta}";
            if (Directory.Exists(caminhoDaPasta))
            {
                string[] arquivos = Directory.GetFiles(caminhoDaPasta);
                Console.WriteLine("Arquivos nas pastas: ");
                foreach (string arquivo in arquivos)
                {
                    Console.WriteLine("\n - "+Path.GetFileName(arquivo));
                }
                Console.WriteLine($"São todos os arquivos que estão presentes na pasta {nomepasta}\nPressione qualquer tecla para ir pro menu.");
                Console.ReadKey();
                MenuDeOpcoes(0);
            }
            return nomepasta;
        }

        public static string ExcluirArquivos()
        {
            Console.Clear();
            Console.Write("Digite o nome da pasta onde o arquivo que deseja excluir está localizado: ");
            string pastanome = Console.ReadLine().Trim();
            string pastacaminho = $"C:\\Users\\ezmkn\\OneDrive\\Área de Trabalho\\{pastanome}";

            if (Directory.Exists(pastacaminho))
            {
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
            else
            {
                Console.WriteLine("Pasta não encontrada.");
            }

            Console.WriteLine("Pressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();

            return pastanome;
        }



        public static string AbrirArquivos()
        {
            Console.Clear();
            Console.Write("Digite o nome da pasta onde o arquivo que deseja abrir está localizado: ");
            string pastanome = Console.ReadLine().Trim();
            string pastacaminho = $"C:\\Users\\ezmkn\\OneDrive\\Área de Trabalho\\{pastanome}";

            if (!Directory.Exists(pastacaminho))
            {
                Console.WriteLine("Pasta não encontrada.");
            }
            else
            {
                Console.Write("Digite o nome do arquivo que deseja abrir (ex: arquivo.txt): ");
                string nomeProcurado = Console.ReadLine().Trim();
                string caminhoDoArquivo = Path.Combine(pastacaminho, nomeProcurado);

                if (!File.Exists(caminhoDoArquivo))
                {
                    Console.WriteLine("Arquivo não encontrado.");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\n--- Conteúdo do Arquivo ---\n");

                    string conteudo = File.ReadAllText(caminhoDoArquivo);
                    if (string.IsNullOrWhiteSpace(conteudo))
                        Console.WriteLine("[O arquivo está vazio]");
                    else
                        Console.WriteLine(conteudo);
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
            return pastanome;
        }


        public static string EscreverEmArquivos()
        {
            Console.Clear();
            Console.Write("Digite o nome da pasta onde o arquivo que deseja escrever está localizado: ");
            string pastanome = Console.ReadLine().Trim();
            string pastacaminho = $"C:\\Users\\ezmkn\\OneDrive\\Área de Trabalho\\{pastanome}";
            if (Directory.Exists(pastacaminho))
            {
                Console.Write("Digite o nome do arquivo que deseja abrir (ex: arquivo.txt): ");
                string nomeProcurado = Console.ReadLine().Trim();
                string caminhoDoArquivo = Path.Combine(pastacaminho, nomeProcurado);
                if (File.Exists(caminhoDoArquivo))
                {
                    Console.Write("Digite o texto que deseja adicionar ao arquivo: ");
                    string conteudo = Console.ReadLine();
                    File.AppendAllText(caminhoDoArquivo, conteudo);
                    Console.WriteLine("Texto adicionado com sucesso!");
                }
                else
                {
                    Console.WriteLine("Arquivo não encontrado.");
                }
            }
            else
            {
                Console.WriteLine("Pasta não encontrada.");
            }
            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu.");
            Console.ReadKey();
            MenuDeOpcoes(0);
            return pastanome;
        }

        static void Main(string[] args)
        {
            while (true)
            {
                int opcaoEscolhida = MenuDeOpcoes(0);
                switch (opcaoEscolhida)
                {
                    case 1:
                        CriarPasta("", 0, "");
                        break;
                    case 2:
                        ListarArquivos();
                        break;
                    case 3:
                        ExcluirArquivos();
                        break;
                    case 4:
                        AbrirArquivos();
                        break;
                    case 5:
                        EscreverEmArquivos();
                        break;
                    case 6:
                        Console.WriteLine("Encerrando o programa...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida.");
                        break;
                }
            }
        }



    }
}