using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MES_by_Polytech.DateBase;
namespace MES_by_Polytech.Model
{
    internal class UsersModel
    {   
        static public string Username { get; set; }
        public string Password { get; set; }
        Conncet connect;
        public UsersModel()
        {
            
        }
  
        public bool IsValidCredentials(string username, string password)
        {
            return username == "admin" && password == "admin";
        }
    }
}
