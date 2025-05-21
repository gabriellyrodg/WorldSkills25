using System.IO;

namespace PastaNotas
{
    class Program
    {
        public static string Mensagem(string nome, float mediafinal)
        {
            string mensagem = "Nome do Aluno: " + nome + "\nMedia Final do aluno: " + mediafinal;
            return mensagem;
        }

        static void Main(string[] args)
        {
            string arquivo = "alunos.txt";
            Directory.CreateDirectory("Notas");

            Console.WriteLine("| SALVAMENTO DE INFORMAÇÕES DE ALUNOS EM PASTA 'NOTAS' |");

            if (Directory.Exists("Notas"))
            {
                Console.WriteLine("\nPasta encontrada ou criada com sucesso.");
                Console.WriteLine("Aperte qualquer tecla para iniciar: ");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Falha em encontrar ou criar a pasta.");

            }
            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                Console.WriteLine("| Salvamento de Alunos em TXT |\n ");
                Console.Write($"Digite o nome do aluno {i + 1}: ");
                string aluno = Console.ReadLine();
                Console.Write($"Digite a primeira nota do aluno {i + 1}: ");
                float primeiranota = float.Parse(Console.ReadLine());
                Console.Write($"Digite a segunda nota do aluno {i + 1}: ");
                float segundanota = float.Parse(Console.ReadLine());
                Console.Write($"Digite a terceira nota do aluno {i + 1}: ");
                float terceiranota = float.Parse(Console.ReadLine());
                float media = primeiranota + segundanota + terceiranota / 3;
                string mensagemfinal = Mensagem(aluno, media);
                File.AppendAllText("Notas/alunos.txt", mensagemfinal + "\n\n");
                Console.WriteLine("Adicionado com sucesso! Pressione 1 para continuar ou 2 para sair: ");
                int continuar = int.Parse(Console.ReadLine());
                if (continuar == 1)
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
}
