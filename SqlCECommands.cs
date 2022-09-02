using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoDeDados {
    internal class SqlCECommands: ICommands {
        private static string pathOfData = Application.StartupPath + @"\dbSQLServer.sdf";//se quiser colocar o arquivo do banco de dados dentro de alguma outra pasta, primeiro precisa criar essa pasta caso ela não exista senão vai dar erro
        private static string stringConnection = @"DataSource = " + pathOfData + "; Password = '123'";

        CommandsForm commandsForm;

        public SqlCECommands(CommandsForm commandsForm) {
            this.commandsForm = commandsForm;
        }

        public void createDatabase() {
            SqlCeEngine db = new SqlCeEngine(stringConnection);

            try {
                if(!File.Exists(pathOfData)) {
                    db.CreateDatabase(); //cria o arquivo que está no pathOfData
                }
                commandsForm.labelResultado.Text = "Conectado com sucesso ao banco de dados Sql Compact Edition";
            } catch(Exception ex) {
                commandsForm.labelResultado.Text = ex.Message;
            } finally {
                db.Dispose();
            }

        }
        public void connectDatabase() {


            SqlCeConnection connection = new SqlCeConnection(stringConnection);

            try {
                connection.Open();
                commandsForm.labelResultado.Text = "Conectou com o SQL Compact!";
            } catch(Exception ex) {
                commandsForm.labelResultado.Text = ex.Message;
            } finally {
                connection.Close();
            }
        }

        public void createTable() {

            SqlCeConnection connection = new SqlCeConnection(stringConnection);

            SqlCeCommand command = new SqlCeCommand();
            command.CommandText = "CREATE TABLE person (id INT IDENTITY NOT NULL PRIMARY KEY, AGE NVARCHAR(3), NAME NVARCHAR(50), EMAIL NVARCHAR(50))";
            command.Connection = connection;

            try {
                connection.Open();
                command.ExecuteNonQuery();

                commandsForm.labelResultado.Text = "Tabela 'person' criada no SqlCe";
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
            SqlCeConnection connection = new SqlCeConnection(stringConnection);

            SqlCeCommand command = new SqlCeCommand();
            command.CommandText = $"INSERT INTO person (AGE, NAME, EMAIL) VALUES ('{commandsForm.maskedTextBoxAge.Text}', '{commandsForm.textBoxName.Text}', '{commandsForm.textBoxEmail.Text}')";
            command.Connection = connection;

            try {
                connection.Open();
                command.ExecuteNonQuery();

                commandsForm.labelResultado.Text = "Dados inseridos com sucesso na tabela person do SQL CE";
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
            SqlCeConnection connection = new SqlCeConnection(stringConnection);
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
                SqlCeDataAdapter sqlCeDataAdapter = new SqlCeDataAdapter(query, stringConnection);

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

                SqlCeConnection connection = new SqlCeConnection(stringConnection);
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

        private void executeCommand(string commandText, string rowId) {
            SqlCeConnection connection = new SqlCeConnection(stringConnection);
            connection.Open();

            try {
                var command = connection.CreateCommand();

                command.CommandText = $"{commandText} where id = {rowId}";

                int rowsAffected = command.ExecuteNonQuery();
                if(rowsAffected > 0) {
                    commandsForm.labelResultado.Text = $"Alterou os dados com sucesso";
                } else {
                    commandsForm.labelResultado.Text = $"Não foram encontrados dados com esse parâmetro!";
                }

            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                if(connection.State == ConnectionState.Open)
                    connection.Close();

            }
        }
        public void updateData() {
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
                        executeCommand($"update person set email = '{commandsForm.textBoxEmail.Text}'", rowId);
                    }

                    if(commandsForm.textBoxName.Text != "") {
                        executeCommand($"update person set name = '{commandsForm.textBoxName.Text}'", rowId);
                    }

                    if(commandsForm.maskedTextBoxAge.Text != "") {
                        executeCommand($"update person set age = '{commandsForm.maskedTextBoxAge.Text}'", rowId);
                    }
                }
                commandsForm.textBoxEmail.Text = "";
                commandsForm.textBoxName.Text = "";
                commandsForm.maskedTextBoxAge.Text = "";
            }
            selectData();
        }
    }
}
