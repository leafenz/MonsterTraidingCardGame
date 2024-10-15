using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Models;

namespace MonsterTradingCardGame.Server
{
    public class Server
    {
        private TcpListener _listener;

        public Server(int port)
        {
            _listener = new TcpListener(IPAddress.Any, port);
        }

        public async Task StartAsync()
        {
            _listener.Start();
            Console.WriteLine("Server gestartet und wartet auf Verbindungen...");

            while (true)
            {
                TcpClient client = await _listener.AcceptTcpClientAsync();
                _ = Task.Run(() => HandleClientAsync(client));
            }
        }

        private async Task HandleClientAsync(TcpClient client)
        {
            try
            {
                using (NetworkStream stream = client.GetStream())
                {
                    byte[] buffer = new byte[1024];
                    int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
                    string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                    Console.WriteLine("Anfrage erhalten: \n" + request);

                    var response = RequestHandler.HandleRequest(request);
                    await SendResponseAsync(stream, response.Status, response.ContentType, response.Body);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler beim Verarbeiten der Anfrage: {ex.Message}");
                await SendResponseAsync(client.GetStream(), "500 Internal Server Error", "text/plain", "Ein Fehler ist aufgetreten.");
            }
            finally
            {
                client.Close();
            }
        }

        private async Task SendResponseAsync(NetworkStream stream, string status, string contentType, string body)
        {
            string response = $"HTTP/1.1 {status}\r\n" +
                              $"Content-Type: {contentType}\r\n" +
                              $"Content-Length: {body.Length}\r\n" +
                              $"\r\n" +
                              $"{body}";
            byte[] responseBytes = Encoding.UTF8.GetBytes(response);
            await stream.WriteAsync(responseBytes, 0, responseBytes.Length);
        }
    }
}
