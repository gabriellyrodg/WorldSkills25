using System;
using System.Collections.Generic;

namespace SaldoDeFaltas
{
    public class SistemaAprovacao
    {
        private List<Aluno> alunos = new List<Aluno>();

        public void Executar()
        {
            Console.WriteLine("| Sistema Final De Aprovação De Alunos |\n - Pressione Qualquer Tecla Para Iniciar.");
            Console.ReadKey();

            for (int i = 0; i < 10; i++)
            {
                Console.Clear();
                Aluno aluno = new Aluno();

                Console.Write($"Digite o nome do {i + 1}º Aluno: ");
                aluno.Nome = Console.ReadLine();

                Console.WriteLine($"Pronto! Pressione qualquer tecla para analisarmos a situação faltosa de {aluno.Nome}.");
                Console.ReadKey();

                Console.Clear();
                Console.WriteLine("| Simulador de Quantidade de Faltas |");
                Console.Write($"Quantos DIAS {aluno.Nome} faltou: ");
                int dias = int.Parse(Console.ReadLine());
                aluno.Faltas = dias * 6;

                Console.WriteLine($"Total de faltas: {aluno.Faltas}");
                Console.WriteLine("Pressione qualquer tecla para as notas.");
                Console.ReadKey();

                Console.Clear();
                Console.WriteLine("| Simulador de Notas |");
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"Digite a {j + 1}ª nota de {aluno.Nome}: ");
                    aluno.Notas.Add(double.Parse(Console.ReadLine()));
                }

                aluno.CalcularMedia();
                aluno.DeterminarSituacao();

                Console.Clear();
                Console.WriteLine($"| Resultado: {aluno.Nome} foi: {aluno.Situacao}");

                alunos.Add(aluno);

                Console.WriteLine("\n| 1 - Continuar    |   2 - Sair |\n- Opção Escolhida: ");
                int op = int.Parse(Console.ReadLine());
                if (op != 1)
                    break;
            }

            MostrarResumo();
        }

        private void MostrarResumo()
        {
            Console.Clear();
            Console.WriteLine("| Resumo Final dos Alunos |");
            Console.WriteLine("--------------------------------------");

            foreach (var aluno in alunos)
            {
                Console.WriteLine($"Aluno: {aluno.Nome}");
                Console.WriteLine($"Faltas: {aluno.Faltas}");
                Console.WriteLine($"Média Final: {aluno.MediaFinal:F2}");
                Console.WriteLine($"Situação: {aluno.Situacao}");
                Console.WriteLine("--------------------------------------");
            }

            Console.WriteLine("Fim da listagem. Pressione qualquer tecla para encerrar.");
            Console.ReadKey();
        }
    }
}
