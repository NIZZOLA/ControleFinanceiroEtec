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

            return true;
        }

    }
}
