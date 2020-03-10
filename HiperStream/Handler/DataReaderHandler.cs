using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.IO;
using System.Text.RegularExpressions;

namespace HiperStream
{
    public static class DataReaderHandler
    {       
        public static DataTable FileToDataTable(string path)
        {
            DataTable dataTable = new DataTable();
            var rawFile = File.ReadAllLines(path);

            if (rawFile.Length > 0)
            {
                string firstLine = rawFile[0];
                string[] headerLabels = firstLine.Split(";");

                foreach (var header in headerLabels)
                {
                    dataTable.Columns.Add(new DataColumn(header));
                }

                for (int i = 1; i < rawFile.Length; i++)
                {
                   
                    string[] line = rawFile[i].Split(";");

                    DataRow dataRow = dataTable.NewRow();

                    for (int j = 0; j < dataRow.ItemArray.Length; j++)
                    {
                        dataRow[j] = line[j];
                    }

                    dataTable.Rows.Add(dataRow);
                }
            }

            return dataTable;
        }
    }
}
