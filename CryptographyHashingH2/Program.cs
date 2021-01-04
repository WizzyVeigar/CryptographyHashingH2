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


                Console.WriteLine("is this validation? y/n");
                bool isValidation = Console.ReadLine().ToLower() == "y" ? true : false;
                if (isValidation)
                {
                    Console.WriteLine("Enter hashed text");
                    string hashedText = Console.ReadLine();
                    Console.WriteLine("Your inserted text:\n" + hashedText);
                }

                switch (encryptMethod)
                {
                    case "sha256":
                    case "1":
                        Console.WriteLine("Hashed value: " + Convert.ToBase64String(HashData.ComputeHmacsha256(Encoding.UTF8.GetBytes(hashString), Encoding.UTF8.GetBytes(userKey))));
                        break;
                    case "md5":
                    case "2":
                        Console.WriteLine("Hashed value: " + Convert.ToBase64String(HashData.ComputeHmacmd5(Encoding.UTF8.GetBytes(hashString), Encoding.UTF8.GetBytes(userKey))));
                        break;
                    case "sha1":
                    case "3":
                        Console.WriteLine("Hashed value: " + Convert.ToBase64String(HashData.ComputeHmacsha1(Encoding.UTF8.GetBytes(hashString), Encoding.UTF8.GetBytes(userKey))));
                        break;
                    default:
                        break;
                }

                Console.ReadKey();
            }
        }
    }
}
