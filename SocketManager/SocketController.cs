using System.Net.Sockets;
using System.Collections;
using System.Threading.Tasks;
using System.Threading;
using System;
namespace ONVO_App.SocketManager
{
    public class SocketController
    {
        private ArrayList listeners = new ArrayList();

        public SocketController() {

        }

        public void start() {
            Task t = new Task(createListener);
            t.ContinueWith(checkListeners, this);

            t.Start();
        }

        private void createListener() {
            SocketListener listener = new SocketListener();
            listeners.Add(listener);
            listener.startListening();
        }

        Action<Task, Object> checkListeners = (Task task, Object arg) => {
            SocketController sc = arg as SocketController;

            ArrayList listeners = sc.listeners;

            Action<Task, Object> createListener = (Task t, Object a) => {
                sc.createListener();
            };
            
            bool needsNew = true;
            foreach(SocketListener sl in listeners) {
                if(sl.GetConnectionStatus() == ConnectionStatus.LISTENING) {
                    needsNew = false;
                }
            }

            if(needsNew) {
                task.ContinueWith(createListener, sc);
            } else {
                task.ContinueWith(sc.checkListeners, arg);
            }
        };
    }
}