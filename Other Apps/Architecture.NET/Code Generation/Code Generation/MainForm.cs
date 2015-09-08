using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using USAACE.Common.Database;
using USAACE.Common.CodeServices;
using System.IO;

namespace Code_Generation
{
    public partial class frmCodeGeneration : Form
    {
        public frmCodeGeneration()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.SelectedPath = @"C:\Users\antonio.ponzi\Desktop\Temp\eStaffing";
            dialog.ShowDialog();

            Database database = new Database(txtConnectionString.Text);

            Directory.CreateDirectory(String.Format("{0}\\Data\\", dialog.SelectedPath));
            Directory.CreateDirectory(String.Format("{0}\\Code\\", dialog.SelectedPath));
            StreamWriter sqlFile = File.CreateText(String.Format("{0}\\Data\\SqlFile.sql", dialog.SelectedPath));

            foreach (Table table in database.Tables)
            {
                if (!table.IsView)
                {
                    sqlFile.Write(StoredProcedureGenerator.GenerateInsertProcedure(table));
                    sqlFile.Write(StoredProcedureGenerator.GenerateDeleteProcedure(table));
                    sqlFile.Write(StoredProcedureGenerator.GenerateUpdateProcedure(table));
                }

                sqlFile.Write(StoredProcedureGenerator.GenerateSearchProcedure(table));

                StreamWriter classFile = File.CreateText(String.Format("{0}\\Code\\{1}.cs", dialog.SelectedPath, table.Name));
                classFile.Write(ClassGenerator.GenerateClass(table, txtRootNamespace.Text));
                classFile.Close();
            }

            sqlFile.Close();

            MessageBox.Show("Completed!");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtConnectionString.Text = @"Data Source=RUCKA0011SPSDW1;Initial Catalog=eStaffing_Dev;Integrated Security=SSPI;";
            txtRootNamespace.Text = @"USAACE.eStaffing.Domain.Entities";
        }
    }
}
