using System.Web;
using System.Net.Http;
using System.IO;
using ONVO_App.Models;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using System.Collections.Generic;
namespace ONVO_App.Database
{
    public class DatabaseController
    {
        private string databaseURI;

        public DatabaseController() {
            StreamReader reader = new StreamReader(File.OpenRead(Directory.GetCurrentDirectory() + "/keys.txt"));

            string input = reader.ReadLine();
            string[] inputs = input.Split(" ");

            if(inputs[0] == "database") {
                databaseURI = inputs[1];
            }

            reader.Close();
        }

        public async void sendGoon(GoonModel goon) {
            string endpoint = "/goon-table/.json";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync<GoonModel>(databaseURI + endpoint, goon);

            if((int)response.StatusCode == 200) {
                //do nothing here, it worked
            } else {
                //TODO: Add some handling to decide what to do depending on the error here.s
            }
        }

        public async Task<List<GoonModel>> getGoons() {
            string endpoint = "/goon-table/.json";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(databaseURI + endpoint);

            Stream jsonStream = await response.Content.ReadAsStreamAsync();

            JsonDocument jsonDoc = await JsonDocument.ParseAsync(jsonStream);

            JsonElement.ObjectEnumerator jsonEnumerator = jsonDoc.RootElement.EnumerateObject();

            List<GoonModel> models = new List<GoonModel>();

            while(jsonEnumerator.MoveNext()) {
                string nestedJson = jsonEnumerator.Current.Value.GetRawText();
                Console.WriteLine(nestedJson);
                GoonModel model = JsonSerializer.Deserialize<GoonModel>(nestedJson);
                models.Add(model);
            }

            return models;
        }

        public async void sendAccount(AccountModel acc) {
            string endpoint = "/account-table/.json";

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.PostAsJsonAsync<AccountModel>(databaseURI + endpoint, acc);

            if((int)response.StatusCode == 200) {

            } else {

            }
        }

        public async Task<List<AccountModel>> getAccounts(string username) {
            string endpoint = "/account-table/.json";

            HttpClient client = new HttpClient();
            HttpResponseMessage resp = await client.GetAsync(databaseURI + endpoint);

            Stream jsonStream = await resp.Content.ReadAsStreamAsync();
            JsonDocument jsonDoc = await JsonDocument.ParseAsync(jsonStream);
            JsonElement.ObjectEnumerator jsonEnum = jsonDoc.RootElement.EnumerateObject();

            List<AccountModel> models = new List<AccountModel>();

            while(jsonEnum.MoveNext()) {
                string nestedJson = jsonEnum.Current.Value.GetRawText();
                AccountModel model = JsonSerializer.Deserialize<AccountModel>(nestedJson);

                models.Add(model);
            }

            return models;
        }

        public async Task<AccountModel> getAccount(string username) {
            string endpoint = "/account-table/.json";

            HttpClient client = new HttpClient();
            HttpResponseMessage resp = await client.GetAsync(databaseURI + endpoint);

            Stream jsonStream = await resp.Content.ReadAsStreamAsync();
            JsonDocument jsonDoc = await JsonDocument.ParseAsync(jsonStream);
            JsonElement.ObjectEnumerator jsonEnum = jsonDoc.RootElement.EnumerateObject();

            List<AccountModel> models = new List<AccountModel>();

            while(jsonEnum.MoveNext()) {
                string nestedJson = jsonEnum.Current.Value.GetRawText();
                AccountModel model = JsonSerializer.Deserialize<AccountModel>(nestedJson);

                if(model.username == username) {
                    return model;
                }
            }

            return null;
        }
    }
}