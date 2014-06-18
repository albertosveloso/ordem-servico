using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoDados;
using ObjetoTransferencia;
using System.Data.SqlClient;
using System.Data;

namespace Negocios
{
    public class NegOrdemServico
    {
        //Objeto responsavel pelo comunicação com banco de dados
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        //Inserir ordem de serviço
        public string Inserir(OrdemServico ordemServico)
        {
            try
            {
                string sql = "INSERT INTO tblOrdemServico(DataCadastro, IdCliente, ValorTotal) VALUES " +
                    "(@DataCadastro, @IDCliente, @ValorTotal) SELECT @@IDENTITY";

                acessoDados.LimparParametros();
                acessoDados.AdicionarParametro(new SqlParameter("@DataCadastro", DateTime.Now));
                acessoDados.AdicionarParametro(new SqlParameter("@IdCliente", ordemServico.Cliente.IdCliente));
                acessoDados.AdicionarParametro(new SqlParameter("@ValorTotal", ordemServico.ValorTotal));

                return acessoDados.ExecutarScalar(sql, CommandType.Text).ToString();
            }
            catch (Exception ex)
            {
                //tratamento de excessão - mensagem ao usuário
                throw new Exception("Falha ao inserir ordem de servico. Motivo: " + ex.Message);
            }

        }

        //Alterar ordem de serviço
        public string Alterar(OrdemServico ordemServico)
        {
            try
            {
                string sql = "UPDATE tblOrdemServico set DataCadastro = @DataCadastro, IdCliente = @IdCliente, " +
                    "ValorTotal = @ValorTotal where IdOrdemServico = @IdOrdemServico select @IdOrdemServico";

                acessoDados.LimparParametros();
    
                acessoDados.AdicionarParametro(new SqlParameter("@DataCadastro", ordemServico.DataCadastro));
                acessoDados.AdicionarParametro(new SqlParameter("@IdCliente", ordemServico.Cliente.IdCliente));
                acessoDados.AdicionarParametro(new SqlParameter("@ValorTotal", ordemServico.ValorTotal));

                return acessoDados.ExecutarScalar(sql, CommandType.Text).ToString();
            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao alterar ordem de servico. Motivo: " + ex.Message);
            }
        }

        //Excluir ordem de serviço
        public string Excluir(OrdemServico ordemServico)
        {
            try
            {
                string sql = "DELETE FROM tblOrdemServicoItem where IdOrdemSErvico = @idOrdemServico DELETE FROM tblOrdemServico WHERE IdOrdemServico = @IdOrdemServico SELECT @IdOrdemServico";

                acessoDados.LimparParametros();
                acessoDados.AdicionarParametro(new SqlParameter("@IdOrdemServico", ordemServico.IdOrdemServico));

                return acessoDados.ExecutarScalar(sql, CommandType.Text).ToString();

            }
            catch (Exception ex)
            {

                throw new Exception("Falha ao excluir ordem de serviço. Motivo: " + ex.Message);
            }
        }

        //Consultar ordem de serviço
        public OrdemServicoLista Consultar(DateTime dataInicial, DateTime dataFinal)
        {
            try
            {
                string sql = "SELECT o.IdOrdemServico, o.DataCadastro, o.IdCliente, c.Nome, o.ValorTotal " +
                             "FROM tblOrdemServico AS o JOIN tblCliente as c ON (c.IdCliente = o.IdCliente) " +
                             "WHERE CAST(o.DataCadastro AS date) " +
                             "BETWEEN @DataInicio AND @DataFinal";

                acessoDados.LimparParametros();
                acessoDados.AdicionarParametro(new SqlParameter("@DataInicio", dataInicial.Date));
                acessoDados.AdicionarParametro(new SqlParameter("@DataFinal", dataFinal.Date));

                OrdemServicoLista lista = new OrdemServicoLista();
                using (DataTable tabela = acessoDados.ExecutarConsulta(sql, CommandType.Text))
                {
                    foreach (DataRow linha in tabela.Rows)
                    {
                        OrdemServico novaOrdemServico = new OrdemServico();

                        novaOrdemServico.IdOrdemServico = Convert.ToInt32(linha["IdOrdemServico"]);
                        novaOrdemServico.DataCadastro = Convert.ToDateTime(linha["DataCadastro"]);

                        novaOrdemServico.Cliente = new Cliente
                        {
                            IdCliente = Convert.ToInt32(linha["IdCliente"]),
                            Nome = (linha["Nome"]).ToString()
                        };

                        novaOrdemServico.ValorTotal = Convert.ToDecimal(linha["ValorTotal"]);

                        lista.Add(novaOrdemServico);
                    }
                }

                return lista;

            }
            catch (Exception ex)
            {

                throw new Exception("Falha ao consultar ordem de serviço. Motivo: " + ex.Message);
            }
        }

        //Incluir Valor Total
        public string IncluirValorTotal(OrdemServico ordem)
        {
            try 
	        {	        
		        string sql = "UPDATE tblOrdemServico set ValorTotal = @ValorTotal WHERE IdOrdemServico = @IdOrdemServico select @IdOrdemServico";
    
                acessoDados.LimparParametros();
                acessoDados.AdicionarParametro(new SqlParameter("@ValorTotal", ordem.ValorTotal));
                acessoDados.AdicionarParametro(new SqlParameter("@IdOrdemServico", ordem.IdOrdemServico));

                return acessoDados.ExecutarScalar(sql, CommandType.Text).ToString();
	        }
	        catch (Exception ex)
	        {
		
		         throw new Exception("Falha ao adicionar valor a ordem de serviço. Motivo: " + ex.Message);
            }

            
            
        }

    }
}
