using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace BattleRise.TempAuth
{
    public class AccountStorage
    {
        private const string fileFolder = @"D:\BattleRiseAccounts.json";
        private List<Account> accounts = new List<Account>();
        public void Register(string login, string password)
        {
            LoadAccounts();
            var logAccounts = accounts.Where(a => a.login==login).ToList();
            if (logAccounts == null)
            {
                accounts.Add(new Account(login, password, accounts.Count + 1));
                var options = new JsonSerializerOptions { WriteIndented = true };
                string json = System.Text.Json.JsonSerializer.Serialize(accounts, options);
                File.WriteAllText(fileFolder, json);
            }
            else
            {
                throw new Exception("Аккаунт с таким логином уже есть");
            }
        }

        public int LoginByPassword(string login, string password)
        {
            LoadAccounts();
            var account = accounts.Where(a => a.login == login).Where(a => a.password == password).FirstOrDefault();
            if (account != null)
                return account.id;
            else
                return 0;
        }

        private void LoadAccounts()
        {
            if (File.Exists(fileFolder))
            {
                accounts = JsonConvert.DeserializeObject<List<Account>>(File.ReadAllText(fileFolder)).ToList();
            }
        }
    }
}
