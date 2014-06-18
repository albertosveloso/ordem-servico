using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class ClienteEndereco
    {
        public Cliente Cliente { get; set; }
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public decimal CEP { get; set; }

        public ClienteEndereco() {
            this.Cliente = new Cliente();
        }
    }

    public class ClienteEnderecoLista : List<ClienteEndereco> { }
}

