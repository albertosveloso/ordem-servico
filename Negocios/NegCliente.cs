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
    public class NegCliente
    {
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        //Inserir cliente
        public string Inserir(Cliente cliente)
        {
            try
            {
                string sql = "INSERT INTO tblcliente(nome,cpf,datacadastro) values(@nome, @cpf, @datacadastro) select @@identity";

                acessoDados.LimparParametros();
                acessoDados.AdicionarParametro(new SqlParameter("@nome", cliente.Nome));
                acessoDados.AdicionarParametro(new SqlParameter("@cpf", cliente.CPF));
                acessoDados.AdicionarParametro(new SqlParameter("@datacadastro", DateTime.Now));

                return acessoDados.ExecutarScalar(sql, CommandType.Text).ToString();

            }
            catch (Exception ex)
            {
                 throw new Exception("Falha ao inserir serviço. Motivo: " + ex.Message);
            }
        
        }
        
        //Alterar cliente
        public string Alterar(Cliente cliente)
        {
            try
            {
                string sql = "UPDATE tblcliente SET nome = @nome, cpf = @cpf WHERE idcliente = @idcliente select @idcliente";

                acessoDados.LimparParametros();
                acessoDados.AdicionarParametro(new SqlParameter("@nome", cliente.Nome));
                acessoDados.AdicionarParametro(new SqlParameter("@cpf", cliente.CPF));
                acessoDados.AdicionarParametro(new SqlParameter("@idcliente", cliente.IdCliente));

                return acessoDados.ExecutarScalar(sql, CommandType.Text).ToString();

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao alterar cliente. Motivo: " + ex.Message);
            }
        
        }

        //Consultar Cliente
        public ClienteLista Consultar(string nome)
        {
            try
            {
                //Criação de um objeto que representa um vetor de clientes.
                ClienteLista lista = new ClienteLista();

                string sql = "select idcliente, nome, cpf, datacadastro from tblcliente where nome like '%' + @nome + '%'";
                acessoDados.LimparParametros();
                acessoDados.AdicionarParametro(new SqlParameter("nome",nome));

                using (DataTable tabela = acessoDados.ExecutarConsulta(sql, CommandType.Text))
                {
                    foreach (DataRow linha in tabela.Rows) //percorrendo as linhas da tabela
                    {
                        Cliente cliente = new Cliente(); //criando objeto do tipo cliente

                        cliente.IdCliente = Convert.ToInt32(linha["idcliente"]);
                        cliente.Nome = linha["nome"].ToString();
                        cliente.CPF = Convert.ToDecimal(linha["cpf"]);
                        cliente.DataCadastro = Convert.ToDateTime(linha["datacadastro"]);

                        lista.Add(cliente);
                    }
                
                }

                return lista;

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao consultar cliente. Motivo: " + ex.Message);
            }    
        
        }

        //Excluir Cliente
        public string Excluir(Cliente cliente)
        {
            try
            {
                string sql = "delete from tblclientetelefone where idcliente= @idcliente " +
                             "delete from tblclienteendereco where idcliente= @idcliente " +
                             "delete from tblcliente where idcliente = @idcliente select @idcliente";

                acessoDados.LimparParametros();
                acessoDados.AdicionarParametro(new SqlParameter("@idcliente" , cliente.IdCliente));

                return acessoDados.ExecutarScalar(sql, CommandType.Text).ToString();

            }
            catch (Exception ex)
            {
                throw new Exception("Falha ao excluir cliente.\nEste cliente pode estar sendo usado em uma ordem de servico," +
                    " exclua a ordem de serviço primeiro.\n\n Motivo: " + ex.Message);
            }
        
        }



    }
}
