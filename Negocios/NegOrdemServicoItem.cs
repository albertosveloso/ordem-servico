using AcessoDados;
using ObjetoTransferencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocios
{
    public class NegOrdemServicoItem
    {
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        //Inserir item a ordem de serviço
        public string Inserir(OrdemServicoItem ordemServicoItem)
        {
            try
            {
                string sql = "INSERT INTO tblOrdemServicoItem(IdOrdemServico, IdServico, ValorTotal) values (@IdOrdemServico, @IdServico, @ValorTotal)" + 
                    " select @IdOrdemServico";

                acessoDados.LimparParametros();
                acessoDados.AdicionarParametro(new SqlParameter("@IdOrdemServico", ordemServicoItem.OrdemServico.IdOrdemServico));
                acessoDados.AdicionarParametro(new SqlParameter("@IdServico", ordemServicoItem.Servico.IdServico));
                acessoDados.AdicionarParametro(new SqlParameter("@ValorTotal", ordemServicoItem.ValorTotal));

                return acessoDados.ExecutarScalar(sql, CommandType.Text).ToString();

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao inserir item na ordem de servico. Motivo: " + ex.Message);
            }
        }

        //Alterar item da ordem de serviço
        public string Alterar(OrdemServicoItem ordemServicoItem)
        {
            try
            {
                string sql = "UPDATE tblOrdemServicoitem SET ValorTotal = @ValorTotal WHERE " +
                "IdOrdemServico = @IdOrdemServico AND " + 
                "IdServico = @IdServico SELECT @IdOrdemServico";

                acessoDados.LimparParametros();
                acessoDados.AdicionarParametro(new SqlParameter("@IdOrdemServico", ordemServicoItem.OrdemServico.IdOrdemServico));
                acessoDados.AdicionarParametro(new SqlParameter("@IdServico", ordemServicoItem.Servico.IdServico));
                acessoDados.AdicionarParametro(new SqlParameter("@ValorTotal", ordemServicoItem.ValorTotal));

                return acessoDados.ExecutarScalar(sql, CommandType.Text).ToString();

            }
            catch (Exception ex)
            {
                
                throw new Exception("Falha ao alterar item da ordem de serviço. Motivo: " + ex.Message);
            }
        
        }

        //Excluir item da ordem de serviço
        public string Excluir(OrdemServicoItem ordemServicoItem)
        {
            try
            {
                string sql = "DELETE FROM tblOrdemServicoItem where IdOrdemServico = @IdOrdemServico AND IdServico = @IdServico select @IdOrdemServico";

                acessoDados.LimparParametros();

                acessoDados.AdicionarParametro(new SqlParameter("@IdOrdemServico", ordemServicoItem.OrdemServico.IdOrdemServico));
                acessoDados.AdicionarParametro(new SqlParameter("@IdServico", ordemServicoItem.Servico.IdServico));

                return acessoDados.ExecutarScalar(sql, CommandType.Text).ToString();

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao excluir item da ordem de serviço. Motivo: " + ex.Message);
            }
        
        }

        //Consultar item
        public OrdemServicoItemLista Consultar(int IdOrdemServico)
        {
            try
            {
                string sql = "SELECT os.IdOrdemServico, os.IdServico, s.Nome, os.ValorTotal FROM tblOrdemServicoItem as os JOIN	tblServico as s " +
                "ON s.IdServico = os.IdServico WHERE os.IdOrdemServico = @IdOrdemServico";

                acessoDados.LimparParametros();

                acessoDados.AdicionarParametro(new SqlParameter("@IdOrdemServico", IdOrdemServico));

                OrdemServicoItemLista lista = new OrdemServicoItemLista();

                using (DataTable tabela = acessoDados.ExecutarConsulta(sql, CommandType.Text))
                { 
                    foreach(DataRow linha in tabela.Rows)
                    {
                        OrdemServicoItem novoOrdemServicoItem = new OrdemServicoItem();

                        novoOrdemServicoItem.OrdemServico = new OrdemServico
                        {
                            IdOrdemServico  = Convert.ToInt32(linha["IdOrdemServico"])
                        };

                        novoOrdemServicoItem.Servico = new Servico
                        {
                            IdServico = Convert.ToInt32(linha["IdServico"]),
                            Nome = linha["Nome"].ToString()
                        };

                        novoOrdemServicoItem.ValorTotal = Convert.ToDecimal(linha["ValorTotal"]);

                        lista.Add(novoOrdemServicoItem);
                    }
                
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao consultar item da ordem de servico. Motivo: " + ex.Message);
            }
            
        }


    }
}
