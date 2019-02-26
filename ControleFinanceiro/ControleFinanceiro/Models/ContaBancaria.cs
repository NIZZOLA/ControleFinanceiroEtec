using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleFinanceiro.Models
{
    public class ContaBancaria
    {
        public int ContaBancariaId { get; set; }

        public int Agencia { get; set; }
        public int DigitoAgencia { get; set; }
        public int Numero { get; set; }
        public int DigitoNumero { get; set; }

        public decimal Saldo { get; set; }

        public bool Ativa { get; set; }
        public DateTime DataAbertura { get; set; }
        public DateTime? DataEncerramento { get; set; }

        public Cliente Cliente { get; set; }
    }
}
