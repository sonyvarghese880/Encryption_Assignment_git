using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Encoding_Encryption_Assignment.Models
{
    class Base64Converter
    {
        /// <summary>
        /// Encodes a String to a Base64 String
        /// </summary>
        /// <param name="data">String data</param>
        /// <returns>Base64 Encoded String</returns>
        public string StringToBase64(string data)
        {
            byte[] bytearray = Encoding.ASCII.GetBytes(data);

            string result = Convert.ToBase64String(bytearray);

            return result;
        }
        /// <summary>
        /// Converts a Base64 string to decoded String
        /// </summary>
        /// <param name="base64String">Base64 encoded string</param>
        /// <returns>Decoded String from Base64</returns>
        public  string Base64ToString(string base64String)
        {
            byte[] bytearray = Convert.FromBase64String(base64String);

            using (var ms = new MemoryStream(bytearray))
            {
                using (StreamReader reader = new StreamReader(ms))
                {
                    string text = reader.ReadToEnd();
                    return text;
                }
            }
        }
    }
}
