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
using ObjetoTransferencia;
using Negocios;

namespace Apresentacao
{
    public partial class FrmCadClienteTelefone : FrmBase
    {
        NegCliente negCliente = new NegCliente(); //objeto Global do tipo NegCliente
        NegClienteTelefone negClienteTelefone = new NegClienteTelefone();
        ClienteTelefone clienteTelefone = new ClienteTelefone();
        bool alterarRegistro = false;
        
        public FrmCadClienteTelefone(ClienteTelefone clienteTelefone, bool alterar)
        {
            InitializeComponent();

            this.clienteTelefone = clienteTelefone;

            if (alterar == true)
            {
                this.Text = "Alterar Telefone do Cliente";

                txtTelefone.Text = this.clienteTelefone.Telefone.ToString();
                
            }



        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                NegClienteTelefone negClienteTelefone = new NegClienteTelefone();

                this.clienteTelefone.Telefone = Convert.ToDecimal(txtTelefone.Text);
                
                int resultado;
                string retorno = string.Empty;
                if (this.alterarRegistro == false)
                {
                    retorno = negClienteTelefone.Inserir(this.clienteTelefone);
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
