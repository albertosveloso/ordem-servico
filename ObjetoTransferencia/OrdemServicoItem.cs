using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class OrdemServicoItem
    {
        public OrdemServico OrdemServico { get; set; }
        public Servico Servico { get; set; } //Verificar se é necessário colocar quantidade e valor total já que o cliente não vai pedir o mesmo serviço duas vezes
        public decimal ValorTotal { get; set; }
    }

    public class OrdemServicoItemLista : List<OrdemServicoItem> { }
}
