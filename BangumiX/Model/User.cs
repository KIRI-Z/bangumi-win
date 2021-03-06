﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using BangumiX.Properties;

namespace BangumiX.Model
{
    public class User
    {
        public string username { get; set; }
        public string nickname { get; set; }
        public Dictionary<string, string> avatar { get; set; }
    }

    public class Login
    {
        public string Captcha { get; set; }

        private string _email;
        public string Email
        {
            get
            {
                _email = Settings.Default.Email;
                return _email;
            }
            set
            {
                _email = value;
                Settings.Default.Email = _email;
                Settings.Default.Save();
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                if (SavePassword)
                {
                    _password = Settings.Default.Password;
                }
                return _password;
            }
            set
            {
                _password = value;
                if (SavePassword)
                {
                    Settings.Default.Password = _password;
                    Settings.Default.Save();
                }
                else
                {
                    Settings.Default.Password = String.Empty;
                    Settings.Default.Save();
                }
            }
        }

        private bool _save_password;
        public bool SavePassword
        {
            get
            {
                _save_password = Settings.Default.SavePassword;
                return _save_password;
            }
            set
            {
                _save_password = value;
                Settings.Default.SavePassword = _save_password;
                Settings.Default.Save();
            }
        }

        private bool _never_ask;
        public bool NeverAsk
        {
            get
            {
                _never_ask = Settings.Default.NeverAsk;
                return _never_ask;
            }
            set
            {
                _never_ask = value;
                Settings.Default.NeverAsk = _never_ask;
                Settings.Default.Save();
            }
        }
    }

    public class Token
    {
        public uint user_id
        {
            get
            {
                return Settings.Default.UserID;
            }
            set
            {
                Settings.Default.UserID = value;
                Settings.Default.Save();
            }
        }
        public string access_token
        {
            get
            {
                return Settings.Default.AccessToken;
            }
            set
            {
                Settings.Default.AccessToken = value;
                Settings.Default.Save();
            }
        }
        public uint expires_in
        {
            get
            {
                return Settings.Default.Expire;
            }
            set
            {
                Settings.Default.Expire = value;
                Settings.Default.Save();
            }
        }
        public string refresh_token
        {
            get
            {
                return Settings.Default.RefreshToken;
            }
            set
            {
                Settings.Default.RefreshToken = value;
                Settings.Default.Save();
            }
        }
        public DateTime token_time
        {
            get
            {
                return Settings.Default.TokenTime;
            }
            set
            {
                Settings.Default.TokenTime = value;
                Settings.Default.Save();
            }
        }
        public string token_type
        {
            get
            {
                return Settings.Default.TokenType;
            }
            set
            {
                Settings.Default.TokenType = value;
                Settings.Default.Save();
            }
        }
    }
}
