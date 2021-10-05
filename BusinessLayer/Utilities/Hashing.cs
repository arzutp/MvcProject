using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Utilities
{
    public class Hashing
    {
        public static string MD5Olustur(string text)
        {
            MD5 md = new MD5CryptoServiceProvider();

            md.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            byte[] result = md.Hash;
            StringBuilder str = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                str.Append(result[i].ToString("x2"));
            }
            return str.ToString();

        }
    }
}
