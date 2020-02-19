using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Threading;
using System;
namespace ONVO_App.SocketManager
{
    public class SocketListener
    {
        private class StateObject {
            public Socket workSocket = null;
            public const int BufferSize = 1024;
            public byte[] buffer = new byte[BufferSize];
            public StringBuilder sb = new StringBuilder();
        }

        private ManualResetEvent allDone = new ManualResetEvent(false);
        private ConnectionStatus connectionStatus = ConnectionStatus.INITIALISED;

        public SocketListener() {
        }

        public void startListening() {
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress iPAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(iPAddress, 0);

            Socket listener = new Socket(iPAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

            try {
                listener.Bind(localEndPoint);
                listener.Listen(100);
                connectionStatus = ConnectionStatus.LISTENING;

                while(true) {
                    allDone.Reset();

                    Console.WriteLine("Waiting for a connection...");
                    listener.BeginAccept(new System.AsyncCallback(AcceptCallback), listener);

                    allDone.WaitOne();
                }
            } catch(Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        public void AcceptCallback(IAsyncResult ar) {
            allDone.Set();

            Socket listener = ar.AsyncState as Socket;
            Socket handler = listener.EndAccept(ar);

            StateObject state = new StateObject();
            state.workSocket = handler;

            connectionStatus = ConnectionStatus.CONNECTED;

            handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
        }

        public void ReadCallback(IAsyncResult ar) {
            String content = String.Empty;

            StateObject state = ar.AsyncState as StateObject;
            Socket handler = state.workSocket;

            int bytesRead = handler.EndReceive(ar);

            if (bytesRead > 0) {
                state.sb.Append(Encoding.ASCII.GetString(state.buffer, 0, bytesRead));
            }

            content = state.sb.ToString();
            if(content.IndexOf("<EOF>") > -1) {
                //TODO: Add parameters on constructor to allow for this to be read elsewhere...
                Send(handler, content);
            } else {
                handler.BeginReceive(state.buffer, 0, StateObject.BufferSize, 0, new AsyncCallback(ReadCallback), state);
            }
        }

        private void Send(Socket handler, String data) {    
            byte[] byteData = Encoding.ASCII.GetBytes(data);  
    
            handler.BeginSend(byteData, 0, byteData.Length, 0,  
            new AsyncCallback(SendCallback), handler);  
        }  

        private void SendCallback(IAsyncResult ar) {
            try {
                Socket handler = ar.AsyncState as Socket;

                int bytesSent = handler.EndSend(ar);

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            } catch(Exception e) {
                Console.WriteLine(e.ToString());
            }
        }

        public ConnectionStatus GetConnectionStatus() {
            return connectionStatus;
        }
    }
}