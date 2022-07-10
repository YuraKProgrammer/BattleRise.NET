using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleRise.TempAuth
{
    public class Account
    {
        public int id { get; }
        public string login { get; }
        public string password { get; }

        public Account(string login, string password, int id)
        {
            this.login = login;
            this.password = password;
            this.id = id;
        } 
    }
}
