using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        public string CPF { get; set; }

        public string Nome { get; set; }

        public string Telefone { get; set; }

        public string Email { get; set; }

        public DateTime Nascimento { get; set; }
        public bool Ativo { get; set; }
    }
}
