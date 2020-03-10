using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace HiperStream
{
    public static class AddressHelper
    {        
        public static bool CepValidate(string cep)
        {
            cep = cep.Trim();

            if (string.IsNullOrEmpty(cep) || cep.Length != 8 || Regex.IsMatch(cep, (@"^.*(?:(\d)\1{7})$")))
            {
                return false;
            }

            return true;
        }
    }
}
