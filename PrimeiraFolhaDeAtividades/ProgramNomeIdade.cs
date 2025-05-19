using System;

class Program
{
    static string NomeEIdade(string nome, string idade)
    {
        return $"Nome: {nome}\n Idade: {idade}";
    }
    static int Verificador(int verificacao)
    {
        if (verificacao >= 18) {
            return 1;
        }
        else {
            return 0;
        }
    }
     static void Main()
        {
            Console.Write("Digite seu nome: ");
            string NomePessoa = Console.ReadLine();
            Console.WriteLine("Digite sua idade: ");
            string Idadepessoa = Console.ReadLine();
            Console.WriteLine(NomeEIdade(NomePessoa, Idadepessoa));
            int idadeint = int.Parse(Idadepessoa);
            int resultado = Verificador(idadeint);
            if (resultado == 1)
            {
                Console.WriteLine("Voce é maior de idade!");
            }
            else
            {
                Console.WriteLine("Voce é menor de idade.");
            }
        }
    }

