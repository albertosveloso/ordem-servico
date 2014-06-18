using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class OrdemServico
    {
        public int? IdOrdemServico { get; set; }
        public DateTime DataCadastro { get; set; }
        public Cliente Cliente { get; set; }
        public decimal ValorTotal { get; set; }
    }

    public class OrdemServicoLista : List<OrdemServico> { }
}
