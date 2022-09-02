using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoDeDados {
    interface ICommands {
        void createDatabase();
        void connectDatabase();
        void createTable();
        void insertData();
        void selectData();
        void deleteData();
        void updateData();
    }
}
