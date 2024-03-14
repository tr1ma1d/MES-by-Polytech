using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MES_by_Polytech.Model
{
    internal class UsersModel
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public bool IsValidCredentials(string username, string password)
        {
            return Username == username && Password == password;
        }
    }
}
