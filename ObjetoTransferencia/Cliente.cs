using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class Cliente
    {
        public int? IdCliente { get; set; }
        public string Nome { get; set; }
        public decimal CPF { get; set; }
        public DateTime DataCadastro { get; set; }

        public override string ToString()
        {
            return this.Nome;
        }
    }

    public class ClienteLista : List<Cliente> { }
}
