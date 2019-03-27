using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models
{
    [Table("Cliente")]
    public class Cliente
    {
        // ctor + 2 x tab
        public Cliente()
        {
           
        }

        public Cliente( string codigo, string cpf, string nome, string telefone, 
            string email, string nascimento, bool? ativo = true )
        {
            if( codigo != "" )
                this.ClienteId = int.Parse( codigo );
            this.CPF = cpf;
            this.Nome = nome;
            this.Telefone = telefone;
            this.Email = email;
            this.Nascimento = DateTime.Parse(nascimento);
        }

        [Key]
        public int ClienteId { get; set; }

        [MaxLength(18)]
        public string CPF { get; set; }

        [MaxLength(50)]
        public string Nome { get; set; }

        [MaxLength(15)]
        public string Telefone { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        public DateTime Nascimento { get; set; }
        public bool Ativo { get; set; }
    }
}
