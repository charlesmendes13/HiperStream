using System;
using System.Data;
using System.IO;
using System.Text;

namespace HiperStream
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory.ToString(), "Baseficticia.txt");

            var dataTable = DataReaderHandler.FileToDataTable(path);

            int index = 0;

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                var dr = dataTable.Rows[index];

                if (!AddressHelper.CepValidate(dr["CEP"].ToString()))
                {
                    dr.Delete();
                    index -= 1;
                }

                index++;
            }

            dataTable.AcceptChanges();

            StringBuilder zeroeds = new StringBuilder();

            zeroeds = FormatterUtil.HeaderCreator();
            zeroeds.AppendLine();

            foreach (DataRow dr in dataTable.Rows)
            {
                if (dr[6].ToString() == "0")
                {
                    zeroeds.Append(dr[0].ToString() + "; ");
                    zeroeds.Append(FormatterUtil.AddressContact(dr));
                    zeroeds.Append(dr[6].ToString() + "; ");
                    zeroeds.Append(dr[7].ToString());

                    zeroeds.AppendLine();
                }
            }

            using (StreamWriter writer = new StreamWriter("FaturasZeradas.csv"))
            {
                writer.Write(zeroeds.ToString());
            }

            GeneratorHook generator = new GeneratorHook();
            generator.ByNumberOfPages(dataTable);
        }
    }
}
