using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using MySql.Data.MySqlClient;
using System.Data.SqlServerCe;


namespace BancoDeDados {
    public partial class CommandsForm: Form {
        readonly MySqlCommands mySqlCommands;
        readonly SqLiteCommands sqLiteCommands;
        readonly SqlCECommands sqlCECommands;
        public CommandsForm() {
            InitializeComponent();
            mySqlCommands = new MySqlCommands(this);
            sqlCECommands = new SqlCECommands(this);
            sqLiteCommands = new SqLiteCommands(this);
        }

        private void buttonConectar_Click(object sender, EventArgs e) {
            if(radioButtonMySql.Checked) {
                mySqlCommands.connectDatabase();
            } else if(radioButtonSqlCE.Checked) {
                sqlCECommands.connectDatabase();
            } else if(radioButtonSqLite.Checked) {
                sqLiteCommands.connectDatabase();
            } else {
                MessageBox.Show("Selecione um banco de dados!");
            }
        }

        private void buttonCriarTabela_Click(object sender, EventArgs e) {
            if(radioButtonMySql.Checked) {
                mySqlCommands.createTable();
            } else if(radioButtonSqlCE.Checked) {
                sqlCECommands.createTable();
            } else if(radioButtonSqLite.Checked) {
                sqLiteCommands.createTable();
            } else {
                MessageBox.Show("Selecione um banco de dados!");
            }
        }

        private void buttonInserir_Click(object sender, EventArgs e) {
            if(radioButtonMySql.Checked) {
                mySqlCommands.insertData();
            } else if(radioButtonSqlCE.Checked) {
                sqlCECommands.insertData();
            } else if(radioButtonSqLite.Checked) {
                sqLiteCommands.insertData();
            } else {
                MessageBox.Show("Selecione um banco de dados!");
            }
        }

        private void buttonCreateDatabaseMySql_Click(object sender, EventArgs e) {
            if(radioButtonMySql.Checked) {
                mySqlCommands.createDatabase();
            } else if(radioButtonSqlCE.Checked) {
                sqlCECommands.createDatabase();
            } else if(radioButtonSqLite.Checked) {
                sqLiteCommands.connectDatabase(); //coloquei o o "connectDatabase" porque o comando pra conectar e criar o banco de dados é o mesmo
            } else {
                MessageBox.Show("Selecione um banco de dados!");
            }
        }

        private void buttonPesquisar_Click(object sender, EventArgs e) {
            if(radioButtonMySql.Checked) {
                mySqlCommands.selectData();
            } else if(radioButtonSqlCE.Checked) {
                sqlCECommands.selectData();
            } else if(radioButtonSqLite.Checked) {
                sqLiteCommands.selectData();
            } else {
                MessageBox.Show("Selecione um banco de dados!");
            }
        }

        private void buttonExcluir_Click(object sender, EventArgs e) {
            if(radioButtonMySql.Checked) {
                mySqlCommands.deleteData();
            } else if(radioButtonSqlCE.Checked) {
                sqlCECommands.deleteData();
            } else if(radioButtonSqLite.Checked) {
                sqLiteCommands.deleteData();
            } else {
                MessageBox.Show("Selecione um banco de dados!");
            }
        }

        private void buttonEditar_Click(object sender, EventArgs e) {
            if(radioButtonMySql.Checked) {
                mySqlCommands.updateData();
            } else if(radioButtonSqlCE.Checked) {
                sqlCECommands.updateData();
            } else if(radioButtonSqLite.Checked) {
                sqLiteCommands.updateData();
            } else {
                MessageBox.Show("Selecione um banco de dados!");
            }
        }
    }
}
