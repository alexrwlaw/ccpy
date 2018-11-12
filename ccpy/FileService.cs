using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ccpy
{
    class FileService
    {
        public void LoadFiles(BindingSource bindingSource, string folderPath)
        {
            IEnumerable<string> files = Directory.EnumerateFiles(folderPath, "*.*", SearchOption.AllDirectories);

            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("Name", typeof(string));
            dataTable.Columns.Add("Size", typeof(long));
            dataTable.Columns.Add("Date", typeof(DateTime));

            foreach (string file in files)
            {
                FileInfo fileInfo = new FileInfo(file);

                DataRow dataRow = dataTable.NewRow();
                dataRow["Name"] = file;
                dataRow["Size"] = fileInfo.Length;
                dataRow["Date"] = fileInfo.LastWriteTime;
                dataTable.Rows.Add(dataRow);
            }

            bindingSource.DataSource = dataTable;
        }
    }
}
