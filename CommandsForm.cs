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
using System.Data.SQLite;

namespace BancoDeDados {
    public partial class CommandsForm: Form {
        public CommandsForm() {
            InitializeComponent();
        }
       
        private void buttonConectar_Click(object sender, EventArgs e) {
            //SqlCompactEdition.createAndConnectDatabaseCE(labelResultado);

            //SqLite.connectDatabaseSqLite(labelResultado);

            //MySQL.connectDatabaseMySql(labelResultado);
        }

        private void buttonCriarTabela_Click(object sender, EventArgs e) {
            SqlCompactEdition.createTableCE(labelResultado);
        }
    }
}
