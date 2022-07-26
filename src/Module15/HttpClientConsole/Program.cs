using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace HttpClientConsole
{
    class Program
    {
        static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            try
            {
                HttpRequestMessage request = new(HttpMethod.Get, "http://localhost:8888/MyNameByCookies?name=Zairoff");
                //request.Headers.Add("X-MyName", "Maruf");

                HttpResponseMessage response = client.Send(request);
                response.EnsureSuccessStatusCode();
                string responseBody = response.Content.ReadAsStringAsync().Result;

                Console.WriteLine($"Response: {responseBody}, StatusCode: {response.StatusCode}");

                // if response contains cookie
                response.Headers.TryGetValues("Set-Cookie", out IEnumerable<string> values);

                foreach (var value in values)
                {
                    Console.WriteLine($"Cookie: {value}");
                }

                Console.ReadLine();
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Exception: {ex.Message}");
            }
        }
    }
}
