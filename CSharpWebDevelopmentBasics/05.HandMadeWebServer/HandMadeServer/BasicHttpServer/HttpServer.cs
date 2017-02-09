namespace BasicHttpServer
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using Models;

    public class HttpServer
    {

        public HttpServer(ushort portNumber, IEnumerable<Route> routes)
        {
            this.Port = portNumber;
            this.HttpProcessor = new HttpProcessor(routes);
            this.IsActive = true;
            
        }
        public TcpListener TcpListener { get; set; }

        public ushort Port { get; set; }

        public bool IsActive { get; set; }

        public HttpProcessor HttpProcessor { get; set; }

        public void Listen()
        {
            this.TcpListener = new TcpListener(IPAddress.Any, this.Port);
            this.TcpListener.Start();
            while (IsActive)
            {
                TcpClient client = TcpListener.AcceptTcpClient();
                Thread thread = new Thread(() =>
                {
                    this.HttpProcessor.HandleClient(client);
                });
                thread.Start();
                Thread.Sleep(1);
            }
        }
    }
}
