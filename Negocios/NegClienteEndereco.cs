using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AcessoDados;
using ObjetoTransferencia;
using System.Data;
using System.Data.SqlClient;

namespace Negocios
{
    public class NegClienteEndereco
    {
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        //Inserir endereço
        public string Inserir(ClienteEndereco clienteEndereco)
        {
            try
            {
                string sql = "INSERT INTO tblClienteEndereco(idcliente, logradouro, numero, bairro, cidade, cep) values" +
                    "(@idcliente, @logradouro, @numero, @bairro, @cidade, @cep) select @idcliente";

                acessoDados.LimparParametros();
                acessoDados.AdicionarParametro(new SqlParameter("@idcliente", clienteEndereco.Cliente.IdCliente));
                acessoDados.AdicionarParametro(new SqlParameter("@logradouro", clienteEndereco.Logradouro));
                acessoDados.AdicionarParametro(new SqlParameter("@numero", clienteEndereco.Numero));
                acessoDados.AdicionarParametro(new SqlParameter("@bairro", clienteEndereco.Bairro));
                acessoDados.AdicionarParametro(new SqlParameter("@cidade", clienteEndereco.Cidade));
                acessoDados.AdicionarParametro(new SqlParameter("@cep", clienteEndereco.CEP));

                return acessoDados.ExecutarScalar(sql, CommandType.Text).ToString();

            }
            catch (Exception ex)
            {

                throw new Exception("Falha ao inserir endereço do cliente. Motivo: " + ex.Message);
            }
        }

        //Consultar
        public ClienteEnderecoLista Consultar(Cliente cliente)
        {
            try
            {
                string sql = "select idcliente, logradouro, numero, bairro, cidade, cep from tblClienteEndereco where idcliente = @idcliente";

                acessoDados.LimparParametros();
                acessoDados.AdicionarParametro(new SqlParameter("@idcliente",cliente.IdCliente));

                ClienteEnderecoLista lista = new ClienteEnderecoLista();
                using (DataTable tabela = acessoDados.ExecutarConsulta(sql, CommandType.Text))
                {
                    foreach (DataRow linha in tabela.Rows)
                    {
                        ClienteEndereco clienteEndereco = new ClienteEndereco();
                        clienteEndereco.Cliente.IdCliente = Convert.ToInt32(linha["idcliente"]);
                        clienteEndereco.Logradouro = linha["logradouro"].ToString();
                        clienteEndereco.Numero = Convert.ToInt32(linha["numero"]);
                        clienteEndereco.Bairro = linha["bairro"].ToString();
                        clienteEndereco.Cidade = linha["cidade"].ToString();
                        clienteEndereco.CEP = Convert.ToDecimal(linha["cep"]);

                        lista.Add(clienteEndereco);

                    }

                }

                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Falha ao consultar endereços. Motivo: " + ex.Message);
            }
        
        }

        //Excluir (a verificar)
        public string Excluir(ClienteEndereco clienteEndereco)
        {
            try
            {
                string sql = "delete from tblclienteendereco where idcliente = @idcliente and logradouro = @logradouro select @idcliente";

                acessoDados.LimparParametros();
                acessoDados.AdicionarParametro(new SqlParameter("@idcliente", clienteEndereco.Cliente.IdCliente));
                acessoDados.AdicionarParametro(new SqlParameter("@logradouro", clienteEndereco.Logradouro));

                return acessoDados.ExecutarScalar(sql, CommandType.Text).ToString();

            }
            catch (Exception ex)
            {

                throw new Exception("Falha ao excluir endereço. Motivo: " + ex.Message);
            }


        }
        
        
    }
}
