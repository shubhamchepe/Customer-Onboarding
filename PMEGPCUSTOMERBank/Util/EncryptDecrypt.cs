using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace PMEGPCUSTOMERBank.Util
{
    public class EncryptDecrypt
    {
        // Encrypt request body
        public static string EncryptRequestBody(string plainJson)
        {
            //// Deserialize raw json string into object
            //var obj = JsonConvert.DeserializeObject<object>(plainJson);

            //// Re-serialize with indentation (pretty print like Postman)
            //string prettyJson = JsonConvert.SerializeObject(obj, Formatting.Indented);

            //// Base64 encode
            //var plainBytes = Encoding.UTF8.GetBytes(prettyJson);
            //string base64String = Convert.ToBase64String(plainBytes);

            //// Wrap inside "data"
            //var wrapper = new Dictionary<string, string>
            //{
            //    { "data", base64String }
            //};

            //return JsonConvert.SerializeObject(wrapper);

            // Pretty JSON
            var obj = System.Text.Json.JsonSerializer.Deserialize<object>(plainJson);
            var options = new System.Text.Json.JsonSerializerOptions { WriteIndented = true };
            string prettyJson = System.Text.Json.JsonSerializer.Serialize(obj, options);

            // Base64 encode
            var plainBytes = Encoding.UTF8.GetBytes(prettyJson);
            return Convert.ToBase64String(plainBytes); // 🔹 Only return encoded string
        }

        // Decrypt response body
        public static string DecryptRequestBody(string encryptedJson)
        {
            var obj = JsonConvert.DeserializeObject<Dictionary<string, string>>(encryptedJson);
            if (obj != null && obj.ContainsKey("data"))
            {
                string base64String = obj["data"];
                var plainBytes = Convert.FromBase64String(base64String);
                return Encoding.UTF8.GetString(plainBytes);
            }
            return encryptedJson; // fallback if not in expected format
        }
    }
}
