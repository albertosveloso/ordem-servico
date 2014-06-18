using Apresentacao.Base;
using ObjetoTransferencia;
using Negocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apresentacao
{
    public partial class FrmPesquisarCliente : FrmBase
    {

        public Cliente ClienteSelecionado { get; set; }

        public FrmPesquisarCliente()
        {
            InitializeComponent();
            dgwPesquisa.AutoGenerateColumns = false;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                NegCliente negCliente = new NegCliente();

                dgwPesquisa.DataSource = negCliente.Consultar(txtPesquisaNome.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (dgwPesquisa.SelectedRows.Count == 0)
            {
                MessageBox.Show("Favor selecionar um cliente.", "Informação",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.ClienteSelecionado = dgwPesquisa.SelectedRows[0].DataBoundItem as Cliente;
            DialogResult = DialogResult.OK;

        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void txtPesquisaNome_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Enter) == true)
                btnPesquisar_Click(null, null);
        }
    }
}
