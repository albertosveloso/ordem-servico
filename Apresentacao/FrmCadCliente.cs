using Apresentacao.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocios;
using ObjetoTransferencia;

namespace Apresentacao
{
    public partial class FrmCadCliente : FrmBase
    {
        NegCliente negCliente = new NegCliente();
        Cliente cliente;
        bool consulta;
        ClienteEnderecoLista listaEndereco = new ClienteEnderecoLista();

        public FrmCadCliente(Cliente cliente, bool consulta)
        {
            InitializeComponent();

            this.cliente = cliente;
            this.consulta = consulta;

            if ((this.cliente).IdCliente.HasValue == false)
            {
                gbxEndereco.Enabled = false;
                gbxTelefone.Enabled = false;
            }
            
            if ((this.cliente.IdCliente.HasValue == true) && (this.consulta == false))
            {

                this.Text = "Alterar Cliente";
                txtCodigo.Text = this.cliente.IdCliente.Value.ToString();

                AtualizarGrid();
            
            }
            else if ((this.cliente.IdCliente.HasValue == true) && (this.consulta == true))
            {
                this.Text = "Consultar Cliente";

                txtCodigo.Text = this.cliente.IdCliente.Value.ToString();
                txtNome.ReadOnly = true;
                txtCPF.ReadOnly = true;
                btnSalvar.Visible = false;
                gbxEndereco.Enabled = false;
                gbxTelefone.Enabled = false;

                AtualizarGrid();
            }

            txtNome.Text = this.cliente.Nome;
            txtCPF.Text = this.cliente.CPF.ToString();
            
            
       }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNome.Text) == true)
                {
                    MessageBox.Show("Insira o nome do cliente", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNome.Focus();
                    return;
                }

                decimal decCPF;

                if (decimal.TryParse(txtCPF.Text, out decCPF) == false)
                {
                    MessageBox.Show("Insira o CPF do cliente", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCPF.Focus();
                    return;
                }

                this.cliente.Nome = txtNome.Text;
                this.cliente.CPF = decCPF;

                string retorno = String.Empty;
                int resultado;

                if (this.cliente.IdCliente.HasValue == false)
                {
                    retorno = negCliente.Inserir(this.cliente);

                    if (int.TryParse(retorno, out resultado))
                    {
                        cliente.IdCliente = resultado;
                    }

                }
                else
                {
                    retorno = negCliente.Alterar(this.cliente);
                }

                if(int.TryParse(retorno, out resultado) == true)
                {
                    txtCodigo.Text = retorno;
                    txtNome.ReadOnly = true;
                    txtCPF.ReadOnly = true;
                    btnSalvar.Enabled = false;
                    gbxEndereco.Enabled = true;
                    gbxTelefone.Enabled = true;

                }
                else
                {
                    MessageBox.Show("Falha ao salvar cliente. Motivo: " + retorno, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show(ex.Message,"Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnIncluirEndereco_Click(object sender, EventArgs e)
        {
            try
            {
                using (frmCadClienteEndereco frmCadClienteEndereco = new frmCadClienteEndereco(new ClienteEndereco {Cliente = this.cliente }, false))
                {
                    if (frmCadClienteEndereco.ShowDialog() == DialogResult.OK)
                    {
                        AtualizarGrid();
                        
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //Método para atualizar o grid
        private void AtualizarGrid()
        {
            try
            {
                NegClienteEndereco negClienteEndereco = new NegClienteEndereco();
                NegClienteTelefone negClienteTelefone = new NegClienteTelefone();

                dgwEnderecos.DataSource = negClienteEndereco.Consultar(this.cliente);
                dgwTelefone.DataSource = negClienteTelefone.Consultar(this.cliente);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnExcluirEndereco_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgwEnderecos.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Selecione um endereço.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //verificacao se o cliente deseja excluir o registro mesmo
                if (MessageBox.Show("Deseja excluir o endereco selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                ClienteEndereco enderecoSelecionado = dgwEnderecos.SelectedRows[0].DataBoundItem as ClienteEndereco;
                NegClienteEndereco negClienteEndereco = new NegClienteEndereco();

                int resultado;
                string retorno = negClienteEndereco.Excluir(enderecoSelecionado);

                if (int.TryParse(retorno, out resultado) == true)
                {
                    AtualizarGrid();
                }
                else
                {
                    MessageBox.Show("Falha ao excluir endereço. Motivo: " + retorno, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnIncluirTelefone_Click(object sender, EventArgs e)
        {
            try
            {
                using (FrmCadClienteTelefone frmCadClienteTelefone = new FrmCadClienteTelefone(new ClienteTelefone { Cliente = this.cliente }, false))
                {
                    if (frmCadClienteTelefone.ShowDialog() == DialogResult.OK)
                    {
                        AtualizarGrid();

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluirTelefone_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgwEnderecos.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Selecione um telefone.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //verificacao se o cliente deseja excluir o registro mesmo
                if (MessageBox.Show("Deseja excluir o telefone selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                ClienteTelefone telefoneSelecionado = dgwTelefone.SelectedRows[0].DataBoundItem as ClienteTelefone;
                NegClienteTelefone negClienteTelefone = new NegClienteTelefone();

                int resultado;
                string retorno = negClienteTelefone.Excluir(telefoneSelecionado);

                if (int.TryParse(retorno, out resultado) == true)
                {
                    AtualizarGrid();
                }
                else
                {
                    MessageBox.Show("Falha ao excluir telefone. Motivo: " + retorno, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



    }
}
