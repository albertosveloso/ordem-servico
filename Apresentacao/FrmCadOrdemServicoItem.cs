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
    public partial class FrmCadOrdemServicoItem : FrmBase
    {
        NegServico negServico = new NegServico(); //objeto global do tipo NegServico
        ServicoLista servicoLista = new ServicoLista(); //Lista de serviços
        OrdemServicoItem ordemServicoItem; //Objeto global ordemServicoItem
        bool alterarRegistro;

        OrdemServicoItemLista listaItens; //Variavel para guardar o valor da tela anterior para da frente (usar sempre construtor da tela anterior)

        //listaitens é para tratar o erro de chave dulicada, chamamos o objeto

        public FrmCadOrdemServicoItem(OrdemServicoItem ordemServicoItem, bool alterar, OrdemServicoItemLista listaItens)
        {
            InitializeComponent();

            this.listaItens = listaItens;

            this.ordemServicoItem = ordemServicoItem; // o item selecionado da tela anterior que foi passado para esta tela vai ser armazenado neste objeto

            this.alterarRegistro = alterar;

            servicoLista = negServico.Consultar("%"); // vai trazer todos os servicos cadastros e incluir na lista de servico o resultado
            //Propriedade exclusiva do combobox
            cbxServico.DisplayMember = "Nome"; //vai mostrar a descricao do servico no combobox
            cbxServico.ValueMember = "IdServico"; //o que identifica os registros contidos no combobox é a propriedade IdServico
            cbxServico.DataSource = servicoLista; //a lista de servicos vai preencher o objeto de dados

            if (this.ordemServicoItem.Servico != null) //se o serviço já estiver registrado na ordem de serviço
            {
                cbxServico.SelectedValue = this.ordemServicoItem.Servico.IdServico;
                cbxServico.Enabled = false;
            }

            if (alterar == true)
            {
                this.Text = "Alterar item na ordem de serviço"; //Se o parametro for alterar troca o titulo do form para "Alterar Item na ordem de serviço"

                txtValorTotal.Text = this.ordemServicoItem.ValorTotal.ToString("0.00"); // Valor total associado ao objeto da ordem de servico item e passamos para a caixa de texto valor total
            }


        }

        private void cbxServico_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxServico.Items.Count > 0)
            {
                Servico servicoSelecionado;
                int idServico;

                idServico = Convert.ToInt32(cbxServico.SelectedValue);

                servicoSelecionado = servicoLista.Where(s=>s.IdServico == idServico).FirstOrDefault();

                txtValorTotal.Text = (servicoSelecionado.Valor).ToString("0.00");
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                NegOrdemServicoItem negOrdemServicoItem = new NegOrdemServicoItem();

                int idServico = Convert.ToInt32(cbxServico.SelectedValue);

                //Verificando se o servico já existe dentro da lista
                if (this.listaItens.Where(s => s.Servico.IdServico == idServico).Count() > 0)
                {
                    MessageBox.Show("Serviço já inserido na ordem de serviço!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Servico servicoSelecionado = servicoLista.Where(s => s.IdServico == idServico).FirstOrDefault();

                this.ordemServicoItem.Servico = servicoSelecionado;
                this.ordemServicoItem.ValorTotal = Convert.ToDecimal(txtValorTotal.Text);

                int resultado;
                string retorno = string.Empty; //retorno que vai vir do banco de dados

                if (this.alterarRegistro == false)
                {
                    retorno = negOrdemServicoItem.Inserir(this.ordemServicoItem);
                }
                else
                {
                    retorno = negOrdemServicoItem.Alterar(this.ordemServicoItem);
                }

                if (int.TryParse(retorno, out resultado) == true) // se conseguiu converter para inteiro
                {
                    this.DialogResult = DialogResult.OK; //Tudo ok!
                }
                else
                {
                    MessageBox.Show(retorno, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {
                 MessageBox.Show(ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
