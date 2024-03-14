using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using MES_by_Polytech.Macro;
using MES_by_Polytech.Model;
using Prism.Commands;
using Prism.Mvvm;
namespace MES_by_Polytech.ViewModel
{
    public class LoginViewModel : BindableBase
    {
        private string _username;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public DelegateCommand LoginCommand { get; }

        private UsersModel _userModel;

        public LoginViewModel()
        {
            LoginCommand = new DelegateCommand(Login);
        }

        private void Login()
        {
            // Здесь должна быть ваша логика проверки учетных данных
            if (Username == "admin" && Password == "admin")
            {
                MessageBox.Show("Успешная авторизация!");
            }
            else
            {
                MessageBox.Show("Неверные учетные данные!");
            }
        }
    }
}
