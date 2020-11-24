using Eleições2020.Models;
using Eleições2020.Views;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Eleições2020
{
    public partial class Form1 : Form
    {
        Font fonteNumero = new Font("Segoe WP", 15, FontStyle.Bold);
        Font fonteNome = new Font("Segoe WP", 13);
        
        public static Eleicao novaEleicao = new Eleicao();
        public string PonteNumero { get; set; }

        List<Partido> partidos = new List<Partido>()
        {
            new Partido("MDB"),
            new Partido("PT"),
            new Partido("PSDB")
        };

        public Form1()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            livrarTab0();
            btnFechar.Enabled = false;
            cmbPartido.DataSource = partidos;
        }

        private void livrarTab0()
        {
            tabControl1.TabPages[0].Enabled = true;
            tabControl1.TabPages[1].Enabled = false;
            tabControl1.TabPages[2].Enabled = false;
        }

        private void livrarTab1()
        {
            tabControl1.TabPages[0].Enabled = false;
            tabControl1.TabPages[1].Enabled = true;
            tabControl1.TabPages[2].Enabled = false;
        }

        private void livrarTab2()
        {
            tabControl1.TabPages[0].Enabled = false;
            tabControl1.TabPages[1].Enabled = false;
            tabControl1.TabPages[2].Enabled = true;
        }

        private void livrarTab3()
        {
            tabControl1.TabPages[0].Enabled = false;
            tabControl1.TabPages[1].Enabled = false;
            tabControl1.TabPages[2].Enabled = false;
            tabControl1.TabPages[3].Enabled = true;
        }

        // Botoes
        private void btnIniciar_Click(object sender, EventArgs e)
        {
            tabControl1.SelectTab(1);
            livrarTab1();
            txtNumero.Enabled = false;
            txtNome.Enabled = false;
            cmbPartido.SelectedIndex = -1;
        }

        private void btnDefinirNumero_Click(object sender, EventArgs e)
        {
            btnDefinirNumero.Enabled = false;
            FormNumero formNumero = new FormNumero(this);
            formNumero.ShowDialog();
            txtNome.Enabled = true;
            txtNome.Font = fonteNome;
            txtNome.Focus();
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            Close();
        }

        Candidato candidato;
        private void btnSalvar_Click(object sender, EventArgs e)
        {
            ValidarFechamentoDeFormNumero();
        }

        private void btnIrParaVotação_Click(object sender, EventArgs e)
        {
            if (novaEleicao.IsEleicaoValida())
            {
                livrarTab2();
                cmbCandidatos.DataSource = Eleicao.candidatos;
                tabControl1.SelectTab(2);
                cmbCandidatos.SelectedIndex = -1;
            }
            else
            {
                MessageBox.Show("Deve ter pelo menos DOIS candidatos cadastrados para seguir adiante!!");
            }
        }

        private void btnVotar_Click(object sender, EventArgs e)
        {
            ValidarVoto();
        }

        private void btnIrParaResultado_Click(object sender, EventArgs e)
        {
            tblResultadoDaEleição.DataSource = Eleicao.candidatos;
            VerificarVotosTotais();
            btnFechar.Enabled = true;
            btnIrParaVotacaoNovamente.Enabled = true;
            tblResultadoDaEleição.Columns["Partido"].Width = 50;
            tblResultadoDaEleição.Columns["Numero"].Width = 50;
            tblResultadoDaEleição.Columns["Votos"].Width = 60;
        }

        private void btnIrParaVotacaoNovamente_Click(object sender, EventArgs e)
        {
            btnIrParaVotacaoNovamente.Enabled = false;
            ZerarVotos();
            tabControl1.SelectTab(2);
            livrarTab2();
        }

        // Métodos
        public void ValidarFechamentoDeFormNumero()
        {
            if (string.IsNullOrWhiteSpace(PonteNumero))
            {
                MessageBox.Show("Nenhum número informado!");
                btnDefinirNumero.Enabled = true;
                txtNome.Clear();
                txtNumero.Clear();
                cmbPartido.SelectedIndex = -1;
                return;
            }
            else
            {
                btnDefinirNumero.Enabled = true;
                candidato = new Candidato(txtNome.Text.Trim(), txtNumero.Text);
                candidato.Partido = cmbPartido.Text;
                MessageBox.Show(novaEleicao.AdicionarCandidato(candidato));
                txtNome.Clear();
                txtNumero.Clear();
                cmbPartido.SelectedIndex = -1;
                PonteNumero = "";
            }
        }

        public void PopularTxtNumero()
        {
            txtNumero.Text = PonteNumero;
            txtNumero.Font = fonteNumero;
        }

        public void ValidarVoto()
        {
            if (string.IsNullOrWhiteSpace(cmbCandidatos.Text))
            {
                MessageBox.Show("Nenhum candidato foi selecionado");
            }
            else
            {
                foreach (Candidato c in Eleicao.candidatos)
                {
                    if (c.Nome == cmbCandidatos.Text)
                    {
                        c.Votos += 1;
                        novaEleicao.votosTotais++;
                        MessageBox.Show($"Voto no candidato {c.Nome} registrado");
                    }
                }
            }
        }

        public void LimparTxtNumero()
        {
            txtNumero.Clear();
        }

        public void ZerarVotos()
        {
            novaEleicao.votosTotais = 0;
            foreach (Candidato c in Eleicao.candidatos)
            {
                c.Votos = 0;
            }
        }

        public void VerificarVotosTotais()
        {
            if (novaEleicao.votosTotais < 1)
            {
                MessageBox.Show("Nenhum voto foi registrado!!");
                return;
            }
            else
            {
                livrarTab3();
                tabControl1.SelectTab(3);
                tabControl1.TabPages[3].Enabled = true;
                labVencedor.Text = novaEleicao.SetarVencedorOuEmpate();
                AtivarbtnIrParaVotacaoNovamente();
            }
        }

        public void AtivarbtnIrParaVotacaoNovamente()
        {
            if (novaEleicao.SetarVencedorOuEmpate() == "EMPATE")
            {
                btnFechar.Visible = false;
                btnIrParaVotacaoNovamente.Visible = true;
                cmbCandidatos.SelectedIndex = -1;
                return;
            }
            else
            {
                btnFechar.Visible = true;
                btnIrParaVotacaoNovamente.Visible = false;
                return;
            }
        }
    }
}
