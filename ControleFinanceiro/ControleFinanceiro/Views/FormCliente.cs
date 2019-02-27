using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControleFinanceiro.Views
{
    public partial class FormCliente : Form
    {
        public FormCliente()
        {
            InitializeComponent();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            LimpaCores();

            if (!Validate())
                return;
        }

        private bool Validate()
        {
            string mensagem = "";
            bool retorno = true;

            if (!Helpers.ValidaCpf(mskCpf.Text))
            {
                mensagem += "O CPF não é válido !\n";
                mskCpf.BackColor = Color.Red;
                retorno = false;
            }

            if (!DateTime.TryParse(mskNascimento.Text, out DateTime data))
            {
                mensagem += "A data de nascimento não é válida !\n";
                mskNascimento.BackColor = Color.Red;
                retorno = false;
            }

            if( ! Helpers.ValidarEmail( txtEmail.Text ) )
            {
                mensagem += "O campo e-mail não é valido !\n";
                txtEmail.BackColor = Color.Red;
                retorno = false;
            }

            if (mensagem != "")
                MessageBox.Show(mensagem, "ERRO DE PREENCHIMENTO",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            return retorno;
        }

        private void LimpaCores()
        {
            mskNascimento.BackColor = Color.White;
            mskCpf.BackColor = Color.White;
            txtEmail.BackColor = Color.White;
        }


    }
}