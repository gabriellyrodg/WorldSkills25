﻿using System;
using System.Collections.Generic;

public static class Atendente
{
    public static string FalarComAtendente()
    {
        Console.Clear();
        var respostas = new Dictionary<string, string>
        {
            { "olá", "Oi! Como posso te ajudar hoje?" },
            { "oi", "E aí! Tudo certo?" },
            { "bom dia", "Bom diaaa! Café passado?" },
            { "boa tarde", "Boa tarde!" },
            { "boa noite", "Boa noite! Hora de descansar" },
            { "ajuda", "Claro! Me diga no que você precisa." },
            { "obrigado", "Qualquer coisa é só falar." },
            { "tchau", " Até a próxima!" }
        };

        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("|     Atendente Automático       |\n--------------------------------------------");
        while (true)
        {
            Console.Write("Digite sua mensagem: ");
            string input = Console.ReadLine().ToLower();

            if (input == "sair")
            {
                Console.WriteLine("Atendente: Falou! Até mais");
                break;
            }

            bool respondeu = false;

            foreach (var chave in respostas.Keys)
            {
                if (input.Contains(chave))
                {
                    Console.WriteLine("Atendente: " + respostas[chave]);
                    respondeu = true;
                }
                else 
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Atendente: Não consegui entender, sinto muito! Posso te encaminhar para o Suporte tecnico se for um problema.\n Pressione 1 para ir para o suporte tecnico ou 2 para continuar no chat: ")
                    int help = int.Parse(Console.ReadLine())
                    if (help == 1)
                    {
                        SuporteTecnico.Suporte();
                    }
                    else if (help == 2)
                    {
                        Atendente.FalarComAtendente();
                    }
                    else 
                    {
                        Console.WriteLine("Opção Invalida. Retornando para o menu...")
                        Menu.MenuPrincipal(1);
                    }
                }
                    
            }

            if (!respondeu)
            {
                Console.WriteLine("Atendente: Não saquei o que você quis dizer");
                Menu.back();
            }
        }
        Menu.back();
        return "";
    }
}
