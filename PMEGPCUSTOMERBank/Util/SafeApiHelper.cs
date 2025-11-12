using Newtonsoft.Json;

namespace PMEGPCUSTOMERBank.Util
{
    public static class SafeApiHelper
    {
        /// <summary>
        /// Safely deserialize JSON response with error handling
        /// </summary>
        public static async Task<List<T>> SafeDeserializeList<T>(
            Func<Task<string>> apiCall,
            string errorContext = "API Call")
        {
            try
            {
                string response = await apiCall();

                // Check for empty or invalid response
                if (string.IsNullOrWhiteSpace(response) ||
                    response == "[]" ||
                    response == "{}")
                {
                    System.Diagnostics.Debug.WriteLine($"{errorContext}: Empty response");
                    return new List<T>();
                }

                // Attempt deserialization
                var result = JsonConvert.DeserializeObject<List<T>>(response);
                return result ?? new List<T>();
            }
            catch (JsonException jsonEx)
            {
                System.Diagnostics.Debug.WriteLine($"{errorContext} - JSON Error: {jsonEx.Message}");
                return new List<T>();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"{errorContext} - Error: {ex.Message}");
                return new List<T>();
            }
        }

        /// <summary>
        /// Safely deserialize single object response
        /// </summary>
        public static async Task<T> SafeDeserializeObject<T>(
            Func<Task<string>> apiCall,
            string errorContext = "API Call") where T : class, new()
        {
            try
            {
                string response = await apiCall();

                if (string.IsNullOrWhiteSpace(response) ||
                    response == "[]" ||
                    response == "{}")
                {
                    System.Diagnostics.Debug.WriteLine($"{errorContext}: Empty response");
                    return new T();
                }

                var result = JsonConvert.DeserializeObject<T>(response);
                return result ?? new T();
            }
            catch (JsonException jsonEx)
            {
                System.Diagnostics.Debug.WriteLine($"{errorContext} - JSON Error: {jsonEx.Message}");
                return new T();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"{errorContext} - Error: {ex.Message}");
                return new T();
            }
        }

        /// <summary>
        /// Check if device has internet connection
        /// </summary>
        public static bool HasInternetConnection()
        {
            try
            {
                var current = Connectivity.Current.NetworkAccess;
                return current == NetworkAccess.Internet;
            }
            catch
            {
                return false;
            }
        }
    }
}