using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BE_012026.CommonNetcore
{
    public static class Sercutity
    {
        public static bool CheckSpecialCharacter(string inputString)
        {
            var regexItem = new Regex("^[a-zA-Z0-9 ]*$");
            if (!regexItem.IsMatch(inputString))
            {
                return false;
            }
            return true;
        }
        public static bool CheckXSSInput(string input)
        {
            try
            {
                var listdangerousString = new List<string> { "<applet", "<body", "<bgsound", "<embed", "<frame", "<script", "<img", "<onblur", "<onchange", "<onclick", "<ondblclick", "<enerror", "<onfocus", "<onkeydown", "<onkeypress", "<onkeyup", "<onload", "<onmousedown", "<onmousemove", "<onmouseout", "<onmouseover", "<onmouseup", "<onreset", "<onselect", "<onsubmit", "<onunload", "javascript:", "vbscript:", "onabort", "onactivate", "onafterprint", "onafterupdate", "onbeforeactivate", "onbeforecopy", "onbeforecut", "onbeforedeactivate", "onbeforeeditfocus", "onbeforepaste", "onbeforeprint", "onbeforeunload", "onbegin" };
                if (string.IsNullOrEmpty(input)) return false;


                foreach (var dangerous in listdangerousString)
                {
                    if (input.Trim().ToLower().IndexOf(dangerous) >= 0) return false;


                }
                return true;


            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static string GetSaltedHash(string password)
        {
            var salt = "Hqr^@iG%.GlE3)o"; //32 bytes = 256 bits

            //compute the hash
            var hash = ComputeHash(password, salt);

            //combine salt and hash for storage
            var saltedHash = new byte[salt.Length + hash.Length];


            return Convert.ToBase64String(saltedHash);
        }
        public static byte[] ComputeHash(string password, string salt)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                //combine password and salt
                var saltedPassword = Encoding.UTF8.GetBytes(password);
                var saltedPasswordWithSalt = new byte[saltedPassword.Length + salt.Length];
                return sha256.ComputeHash(saltedPasswordWithSalt);
            }
        }
        public static string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (var sha256Hash = System.Security.Cryptography.SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}
