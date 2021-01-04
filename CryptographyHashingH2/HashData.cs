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
        static private HMAC myMac = null;

        public static byte[] ComputeHmacsha256(byte[] toBeHashed, byte[] key)
        {
            myMac = new HMACSHA256(key);
            return myMac.ComputeHash(toBeHashed);
        }

        public static byte[] ComputeHmacsha1(byte[] toBeHashed, byte[] key)
        {
            using (myMac = new HMACSHA1(key))
            {
                return myMac.ComputeHash(toBeHashed);
            }
        }

        public static byte[] ComputeHmacmd5(byte[] toBeHashed, byte[] key)
        {
            myMac = new HMACMD5(key);
            return myMac.ComputeHash(toBeHashed);

        }

        /// <summary>
        /// Method for checking if a hash array has been altered 
        /// </summary>
        /// <param name="arrToCheck">Array that has been potentially altered</param>
        /// <param name="mac">Array that is used to check if <paramref name="arrToCheck"/> has been altered from it's actual result</param>
        /// <param name="key">Key for bath <paramref name="key"/> and <paramref name="arrToCheck"/></param>
        /// <returns></returns>
        public static bool CheckAuthenticity(byte[] arrToCheck, byte[] mac, byte[] key)
        {
            myMac.Key = key;

            if (CompareByteArrays(arrToCheck, mac, myMac.HashSize / 8) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static bool CompareByteArrays(byte[] a, byte[] b, int len)
        {
            for (int i = 0; i < len; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
