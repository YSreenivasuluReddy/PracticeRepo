using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientEx
{
    internal class Program
    {
        //here i will change the entry method as asynchronous,
        //because here i am getting the response from the third party module.
        static async Task Main(string[] args)
        {
            //now here i will use the HttpClient class,
            //because here i want to communicate with the third party api.
            HttpClient _client = new HttpClient();

            //now i will send the above request to get the response.
            HttpResponseMessage response = await _client.GetAsync("https://dummyjson.com/users");

            //now i want to check whether it retuns which status code.
            Console.WriteLine(response.StatusCode.ToString());

            //now i will convert the data in to readable mode.
            var data = await response.Content.ReadAsStringAsync();
            //here ReadAsStringAsync - is used to Serilaize the HTTP Content to a string,
            //as a asynchronous operation.

            Console.WriteLine(data);
            Console.ReadLine();

            //foreach (var item in data)
            //{
            //    string 
            //}

        }
    }
}
