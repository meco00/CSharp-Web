using FirstWorkshop.Server;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FirstWorkshop
{
   public class Program
    {
        //localhost 127.01.01
       public static async Task Main(string[] args)
        {
            var server = new HttpServer("127.0.0.1",5050);

            await server.Start();
          
            
        }
    }
}
