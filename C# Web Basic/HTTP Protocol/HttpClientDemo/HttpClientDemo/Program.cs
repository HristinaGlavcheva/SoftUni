using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace HttpClientDemo
{
    class Program
    {
        static Dictionary<string, int> SessionStorage = new Dictionary<string, int>();
        static string NewLine = "\r\n";

        static async Task Main(string[] args)
        {
            //await ReadData();

            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, 80);
            tcpListener.Start();

            // daemon // service
            while (true)
            {
                TcpClient client = tcpListener.AcceptTcpClient();
                ProcessClientAsync(client);
            }
        }

        public static async Task ProcessClientAsync(TcpClient client)
        {
            Console.WriteLine(client.Client.RemoteEndPoint); 
            
            using var stream = client.GetStream();

            byte[] buffer = new byte[1000000];
            var length = await stream.ReadAsync(buffer, 0, buffer.Length);

            var requestString = Encoding.UTF8.GetString(buffer, 0, length);
            Console.WriteLine(requestString);

            //Thread.Sleep(5000);

            var sid = Guid.NewGuid().ToString();
            var match = Regex.Match(requestString, @"sid=[^\n]*\r\n");
            if (match.Success)
            {
                sid = match.Value.Substring(4);
            }

            if (!SessionStorage.ContainsKey(sid))
            {
                SessionStorage.Add(sid, 0);
            }

            SessionStorage[sid]++;

            Console.WriteLine(sid);

            bool sessionSet = false;
            if (requestString.Contains("sid="))
            {
                sessionSet = true;
            }

            string html = $"<h1>Hello from TinaServer for the {SessionStorage[sid]} time {DateTime.Now}</h1>" +
                $"<form method=post><input name=username /><input name=pasword />" +
                $"<input type=submit /></form>" + DateTime.Now;

            var responseString = "HTTP/1.1 200 OK" + NewLine +
                "Server: TinaServer 2020" + NewLine +
                "Content-Type: text/html; charset=utf-8" + NewLine +
                //(!sessionSet ? ("Set-Cookie: sid=1dg2d1g2d1ag21g21d2; Path=/;" + NewLine) : string.Empty) +
                //"Set-Cookie: sid=1dg2d1g2d1ag21g21d2; Expires= " + DateTime.UtcNow.AddSeconds(30).ToString("R") + NewLine +
                $"Set-Cookie: sid={sid}; HttpOnly; Max-Age= " + (60 * 60 * 24 * 100) + NewLine +
                "Content-Length: " + html.Length + NewLine +
                NewLine +
                html +
                NewLine;

            //var responseString = "HTTP/1.1 200 OK" + NewLine +
            //    "Server: TinaServer 2020" + NewLine +
            //    "Content-Type: text/plain; charset=utf-8" + NewLine +
            //    "Content-Disposition: attachment; filename=tina.txt" + NewLine +
            //    "Content-Length: " + html.Length + NewLine +
            //    NewLine +
            //    html +
            //    NewLine;

            //var responseString = "HTTP/1.1 307 Redirect" + NewLine +
            //    "Server: TinaServer 2020" + NewLine +
            //    "Location: https://google.com" + NewLine +
            //    "Content-Type: text/html; charset=utf-8" + NewLine +
            //    "Content-Length: " + html.Length + NewLine +
            //    NewLine +
            //    html +
            //    NewLine;

            byte[] responseBytes = Encoding.UTF8.GetBytes(responseString);
            await stream.WriteAsync(responseBytes);

            Console.WriteLine(new string('=', 70));
        }

        static async Task ReadData()
        {
            Console.OutputEncoding = Encoding.UTF8;
            string url = "https://softuni.bg/trainings/3164/csharp-web-basics-september-2020/internal";
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync(url);
            Console.WriteLine(response.StatusCode);
            Console.WriteLine(response.Headers);
            Console.WriteLine(string.Join(Environment.NewLine, response.Headers.Select(x => x.Key + ": " + x.Value.First())));

            //var html = await httpClient.GetStringAsync(url);
            //Console.WriteLine(html);
        }
    }
}
