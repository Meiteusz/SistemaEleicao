namespace Eleições2020.Models
{
    public class Candidato
    {
        public Candidato(string p_nome, string p_numero)
        {
            Nome = p_nome;
            Numero = p_numero;
        }

        public override string ToString()
        {
            return nome;
        }

        private string partido;
        public string Partido
        {
            get
            {
                return partido;
            }
            set
            {
                partido = value;
            }
        }

        private string numero;
        public string Numero
        {
            get
            {
                return numero;
            }
            set
            {
                numero = value;
            }
        }

        private string nome;
        public string Nome
        {
            get
            {
                return nome;
            }
            set
            {
                nome = value;
            }
        }

        private int votos;
        public int Votos
        {
            get
            {
                return votos;
            }
            set
            {
                votos = value;
            }
        }
    }
}
