using Eleições2020.Views;

namespace Eleições2020.Models
{
    class CandidatoValidator
    {
        private string ValidarCandidato(Candidato candidato)
        {
            string erros = "";
            if (string.IsNullOrWhiteSpace(candidato.Nome))
            {
                erros += "O nome está vazio";
            }
            else if (candidato.Nome.Length <= 3 || candidato.Nome.Length >= 65)
            {
                erros += "O nome deve conter entre 3 e 65 caracteres\n";
            }
            else if (string.IsNullOrEmpty(candidato.Partido))
            {
                erros += "O partido deve ser informado!!\n";
            }
            for (int i = 0; i < candidato.Nome.Length; i++)
            {
                if (!char.IsLetter(candidato.Nome[i]) && !char.IsWhiteSpace(candidato.Nome[i]))
                {
                    erros += "Nome inválido! Um caractere inválido foi indentificado no nome\n";
                    break;
                }
            }
            foreach (Candidato c in Eleicao.candidatos)
            {
                if (c.Numero == candidato.Numero)
                {
                    erros += "Já existe outro candidato com este número\n";
                }
            }
            return erros;
        }

        public string Validar(Candidato c)
        {
            return ValidarCandidato(c);
        }
    }
}
