using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models
{
    public class Cliente
    {
        // ctor + 2 x tab
        public Cliente()
        {
           
        }

        public Cliente( string codigo, string cpf, string nome, string telefone, 
            string email, string nascimento, bool? ativo = true )
        {
            this.ClienteId = int.Parse( codigo );
            this.CPF = cpf;
            this.Nome = nome;
            this.Telefone = telefone;
            this.Email = email;
            this.Nascimento = DateTime.Parse(nascimento);
        }

        public int ClienteId { get; set; }

        public string CPF { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public DateTime Nascimento { get; set; }
        public bool Ativo { get; set; }
    }
}
