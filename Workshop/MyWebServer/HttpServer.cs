using MyWebServer.Http;
using MyWebServer.Responses;
using MyWebServer.Routing;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MyWebServer
{
    public class HttpServer
    {
        private readonly IPAddress iPAddress;
        private readonly int port;
        private readonly TcpListener listener;

        private readonly RoutingTable routingTable;

        public HttpServer(string ipAdress,int port, Action<IRoutingTable> routingTableConfiguration)
        {
            this.iPAddress = IPAddress.Parse(ipAdress);

            this.port = port;

            listener= new TcpListener(this.iPAddress, this.port);

           

            routingTableConfiguration(this.routingTable = new RoutingTable());

        }

        public HttpServer(int port, Action<IRoutingTable> routingTable) :this("127.0.0.1",port,routingTable)
        {

        }

        public HttpServer(string ipAdress, Action<IRoutingTable> routingTable) :this(ipAdress,5000,routingTable)    
        {
    

        }

        public HttpServer(Action<IRoutingTable> routingTable):this(5000,routingTable)
        {
          
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

                ;
                var response = this.routingTable.ExecuteRequest(request);

                await WriteResponse(networkStream,response);


                connection.Close();
            }

            
        }


        private async Task<string> ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var requestBuilder = new StringBuilder();

            var totalBytesRead = 0;

            do
            {
                var bytesRead = await networkStream.ReadAsync(buffer, 0, bufferLength);

                totalBytesRead += bytesRead;

                if (bytesRead>10*bufferLength)
                {
                    throw new InvalidOperationException("Request is too large");

                }

                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));

            } while (networkStream.DataAvailable);
            

            return requestBuilder.ToString();
        }

        private async Task WriteResponse(
            NetworkStream networkStream,
            HttpResponse response)
        {
            var responseBytes = Encoding.UTF8.GetBytes(response.ToString());

            await networkStream.WriteAsync(responseBytes);

        }
    }
}
