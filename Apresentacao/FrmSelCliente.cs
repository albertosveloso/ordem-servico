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
    public partial class FrmSelCliente : FrmBase
    {
        public FrmSelCliente()
        {
            InitializeComponent();
            dgwTabela.AutoGenerateColumns = false;
        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                using (FrmCadCliente frmCadCliente = new FrmCadCliente(new Cliente(), false))
                {
                    if (frmCadCliente.ShowDialog() == DialogResult.OK)
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
                NegCliente negCliente = new NegCliente();

                dgwTabela.DataSource = negCliente.Consultar(txtCliente.Text);

                if (dgwTabela.RowCount == 0)
                {
                    MessageBox.Show("Não existe cliente com o nome informado.", "Informação", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



        }

        private void txtCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)

                btnPesquisar.PerformClick();
        }

        private void txtCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) == true)
                btnPesquisar_Click(null, null);
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgwTabela.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Selecione um registro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Cliente clienteSelecionado = dgwTabela.SelectedRows[0].DataBoundItem as Cliente;
                using (FrmCadCliente frmCadCliente = new FrmCadCliente(clienteSelecionado, false))
                {
                    if (frmCadCliente.ShowDialog() == DialogResult.OK)
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

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgwTabela.SelectedRows.Count < 1)
                {
                    MessageBox.Show("Selecione um registro.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Cliente clienteSelecionado = dgwTabela.SelectedRows[0].DataBoundItem as Cliente;
                using (FrmCadCliente frmCadCliente = new FrmCadCliente(clienteSelecionado, true))
                {
                    if (frmCadCliente.ShowDialog() == DialogResult.OK)
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
                    MessageBox.Show("Selecione um arquivo.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                //verificacao se o cliente deseja excluir o registro mesmo
                if (MessageBox.Show("Deseja excluir o registro selecionado?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.No)
                {
                    return;
                }

                Cliente clienteSelecionado = dgwTabela.SelectedRows[0].DataBoundItem as Cliente;
                NegCliente negCliente = new NegCliente();

                int resultado;
                string retorno = negCliente.Excluir(clienteSelecionado);

                if (int.TryParse(retorno, out resultado) == true)
                {
                    btnPesquisar_Click(null, null);
                }
                else
                {
                    MessageBox.Show("Falha ao excluir cliente. Motivo: " + retorno, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void dgwTabela_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Cliente clienteSelecionado = dgwTabela.SelectedRows[0].DataBoundItem as Cliente;
            using (FrmCadCliente frmCadCliente = new FrmCadCliente(clienteSelecionado, false))
            {
                if (frmCadCliente.ShowDialog() == DialogResult.OK)
                {
                    btnPesquisar_Click(null, null);
                }
            }

        }
    }
}
