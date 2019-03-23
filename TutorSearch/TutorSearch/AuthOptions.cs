using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace TutorSearch
{
    public class AuthOptions
    {
        private const string KEY = "STidGP1M7Zy8YrtNGhy7132GNn4";   // ключ для шифрации

        public const string ISSUER = "TutorSearch"; // издатель токена
        public const int LIFETIME = 1; // время жизни токена - 1 минута

        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
