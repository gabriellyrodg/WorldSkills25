using System;
using System.Collections.Generic;

namespace SaldoDeFaltas
{
    public class Aluno
    {
        public string Nome { get; set; }
        public int Faltas { get; set; }
        public List<double> Notas { get; set; } = new List<double>();
        public double MediaFinal { get; private set; }
        public string Situacao { get; private set; }

        public void CalcularMedia()
        {
            double soma = 0;
            foreach (var nota in Notas)
                soma += nota;

            MediaFinal = Notas.Count > 0 ? soma / Notas.Count : 0;
        }

        public void DeterminarSituacao()
        {
            if (Faltas > 120)
                Situacao = "Reprovado por faltas";
            else if (MediaFinal < 4)
                Situacao = "Reprovado por nota";
            else if (MediaFinal < 6)
                Situacao = "Recuperação";
            else
                Situacao = "Aprovado";
        }
    }
}
