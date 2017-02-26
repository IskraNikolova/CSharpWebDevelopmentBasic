namespace SimpleHttpServer
{
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;
    using Models;

    public class HttpServer
    {
        public HttpServer(int port, IEnumerable<Route> routes)
        {
            this.Port = port;
            this.IsActive = true;
            this.Sessions = new Dictionary<string, HttpSession>();
            this.Processor = new HttpProcessor(routes: routes, sessions: this.Sessions);
        }

        public IDictionary<string, HttpSession> Sessions { get; set; }

        public TcpListener Listener { get; private set; }

        public int Port { get; private set; }

        public HttpProcessor Processor { get; private set; }

        public bool IsActive { get; private set; }
       
        public void Listen()
        {
            this.Listener = new TcpListener(localaddr: IPAddress.Any, port: this.Port);
            this.Listener.Start();
            while (this.IsActive)
            {
                TcpClient client = this.Listener.AcceptTcpClient();
                Thread thread = new Thread(start: () =>
                {
                    this.Processor.HandleClient(tcpClient: client);
                });

                thread.Start();
                Thread.Sleep(millisecondsTimeout: 1);
            }
        }
    }
}