using ONVO_App.Structs;
namespace ONVO_App.Login
{
    public class Account
    {
        private string username;
        private string salt;
        private string password;
        private Player character;

        public Account(string username, string password, string salt) {
            this.username = username;
            this.password = password;
            this.salt = salt;
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

        public string getPassword() {
            return password;
        }

        public Player getPlayer() {
            return character;
        }

        public string getSalt() {
            return salt;
        }
    }
}