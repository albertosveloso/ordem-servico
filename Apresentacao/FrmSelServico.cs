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
    public partial class FrmSelServico : FrmBase
    {
        public FrmSelServico()
        {
            InitializeComponent();

            dgwTabela.AutoGenerateColumns = false;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                NegServico negServico = new NegServico();

                dgwTabela.DataSource = negServico.Consultar(txtNome.Text);

                if (dgwTabela.RowCount == 0)
                {
                    MessageBox.Show("Não existe serviço com o nome informado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("Favor selecionar um serviço!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                Servico servicoSelecionado = dgwTabela.SelectedRows[0].DataBoundItem as Servico;
                using (FrmCadServico frmCadServico = new FrmCadServico(servicoSelecionado, false))
                {
                    if (frmCadServico.ShowDialog() == DialogResult.OK)
                    {
                        btnPesquisar_Click(null,null);
                    }
                }

                  
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) == true)
                btnPesquisar_Click(null, null);
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                using(FrmCadServico frmCadServico = new FrmCadServico(new Servico(), false))
                {
                    if(frmCadServico.ShowDialog() == DialogResult.OK)
                    {
                        btnPesquisar_Click(null,null);
                    }
                
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgwTabela.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Selecione um serviço.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Servico servicoSelecionado = dgwTabela.SelectedRows[0].DataBoundItem as Servico;
                using (FrmCadServico frmCadServico = new FrmCadServico(servicoSelecionado, true))
                {
                    if (frmCadServico.ShowDialog() == DialogResult.OK)
                    {
                        btnPesquisar_Click(null,null);
                    }
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgwTabela.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Selecione um serviço. ", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                if (MessageBox.Show("Deseja excluir o serviço selecionado? ", "Pergunta",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No) 
                {
                    return;
                }

                Servico servicoSelecionado = dgwTabela.SelectedRows[0].DataBoundItem as Servico;
                NegServico negServico = new NegServico();

                int resultado;
                string retorno = negServico.Excluir(servicoSelecionado);

                if (int.TryParse(retorno, out resultado) == true)
                {
                    btnPesquisar_Click(null, null);
                }
                else 
                {
                    MessageBox.Show("Falha ao excluir serviço. Motivo: " + retorno, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgwTabela_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Servico servicoSelecionado = dgwTabela.SelectedRows[0].DataBoundItem as Servico;
            using (FrmCadServico frmCadServico = new FrmCadServico(servicoSelecionado, false))
            {
                if (frmCadServico.ShowDialog() == DialogResult.OK)
                {
                    btnPesquisar_Click(null, null);
                }
            }

        }

    }
}
