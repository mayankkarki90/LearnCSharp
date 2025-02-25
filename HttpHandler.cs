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
                HttpResponseMessage response = null;
                response = await httpClient.PostAsync(new Uri(url), content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }

        public static async Task<string> PostStringRequestWithFormUrlEncoded(string url, string data)
        {
            using (HttpClient httpClient = new HttpClient() { MaxResponseContentBufferSize = int.MaxValue })
            {
                HttpContent content = new StringContent(data);
                content.Headers.ContentType = new MediaTypeHeaderValue(@"application/x-www-form-urlencoded");
                HttpResponseMessage response = null;
                response = await httpClient.PostAsync(new Uri(url), content);
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
                HttpResponseMessage response = null;
                response = await httpClient.PostAsync(new Uri(url), content);
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
                HttpResponseMessage response = null;
                response = await httpClient.PostAsync(new Uri(url), content);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
