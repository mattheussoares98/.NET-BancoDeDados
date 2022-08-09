using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using Application = System.Windows.Forms.Application;

namespace BancoDeDados {
    internal static class SqLite {
        public static void connectDatabaseSqLite(Label labelResultado) {
            string pathOfData = Application.StartupPath + @"\dbSQLite.db";
            string stringConnection = @"Data Source = " + pathOfData + "; Version = 3";
            using(var connection = new SQLiteConnection(stringConnection)) {

                //if(!File.Exists(pathOfData)) {
                //    SQLiteConnection.CreateFile(pathOfData);
                //} //não precisa dessa verificação. Se já houver o arquivo, ele não cria no "connection.Open()";
                try {
                    connection.Open();
                    labelResultado.Text = "Conectou com sucesso no SQLite";
                } catch(Exception ex) {
                    MessageBox.Show(ex.Message);
                } finally {
                    connection.Close();
                }
            }
        }
    }
}
