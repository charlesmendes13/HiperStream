using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace HiperStream
{
    public static class FormatterUtil
    {
        public static StringBuilder HeaderCreator()
        {
            StringBuilder builder = new StringBuilder();

            builder.Append("NomeCliente; ");
            builder.Append("EnderecoCompleto; ");
            builder.Append("ValorFatura; ");
            builder.Append("NumeroPaginas;");

            return builder;
        }

        public static StringBuilder AddressContact(DataRow row)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(row[1].ToString().Trim() + ", ");
            builder.Append(row[2].ToString() + ", ");
            builder.Append(row[3].ToString() + ", ");
            builder.Append(row[4].ToString() + ", ");
            builder.Append(row[5].ToString().Trim() + "; ");

            return builder;
        }
    }
}
