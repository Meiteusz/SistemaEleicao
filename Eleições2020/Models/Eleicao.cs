using Eleições2020.Models;
using System.Collections.Generic;

namespace Eleições2020.Views
{
    public class Eleicao
    {
        CandidatoValidator validator = new CandidatoValidator();
        public static List<Candidato> candidatos = new List<Candidato>();

        public int votosTotais { get; set; }

        public string AdicionarCandidato(Candidato candidato)
        {
            if (string.IsNullOrWhiteSpace(validator.Validar(candidato)))
            {
                candidatos.Add(candidato);
                return "Candidato Validado com sucesso";
            }
            else
            {
                string erros = validator.Validar(candidato);
                return erros;
            }
        }

        public bool IsEleicaoValida()
        {
            if (candidatos.Count >= 2)
            {
                return true;
            }
            return false;
        }

        public string SetarVencedorOuEmpate()
        {
            string resultado = "";
            int maiorQtdVotos = 0;
            foreach (Candidato c in Eleicao.candidatos)
            {
                if (c.Votos > maiorQtdVotos)
                {
                    resultado = c.Nome;
                    maiorQtdVotos = c.Votos;
                }
                else if (c.Votos == maiorQtdVotos)
                {
                    resultado = "EMPATE";
                }
            }
            return resultado;
        }
    }
}
