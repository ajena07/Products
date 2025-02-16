using System.Security.Cryptography;
using System.Text;

namespace ProductsWebAPI.Common
{
    public static class Utilities
    {
        public static int GenerateIdUsingSeedHashing(string ProductName, string ProductType)
        {
            string input = ProductName.Trim().ToLower() + ProductType.Trim().ToLower();  

            // Apply SHA-256 hash to the input string
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                string hashHex = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();  

                string hexDigits = hashHex.Substring(0, 8);  
                long numericId = Convert.ToInt64(hexDigits, 16); 

                int finalId = (int)(numericId % 1000000);
                if (finalId < 100000)
                {
                    finalId += 100000;
                }
                return finalId;
            }
        }


    }
}
