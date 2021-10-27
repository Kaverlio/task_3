using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace task_3
{
    class KeyGenerate
    {
        public static string genPrivateKey()
        {
            byte[] random = new Byte[32];
            RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
            rng.GetBytes(random);
            return BitConverter.ToString(random).Replace("-", "");
        }
    }
}
