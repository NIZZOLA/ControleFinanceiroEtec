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
            if (!Validate())
                return;
        }

        private bool Validate()
        {
            if( ! Helpers.ValidaCpf( mskCpf.Text ))
            {
                MessageBox.Show("O CPF não é válido !");
                return false;
            }

            if( ! DateTime.TryParse( mskNascimento.Text, out DateTime data ) )
            {
                MessageBox.Show("A data de nascimento não é válida !");
                return false;
            }

            return true;
        }

    }
}
