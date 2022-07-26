using System;

namespace HttpServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var listener = new Listener("http://localhost:8888/");
            listener.Start();
            Console.WriteLine("Started ...");

            var run = true;
            while (run)
            {
                run = listener.Listen();
                Console.WriteLine("Received");
            }
        }
    }
}
