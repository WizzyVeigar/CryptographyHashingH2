using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptographyHashingH2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter text to hash");
                string hashString = Console.ReadLine();
                Console.WriteLine("Enter key");
                string userKey = Console.ReadLine();

                Console.WriteLine("Choose encryption form \n" +
                    "1. Sha256\n" +
                    "2. MD5\n" +
                    "3. Sha1");
                string encryptMethod = Console.ReadLine().ToLower();

                byte[] internalHashedArr = null;
                switch (encryptMethod)
                {
                    case "sha256":
                    case "1":
                        internalHashedArr = HashData.ComputeHmacsha256(Encoding.UTF8.GetBytes(hashString), Encoding.UTF8.GetBytes(userKey));
                        break;
                    case "md5":
                    case "2":
                        internalHashedArr = HashData.ComputeHmacmd5(Encoding.UTF8.GetBytes(hashString), Encoding.UTF8.GetBytes(userKey));
                        break;
                    case "sha1":
                    case "3":
                        internalHashedArr = HashData.ComputeHmacsha1(Encoding.UTF8.GetBytes(hashString), Encoding.UTF8.GetBytes(userKey));
                        break;
                    default:
                        break;
                }

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < internalHashedArr.Length; i++)
                {
                    builder.Append(internalHashedArr[i].ToString("x2"));
                }

                Console.WriteLine("is this validation? y/n");
                bool isValidation = Console.ReadLine().ToLower() == "y" ? true : false;
                if (isValidation)
                {
                    Console.WriteLine("Enter hashed text");
                    string uText = Console.ReadLine();

                    if (builder.ToString() == uText)
                    {
                        Console.WriteLine("Den er god nok");
                    }
                    else
                    {
                        Console.WriteLine("Something has been changed");
                    }
                }
                else
                {                   
                    Console.WriteLine("Hashed value: " + builder);
                }
                Console.ReadKey();
            }
        }
    }
}
