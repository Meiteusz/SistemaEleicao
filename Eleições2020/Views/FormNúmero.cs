using System;
using System.Windows.Forms;

namespace Eleições2020.Views
{
    public partial class FormNumero : Form
    {
        Form1 FormPrincipal;

        public FormNumero(Form1 f)
        {
            FormPrincipal = f;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private string numero = "";

        public void DesativarBotoes()
        {
            btn1.Enabled = false;
            btn2.Enabled = false;
            btn3.Enabled = false;
            btn4.Enabled = false;
            btn5.Enabled = false;
            btn6.Enabled = false;
            btn7.Enabled = false;
            btn8.Enabled = false;
            btn9.Enabled = false;
            return;
        }

        public void AtivarBotoes()
        {
            btn1.Enabled = true;
            btn2.Enabled = true;
            btn3.Enabled = true;
            btn4.Enabled = true;
            btn5.Enabled = true;
            btn6.Enabled = true;
            btn7.Enabled = true;
            btn8.Enabled = true;
            btn9.Enabled = true;
            return;
        }

        #region Numericos
        private void btn1_Click(object sender, EventArgs e)
        {
            numero += "1";
            labNumero.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            numero += "2";
            labNumero.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            numero += "3";
            labNumero.Text += "3";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            numero += "4";
            labNumero.Text += "4";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            numero += "5";
            labNumero.Text += "5";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            numero += "6";
            labNumero.Text += "6";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            numero += "7";
            labNumero.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            numero += "8";
            labNumero.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            numero += "9";
            labNumero.Text += "9";

        }
        #endregion

        public string ValidarDoisNumeros()
        {
            if (numero.Length != 2)
            {
                DesativarBotoes();
                FormPrincipal.LimparTxtNumero();
                numero = "";
                labNumero.Text = "";
                AtivarBotoes();
                return "DOIS números devem ser informados!!!";
            }
            else
            {
                FormPrincipal.PonteNumero = numero;
                FormPrincipal.PopularTxtNumero();
                Close();
            }
            return "\t✔\t";
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ValidarDoisNumeros());
        }

        private void FormNumero_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (numero.Length != 2)
            {
                e.Cancel = true;
            }
        }

        private void btnApagar_Click(object sender, EventArgs e)
        {
            labNumero.Text = "";
            numero = "";
        }
    }
}
