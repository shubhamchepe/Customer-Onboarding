using System.Text;

namespace PMEGPCUSTOMERBank.Util
{
    public class HttpClientClass
    {
        private static readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };

        public static async Task<string> PostAsyncTask(string url, string jsonContent)
        {
            try
            {
                var handler = new HttpClientHandler();

#if DEBUG
                // Bypass SSL for local development
                handler.ServerCertificateCustomValidationCallback =
                    (message, cert, chain, errors) => true;
#endif

                using var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(30);

                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(url, content);

                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ HTTP Error: {ex.Message}");
                throw;
            }
        }

        // In HttpClientClass (Util folder)
        public static async Task<string> GetStateAsyncTask(string url)
        {
            try
            {
                System.Diagnostics.Debug.WriteLine($"📤 GET Request: {url}");

                var handler = new HttpClientHandler();

#if DEBUG
                // Bypass SSL for local development
                handler.ServerCertificateCustomValidationCallback =
                    (message, cert, chain, errors) => true;
#endif

                using var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(30);

                var response = await client.GetAsync(url);

                System.Diagnostics.Debug.WriteLine($"📥 Response Status: {response.StatusCode}");

                if (!response.IsSuccessStatusCode)
                {
                    var errorContent = await response.Content.ReadAsStringAsync();
                    System.Diagnostics.Debug.WriteLine($"❌ Error Response: {errorContent}");
                    throw new Exception($"API returned {response.StatusCode}");
                }

                string result = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine($"📥 Response: {result.Substring(0, Math.Min(200, result.Length))}...");

                return result;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"❌ GetStateAsyncTask Error: {ex.Message}");
                System.Diagnostics.Debug.WriteLine($"❌ Stack Trace: {ex.StackTrace}");
                throw;
            }
        }

        public static async Task<string> PostRequestAsync(string apiUrl, string jsonString)
        {
            try
            {
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(apiUrl, content);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine($"API Error: {response.StatusCode}");
                    return "{}";
                }

                // Validate JSON
                if (string.IsNullOrWhiteSpace(responseBody) ||
                    (!responseBody.TrimStart().StartsWith("{") && !responseBody.TrimStart().StartsWith("[")))
                {
                    System.Diagnostics.Debug.WriteLine($"Invalid JSON Response: {responseBody}");
                    return "{}";
                }

                return responseBody;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in PostRequestAsync: {ex.Message}");
                return "{}";
            }
        }
    }
}