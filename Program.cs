using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace HashGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            // Check if a file was dropped on the executable
            if (args.Length == 0)
            {
                Console.WriteLine("No file was dropped on the executable.");
                return;
            }

            // Get the path of the dropped file
            string filePath = args[0];

            // Check if the file exists
            if (!File.Exists(filePath))
            {
                Console.WriteLine("The file does not exist.");
                return;
            }

            // Calculate the MD5 hash
            string md5Hash = CalculateHash(filePath, new MD5CryptoServiceProvider());
            Console.WriteLine("MD5 hash: " + md5Hash);

            // Calculate the SHA1 hash
            string sha1Hash = CalculateHash(filePath, new SHA1CryptoServiceProvider());
            Console.WriteLine("SHA1 hash: " + sha1Hash);

            // Calculate the SHA256 hash
            string sha256Hash = CalculateHash(filePath, new SHA256CryptoServiceProvider());
            Console.WriteLine("SHA256 hash: " + sha256Hash);

            // Keep the console open
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }

        static string CalculateHash(string filePath, HashAlgorithm hashAlgorithm)
        {
            // Open the file
            using (FileStream stream = File.OpenRead(filePath))
            {
                // Calculate the hash
                byte[] hash = hashAlgorithm.ComputeHash(stream);

                // Convert the hash to a hexadecimal string
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
