using System;
using System.IO;
using System.Net;
using System.Text;

namespace WebServer
{
    class Program
    {
        static void Main(string[] args)
        {
            HttpListener hl = new HttpListener();
            hl.Prefixes.Add("http://localhost:8888/pp/");

            hl.Start();

            Console.WriteLine("Waiting Conections...");

            while (true)
            {
                HttpListenerContext context = hl.GetContext();
                HttpListenerResponse response = context.Response;

                StreamReader sr = new StreamReader(@"C:/ORT_DZ/server/index.html", Encoding.UTF8);
                string text = sr.ReadToEnd();

                byte[] buffer = Encoding.UTF8.GetBytes(text);
                response.ContentLength64 = buffer.Length;
                Stream stream = response.OutputStream;
                stream.Write(buffer, 0, buffer.Length);
                stream.Close();

                hl.Stop();
                Console.WriteLine("Conection complete!");
            }
        }
    }
}
