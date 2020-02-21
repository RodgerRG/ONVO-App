using System.Web;
using System.Net.Http;
using System.IO;
using ONVO_App.Models;
using System;
namespace ONVO_App.Database
{
    public class DatabaseController
    {
        private string databaseURI;

        public DatabaseController() {
            StreamReader reader = new StreamReader(File.OpenRead(Directory.GetCurrentDirectory() + "/keys.txt"));

            string input = reader.ReadLine();
            string[] inputs = input.Split("");

            if(inputs[0] == "Database") {
                databaseURI = inputs[1];
            }
        }

        public async void sendGoon(GoonModel goon) {
            string endpoint = "/goon-table/";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync<GoonModel>(databaseURI + endpoint, goon);
            Console.WriteLine("Database URL is: " + databaseURI);
            Console.WriteLine("Sending data...");

            if((int)response.StatusCode == 200) {
                //do nothing here, it worked
            } else {
                //TODO: Add some handling to decide what to do depending on the error here.s
            }
        }
    }
}