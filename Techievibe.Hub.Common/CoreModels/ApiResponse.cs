using Newtonsoft.Json;

namespace Techievibe.Hub.Common.ApiModels
{
    /// <summary>
    /// Generic Api Response across the application.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// Creates a ApiResponse object with required properties.
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="StatusCode"></param>
        /// <param name="Errors"></param>
        public ApiResponse(T Data, int StatusCode, List<string> Errors)
        {
            this.Data = Data;
            this.StatusCode = StatusCode;
            this.Errors = Errors;
            this.ApiVersion = "v1";
        }

        /// <summary>
        /// The version of the API sent in the response
        /// </summary>
        [JsonProperty(Order = 1)]
        public string ApiVersion { get; set; }

        /// <summary>
        /// The status code in int
        /// </summary>
        [JsonProperty(Order = 2)]
        public int StatusCode { get; set; }

        /// <summary>
        /// List of errors in failure scenarios.
        /// </summary>
        [JsonProperty(Order = 4)]
        public List<string> Errors { get; set; }

        /// <summary>
        /// Data in success scenarios.
        /// </summary>
        [JsonProperty(Order = 3)]
        public T Data;
    }
}
