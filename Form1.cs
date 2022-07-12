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
using System.Data.SQLite;
using MySql.Data.MySqlClient;
using System.Data.SqlServerCe;

namespace BancoDeDados {
    public partial class Form1: Form {
        public Form1() {
            InitializeComponent();
        }

        private void createDatabaseMySql() {
            string connString = "Server=127.0.0.1;Uid=root;Pwd=c96b8031";
            var connection = new MySqlConnection(connString);
            var command = connection.CreateCommand();

            try {
                labelResultado.Text = "Executando";
                connection.Open();
                command.CommandText = "CREATE DATABASE IF NOT EXISTS teste";
                command.ExecuteNonQuery();
                labelResultado.Text = "Criou o banco com sucesso";
            } catch(Exception ex) {
                labelResultado.Text = ex.Message;
            } finally {
                if(connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        private void insertDataOnMySql() {
            var connString = "Server=127.0.0.1;Database=teste;Uid=root;Pwd=c96b8031";
            var connection = new MySqlConnection(connString);
            connection.Open();

            try {
                var command = connection.CreateCommand();

                command.CommandText = "INSERT INTO person (IDADE, NAME, SEX) VALUES ('24', 'Mattheus', 'M')";
                command.ExecuteNonQuery();
                labelResultado.Text = "Inseriu os dados com sucesso";

            } catch(Exception ex) {
                labelResultado.Text = ex.Message;
            } finally {
                if(connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        private void connectDatabaseMySql() {
            string connString = "Server=127.0.0.1;Uid=root;Pwd=c96b8031";
            var connection = new MySqlConnection(connString);
            try {
                connection.Open();
                MessageBox.Show("Conectado com sucesso ao MySQL!");
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                if(connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        private void connectDatabaseCE() {
            string pathOfData = Application.StartupPath + @"\db\dbSQLServer.sdf";
            string stringConnection = @"DataSource = " + pathOfData + "; Password = '123'";
            SqlCeEngine db = new SqlCeEngine(stringConnection);

            if(!File.Exists(pathOfData)) {
                db.CreateDatabase();
            }

            db.Dispose();

            SqlCeConnection connection = new SqlCeConnection(stringConnection);

            try {
                connection.Open();
                MessageBox.Show("Conectou com o SQL Compact!");
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                connection.Close();
            }
        }
        private void connectDatabaseSqLite() {
            string pathOfData = Application.StartupPath + @"\db\dbSQLite.db";
            string stringConnection = @"Data Source = " + pathOfData + "; Version = 3";
            using(var connection = new SQLiteConnection(stringConnection)) {

                //if(!File.Exists(pathOfData)) {
                //    SQLiteConnection.CreateFile(pathOfData);
                //} //não precisa dessa verificação. Se já houver o arquivo, ele não cria no "connection.Open()";
                try {
                    connection.Open();
                    MessageBox.Show("Conectou com sucesso no SQLite");
                } catch(Exception ex) {
                    MessageBox.Show(ex.Message);
                } finally {
                    connection.Close();
                }
            }
        }
        private void buttonConectar_Click(object sender, EventArgs e) {
            connectDatabaseCE();

            connectDatabaseSqLite();

            connectDatabaseMySql();
        }
    }
}
