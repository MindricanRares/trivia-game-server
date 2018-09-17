using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TriviaServer.DAO.Utils
{
    public class Password
    {
        public String Pass { get; set; }

        public string EncryptString(string strEncrypted)
        {
            byte[] b = System.Text.ASCIIEncoding.ASCII.GetBytes(strEncrypted);
            string encryptedPassword = Convert.ToBase64String(b);
            return encryptedPassword;
        }

        public string DecryptString(string encrString)
        {
            byte[] b = Convert.FromBase64String(encrString);
            string decryptedPassword = System.Text.ASCIIEncoding.ASCII.GetString(b);
            return decryptedPassword;
        }
    }
}
