using System.Net.Sockets;
using System.Text;
using System.Net;
using System.Threading;
namespace ONVO_App.SocketManager
{
    public class SocketListener
    {
        private class StateObject {
            private Socket workSocket = null;
            private const int BufferSize = 1024;
            private byte[] buffer = new byte[BufferSize];
            private StringBuilder sb = new StringBuilder();
        }

        private ManualResetEvent allDone = new ManualResetEvent(false);

        public SocketListener() {

        }

        public void startListening() {
            
        }
    }
}