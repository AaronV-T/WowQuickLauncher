using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WowQuickLauncher
{
    public class AccountInfo
    {
        public string username, password;
        public int x, y, width, height;

        public AccountInfo() { }

        public AccountInfo(string username, string password, int x, int y, int width, int height)
        {
            this.username = username;
            this.password = password;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }
    }

    public class FileIO
    {
        const string ACCOUNT_FILE_NAME = "accounts.txt";

        public static List<AccountInfo> GetAccountInfo(out string launchPath, out bool enterWorld, out int loginWait, out int enterWorldWait)
        {
            List<AccountInfo> accounts = new List<AccountInfo>();
            launchPath = string.Empty;
            enterWorld = false;
            loginWait = 10000;
            enterWorldWait = 5000;

            using (StreamReader file = new StreamReader(ACCOUNT_FILE_NAME))
            {
                string line = string.Empty;
                while ((line = file.ReadLine()) != null)
                {
                    line = line.Trim();
                    if (line.Length == 0)
                        continue;

                    List<string> pair = line.Split(new[] { '=' }, 2).ToList(); // Split the line on only the first =

                    string param = pair[0].ToLower();
                    foreach (string s in pair)
                        Console.Write($"{s} ");
                    Console.WriteLine();

                    try
                    {
                        if (param == "defineaccount")
                            accounts.Add(new AccountInfo());
                        else if (param == "username")
                            accounts[accounts.Count - 1].username = pair[1];
                        else if (param == "password")
                            accounts[accounts.Count - 1].password = pair[1];
                        else if (param == "x")
                            accounts[accounts.Count - 1].x = int.Parse(pair[1]);
                        else if (param == "y")
                            accounts[accounts.Count - 1].y = int.Parse(pair[1]);
                        else if (param == "width")
                            accounts[accounts.Count - 1].width = int.Parse(pair[1]);
                        else if (param == "height")
                            accounts[accounts.Count - 1].height = int.Parse(pair[1]);
                        else if (param == "path")
                            launchPath = pair[1];
                        else if (param == "enterworld")
                        {
                            if (pair[1] == "true" || pair[1] == "yes")
                                enterWorld = true;
                        }
                        else if (param == "loginwait")
                            loginWait = int.Parse(pair[1]);
                        else if (param == "enterworldwait")
                            enterWorldWait = int.Parse(pair[1]);
                    }
                    catch (Exception ex)
                    {
                        throw new Exception($"Bad line: \"{line}\".\nOriginal error: \"{ex.Message}\"");
                    }
                }
            }

            return accounts;
        }
    }
}
