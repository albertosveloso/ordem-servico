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
    public class NegClienteTelefone
    {
        AcessoDadosSqlServer acessoDados = new AcessoDadosSqlServer();

        //Inserir telefone
        public string Inserir(ClienteTelefone clienteTelefone)
        {
            try
            {
                string sql = "INSERT INTO tblClientetelefone(idcliente, telefone) values" +
                    "(@idcliente, @telefone) select @idcliente";

                acessoDados.LimparParametros();
                acessoDados.AdicionarParametro(new SqlParameter("@idcliente", clienteTelefone.Cliente.IdCliente));
                acessoDados.AdicionarParametro(new SqlParameter("@telefone", clienteTelefone.Telefone));
          
                return acessoDados.ExecutarScalar(sql, CommandType.Text).ToString();

            }
            catch (Exception ex)
            {

                throw new Exception("Falha ao inserir endereço do cliente. Motivo: " + ex.Message);
            }
        
        }

        //Consultar telefones
        public ClienteTelefoneLista Consultar(Cliente cliente)
        {
            try
            {
                string sql = "select idcliente, telefone from tblClienteTelefone where idcliente = @idcliente";

                acessoDados.LimparParametros();
                acessoDados.AdicionarParametro(new SqlParameter("@idcliente", cliente.IdCliente));

                ClienteTelefoneLista lista = new ClienteTelefoneLista();
                using (DataTable tabela = acessoDados.ExecutarConsulta(sql, CommandType.Text))
                {
                    foreach (DataRow linha in tabela.Rows)
                    {
                        ClienteTelefone clienteTelefone = new ClienteTelefone();
                        clienteTelefone.Cliente.IdCliente = Convert.ToInt32(linha["idcliente"]);
                        clienteTelefone.Telefone = Convert.ToDecimal(linha["telefone"]);
                        
                        lista.Add(clienteTelefone);

                    }

                }

                return lista;
            }
            catch (Exception ex)
            {

                throw new Exception("Falha ao consultar endereços. Motivo: " + ex.Message);
            }

        }

        //Excluir telefones
        public string Excluir(ClienteTelefone clienteTelefone)
        {
            try
            {
                string sql = "delete from tblclientetelefone where idcliente = @idcliente and telefone = @telefone select @idcliente";

                acessoDados.LimparParametros();
                acessoDados.AdicionarParametro(new SqlParameter("@idcliente", clienteTelefone.Cliente.IdCliente));
                acessoDados.AdicionarParametro(new SqlParameter("@telefone", clienteTelefone.Telefone));

                return acessoDados.ExecutarScalar(sql, CommandType.Text).ToString();

            }
            catch (Exception ex)
            {

                throw new Exception("Falha ao excluir endereço. Motivo: " + ex.Message);
            }
        }





    }
}
