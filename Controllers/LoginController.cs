using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using ONVO_App.GoonGenerator;
using ONVO_App.Models;
using ONVO_App.Database;
using ONVO_App.Structs;
using ONVO_App.Login;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Threading;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Web;
using System.Net.Http;
using System.IO;
using System.Text.Json;
namespace ONVO_App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private DatabaseController databaseController;

        public LoginController() {
            databaseController = new DatabaseController();
        }

        [HttpPost("login")]
        public IActionResult login([FromBody] CredentialModel credentials) {
            string username = credentials.username;
            string password = credentials.password;

            AccountModel acc = databaseController.getAccount(username).Result;
            if(hashPass(Convert.FromBase64String(acc.salt), password) == acc.password){
                //TODO: Write in login procedures here, namely token generation to allow for easy communications/auth.
                return Accepted();
            } else {
                return Unauthorized("Bad Login Credentials");
            }
        }

        [HttpPost("signup")]
        public IActionResult signup([FromBody] string form) {
            if(form != null) {
                //for now, just add a dummy acc.
                byte[] salt = genSalt();
                string hashed = hashPass(salt, "foobar1");

                Account acc = new Account("foobar", hashed, Convert.ToBase64String(salt));
                databaseController.sendAccount((AccountModel) acc);

                Console.WriteLine(form);
                return Accepted();
            } else {
                return BadRequest();
            }
        }

        private string hashPass(byte[] salt, string pass) {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: pass,
                salt: salt,
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        private byte[] genSalt() {
            byte[] salt = new byte[128 / 8];
            using(var rng = RandomNumberGenerator.Create()) {
                rng.GetBytes(salt);
            }

            return salt;
        }
    }
}