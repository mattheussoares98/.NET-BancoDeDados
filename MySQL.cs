using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoDeDados {
    internal static class MySQL {
        public static void insertDataOnMySql(Label labelResultado) {
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
        public static void connectDatabaseMySql(Label labelResultado) {
            string connString = "Server=127.0.0.1;Uid=root;Pwd=c96b8031";
            var connection = new MySqlConnection(connString);
            try {
                connection.Open();
                labelResultado.Text = "Conectado com sucesso ao MySQL!";
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                if(connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        public static void createDatabaseMySql(Label labelResultado) {
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
    }
}
