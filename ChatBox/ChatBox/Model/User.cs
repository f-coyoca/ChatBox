using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace ChatBox.Model
{
    public class User : INotifyPropertyChanged
    {
        private string userid;
        public string Userid
        {
            get { return userid; }
            set { userid = value; OnPropertyChanged("Userid"); }
        }
        private string username;
        public string Username
        {
            get { return username; }
            set { username = value; OnPropertyChanged("Username"); }
        }
        private string password;
        public string Password
        {
            get { return password; }
            set { password = value;OnPropertyChanged("Password"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            //
        }

        public static async Task<bool> Login(string username,string password)
        {
            bool isUserNameEmpty = string.IsNullOrEmpty(username);
            bool isPasswordEmpty = string.IsNullOrEmpty(password);

            if (isUserNameEmpty || isPasswordEmpty)
                return false;
            else
            {
                return true;
            }
        }
    }
}
