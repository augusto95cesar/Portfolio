using System.Security.Cryptography;
using System.Text;

namespace MaximaCRUD.Service
{
    public static class Hash
    {
        public static string GerarHashSenha(this string texto)
        { 
            SHA256 sha256 = SHA256Managed.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(texto);
            byte[] hash = sha256.ComputeHash(bytes);
            StringBuilder result = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                result.Append(hash[i].ToString("X"));
            }
            return result.ToString();
        }

        public static string FormatQuery(this string value)
        {
            var teste = value.ToString().Replace("[", "\"").Replace("]", "\"");
            return teste;
        }
    }
}
