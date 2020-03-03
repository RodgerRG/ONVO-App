using ONVO_App.Structs;
using ONVO_App.Login;
namespace ONVO_App.Models
{
    public class AccountModel
    {
        public string username {get; set;}
        public string password {get; set;}
        public Player player {get; set;}
        public string salt {get; set;}

        public AccountModel(string username, string password, Player player, string salt) {
            this.username = username;
            this.password = password;
            this.player = player;
            this.salt = salt;
        }

        public AccountModel() {}

        public static explicit operator AccountModel(Account a) => new AccountModel(a.getUsername(), a.getPassword(), a.getPlayer(), a.getSalt());
    }
}