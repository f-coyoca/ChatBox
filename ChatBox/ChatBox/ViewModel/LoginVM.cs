using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using ChatBox.Model;
using ChatBox.View;

namespace ChatBox.ViewModel.Command
{
    class LoginVM : INotifyPropertyChanged
    {
        private User user;
        public User User
        {
            get { return user; }
            set { user = value; OnPropertyChanged("User"); }
        }
        private string username;
        public string Username
        {
            get { return username; }
            set { username = value;
                User = new User()
                {
                    Username = this.Username,
                    Password = this.Password
                };
            }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                User = new User()
                {
                    Username = this.Username,
                    Password = this.Password
                };
                OnPropertyChanged("Password");
            }
        }
        
        
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string parameter)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(parameter));
        }
        public LoginCommand LoginCommand { get; set; }
        public LoginVM()
        {
            User = new User();
            LoginCommand = new LoginCommand(this);
        }

        public async void Login()
        {
            bool canLogin = await User.Login(User.Username, User.Password);
            if (canLogin)
                await App.Current.MainPage.Navigation.PushAsync(new HomePage());
            else
                await App.Current.MainPage.DisplayAlert("Error", "Please valid field", "Ok");
        }

    }
}
