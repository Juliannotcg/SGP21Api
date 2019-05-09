using System.Security.Cryptography;
using System.Text;

namespace WebApi_SGP.Helpers
{
    public static class ConverterMD5
    {
        private static  string ConverterParaHexadecimal(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder(bytes.Length);
            foreach (byte a in bytes)
                sb.Append((a < 16) ? "0" + a.ToString("x") : a.ToString("x"));
            return sb.ToString();
        }

        public static string RetornarMD5String(string entrada)
        {
            byte[] processar = Encoding.Default.GetBytes(entrada);
            MD5CryptoServiceProvider cryptHandler = new MD5CryptoServiceProvider();
            byte[] hash = cryptHandler.ComputeHash(processar);
            return ConverterParaHexadecimal(hash);

        }
    }
}
