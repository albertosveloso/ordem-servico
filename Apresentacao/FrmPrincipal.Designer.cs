namespace Apresentacao
{
    partial class FrmPrincipal
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mnuBarraMenu = new System.Windows.Forms.MenuStrip();
            this.mnuCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadastroCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCadastroServico = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOrdemServico = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuBarraMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // mnuBarraMenu
            // 
            this.mnuBarraMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCadastro,
            this.mnuOrdemServico});
            this.mnuBarraMenu.Location = new System.Drawing.Point(0, 0);
            this.mnuBarraMenu.Name = "mnuBarraMenu";
            this.mnuBarraMenu.Size = new System.Drawing.Size(1008, 24);
            this.mnuBarraMenu.TabIndex = 1;
            this.mnuBarraMenu.Text = "menuStrip1";
            // 
            // mnuCadastro
            // 
            this.mnuCadastro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuCadastroCliente,
            this.mnuCadastroServico});
            this.mnuCadastro.Name = "mnuCadastro";
            this.mnuCadastro.Size = new System.Drawing.Size(66, 20);
            this.mnuCadastro.Text = "&Cadastro";
            // 
            // mnuCadastroCliente
            // 
            this.mnuCadastroCliente.Name = "mnuCadastroCliente";
            this.mnuCadastroCliente.Size = new System.Drawing.Size(112, 22);
            this.mnuCadastroCliente.Text = "C&liente";
            this.mnuCadastroCliente.Click += new System.EventHandler(this.mnuCadastroCliente_Click);
            // 
            // mnuCadastroServico
            // 
            this.mnuCadastroServico.Name = "mnuCadastroServico";
            this.mnuCadastroServico.Size = new System.Drawing.Size(112, 22);
            this.mnuCadastroServico.Text = "&Serviço";
            this.mnuCadastroServico.Click += new System.EventHandler(this.mnuCadastroServico_Click);
            // 
            // mnuOrdemServico
            // 
            this.mnuOrdemServico.Name = "mnuOrdemServico";
            this.mnuOrdemServico.Size = new System.Drawing.Size(113, 20);
            this.mnuOrdemServico.Text = "&Ordem de Serviço";
            this.mnuOrdemServico.Click += new System.EventHandler(this.mnuOrdemServico_Click);
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Apresentacao.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1008, 511);
            this.Controls.Add(this.mnuBarraMenu);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.mnuBarraMenu;
            this.Name = "FrmPrincipal";
            this.Text = "Genesis Sistemas  |  Ordem de Serviço";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mnuBarraMenu.ResumeLayout(false);
            this.mnuBarraMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mnuBarraMenu;
        private System.Windows.Forms.ToolStripMenuItem mnuCadastro;
        private System.Windows.Forms.ToolStripMenuItem mnuCadastroCliente;
        private System.Windows.Forms.ToolStripMenuItem mnuCadastroServico;
        private System.Windows.Forms.ToolStripMenuItem mnuOrdemServico;
    }
}

