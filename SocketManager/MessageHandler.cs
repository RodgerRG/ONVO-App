using System.Text.Json;
using System.Text.Json.Serialization;
using ONVO_App.GoonGenerator;

namespace ONVO_App.SocketManager
{
    public class MessageHandler
    {
        public MessageHandler() {
        }

        public Goon deserializeGoon(string message) {
            Goon goon = JsonSerializer.Deserialize<Goon>(message);

            return goon;
        }

        public string serializeGoon(Goon g) {
            string json = JsonSerializer.Serialize<Goon>(g);

            return json;
        }
    }
}