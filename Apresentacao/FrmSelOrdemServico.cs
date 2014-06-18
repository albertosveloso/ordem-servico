using Apresentacao.Base;
using ObjetoTransferencia;
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

namespace Apresentacao
{
    public partial class FrmSelOrdemServico : FrmBase
    {
        public FrmSelOrdemServico()
        {
            InitializeComponent();
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                using (FrmCadOrdemServico frmCadOrdemServico = new FrmCadOrdemServico(new OrdemServico(), false))
                {
                    if (frmCadOrdemServico.ShowDialog() == DialogResult.OK)
                    {
                        btnPesquisar_Click(null, null);
                        

                    }
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                Negocios.NegOrdemServico negOrdemServico = new Negocios.NegOrdemServico();

                dgwTabela.DataSource = negOrdemServico.Consultar(dtpDataInicio.Value, dtpDataFinal.Value);

                if (dgwTabela.RowCount == 0)
                {
                    MessageBox.Show("Não existe ordem de serviço no período informado", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgwTabela.SelectedRows.Count < 1) //se nao houver nenhum registro selecionado pelo usuario
                {
                    //mensagem
                    MessageBox.Show("Favor selecionar uma Ordem Servico!", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                OrdemServico ordemServicoSelecionada = dgwTabela.SelectedRows[0].DataBoundItem as OrdemServico; //pegando a linha selecionada converte ele para um objeto do tipo ordemservico
                //Chamar formulario que permite a pesquisa 
                using (FrmCadOrdemServico frmCadOrdemServico = new FrmCadOrdemServico(ordemServicoSelecionada, true))
                {
                    frmCadOrdemServico.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgwTabela.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Favor selecionar uma ordem de serviço.", "Alerta", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                OrdemServico ordemServicoSelecionada = dgwTabela.SelectedRows[0].DataBoundItem as OrdemServico;

                using (FrmCadOrdemServico frmCadOrdemServico = new FrmCadOrdemServico(ordemServicoSelecionada, false))
                {
                    if (frmCadOrdemServico.ShowDialog() == DialogResult.OK)
                    {
                        btnPesquisar_Click(null, null);

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgwTabela.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Selecione uma ordem de serviço.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //verificacao se o cliente deseja excluir o registro mesmo
                if (MessageBox.Show("Deseja excluir o a ordem selecionada?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                OrdemServico ordemServicoSelecionado = dgwTabela.SelectedRows[0].DataBoundItem as OrdemServico;
                NegOrdemServico negOrdemServico = new NegOrdemServico();

                int resultado;
                string retorno = negOrdemServico.Excluir(ordemServicoSelecionado);

                if (int.TryParse(retorno, out resultado) == true)
                {
                    btnPesquisar_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Falha ao excluir ordem de serviço. Motivo: " + retorno, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgwTabela_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            OrdemServico ordemServicoSelecionada = dgwTabela.SelectedRows[0].DataBoundItem as OrdemServico;

            using (FrmCadOrdemServico frmCadOrdemServico = new FrmCadOrdemServico(ordemServicoSelecionada, false))
            {
                if (frmCadOrdemServico.ShowDialog() == DialogResult.OK)
                {
                    btnPesquisar_Click(null, null);
                }
            }
        }

    
    }
}
