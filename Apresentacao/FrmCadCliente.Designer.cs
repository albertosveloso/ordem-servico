namespace Apresentacao
{
    partial class FrmCadCliente
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbxEndereco = new System.Windows.Forms.GroupBox();
            this.dgwEnderecos = new System.Windows.Forms.DataGridView();
            this.colRuaAvenida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colBairro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCidade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCEP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnExcluirEndereco = new System.Windows.Forms.Button();
            this.btnIncluirEndereco = new System.Windows.Forms.Button();
            this.btnFechar = new System.Windows.Forms.Button();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.gbxTelefone = new System.Windows.Forms.GroupBox();
            this.btnExcluirTelefone = new System.Windows.Forms.Button();
            this.btnIncluirTelefone = new System.Windows.Forms.Button();
            this.dgwTelefone = new System.Windows.Forms.DataGridView();
            this.colTelefone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colCliente = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblCPF = new System.Windows.Forms.Label();
            this.txtNome = new System.Windows.Forms.TextBox();
            this.lblNome = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.lblCodigo = new System.Windows.Forms.Label();
            this.txtCPF = new System.Windows.Forms.MaskedTextBox();
            this.gbxEndereco.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwEnderecos)).BeginInit();
            this.gbxTelefone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgwTelefone)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxEndereco
            // 
            this.gbxEndereco.Controls.Add(this.dgwEnderecos);
            this.gbxEndereco.Controls.Add(this.btnExcluirEndereco);
            this.gbxEndereco.Controls.Add(this.btnIncluirEndereco);
            this.gbxEndereco.Location = new System.Drawing.Point(12, 56);
            this.gbxEndereco.Name = "gbxEndereco";
            this.gbxEndereco.Size = new System.Drawing.Size(827, 201);
            this.gbxEndereco.TabIndex = 17;
            this.gbxEndereco.TabStop = false;
            this.gbxEndereco.Text = "Endereço(s):";
            // 
            // dgwEnderecos
            // 
            this.dgwEnderecos.AllowUserToAddRows = false;
            this.dgwEnderecos.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgwEnderecos.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgwEnderecos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwEnderecos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colRuaAvenida,
            this.colCliente2,
            this.colNumero,
            this.colBairro,
            this.colCidade,
            this.colCEP});
            this.dgwEnderecos.Location = new System.Drawing.Point(8, 20);
            this.dgwEnderecos.Name = "dgwEnderecos";
            this.dgwEnderecos.ReadOnly = true;
            this.dgwEnderecos.RowHeadersVisible = false;
            this.dgwEnderecos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwEnderecos.Size = new System.Drawing.Size(813, 145);
            this.dgwEnderecos.TabIndex = 0;
            // 
            // colRuaAvenida
            // 
            this.colRuaAvenida.DataPropertyName = "logradouro";
            this.colRuaAvenida.HeaderText = "Rua | Avenida";
            this.colRuaAvenida.Name = "colRuaAvenida";
            this.colRuaAvenida.ReadOnly = true;
            this.colRuaAvenida.Width = 300;
            // 
            // colCliente2
            // 
            this.colCliente2.DataPropertyName = "Cliente";
            this.colCliente2.HeaderText = "Cliente";
            this.colCliente2.Name = "colCliente2";
            this.colCliente2.ReadOnly = true;
            this.colCliente2.Visible = false;
            // 
            // colNumero
            // 
            this.colNumero.DataPropertyName = "numero";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.colNumero.DefaultCellStyle = dataGridViewCellStyle2;
            this.colNumero.HeaderText = "Número";
            this.colNumero.Name = "colNumero";
            this.colNumero.ReadOnly = true;
            this.colNumero.Width = 60;
            // 
            // colBairro
            // 
            this.colBairro.DataPropertyName = "bairro";
            this.colBairro.HeaderText = "Bairro";
            this.colBairro.Name = "colBairro";
            this.colBairro.ReadOnly = true;
            this.colBairro.Width = 175;
            // 
            // colCidade
            // 
            this.colCidade.DataPropertyName = "cidade";
            this.colCidade.HeaderText = "Cidade";
            this.colCidade.Name = "colCidade";
            this.colCidade.ReadOnly = true;
            this.colCidade.Width = 175;
            // 
            // colCEP
            // 
            this.colCEP.DataPropertyName = "cep";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "00000-000";
            this.colCEP.DefaultCellStyle = dataGridViewCellStyle3;
            this.colCEP.HeaderText = "CEP";
            this.colCEP.Name = "colCEP";
            this.colCEP.ReadOnly = true;
            // 
            // btnExcluirEndereco
            // 
            this.btnExcluirEndereco.Location = new System.Drawing.Point(771, 171);
            this.btnExcluirEndereco.Name = "btnExcluirEndereco";
            this.btnExcluirEndereco.Size = new System.Drawing.Size(50, 20);
            this.btnExcluirEndereco.TabIndex = 1;
            this.btnExcluirEndereco.Text = "&Excluir";
            this.btnExcluirEndereco.UseVisualStyleBackColor = true;
            this.btnExcluirEndereco.Click += new System.EventHandler(this.btnExcluirEndereco_Click);
            // 
            // btnIncluirEndereco
            // 
            this.btnIncluirEndereco.Location = new System.Drawing.Point(6, 171);
            this.btnIncluirEndereco.Name = "btnIncluirEndereco";
            this.btnIncluirEndereco.Size = new System.Drawing.Size(50, 20);
            this.btnIncluirEndereco.TabIndex = 0;
            this.btnIncluirEndereco.Text = "&Inserir";
            this.btnIncluirEndereco.UseVisualStyleBackColor = true;
            this.btnIncluirEndereco.Click += new System.EventHandler(this.btnIncluirEndereco_Click);
            // 
            // btnFechar
            // 
            this.btnFechar.Location = new System.Drawing.Point(764, 392);
            this.btnFechar.Name = "btnFechar";
            this.btnFechar.Size = new System.Drawing.Size(75, 23);
            this.btnFechar.TabIndex = 3;
            this.btnFechar.Text = "&Fechar";
            this.btnFechar.UseVisualStyleBackColor = true;
            this.btnFechar.Click += new System.EventHandler(this.btnFechar_Click);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(582, 27);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 23);
            this.btnSalvar.TabIndex = 2;
            this.btnSalvar.Text = "&Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // gbxTelefone
            // 
            this.gbxTelefone.Controls.Add(this.btnExcluirTelefone);
            this.gbxTelefone.Controls.Add(this.btnIncluirTelefone);
            this.gbxTelefone.Controls.Add(this.dgwTelefone);
            this.gbxTelefone.Location = new System.Drawing.Point(13, 269);
            this.gbxTelefone.Name = "gbxTelefone";
            this.gbxTelefone.Size = new System.Drawing.Size(177, 146);
            this.gbxTelefone.TabIndex = 6;
            this.gbxTelefone.TabStop = false;
            this.gbxTelefone.Text = "Telefone(s):";
            // 
            // btnExcluirTelefone
            // 
            this.btnExcluirTelefone.Location = new System.Drawing.Point(112, 119);
            this.btnExcluirTelefone.Name = "btnExcluirTelefone";
            this.btnExcluirTelefone.Size = new System.Drawing.Size(50, 20);
            this.btnExcluirTelefone.TabIndex = 1;
            this.btnExcluirTelefone.Text = "E&xcluir";
            this.btnExcluirTelefone.UseVisualStyleBackColor = true;
            this.btnExcluirTelefone.Click += new System.EventHandler(this.btnExcluirTelefone_Click);
            // 
            // btnIncluirTelefone
            // 
            this.btnIncluirTelefone.Location = new System.Drawing.Point(7, 119);
            this.btnIncluirTelefone.Name = "btnIncluirTelefone";
            this.btnIncluirTelefone.Size = new System.Drawing.Size(50, 20);
            this.btnIncluirTelefone.TabIndex = 0;
            this.btnIncluirTelefone.Text = "I&nserir";
            this.btnIncluirTelefone.UseVisualStyleBackColor = true;
            this.btnIncluirTelefone.Click += new System.EventHandler(this.btnIncluirTelefone_Click);
            // 
            // dgwTelefone
            // 
            this.dgwTelefone.AllowUserToAddRows = false;
            this.dgwTelefone.AllowUserToDeleteRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.dgwTelefone.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgwTelefone.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgwTelefone.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTelefone,
            this.colCliente});
            this.dgwTelefone.Location = new System.Drawing.Point(7, 20);
            this.dgwTelefone.Name = "dgwTelefone";
            this.dgwTelefone.ReadOnly = true;
            this.dgwTelefone.RowHeadersVisible = false;
            this.dgwTelefone.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgwTelefone.Size = new System.Drawing.Size(155, 93);
            this.dgwTelefone.TabIndex = 0;
            // 
            // colTelefone
            // 
            this.colTelefone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.colTelefone.DataPropertyName = "telefone";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            dataGridViewCellStyle5.Format = "(00) 0000-0000";
            this.colTelefone.DefaultCellStyle = dataGridViewCellStyle5;
            this.colTelefone.HeaderText = "Telefone";
            this.colTelefone.Name = "colTelefone";
            this.colTelefone.ReadOnly = true;
            this.colTelefone.Width = 150;
            // 
            // colCliente
            // 
            this.colCliente.DataPropertyName = "Cliente";
            this.colCliente.HeaderText = "Cliente";
            this.colCliente.Name = "colCliente";
            this.colCliente.ReadOnly = true;
            this.colCliente.Visible = false;
            // 
            // lblCPF
            // 
            this.lblCPF.AutoSize = true;
            this.lblCPF.Location = new System.Drawing.Point(480, 12);
            this.lblCPF.Name = "lblCPF";
            this.lblCPF.Size = new System.Drawing.Size(30, 13);
            this.lblCPF.TabIndex = 4;
            this.lblCPF.Text = "CPF:";
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(73, 28);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(403, 20);
            this.txtNome.TabIndex = 0;
            // 
            // lblNome
            // 
            this.lblNome.AutoSize = true;
            this.lblNome.Location = new System.Drawing.Point(70, 12);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(38, 13);
            this.lblNome.TabIndex = 2;
            this.lblNome.Text = "Nome:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(12, 28);
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.ReadOnly = true;
            this.txtCodigo.Size = new System.Drawing.Size(53, 20);
            this.txtCodigo.TabIndex = 1;
            this.txtCodigo.TabStop = false;
            this.txtCodigo.Text = "0";
            this.txtCodigo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lblCodigo
            // 
            this.lblCodigo.AutoSize = true;
            this.lblCodigo.Location = new System.Drawing.Point(9, 12);
            this.lblCodigo.Name = "lblCodigo";
            this.lblCodigo.Size = new System.Drawing.Size(43, 13);
            this.lblCodigo.TabIndex = 0;
            this.lblCodigo.Text = "Código:";
            // 
            // txtCPF
            // 
            this.txtCPF.Location = new System.Drawing.Point(483, 28);
            this.txtCPF.Mask = "000.000.000-00";
            this.txtCPF.Name = "txtCPF";
            this.txtCPF.Size = new System.Drawing.Size(93, 20);
            this.txtCPF.TabIndex = 1;
            this.txtCPF.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            // 
            // FrmCadCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 429);
            this.Controls.Add(this.txtCPF);
            this.Controls.Add(this.gbxEndereco);
            this.Controls.Add(this.btnFechar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.gbxTelefone);
            this.Controls.Add(this.lblCPF);
            this.Controls.Add(this.txtNome);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.lblCodigo);
            this.Name = "FrmCadCliente";
            this.Text = "Cadastrar Cliente";
            this.gbxEndereco.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwEnderecos)).EndInit();
            this.gbxTelefone.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgwTelefone)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCodigo;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.Label lblCPF;
        private System.Windows.Forms.GroupBox gbxTelefone;
        private System.Windows.Forms.DataGridView dgwTelefone;
        private System.Windows.Forms.Button btnExcluirTelefone;
        private System.Windows.Forms.Button btnIncluirTelefone;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnFechar;
        private System.Windows.Forms.GroupBox gbxEndereco;
        private System.Windows.Forms.DataGridView dgwEnderecos;
        private System.Windows.Forms.Button btnExcluirEndereco;
        private System.Windows.Forms.Button btnIncluirEndereco;
        private System.Windows.Forms.DataGridViewTextBoxColumn colRuaAvenida;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente2;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNumero;
        private System.Windows.Forms.DataGridViewTextBoxColumn colBairro;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCidade;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCEP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTelefone;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCliente;
        private System.Windows.Forms.MaskedTextBox txtCPF;
    }
}