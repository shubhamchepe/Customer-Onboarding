using System.Text;

namespace PMEGPCUSTOMERBank.Util
{
    public class HttpClientClass
    {
        private static readonly HttpClient client = new HttpClient
        {
            Timeout = TimeSpan.FromSeconds(30)
        };

        public static async Task<string> PostAsyncTask(string apiUrl, string jsonString)
        {
            try
            {
                var content = new StringContent(jsonString, Encoding.UTF8, "application/json");
                var response = await client.PostAsync(apiUrl, content);

                // Read the raw response first
                string responseBody = await response.Content.ReadAsStringAsync();

                // Check if response is successful
                if (!response.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine($"API Error: {response.StatusCode}");
                    System.Diagnostics.Debug.WriteLine($"Response: {responseBody}");

                    // Return empty JSON array or object based on expected type
                    return "[]"; // or "{}" depending on what your code expects
                }

                // Validate if response is JSON
                if (string.IsNullOrWhiteSpace(responseBody) ||
                    (!responseBody.TrimStart().StartsWith("{") && !responseBody.TrimStart().StartsWith("[")))
                {
                    System.Diagnostics.Debug.WriteLine($"Invalid JSON Response: {responseBody}");
                    return "[]"; // Return empty array as fallback
                }

                return responseBody;
            }
            catch (HttpRequestException ex)
            {
                System.Diagnostics.Debug.WriteLine($"Network Error: {ex.Message}");
                return "[]";
            }
            catch (TaskCanceledException ex)
            {
                System.Diagnostics.Debug.WriteLine($"Request Timeout: {ex.Message}");
                return "[]";
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Unexpected Error: {ex.Message}");
                return "[]";
            }
        }

        public static async Task<string> GetStateAsyncTask(string apiUrl)
        {
            try
            {
                var response = await client.GetAsync(apiUrl);
                string responseBody = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    System.Diagnostics.Debug.WriteLine($"API Error: {response.StatusCode}");
                    return "[]";
                }

                // Validate JSON
                if (string.IsNullOrWhiteSpace(responseBody) ||
                    (!responseBody.TrimStart().StartsWith("{") && !responseBody.TrimStart().StartsWith("[")))
                {
                    System.Diagnostics.Debug.WriteLine($"Invalid JSON Response: {responseBody}");
                    return "[]";
                }

                return responseBody;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in GetStateAsyncTask: {ex.Message}");
                return "[]";
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