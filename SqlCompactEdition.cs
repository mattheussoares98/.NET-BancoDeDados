using System;
using System.Collections.Generic;
using System.Data.SqlServerCe;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BancoDeDados {
    internal class SqlCompactEdition {
        private static string pathOfData = Application.StartupPath + @"\dbSQLServer.sdf";
        private static string stringConnection = @"DataSource = " + pathOfData + "; Password = '123'";
        public static void createAndConnectDatabaseCE(Label labelResultado) {
            SqlCeEngine db = new SqlCeEngine(stringConnection);

            if(!File.Exists(pathOfData)) {
                db.CreateDatabase(); //cria o arquivo que está no pathOfData
            }

            db.Dispose();

            SqlCeConnection connection = new SqlCeConnection(stringConnection);

            try {
                connection.Open();
                labelResultado.Text = "Conectou com o SQL Compact!";
            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                connection.Close();
            }
        }

        public static void createTableCE(Label labelResultado) {

            SqlCeConnection connection = new SqlCeConnection(stringConnection);

            SqlCeCommand command = new SqlCeCommand();
            command.CommandText = "CREATE TABLE pessoas (id INT NOT NULL PRIMARY KEY, nome NVARCHAR(50), email NVARCHAR(50))";
            command.Connection = connection;

            try {
                connection.Open();
                command.ExecuteNonQuery();

                labelResultado.Text = "Tabela 'pessoas' criada no SqlCe";
                command.Dispose();

            } catch(Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                connection.Close();
            }
        }

    }
}
