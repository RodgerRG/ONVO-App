using ONVO_App.Structs;
namespace ONVO_App.Login
{
    public class Account
    {
        private string username;
        private string password;
        private Player character;

        public Account(string username, string password) {
            this.username = username;
            this.password = password;
        }

        public void setCharacter(Player player) {
            this.character = player;
        }

        public void setPassword(string password) {
            this.password = password;
        }

        public void setUsername(string username) {
            this.username = username;
        }

        public string getUsername() {
            return username;
        }
    }
}