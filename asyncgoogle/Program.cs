using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace asyncgoogle
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("1 " + Thread.CurrentThread.ManagedThreadId);
            var client = new HttpClient();
            var task = Privet(client);
            Console.WriteLine("11 " + Thread.CurrentThread.ManagedThreadId);
            var a = 0;
            for (var i = 0; i < 10000000; i++)
            {
                a = i++;
            }
            Console.WriteLine("2 " + Thread.CurrentThread.ManagedThreadId);
            var page = await task;
            Console.WriteLine("3 " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("hello");
        }

        public static async Task<string> Privet(HttpClient client)
        {
            Console.WriteLine("sub " +Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(2000);
            Console.WriteLine("sub after delay" + Thread.CurrentThread.ManagedThreadId);
            return await client.GetStringAsync("https://google.com");
        }
    }
}
