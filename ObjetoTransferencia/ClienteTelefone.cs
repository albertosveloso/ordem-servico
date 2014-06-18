using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class ClienteTelefone
    {
        public Cliente Cliente { get; set; }
        public decimal Telefone { get; set; }

        public ClienteTelefone() {
            this.Cliente = new Cliente();
        }
    }



    public class ClienteTelefoneLista : List<ClienteTelefone> { }
}
