using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using AcessoDados;
using ObjetoTransferencia;



namespace Negocios
{
    public class NegServico
    {
        //Objeto responsável pela conexão com o banco de dados
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        //Inserir serviço
        public string Inserir(Servico servico)
        {
            try
            {
                string sql = "INSERT INTO tblservico(nome, descricao, valor, datacadastro)" +
                    " VALUES (@nome, @descricao, @valor, @datacadastro) SELECT @@IDENTITY";

                acessoDados.LimparParametros();
                acessoDados.AdicionarParametro(new SqlParameter("@nome", servico.Nome));
                acessoDados.AdicionarParametro(new SqlParameter("@descricao", servico.Descricao));
                acessoDados.AdicionarParametro(new SqlParameter("@valor", servico.Valor));
                acessoDados.AdicionarParametro(new SqlParameter("@datacadastro", DateTime.Now));

                return acessoDados.ExecutarScalar(sql, CommandType.Text).ToString();

            }
            catch (Exception ex)
            {
                
                throw new Exception("Falha ao inserir serviço. Motivo: " +ex.Message);
            }
        }

     


        //Consultar serviço
        public ServicoLista Consultar(string nome)
        {
            try
            {
                string sql = "select idservico, nome, descricao, valor, datacadastro from tblservico where nome like '%'+ @nome +'%'";

                acessoDados.LimparParametros();
                acessoDados.AdicionarParametro(new SqlParameter("@nome", nome));

                ServicoLista lista = new ServicoLista();
                using (DataTable tabela = acessoDados.ExecutarConsulta(sql,CommandType.Text))
                {
                    foreach(DataRow linha in tabela.Rows)
                    {
                        Servico servico = new Servico();
                        servico.IdServico = Convert.ToInt32(linha["idservico"]);
                        servico.Nome = linha["nome"].ToString();
                        servico.Descricao = linha["descricao"].ToString();
                        servico.Valor = Convert.ToDecimal(linha["valor"]);
                        servico.DataCadastro = Convert.ToDateTime(linha["datacadastro"]);

                        lista.Add(servico);
                        
                    }
                
                }

                return lista;
            }
            catch (Exception ex)
            {
                
                throw new Exception("Falha ao consultar serviço. Motivo: " + ex.Message);
            }
        
        }

        //Alterar serviço
        public string Alterar(Servico servico)
        {
            try
            {
                string sql = "UPDATE tblServico SET nome = @nome, descricao = @descricao, valor = @valor " +
                    "WHERE idservico = @idservico select @idservico";

                acessoDados.LimparParametros();
                acessoDados.AdicionarParametro(new SqlParameter("@nome", servico.Nome));
                acessoDados.AdicionarParametro(new SqlParameter("@descricao", servico.Descricao));
                acessoDados.AdicionarParametro(new SqlParameter("@valor", servico.Valor));
                acessoDados.AdicionarParametro(new SqlParameter("@idservico", servico.IdServico));

                return acessoDados.ExecutarScalar(sql, CommandType.Text).ToString();


            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao alterar serviço. Motivo: " + ex.Message);
            }
        }

        //Excluir serviço
        public string Excluir(Servico servico)
        {
            try
            {
                string sql = "DELETE FROM tblservico WHERE idservico = @idservico select @idservico";

                acessoDados.LimparParametros();

                acessoDados.AdicionarParametro(new SqlParameter("@idservico", servico.IdServico));

                return acessoDados.ExecutarScalar(sql, CommandType.Text).ToString();

            }
            catch (Exception ex)
            {

                throw new Exception("Falha ao excluir serviço.\nEste serviço pode estar sendo usado em uma ordem de serviço, exclua a ordem de serviço primeiro.\n\nMotivo: " + ex.Message);
            }
        
        }

    }
}
