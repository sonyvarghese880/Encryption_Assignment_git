using Encoding_Encryption_Assignment.Models;
using System;
using System.Linq;

namespace Encoding_Encryption_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**********************BINARY CONVERSION**********************");
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();

            BinaryConverter binaryConverter = new BinaryConverter();
            string binaryValue = binaryConverter.ConvertTo(name);
            Console.WriteLine($"{name} as Binary: {binaryValue}");

            Console.WriteLine("Enter the binary version of your name:");
            string binaryName = Console.ReadLine();

            Console.WriteLine($"Binary code entered in ASCII format: {binaryConverter.ConvertBinaryToString(binaryValue)}");

            Console.WriteLine("**********************HEXADECIMAL CONVERSION**********************");

            HexadecimalConverter hexadecimalConverter = new HexadecimalConverter();
            string hexadecimalValue = hexadecimalConverter.ConvertTo(name);
            Console.WriteLine($"{name} as Hexadecimal: {hexadecimalValue}");
            Console.WriteLine($"{name} from Hexadecimal to ASCII: {hexadecimalConverter.ConveryFromHexToASCII(hexadecimalValue)}");

            Console.WriteLine("**********************BASE64 CONVERSION**********************");
            Base64Converter base64Converter = new Base64Converter();
            string base64Value = base64Converter.StringToBase64(name);
            Console.WriteLine($"{name} as Base64: {base64Value}");

            Console.WriteLine("**********************ENCRYPTION AND DECRYPTION**********************");

            //Output the decoded Base64 string
            string nameBase64Decoded = base64Converter.Base64ToString(base64Value);
            //Console.WriteLine(nameBase64Decoded);
            Console.WriteLine($"{name} from Base64 to ASCII: {nameBase64Decoded}");

            //string unicodeString = "This string contains the unicode character Pi (\u03a0)";
            int[] cipher = new[] { 0, 2, 4, 6, 8, 10, 12 }; //even numbers
            string cipherasString = String.Join(",", cipher.Select(x => x.ToString())); //FOr display

            int encryptionDepth = 20;
            string myName = "VARGHESE";
            Encrypter encrypter = new Encrypter(myName, cipher, encryptionDepth);

            ////Single Level Encrytion
            //string nameEncryptWithCipher = Encrypter.EncryptWithCipher(unicodeString, cipher);
            //Console.WriteLine($"Encrypted once using the cipher {{{cipherasString}}} {nameEncryptWithCipher}");

            //string nameDecryptWithCipher = Encrypter.DecryptWithCipher(nameEncryptWithCipher, cipher);
            //Console.WriteLine($"Decrypted once using the cipher {{{cipherasString}}} {nameDecryptWithCipher}");

            //Deep Encrytion
            string nameDeepEncryptWithCipher = Encrypter.DeepEncryptWithCipher(myName, cipher, encryptionDepth);
            Console.WriteLine($"Deep Encrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepEncryptWithCipher}");

            string nameDeepDecryptWithCipher = Encrypter.DeepDecryptWithCipher(nameDeepEncryptWithCipher, cipher, encryptionDepth);
            Console.WriteLine($"Deep Decrypted {encryptionDepth} times using the cipher {{{cipherasString}}} {nameDeepDecryptWithCipher}");

            //Base64 Encoded
            //Console.WriteLine($"Base64 encoded {myName} {encrypter.Base64}");

            //string base64toPlainText = Encrypter.Base64ToString(encrypter.Base64);
            //Console.WriteLine($"Base64 decoded {encrypter.Base64} {base64toPlainText}");
        }
    }
}
