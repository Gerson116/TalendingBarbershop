using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace TalendingBarbershop.Data.Security
{
    public class Encrypt
    {
        public string EncriptingPassword(string pasword)
        {
            SHA256 sha256 = SHA256Managed.Create();
            ASCIIEncoding encoding = new ASCIIEncoding();
            byte[] stream = null;
            StringBuilder sb = new StringBuilder();
            stream = sha256.ComputeHash(encoding.GetBytes(pasword));
            for (int i = 0; i < stream.Length; i++)
            {
                sb.AppendFormat("{0:x2}", stream[i]);
            }
            return sb.ToString();
        }
    }
}
