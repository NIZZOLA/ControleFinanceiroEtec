using ControleFinanceiro.Data;
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
    public partial class FormCliente : Form
    {
        // instancia o contexto para utilização dentro do form
        private ControleContext ctx = new ControleContext();
        
        public FormCliente()
        {
            InitializeComponent();
            CarregaGrid();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            LimpaCores();

            if (!Validate())
                return;
            /* formas de se passar informações para um objeto
             * 
            // exemplo 1 - forma mais verbosa
            Cliente cli = new Cliente();
            cli.Nome = txtNome.Text;
            cli.CPF = mskCpf.Text;
            //cli.ClienteId = Convert.ToInt32( txtCodigo.Text );
            cli.ClienteId = int.Parse(txtCodigo.Text);
            cli.Email = txtEmail.Text;
            cli.Nascimento = DateTime.Parse(mskNascimento.Text);
            cli.Telefone = mskTelefone.Text;
            
            //exemplo 2 
            Cliente cli2 = new Cliente() { Nome = txtNome.Text, CPF = mskCpf.Text,
             ClienteId = int.Parse(txtCodigo.Text), Email = txtEmail.Text,
            Nascimento = DateTime.Parse(mskNascimento.Text), Telefone = mskTelefone.Text };
            */

            if (txtCodigo.Text == "")
            {
                // exemplo 3 - com construtor
                Cliente cli3 = new Cliente(txtCodigo.Text, mskCpf.Text, txtNome.Text,
                    mskTelefone.Text, txtEmail.Text, mskNascimento.Text);

                // adiciona no contexto um novo cliente
                ctx.Clientes.Add(cli3);
            }
            else
            {
                // criar variavel com o código
                int codigo = Convert.ToInt32(txtCodigo.Text);
                // buscar a entidade direto do banco
                var exist = ctx.Clientes
                    .Where(a => a.ClienteId == codigo )
                    .FirstOrDefault();

                exist.Nome = txtNome.Text;
                exist.CPF = mskCpf.Text;
                exist.Nascimento = DateTime.Parse( mskNascimento.Text);
                exist.Telefone = mskTelefone.Text;
                exist.Ativo = chkAtivo.Checked;
                exist.Email = txtEmail.Text;
                // vincula o novo cadastro alterado do cliente e informa que foi modificado
                ctx.Clientes.Attach(exist);
                ctx.Entry(exist).State = System.Data.Entity.EntityState.Modified;
            }
            // salva-se o conteúdo do contexto
            ctx.SaveChanges();
            CarregaGrid();
            // adiciona o objeto "cli3" na lista
            //lista.Add(cli3);

            // obtem o maior código do cliente inserido na lista
            //int novocodigo = lista.Max(a => a.ClienteId) + 1;
            // atribui o código ao campo txtCodigo da tela
            // txtCodigo.Text = novocodigo.ToString();
            // DECLARAÇÃO MENOS VERBOSA !!!!
            //txtCodigo.Text = (lista.Max(a => a.ClienteId) + 1).ToString();

            // atribui ao objeto datagridview1 a lista como fonte de dados
            // e ordena por nome 
            //dataGridView1.DataSource = lista.OrderBy(a => a.Nome).ToList();
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

        private void CarregaGrid()
        {
            dataGridView1.DataSource = ctx.Clientes.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            string valor = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            CarregaCliente(Convert.ToInt32(valor));
        }

        private void CarregaCliente( int codigo )
        {
            var cliente = ctx.Clientes.Where(a => a.ClienteId == codigo).FirstOrDefault();
            if (cliente != null)
            {
                LimpaCores();
                txtCodigo.Text = cliente.ClienteId.ToString();
                txtNome.Text = cliente.Nome;
                txtEmail.Text = cliente.Email;
                mskCpf.Text = cliente.CPF;
                mskNascimento.Text = cliente.Nascimento.ToString("dd/MM/yyyy");
                mskTelefone.Text = cliente.Telefone;
                chkAtivo.Checked = cliente.Ativo;
            }
            else
                MessageBox.Show("Houve erro ao carregar o código " + codigo);
        }


    }
}