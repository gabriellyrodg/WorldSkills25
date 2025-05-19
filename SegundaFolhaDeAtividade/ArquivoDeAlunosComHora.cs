using System.IO;

class AlunoTXT
{
    static void Main()
    {
        string arquivo = "aluno.txt";
        Console.Clear();
        Console.WriteLine("Sistema de Alunos .txt\n Pressione qualquer tecla para entrar...");

        for (int i = 0; i < 10; i++)
        {
            DateTime data = DateTime.Now;
            Console.ReadKey();
            Console.Clear();
            Console.Write($"Digite o nome do Aluno {i + 1}: ");
            string nome = Console.ReadLine();
            Console.Write($"Digite a idade do Aluno {i + 1}: ");
            int idade = int.Parse(Console.ReadLine());
            Console.Write($"Qual o Curso do Aluno {i + 1}? ");
            string curso = Console.ReadLine();
            Console.Clear();
            File.AppendAllText(arquivo, $"\nNome: {nome}  |  Idade: {idade}  | Curso: {curso}\n" + "Data e hora que foi adicionado: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + "\n");
            Console.WriteLine("Adicionado com sucesso!");
            Console.WriteLine("Deseja continuar? 1 - Sim  |  2 - Não\n Resposta: ");
            int stop = int.Parse(Console.ReadLine());
            if (stop == 1)
            {
                i = i;

            }
            else
            {
                Console.WriteLine("Até Mais!");
                break;
            }




        }
    }
}


