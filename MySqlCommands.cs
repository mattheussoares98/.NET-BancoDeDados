using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoDeDados {
    public class MySqlCommands: ICommands {
        CommandsForm commandsForm;
        public MySqlCommands(CommandsForm commandsForm) {
            this.commandsForm = commandsForm;
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
            var connString = "Server=127.0.0.1;Database=teste;Uid=root;Pwd=c96b8031";
            var connection = new MySqlConnection(connString);
            connection.Open();

            try {
                var command = connection.CreateCommand();

                command.CommandText = $"INSERT INTO person (AGE, NAME, EMAIL) VALUES ('{commandsForm.maskedTextBoxAge.Text}', '{commandsForm.textBoxName.Text}', '{commandsForm.textBoxEmail.Text}')";
                command.ExecuteNonQuery();
                commandsForm.labelResultado.Text = "Inseriu os dados com sucesso";

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
        public void connectDatabase() {
            string connString = "Server=127.0.0.1;Uid=root;Pwd=c96b8031";
            var connection = new MySqlConnection(connString);
            try {
                connection.Open();
                commandsForm.labelResultado.Text = "Conectado com sucesso ao MySQL!";
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                if(connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        public void createDatabase() {
            string connString = "Server=127.0.0.1;Uid=root;Pwd=c96b8031";
            var connection = new MySqlConnection(connString);
            var command = connection.CreateCommand();

            try {
                commandsForm.labelResultado.Text = "Executando";
                connection.Open();
                command.CommandText = "CREATE DATABASE IF NOT EXISTS teste";
                command.ExecuteNonQuery();
                commandsForm.labelResultado.Text = "Criou o banco com sucesso";
            } catch(Exception ex) {
                commandsForm.labelResultado.Text = ex.Message;
            } finally {
                if(connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        public void createTable() {
            var connString = "Server=127.0.0.1;Database=teste;Uid=root;Pwd=c96b8031";
            var connection = new MySqlConnection(connString);
            connection.Open();

            try {
                var command = connection.CreateCommand();

                command.CommandText = "CREATE TABLE person (ID int NOT NULL AUTO_INCREMENT, AGE varchar(3) NOT NULL, NAME varchar(50) NOT NULL, EMAIL varchar(50) NOT NULL, PRIMARY KEY (ID))";
                command.ExecuteNonQuery();
                commandsForm.labelResultado.Text = "Criou a tabela com sucesso";

            } catch(Exception ex) {
                commandsForm.labelResultado.Text = ex.Message;
            } finally {
                if(connection.State == ConnectionState.Open)
                    connection.Close();
            }

        }

        public void selectData() {
            var connString = "Server=127.0.0.1;Database=teste;Uid=root;Pwd=c96b8031";
            var connection = new MySqlConnection(connString);
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
                MySqlDataAdapter sqlCeDataAdapter = new MySqlDataAdapter(query, connString);

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

                var connString = "Server=127.0.0.1;Database=teste;Uid=root;Pwd=c96b8031";
                var connection = new MySqlConnection(connString);
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
            var connString = "Server=127.0.0.1;Database=teste;Uid=root;Pwd=c96b8031";
            var connection = new MySqlConnection(connString);
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
