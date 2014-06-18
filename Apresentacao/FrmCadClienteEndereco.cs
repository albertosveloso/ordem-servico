using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Apresentacao.Base;
using Negocios;
using ObjetoTransferencia;

namespace Apresentacao
{
    public partial class frmCadClienteEndereco : FrmBase
    {
        NegCliente negCliente = new NegCliente(); //objeto Global do tipo NegCliente
        NegClienteEndereco negClienteEndereco = new NegClienteEndereco();
        ClienteEndereco clienteEndereco = new ClienteEndereco();
        bool alterarRegistro = false;
        
        public frmCadClienteEndereco(ClienteEndereco clienteEndereco, bool alterar)
        {
            InitializeComponent();

            this.clienteEndereco = clienteEndereco;

            if (alterar == true)
            {
                this.Text = "Alterar Endereço do Cliente";

                txtCEP.Text = this.clienteEndereco.CEP.ToString("00.000-000");
                txtLogradouro.Text = this.clienteEndereco.Logradouro.ToString();
                txtNumero.Text = this.clienteEndereco.Numero.ToString();
                txtBairro.Text = this.clienteEndereco.Bairro.ToString();
                txtCidade.Text = this.clienteEndereco.Cidade.ToString();
            }

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {


            try
            {
                NegClienteEndereco negClienteEndereco = new NegClienteEndereco();

                this.clienteEndereco.CEP = Convert.ToDecimal(txtCEP.Text);
                this.clienteEndereco.Logradouro = txtLogradouro.Text;
                this.clienteEndereco.Numero = Convert.ToInt32(txtNumero.Text);
                this.clienteEndereco.Bairro = txtBairro.Text;
                this.clienteEndereco.Cidade = txtCidade.Text;
                

                int resultado;
                string retorno = string.Empty;
                if (this.alterarRegistro == false)
                {
                    retorno = negClienteEndereco.Inserir(this.clienteEndereco);
                }
             
                if (int.TryParse(retorno, out resultado) == true)
                {
                    this.DialogResult = DialogResult.OK;
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}
