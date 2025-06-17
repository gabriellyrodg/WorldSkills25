using System;

class Program
{
    static void Main()
    {
        int resultado = 0;

        for (int i = 1; i <= 100; i++)
        {
            Console.WriteLine(resultado);
            resultado += i;
        }
    }
}