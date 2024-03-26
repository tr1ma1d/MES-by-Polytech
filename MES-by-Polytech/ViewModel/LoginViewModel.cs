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
using MES_by_Polytech.DateBase;
using MES_by_Polytech.View;
using Prism.Regions;


namespace MES_by_Polytech.ViewModel
{
    public class LoginViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;
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
        public DelegateCommand CloseCommand { get; }

        private UsersModel _userModel;

        public LoginViewModel()
        {

            Conncet con = new Conncet();
            LoginCommand = new DelegateCommand(Login);
            CloseCommand = new DelegateCommand(CloseCurrentWindow);
        }

        private void Login()
        {
            _userModel = new UsersModel();
          
            if (_userModel.IsValidCredentials(_username,_password))
            {
                UsersModel.Username = _username;
                MoveNextPage();
                MessageBox.Show("Успешная авторизация!");
                CloseCurrentWindow();
                        
            }
            else
            {
                MessageBox.Show("Неверные учетные данные!");
            }
        }
        private void MoveNextPage()
        {
            MainWindow main = new MainWindow();
            main.Show();
        }
        private void CloseCurrentWindow()
        {
            Application.Current.MainWindow.Close();
        }
    }
}
