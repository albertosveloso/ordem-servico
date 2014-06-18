using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class Servico
    {
        public int? IdServico { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataCadastro { get; set; }

        //Atenção !!!!!!
        //Para que o nome do servico apareça corretamente no grid é necessário fazer os seguintes passos:
        public override string ToString() //Modificando o método to string 
        {
            return this.Nome;
        }


    }

    public class ServicoLista : List<Servico> { }
}
