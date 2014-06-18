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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void mnuCadastroCliente_Click(object sender, EventArgs e)
        {
            FrmSelCliente frmSelCliente = new FrmSelCliente(); //Estanciando objeto do tipo FrmSelCliente
            frmSelCliente.MdiParent = this; //informação de que o formulario estanciado é filho do formulario principal
            frmSelCliente.Show(); //abrir formulario frmSelCliente

        }

        private void mnuCadastroServico_Click(object sender, EventArgs e)
        {
            FrmSelServico frmSelServico = new FrmSelServico();
            frmSelServico.MdiParent = this;
            frmSelServico.Show();
        }

        private void mnuOrdemServico_Click(object sender, EventArgs e)
        {
            FrmSelOrdemServico frmSelOrdemServico = new FrmSelOrdemServico();
            frmSelOrdemServico.MdiParent = this;
            frmSelOrdemServico.Show();
        }
    }
}
