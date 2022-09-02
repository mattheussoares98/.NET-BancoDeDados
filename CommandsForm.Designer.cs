namespace BancoDeDados {
    partial class CommandsForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if(disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Idade = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Nome = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonConectar = new System.Windows.Forms.Button();
            this.labelResultado = new System.Windows.Forms.Label();
            this.labelNome = new System.Windows.Forms.Label();
            this.labelEmail = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.textBoxEmail = new System.Windows.Forms.TextBox();
            this.buttonCriarTabela = new System.Windows.Forms.Button();
            this.buttonInserir = new System.Windows.Forms.Button();
            this.buttonPesquisar = new System.Windows.Forms.Button();
            this.buttonExcluir = new System.Windows.Forms.Button();
            this.buttonEditar = new System.Windows.Forms.Button();
            this.buttonCreateDatabaseMysql = new System.Windows.Forms.Button();
            this.labelAge = new System.Windows.Forms.Label();
            this.maskedTextBoxAge = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonSqLite = new System.Windows.Forms.RadioButton();
            this.radioButtonSqlCE = new System.Windows.Forms.RadioButton();
            this.radioButtonMySql = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ID,
            this.Idade,
            this.Nome,
            this.Email});
            this.dataGridView1.Location = new System.Drawing.Point(20, 361);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(485, 232);
            this.dataGridView1.TabIndex = 0;
            // 
            // ID
            // 
            this.ID.HeaderText = "ID";
            this.ID.Name = "ID";
            this.ID.ReadOnly = true;
            // 
            // Idade
            // 
            this.Idade.HeaderText = "IDADE";
            this.Idade.Name = "Idade";
            this.Idade.ReadOnly = true;
            // 
            // Nome
            // 
            this.Nome.HeaderText = "NOME";
            this.Nome.Name = "Nome";
            this.Nome.ReadOnly = true;
            // 
            // Email
            // 
            this.Email.HeaderText = "EMAIL";
            this.Email.Name = "Email";
            this.Email.ReadOnly = true;
            // 
            // buttonConectar
            // 
            this.buttonConectar.Location = new System.Drawing.Point(510, 352);
            this.buttonConectar.Name = "buttonConectar";
            this.buttonConectar.Size = new System.Drawing.Size(177, 35);
            this.buttonConectar.TabIndex = 1;
            this.buttonConectar.Text = "Conectar";
            this.buttonConectar.UseVisualStyleBackColor = true;
            this.buttonConectar.Click += new System.EventHandler(this.buttonConectar_Click);
            // 
            // labelResultado
            // 
            this.labelResultado.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelResultado.Location = new System.Drawing.Point(17, 13);
            this.labelResultado.Name = "labelResultado";
            this.labelResultado.Size = new System.Drawing.Size(674, 168);
            this.labelResultado.TabIndex = 2;
            this.labelResultado.Text = "Resultado";
            // 
            // labelNome
            // 
            this.labelNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNome.Location = new System.Drawing.Point(22, 207);
            this.labelNome.Name = "labelNome";
            this.labelNome.Size = new System.Drawing.Size(105, 40);
            this.labelNome.TabIndex = 3;
            this.labelNome.Text = "Nome";
            // 
            // labelEmail
            // 
            this.labelEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelEmail.Location = new System.Drawing.Point(22, 257);
            this.labelEmail.Name = "labelEmail";
            this.labelEmail.Size = new System.Drawing.Size(105, 40);
            this.labelEmail.TabIndex = 4;
            this.labelEmail.Text = "Email";
            // 
            // textBoxName
            // 
            this.textBoxName.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxName.Location = new System.Drawing.Point(133, 209);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(372, 38);
            this.textBoxName.TabIndex = 5;
            // 
            // textBoxEmail
            // 
            this.textBoxEmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxEmail.Location = new System.Drawing.Point(133, 257);
            this.textBoxEmail.Name = "textBoxEmail";
            this.textBoxEmail.Size = new System.Drawing.Size(373, 38);
            this.textBoxEmail.TabIndex = 6;
            // 
            // buttonCriarTabela
            // 
            this.buttonCriarTabela.Location = new System.Drawing.Point(510, 393);
            this.buttonCriarTabela.Name = "buttonCriarTabela";
            this.buttonCriarTabela.Size = new System.Drawing.Size(177, 35);
            this.buttonCriarTabela.TabIndex = 7;
            this.buttonCriarTabela.Text = "Criar tabela";
            this.buttonCriarTabela.UseVisualStyleBackColor = true;
            this.buttonCriarTabela.Click += new System.EventHandler(this.buttonCriarTabela_Click);
            // 
            // buttonInserir
            // 
            this.buttonInserir.Location = new System.Drawing.Point(511, 434);
            this.buttonInserir.Name = "buttonInserir";
            this.buttonInserir.Size = new System.Drawing.Size(177, 35);
            this.buttonInserir.TabIndex = 8;
            this.buttonInserir.Text = "Inserir";
            this.buttonInserir.UseVisualStyleBackColor = true;
            this.buttonInserir.Click += new System.EventHandler(this.buttonInserir_Click);
            // 
            // buttonPesquisar
            // 
            this.buttonPesquisar.Location = new System.Drawing.Point(511, 475);
            this.buttonPesquisar.Name = "buttonPesquisar";
            this.buttonPesquisar.Size = new System.Drawing.Size(177, 35);
            this.buttonPesquisar.TabIndex = 9;
            this.buttonPesquisar.Text = "Pesquisar";
            this.buttonPesquisar.UseVisualStyleBackColor = true;
            this.buttonPesquisar.Click += new System.EventHandler(this.buttonPesquisar_Click);
            // 
            // buttonExcluir
            // 
            this.buttonExcluir.Location = new System.Drawing.Point(511, 516);
            this.buttonExcluir.Name = "buttonExcluir";
            this.buttonExcluir.Size = new System.Drawing.Size(177, 35);
            this.buttonExcluir.TabIndex = 10;
            this.buttonExcluir.Text = "Excluir";
            this.buttonExcluir.UseVisualStyleBackColor = true;
            this.buttonExcluir.Click += new System.EventHandler(this.buttonExcluir_Click);
            // 
            // buttonEditar
            // 
            this.buttonEditar.Location = new System.Drawing.Point(511, 557);
            this.buttonEditar.Name = "buttonEditar";
            this.buttonEditar.Size = new System.Drawing.Size(177, 35);
            this.buttonEditar.TabIndex = 11;
            this.buttonEditar.Text = "Editar";
            this.buttonEditar.UseVisualStyleBackColor = true;
            this.buttonEditar.Click += new System.EventHandler(this.buttonEditar_Click);
            // 
            // buttonCreateDatabaseMysql
            // 
            this.buttonCreateDatabaseMysql.Location = new System.Drawing.Point(511, 311);
            this.buttonCreateDatabaseMysql.Name = "buttonCreateDatabaseMysql";
            this.buttonCreateDatabaseMysql.Size = new System.Drawing.Size(177, 35);
            this.buttonCreateDatabaseMysql.TabIndex = 12;
            this.buttonCreateDatabaseMysql.Text = "Criar banco de dados";
            this.buttonCreateDatabaseMysql.UseVisualStyleBackColor = true;
            this.buttonCreateDatabaseMysql.Click += new System.EventHandler(this.buttonCreateDatabaseMySql_Click);
            // 
            // labelAge
            // 
            this.labelAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelAge.Location = new System.Drawing.Point(22, 308);
            this.labelAge.Name = "labelAge";
            this.labelAge.Size = new System.Drawing.Size(92, 40);
            this.labelAge.TabIndex = 13;
            this.labelAge.Text = "Idade";
            // 
            // maskedTextBoxAge
            // 
            this.maskedTextBoxAge.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maskedTextBoxAge.Location = new System.Drawing.Point(133, 308);
            this.maskedTextBoxAge.Mask = "000";
            this.maskedTextBoxAge.Name = "maskedTextBoxAge";
            this.maskedTextBoxAge.Size = new System.Drawing.Size(372, 38);
            this.maskedTextBoxAge.TabIndex = 14;
            this.maskedTextBoxAge.ValidatingType = typeof(int);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonSqLite);
            this.groupBox1.Controls.Add(this.radioButtonSqlCE);
            this.groupBox1.Controls.Add(this.radioButtonMySql);
            this.groupBox1.Location = new System.Drawing.Point(512, 184);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 100);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // radioButtonSqLite
            // 
            this.radioButtonSqLite.AutoSize = true;
            this.radioButtonSqLite.Location = new System.Drawing.Point(7, 70);
            this.radioButtonSqLite.Name = "radioButtonSqLite";
            this.radioButtonSqLite.Size = new System.Drawing.Size(55, 17);
            this.radioButtonSqLite.TabIndex = 2;
            this.radioButtonSqLite.TabStop = true;
            this.radioButtonSqLite.Text = "SqLite";
            this.radioButtonSqLite.UseVisualStyleBackColor = true;
            // 
            // radioButtonSqlCE
            // 
            this.radioButtonSqlCE.AutoSize = true;
            this.radioButtonSqlCE.Location = new System.Drawing.Point(7, 46);
            this.radioButtonSqlCE.Name = "radioButtonSqlCE";
            this.radioButtonSqlCE.Size = new System.Drawing.Size(126, 17);
            this.radioButtonSqlCE.TabIndex = 1;
            this.radioButtonSqlCE.TabStop = true;
            this.radioButtonSqlCE.Text = "SQL Compact Edition";
            this.radioButtonSqlCE.UseVisualStyleBackColor = true;
            // 
            // radioButtonMySql
            // 
            this.radioButtonMySql.AutoSize = true;
            this.radioButtonMySql.Location = new System.Drawing.Point(7, 22);
            this.radioButtonMySql.Name = "radioButtonMySql";
            this.radioButtonMySql.Size = new System.Drawing.Size(60, 17);
            this.radioButtonMySql.TabIndex = 0;
            this.radioButtonMySql.TabStop = true;
            this.radioButtonMySql.Text = "MySQL";
            this.radioButtonMySql.UseVisualStyleBackColor = true;
            // 
            // CommandsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 602);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.maskedTextBoxAge);
            this.Controls.Add(this.labelAge);
            this.Controls.Add(this.buttonCreateDatabaseMysql);
            this.Controls.Add(this.buttonEditar);
            this.Controls.Add(this.buttonExcluir);
            this.Controls.Add(this.buttonPesquisar);
            this.Controls.Add(this.buttonInserir);
            this.Controls.Add(this.buttonCriarTabela);
            this.Controls.Add(this.textBoxEmail);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelEmail);
            this.Controls.Add(this.labelNome);
            this.Controls.Add(this.labelResultado);
            this.Controls.Add(this.buttonConectar);
            this.Controls.Add(this.dataGridView1);
            this.Name = "CommandsForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonConectar;
        private System.Windows.Forms.Label labelNome;
        private System.Windows.Forms.Label labelEmail;
        private System.Windows.Forms.Button buttonCriarTabela;
        private System.Windows.Forms.Button buttonInserir;
        private System.Windows.Forms.Button buttonPesquisar;
        private System.Windows.Forms.Button buttonExcluir;
        private System.Windows.Forms.Button buttonEditar;
        internal System.Windows.Forms.Label labelResultado;
        private System.Windows.Forms.Button buttonCreateDatabaseMysql;
        private System.Windows.Forms.Label labelAge;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonSqLite;
        private System.Windows.Forms.RadioButton radioButtonSqlCE;
        private System.Windows.Forms.RadioButton radioButtonMySql;
        public System.Windows.Forms.TextBox textBoxName;
        public System.Windows.Forms.TextBox textBoxEmail;
        public System.Windows.Forms.MaskedTextBox maskedTextBoxAge;
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Idade;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nome;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
    }
}

