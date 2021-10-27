using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace task_3
{
    class HMACGenerate
    {
        public static string genHMAC(string text, string key)
        {
            //var encodedvalue = Encoding.Unicode.GetBytes(stringvalue);
            //using (HashAlgorithm ssp = HashAlgorithm.Create("SHA256"))
            //{

            //    var digest = ssp.ComputeHash(encodedvalue);

            //    return BitConverter.ToString(digest).Replace("-", "").\;

            //}

            using (var hmacsha256 = new HMACSHA256(Encoding.UTF8.GetBytes(key)))
            {
                var hash = hmacsha256.ComputeHash(Encoding.Unicode.GetBytes(text));
                return BitConverter.ToString(hash).Replace("-", "");
            }
        }
    }
}
