using FirstWorkshop.Server.Http;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FirstWorkshop.Server
{
    public class HttpServer
    {
        private readonly IPAddress iPAddress;
        private readonly int port;
        private readonly TcpListener listener;

        public HttpServer(string ipAdress,int port)
        {
            this.iPAddress = IPAddress.Parse(ipAdress);

            this.port = port;

            listener= new TcpListener(this.iPAddress, this.port);

        }

        public  async Task Start()
        {
           

            listener.Start();

            Console.WriteLine($"Server started on port {port}...");
            Console.WriteLine($"Listening for request");

            while (true)
            {
                ;
                var connection = await listener.AcceptTcpClientAsync();

                var networkStream = connection.GetStream();

                var requestText = await ReadRequest(networkStream);

                Console.WriteLine(requestText);

                var request = HttpRequest.Parse(requestText);

                await WriteResponse(networkStream);


                connection.Close();
            }

            
        }


        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var requestBuilder = new StringBuilder();

            var totalBytesRead = 0;

            while (networkStream.DataAvailable)
            {
                var bytesRead = await networkStream.ReadAsync(buffer, 0, bufferLength);

                totalBytesRead += bytesRead;

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));


            }

            return requestBuilder.ToString();
        }

        private async Task WriteResponse(NetworkStream networkStream)
        {

            var content = @"
<html>
    <head>
        <link rel = ""icon"" href = ""data:,"" >
     
         </head>
     
         <body>
             Hello from my server!
     
         </body>
     </html>";

            var contentLength = Encoding.UTF8.GetByteCount(content);



            var response = $@"
HTTP/1.1 200 OK
Server: My Web Server
Date: {DateTime.UtcNow:r}
Content-Length: {contentLength}
Content-Type: text/html; charset=UTF-8

{content}";

            var responseBytes = Encoding.UTF8.GetBytes(response);

            await networkStream.WriteAsync(responseBytes);

        }
    }
}
