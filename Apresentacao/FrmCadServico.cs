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
    public partial class FrmCadServico : FrmBase
    {
        NegServico negServico = new NegServico();
        Servico servico;
        bool consulta;

        public FrmCadServico(Servico servico, bool consulta)
        {
            InitializeComponent();

            this.servico = servico;
            this.consulta = consulta;

            if ((this.servico.IdServico.HasValue == true) && (this.consulta == false))
            {
                this.Text = "Alterar serviço";

                txtCodigo.Text = this.servico.IdServico.Value.ToString();
            }
            else if ((this.servico.IdServico.HasValue == true) && (this.consulta == true))
            {
                this.Text = "Consultar serviço";

                txtCodigo.Text = this.servico.IdServico.Value.ToString();
                txtNome.ReadOnly = true;
                txtDescricao.ReadOnly = true;
                txtValor.ReadOnly = true;

                btnSalvar.Visible = false;
            }

            txtNome.Text = this.servico.Nome;
            txtDescricao.Text = this.servico.Descricao;
            txtValor.Text = this.servico.Valor.ToString("0.00");
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtNome.Text) == true)
                {
                    MessageBox.Show("Informe o nome do serviço.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtNome.Focus();
                    return;
                }
                
                if(string.IsNullOrWhiteSpace(txtDescricao.Text) == true)
                {
                    MessageBox.Show("Informe a descrição do serviço.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDescricao.Focus();
                    return;
                }

                decimal decValor;

                if(decimal.TryParse(txtValor.Text, out decValor) == false || (txtValor.Text == "0,00"))
                {
                    MessageBox.Show("Informe o valor do serviço.", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtValor.Focus();
                    return;
                }

                this.servico.Nome = txtNome.Text;
                this.servico.Descricao = txtDescricao.Text;
                this.servico.Valor = decValor;

                string retorno = string.Empty;
                int resultado;

                if (this.servico.IdServico.HasValue == false)
                {
                    retorno = negServico.Inserir(this.servico);
                }
                else
                {
                    retorno = negServico.Alterar(this.servico);
                }

                if (int.TryParse(retorno, out resultado) == true)
                {
                    this.DialogResult = System.Windows.Forms.DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Falha ao salvar serviço. Motivo: " + retorno, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFechar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void txtValor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtValor_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!Char.IsDigit(e.KeyChar) && e.KeyChar != (char)8 && e.KeyChar != (char)44)
            {
                e.Handled = true;
            }
        }

   

    }
}
