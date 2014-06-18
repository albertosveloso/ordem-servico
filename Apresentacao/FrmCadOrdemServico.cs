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
    public partial class FrmCadOrdemServico : FrmBase
    {
        NegOrdemServico negOrdemServico = new NegOrdemServico();
        NegOrdemServicoItem negOrdemServicoItem = new NegOrdemServicoItem(); //objeto que permite alterar/editar/criar/excluir itens

        //Objeto global que esta associado a ordem de serviço
        private Cliente Cliente;
        private OrdemServico OrdemServico;

        //Objeto global, sempre que a interface for carregada o objeto listaServicos passara a ter conteudo
        private OrdemServicoItemLista listaServicos = new OrdemServicoItemLista();

        public FrmCadOrdemServico(OrdemServico ordemservico, bool consulta)
        {
            //Linq é a capacidade de fazer várias alterações dentro do objeto sem ir até o banco de dados

            InitializeComponent();

            dgwItens.AutoGenerateColumns = false;

            this.OrdemServico = ordemservico;
            //Se o objeto que representa a ordem de servico possuir um id associado a ordem servico
            //indica que a ordem servico já foi gravava no BD.
            if (this.OrdemServico.IdOrdemServico.HasValue == true)
            {
                this.Cliente = this.OrdemServico.Cliente; //Preenchendo cliente da ordem de servico

                if (consulta == false)
                {
                    this.Text = "Alterar ordem de serviço";
                }
                else
                {
                    this.Text = "Consultar ordem de serviço";
                    btnInserir.Enabled = false;
                    btnExcluir.Enabled = false;
                }

                txtCodigo.Text = this.OrdemServico.IdOrdemServico.ToString();
                txtData.Text = this.OrdemServico.DataCadastro.ToString("dd/MM/yy");
                txtCliente.Text = this.OrdemServico.Cliente.Nome;
                txtValorTotal.Text = this.OrdemServico.ValorTotal.ToString("#,##0.00");

                txtCliente.ReadOnly = true;
                btnPesquisarCliente.Enabled = false;

                //Chamar o metodo generico para atualizar o grid com os servicos
                AtualizarTabela();

            }
            else
            {
                txtData.Text = DateTime.Now.ToString("dd/MM/yy");
            }

        }

        //Atualizar o grid
        private void AtualizarTabela()
        {
            
            //Processo onde há necessidade de calcular um valor total da ordem de servico
            listaServicos = negOrdemServicoItem.Consultar(this.OrdemServico.IdOrdemServico.Value); //Objeto para armazenamento temporario do resultado da consulta

            dgwItens.DataSource = null; // desvincula td do grid
            dgwItens.DataSource = listaServicos;

            dgwItens.Update(); //atualizar o grid
            dgwItens.Refresh(); //dá um refresh no grid

            Application.DoEvents(); //faz uma pilha de requisições no Sistema Operacional, faz a atualização atualizar tds pendência gráficas

            //Somando cada valor dos itens para atribuir a caixa valor total
            txtValorTotal.Text = listaServicos.Sum(p => p.ValorTotal).ToString("0.00"); //Linq to object para somar todos os itens, não é necessário o laço de repetição (Foreach) e atribuindo a caixa de texto valor total

            //Incluindo o valor total na tabela Ordem de serviço
            this.OrdemServico.ValorTotal = Convert.ToDecimal(txtValorTotal.Text);
            negOrdemServico.IncluirValorTotal(this.OrdemServico);


        }

        private void btnPesquisarCliente_Click(object sender, EventArgs e)
        {
            using (FrmPesquisarCliente frmPesquisarCliente = new FrmPesquisarCliente())
            {
                if (frmPesquisarCliente.ShowDialog() == DialogResult.OK)
                {
                    this.Cliente = frmPesquisarCliente.ClienteSelecionado;
                    txtCliente.Text = this.Cliente.Nome;

                    txtCliente.ReadOnly = true;
                    btnPesquisarCliente.Enabled = false;
                }
            }
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.Cliente == null)
                {
                    MessageBox.Show("Favor pesquisar um cliente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    btnPesquisarCliente.Focus();
                    return;
                }

                this.OrdemServico.Cliente = this.Cliente; //Cliente da ordem de serviço
                this.OrdemServico.DataCadastro = Convert.ToDateTime(txtData.Text); //data da ordem de servico
                this.OrdemServico.ValorTotal = 0;

                string retorno = string.Empty;
                if (this.OrdemServico.IdOrdemServico.HasValue == false)
                {
                    retorno = negOrdemServico.Inserir(this.OrdemServico);
                    int codigo;
                    if (int.TryParse(retorno, out codigo) == true)
                    {
                        this.OrdemServico.IdOrdemServico = codigo;
                        txtCodigo.Text = this.OrdemServico.IdOrdemServico.ToString();

                        txtCliente.ReadOnly = true;
                        btnPesquisarCliente.Enabled = false;

                    }
                    else
                    {
                        MessageBox.Show("Falha ao inserir ordem de serviço. Motivo: " + retorno,
                           "Falha", MessageBoxButtons.OK,
                           MessageBoxIcon.Error);
                        return;
                    }
                }

                OrdemServicoItem ordemServicoItem = new OrdemServicoItem(); //Objeto que representa um novo item na ordem de serviço
                ordemServicoItem.OrdemServico = this.OrdemServico;

                //Exibir a interface que ira cadastrar um item dentro da ordem de servico
                using (FrmCadOrdemServicoItem frmCadOrdemServicoItem = new FrmCadOrdemServicoItem(ordemServicoItem, false, this.listaServicos)) //Criar objeto do formulario filho
                {
                    if (frmCadOrdemServicoItem.ShowDialog() == DialogResult.OK) // ser der certo chamar o formulario
                    {
                        //Atualiza tabela que exibe os itens.
                        AtualizarTabela();

                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Falha ao inserir item. Motivo: " + ex.Message, "Falha",
                   MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgwItens.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Favor selecionar um serviço", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show("Deseja excluir o serviço selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                {
                    return;
                }

                OrdemServicoItem itemSelecionado = dgwItens.SelectedRows[0].DataBoundItem as OrdemServicoItem;


                int resultado;
                string retorno = string.Empty;

                retorno = negOrdemServicoItem.Excluir(itemSelecionado); //o metodo excluir retorna uma string que sera armazenada na variavel retorno

                if (int.TryParse(retorno, out resultado) == false) //se não for possivel a conversão de retorno para inteiro
                {
                    MessageBox.Show(retorno, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    AtualizarTabela();
                    MessageBox.Show("Serviço excluído com sucesso!", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
