using ControleFinanceiro.Models;
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
    public partial class FormContaCorrente : Form
    {
        public FormContaCorrente()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            // validação dos campos

            ContaBancaria cta = new ContaBancaria( );
        }
    }
}
