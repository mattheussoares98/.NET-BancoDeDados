using Microsoft.Data.Sqlite;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;

namespace BancoDeDados {
    internal class SqLiteCommands: ICommands {
        private static readonly string pathOfData = Application.StartupPath + @"\dbSQLite.db"; //se quiser colocar o arquivo do banco de dados dentro de alguma outra pasta, primeiro precisa criar essa pasta caso ela não exista senão vai dar erro
        private static readonly string stringConnection = @"Data Source = " + pathOfData + "; Version = 3";

        CommandsForm commandsForm;
        public SqLiteCommands(CommandsForm commandsForm) {
            this.commandsForm = commandsForm;
        }
        public void connectDatabase() {
            using(var connection = new SQLiteConnection(stringConnection)) {

                //if(!File.Exists(pathOfData)) {
                //    SQLiteConnection.CreateFile(pathOfData);
                //} //não precisa dessa verificação. Se já houver o arquivo, ele não cria no "connection.Open()";
                try {
                    connection.Open();
                    commandsForm.labelResultado.Text = "Banco do SqLite conectado/criado com sucesso";
                } catch(Exception ex) {
                    commandsForm.labelResultado.Text = ex.Message;
                } finally {
                    connection.Close();
                }
            }
        }

        public void createDatabase() {
            throw new NotImplementedException();
        }

        public void createTable() {
            SQLiteConnection connection = new SQLiteConnection(stringConnection);

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = "CREATE TABLE person (id INTEGER PRIMARY KEY AUTOINCREMENT, NAME NVARCHAR(50), EMAIL NVARCHAR(50), AGE NVARCHAR(3))";
            command.Connection = connection;

            try {
                connection.Open();
                command.ExecuteNonQuery();

                commandsForm.labelResultado.Text = "Tabela 'person' criada no Sqlite";
                command.Dispose();

            } catch(Exception ex) {
                commandsForm.labelResultado.Text = ex.Message;
            } finally {
                connection.Close();
            }

        }

        public void insertData() {
            if(commandsForm.textBoxName.Text.Length == 0 || commandsForm.textBoxName.Text == "") {
                MessageBox.Show("Digite o nome");
                return;
            } else if(!commandsForm.textBoxEmail.Text.Contains("@")) {
                MessageBox.Show("O e-mail não é válido!");
                return;
            } else if(commandsForm.maskedTextBoxAge.Text.Length == 0 || commandsForm.maskedTextBoxAge.Text == "") {
                MessageBox.Show("Insira a idade!");
                return;
            }
            SQLiteConnection connection = new SQLiteConnection(stringConnection);

            SQLiteCommand command = new SQLiteCommand();
            command.CommandText = $"INSERT INTO person (NAME,EMAIL,AGE) VALUES( '{commandsForm.textBoxName.Text}', '{commandsForm.textBoxEmail.Text}', '{commandsForm.maskedTextBoxAge.Text}');";
            command.Connection = connection;

            try {
                connection.Open();
                command.ExecuteNonQuery();

                commandsForm.labelResultado.Text = "Dados inseridos com sucesso no Sqlite";
                command.Dispose();

                commandsForm.textBoxEmail.Text = "";
                commandsForm.textBoxName.Text = "";
                commandsForm.maskedTextBoxAge.Text = "";

            } catch(Exception ex) {
                commandsForm.labelResultado.Text = ex.Message;
            } finally {
                connection.Close();
                selectData();
            }
        }

        public void selectData() {
            SQLiteConnection connection = new SQLiteConnection(stringConnection);
            commandsForm.dataGridView1.Rows.Clear();

            try {
                connection.Open();

                string query = "select * from person";

                if(commandsForm.textBoxName.Text != "" && commandsForm.textBoxEmail.Text != "") {
                    query = $"select * from person where name like '%{commandsForm.textBoxName.Text}%' and email like '%{commandsForm.textBoxEmail.Text}%'";
                } else if(commandsForm.textBoxName.Text != "") {
                    query = $"SELECT * FROM person WHERE NAME LIKE '%{commandsForm.textBoxName.Text}%'";
                } else if(commandsForm.textBoxEmail.Text != "") {
                    query = $"select * from person where email like '%{commandsForm.textBoxEmail.Text}%'";
                }

                DataTable data = new DataTable();

                SQLiteDataAdapter sqlCeDataAdapter = new SQLiteDataAdapter(query, stringConnection);

                sqlCeDataAdapter.Fill(data);

                foreach(DataRow row in data.Rows) {
                    commandsForm.dataGridView1.Rows.Add(row.ItemArray);
                }

            } catch(Exception ex) {
                commandsForm.dataGridView1.Rows.Clear();
                commandsForm.labelResultado.Text = ex.Message;
            } finally {
                connection.Close();
            }
        }

        public void deleteData() {
            if(commandsForm.dataGridView1.SelectedRows.Count <= 0) {
                MessageBox.Show("Seleciona uma linha para excluir os dados dessa linha");
                return;
            } else {

                SQLiteConnection connection = new SQLiteConnection(stringConnection);
                connection.Open();

                try {
                    foreach(DataGridViewRow row in commandsForm.dataGridView1.SelectedRows) {
                        string rowId = row.Cells[0].Value.ToString();

                        var command = connection.CreateCommand();

                        command.CommandText = $"delete from person where id = '{rowId}'";

                        int rowsAffected = command.ExecuteNonQuery();
                        if(rowsAffected > 0) {
                            commandsForm.labelResultado.Text = $"Deletou os dados com sucesso";
                        } else {
                            commandsForm.labelResultado.Text = $"Não foram enconstrados dados com esse parâmetro!";
                        }
                    }

                    commandsForm.textBoxEmail.Text = "";
                    commandsForm.textBoxName.Text = "";
                    commandsForm.maskedTextBoxAge.Text = "";

                } catch(Exception ex) {
                    commandsForm.labelResultado.Text = ex.Message;
                } finally {
                    if(connection.State == ConnectionState.Open)
                        connection.Close();
                    selectData();
                }
            }

        }
        private void executeCommand(SQLiteCommand command) {

            try {

                int rowsAffected = command.ExecuteNonQuery();
                if(rowsAffected > 0) {
                    commandsForm.labelResultado.Text = $"Alterou os dados com sucesso";
                } else {
                    commandsForm.labelResultado.Text = $"Não foram encontrados dados com esse parâmetro!";
                }

            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {


            }
        }
        public void updateData() {
            SQLiteConnection connection = new SQLiteConnection(stringConnection);
            connection.Open();
            var command = connection.CreateCommand();


            if(commandsForm.dataGridView1.SelectedRows.Count <= 0) {
                MessageBox.Show("Seleciona uma linha para editar os dados dessa linha");
                return;
            } else if(commandsForm.dataGridView1.SelectedRows.Count > 1) {
                MessageBox.Show("Selecione apenas uma linha!");
                return;
            } else {
                foreach(DataGridViewRow row in commandsForm.dataGridView1.SelectedRows) {
                    string rowId = row.Cells[0].Value.ToString();

                    if(commandsForm.textBoxEmail.Text != "") {
                        command.CommandText = $"update person set email = '{commandsForm.textBoxEmail.Text}' where id = {rowId}";

                        executeCommand(command);
                    }

                    if(commandsForm.textBoxName.Text != "") {
                        command.CommandText = $"update person set name = '{commandsForm.textBoxName.Text}' where id = {rowId}";
                        executeCommand(command);
                    }

                    if(commandsForm.maskedTextBoxAge.Text != "") {
                        command.CommandText = $"update person set age = '{commandsForm.maskedTextBoxAge.Text}' where id = {rowId}";

                        executeCommand(command);
                    }
                }

                if(connection.State == ConnectionState.Open)
                    connection.Close();

                commandsForm.textBoxEmail.Text = "";
                commandsForm.textBoxName.Text = "";
                commandsForm.maskedTextBoxAge.Text = "";
            }
            selectData();
        }
    }
}
