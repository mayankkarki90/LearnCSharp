using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace LearnCSharp
{
    public class HttpHandler
    {
        public static async Task<string> GetRequest(string url)
        {
            using (HttpClient httpClient = new HttpClient() { MaxResponseContentBufferSize = int.MaxValue })
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        public static async Task<string> PostStringRequest(string url, string data)
        {
            using (HttpClient httpClient = new HttpClient() { MaxResponseContentBufferSize = int.MaxValue })
            {
                HttpContent content = new StringContent(data);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                HttpResponseMessage response = await httpClient.PostAsync(new Uri(url), content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        public static async Task<string> PostFormUrlEncodedRequest(string url, IEnumerable<KeyValuePair<string, string>> data)
        {
            using (HttpClient httpClient = new HttpClient() { MaxResponseContentBufferSize = int.MaxValue })
            {
                HttpContent content = new FormUrlEncodedContent(data);
                content.Headers.ContentType = new MediaTypeHeaderValue("application/x-www-form-urlencoded");
                HttpResponseMessage response = await httpClient.PostAsync(new Uri(url), content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        public static async Task<string> PostMediaRequest(string url, byte[] chunks, string fileName)
        {
            using (HttpClient httpClient = new HttpClient() { MaxResponseContentBufferSize = int.MaxValue })
            {
                MultipartFormDataContent content = new MultipartFormDataContent();
                content.Add(new ByteArrayContent(chunks), "file", fileName);
                HttpResponseMessage response = await httpClient.PostAsync(new Uri(url), content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

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
        public static async Task<HttpResponseMessage> SendRequest(string url, HttpMethod verb, 
            string? accessToken = null, string tokenType = "Bearer",
            object? data = null, string contentType = "application/json", 
            Dictionary<string, string>? queryStringParams = null,
            Dictionary<string, string>? headers = null,
            int httpClientTimeOutMinutes = 5)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.Timeout = TimeSpan.FromMinutes(httpClientTimeOutMinutes);

            var queryString = BuildQueryString(queryStringParams);
            HttpRequestMessage request = new HttpRequestMessage(verb, url + queryString);

            if (!string.IsNullOrWhiteSpace(accessToken) && !string.IsNullOrWhiteSpace(tokenType))
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
        private static string BuildQueryString(Dictionary<string, string>? queryStringParams = null)
        {
            if (queryStringParams == null)
            {
                return string.Empty;
            }

            return string.Format("?{0}", string.Join("&", queryStringParams.Select(kvp => string.Format("{0}={1}", Uri.EscapeDataString(kvp.Key), Uri.EscapeDataString(kvp.Value)))));
        }
    }
}
