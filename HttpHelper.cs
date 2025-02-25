using System.Text;

namespace LearnCSharp
{
    /// <summary>
    /// Helper class to send htttp requests
    /// </summary>
    public class HttpHelper
    {
        /// <summary>
        /// The HTTP client time out minutes.
        /// </summary>
        private const int HttpClientTimeOutMinutes = 5;

        /// <summary>
        /// The form URL encoded content type
        /// </summary>
        public const string FormUrlEncodedContentType = "application/x-www-form-urlencoded; charset=utf-8";

        /// <summary>
        /// Sends the request.
        /// </summary>
        /// <param name="url">The endpoint.</param>
        /// <param name="verb">The verb.</param>
        /// <param name="accessToken">The access token.</param>
        /// <param name="tokenType">Type of the token.</param>
        /// <param name="data">The data.</param>
        /// <param name="contentType">Type of the content.</param>
        /// <param name="queryStringParams">The query string parameters.</param>
        /// <param name="headers">The headers.</param>
        /// <returns>
        /// HttpResponse.
        /// </returns>
        /// <exception cref="NotImplementedException">Supplied Http content type is not implemented.</exception>
        /// <exception cref="Exception">Error occurred while communicating with gateway.</exception>
        public static async Task<HttpResponseMessage> SendRequest(string url, HttpMethod verb, string accessToken = null, string tokenType = "Bearer", object data = null, string contentType = "application/json", Dictionary<string, string> queryStringParams = null, Dictionary<string, string> headers = null)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromMinutes(HttpClientTimeOutMinutes);

            var queryString = BuildQueryString(queryStringParams);
            HttpRequestMessage request = new HttpRequestMessage(verb, url + queryString);

            if (!string.IsNullOrWhiteSpace(accessToken))
            {
                request.Headers.Add("Authorization", $"{tokenType} {accessToken}");
            }

            if (headers != null && headers.Any())
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            if (data != null)
            {
                if (data is string stringContent)
                {
                    request.Content = new StringContent(stringContent, Encoding.UTF8, contentType);
                }
                else if (data is Dictionary<string, string> formBodyParams)
                {
                    request.Content = new FormUrlEncodedContent(formBodyParams);
                }
                else if (data is MemoryStream stream)
                {
                    request.Content = new StreamContent(stream);
                    request.Headers.Add("Content-Type", contentType);
                }
                else
                {
                    throw new NotImplementedException("Http content type not implemented");
                }
            }

            return await httpClient.SendAsync(request);
        }

        /// <summary>
        /// Builds the query string.
        /// </summary>
        /// <param name="queryStringParams">The query string parameters.</param>
        /// <returns></returns>
        private static string BuildQueryString(Dictionary<string, string> queryStringParams)
        {
            if (queryStringParams == null)
            {
                return string.Empty;
            }

            return string.Format("?{0}", string.Join("&", queryStringParams.Select(kvp => string.Format("{0}={1}", Uri.EscapeDataString(kvp.Key), Uri.EscapeDataString(kvp.Value)))));
        }
    }
}
