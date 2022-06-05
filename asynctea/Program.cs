using System;
using System.Threading;
using System.Threading.Tasks;

namespace asynctea
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var tea = await MakeTeaAsync();
            Console.WriteLine(tea);
        }

        public static async Task<string> MakeTeaAsync()
        {
            Console.WriteLine("main thread " + Thread.CurrentThread.ManagedThreadId);
            var boilingWaterTask = BoilWaterAsync();
            Console.WriteLine("take the cups out");
            Console.WriteLine("main thread " + Thread.CurrentThread.ManagedThreadId);

            var a = 0;
            for (var i = 0; i < 100_000_000; i ++ )
            {
                a =+ i;
            }
            Console.WriteLine("main thread after inc" + Thread.CurrentThread.ManagedThreadId);

            Console.WriteLine("put tea in cups");
            var water = await boilingWaterTask;
            var tea = $"poor {water} in cups";
            Console.WriteLine("main thread after water" + Thread.CurrentThread.ManagedThreadId);
            return tea;
        }

        public static async Task<string> BoilWaterAsync()
        {
            Console.WriteLine("start the kettle");
            Console.WriteLine("waiting for the kettle");
            Console.WriteLine("boil thread " + Thread.CurrentThread.ManagedThreadId);
            await Task.Delay(2000);
            Console.WriteLine("boil thread " + Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("kettle finished boiling");
            return "water";
        }
    }
}
