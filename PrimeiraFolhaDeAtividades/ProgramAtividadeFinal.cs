using System;

class Program
{
    static void Main()
    {
        string[] nomes = new string[10];
        int[] idade = new int[10];
        string[] cidade = new string[10];
        int quantidadeCadastrada = 0;
        

        Console.WriteLine("Bem-vindo ao sistema de cadastro de pessoas!");
        Console.WriteLine("Pressione qualquer tecla para continuar...");
        Console.ReadKey();

        while (true)
        {
            Console.Clear();
            Console.WriteLine("Digite a opção desejada:");
            Console.WriteLine("1 - Adicionar pessoa");
            Console.WriteLine("2 - Listar pessoas");
            Console.WriteLine("3 - Buscar pessoa pelo nome");
            Console.WriteLine("4 - Mostrar todos cadastrados");
            Console.Write("5 - Sair do sistema\n Opção Escolhida: ");
            int opcao = int.Parse(Console.ReadLine());

            if (opcao == 1)
            {
                for (int i = quantidadeCadastrada; i < 10; i++)
                {
                    Console.Clear();
                    Console.WriteLine($"Cadastro da {i + 1}ª pessoa:");
                    Console.Write("Nome: ");
                    nomes[i] = Console.ReadLine();
                    Console.Write("Idade: ");
                    idade[i] = int.Parse(Console.ReadLine());
                    Console.Write("Cidade: ");
                    cidade[i] = Console.ReadLine();
                    quantidadeCadastrada++;

                    if (i == 9)
                    {
                        Console.WriteLine("Você atingiu o limite de 10 cadastros.");
                        break;
                    }

                    Console.WriteLine("Deseja continuar?\n1 - Sim | 2 - Não:");
                    int continuar = int.Parse(Console.ReadLine());
                    if (continuar == 2)
                    {
                        break;
                    }
                }
            }

            else if (opcao == 2)
            {
                Console.Clear();
                Console.WriteLine("Como deseja listar?");
                Console.WriteLine("1 - A-Z");
                Console.WriteLine("2 - Z-A");
                Console.WriteLine("3 - Ordem original");
                int listarordem = int.Parse(Console.ReadLine());

                string[] nomesValidos = new string[quantidadeCadastrada];
                for (int i = 0; i < quantidadeCadastrada; i++)
                {
                    nomesValidos[i] = nomes[i];
                }

                if (listarordem == 1)
                {
                    Array.Sort(nomesValidos); 
                }
                else if (listarordem == 2)
                {
                    Array.Sort(nomesValidos);
                    Array.Reverse(nomesValidos); 
                }

                Console.WriteLine("Lista de pessoas cadastradas:");
                for (int i = 0; i < quantidadeCadastrada; i++)
                {
                    int originalIndex = Array.IndexOf(nomes, nomesValidos[i]);
                    Console.WriteLine($"Nome: {nomes[originalIndex]}, Idade: {idade[originalIndex]}, Cidade: {cidade[originalIndex]}");
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();

            }

            else if (opcao == 3)
            {
                Console.Clear();
                Console.Write("Digite o nome da pessoa que deseja buscar: ");
                string nomebuscado = Console.ReadLine();
                bool encontrou = false;

                for (int i = 0; i < quantidadeCadastrada; i++)
                {
                    if (nomes[i] != null && nomes[i].ToLower() == nomebuscado.ToLower())
                    {
                        Console.WriteLine($"Nome: {nomes[i]}, Idade: {idade[i]}, Cidade: {cidade[i]}");
                        encontrou = true;
                        break;
                    }
                }

                if (!encontrou)
                {
                    Console.WriteLine("Nome não encontrado.");
                }

                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }

            else if (opcao == 4)
            {
                Console.Clear();
                Console.WriteLine("Lista completa dos cadastrados:");
                for (int i = 0; i < quantidadeCadastrada; i++)
                {
                    Console.WriteLine($"Nome: {nomes[i]}, Idade: {idade[i]}, Cidade: {cidade[i]}");
                }
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }

            else if (opcao == 5)
            {
                Console.WriteLine("Saindo do sistema. Até logo!");
                break;
            }

            else
            {
                Console.WriteLine("Opção inválida!");
                Console.WriteLine("Pressione qualquer tecla para continuar...");
                Console.ReadKey();
            }
        }
    }
}
