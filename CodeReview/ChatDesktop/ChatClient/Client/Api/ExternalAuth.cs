using System;
using System.Collections.Generic;
using Nemiro.OAuth.LoginForms;

namespace Client.Api
{
    class ExternalAuth
    {
        public ExternalAuth() { }

        public string[] Google_Auth()
        {
            string[] info = new string[2];

            var login = new GoogleLogin("282890727966-fnsa1tofldqjseo801t93i8lah4bijko.apps.googleusercontent.com", "rK8eRcFoO6CjYP9PmrwUczZW", "https://www.googleapis.com/auth/plus.login", autoLogout: true, loadUserInfo: true);
            login.ShowDialog();

            if (login.IsSuccessfully)
            {
                info[0] = login.UserInfo.FirstName;
                info[1] = login.UserInfo.UserId;
            }
            return info;
        }

        public string[] Facebook_Auth()
        {
            string[] info = new string[2];

            var login = new FacebookLogin("1435890426686808", "c6057dfae399beee9e8dc46a4182e8fd", autoLogout: true, loadUserInfo: true);
            login.ShowDialog();

            if (login.IsSuccessfully)
            {
                info[0] = login.UserInfo.FirstName;
                info[1] = login.UserInfo.UserId;
            }

            return info;
        }

        public string Tr(string s)
        {
            string ret = "";
            List<String> rus = new List<string>{ "а", "б","в","г","д","е","ё","ж","з","и","й","к","л","м","н","о","п","р","с","т","у","ф","х","ц","ч","ш","щ","ъ","ы","ь","э","ю","я",
            "А","Б","В","Г","Д","Е","Ё","Ж","З","И","Й","К","Л","М","Н","О","П","Р","С","Т","У","Ф","Х","Ц","Ч","Ш","Щ","Ъ","Ы","Ь","Э","Ю","Я"};
            List<String> eng = new List<string>{"a","b","v","g","d","e","yo","zh","z","i","j","k","l","m","n","o","p","r","s","t","u","f","h","c","ch","sh","sch","j","i","j","e","yu","ya",
            "A","B","V","G","D","E","Yo","Zh","Z","I","J","K","L","M","N","O","P","R","S","T","U","F","H","C","Ch","Sh","Sch","J","I","J","E","Yu","Ya"};

            for (int j = 0; j < s.Length; j++)
                if (rus.Contains(s.Substring(j, 1)))
                {
                    int i = rus.IndexOf(s.Substring(j, 1));
                    ret += eng[i];
                }
                else
                    continue;
            return ret;
        }
    }
}
