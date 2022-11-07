using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyHashingH2
{
    class HashData
    {
        static private HashAlgorithm myAlgorithm = null;
        static IEnumerable<byte> combinedArr = null;
        public static byte[] ComputeHmacsha256(byte[] toBeHashed, byte[] key)
        {
            combinedArr = toBeHashed.Concat(key);
            if (myAlgorithm == null || myAlgorithm.GetType() != typeof(SHA256))
            {
                myAlgorithm = SHA256.Create();
            }
            return myAlgorithm.ComputeHash(combinedArr.ToArray());
        }
        public static byte[] ComputeHmacmd5(byte[] toBeHashed, byte[] key)
        {
            combinedArr = toBeHashed.Concat(key);
            if (myAlgorithm == null || myAlgorithm.GetType() != typeof(MD5))
            {
                myAlgorithm = MD5.Create();
            }
            return myAlgorithm.ComputeHash(combinedArr.ToArray());
        }

        public static byte[] ComputeHmacsha1(byte[] toBeHashed, byte[] key)
        {
            combinedArr = toBeHashed.Concat(key);
            if (myAlgorithm == null || myAlgorithm.GetType() != typeof(SHA1))
            {
                myAlgorithm = SHA1.Create();
            }
            return myAlgorithm.ComputeHash(combinedArr.ToArray());
        }
    }
}
