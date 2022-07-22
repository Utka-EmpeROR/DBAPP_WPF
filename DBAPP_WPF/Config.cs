using System;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAPP_WPF
{
    class Config
    {
        public static string connectString;
        public static OleDbConnection myDB;

        static string defaultFilename = "config.txt";
        public static List<User> Users = new List<User>();
        public static List<AccessLevel> AccesLevels = new List<AccessLevel>();
        public static string Language = "En";
        static string AdminPassword = "qwerty";
        public static string LastUsedDB = "<None>";
        public static readonly string[] AvailableFunctions = { "Operations", "Records", "Registry" };

        public static void ConnectDB(string fileDB)
        {
            Config.LastUsedDB = fileDB;
            connectString = $"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={fileDB};";
            myDB = new OleDbConnection(connectString);
            myDB.Open();
        }

        public static void GetConfig()
        {
            Config.AccesLevels.Add(new AccessLevel(1, AvailableFunctions.ToList<string>()));
            if (!File.Exists(defaultFilename))
            {
                return;
            }
            string[] data = File.ReadAllLines(defaultFilename);
            foreach (var line in data)
            {
                if (line.Contains("LastUsedDB:"))
                {
                    string[] DBstr = line.Split('>');
                    if (DBstr.Length == 2)
                    {
                        LastUsedDB = DBstr[1];
                    }
                    continue;
                }
                string[] str = line.Split(' ');
                if (str.Length < 2 || str.Length > 4)
                {
                    continue;
                }
                switch (str[0])
                {
                    case "Language":
                        if (str.Length == 3)
                        {
                            Language = str[2];
                        }
                        break;
                    case "AdminPassword":
                        if (str.Length == 3)
                        {
                            AdminPassword = str[2];
                        }
                        break;
                    case "User:":
                        if (str.Length == 4 && int.TryParse(str[3], out int accessLevel))
                        {
                            if (Config.AccesLevels.Exists(lvl => lvl.Id == accessLevel))
                            {
                                Users.Add(new User(str[1], str[2],
                                    Config.AccesLevels.Find(lvl => lvl.Id == accessLevel)));
                            }
                        }
                        break;
                    case "AccessLevel:":
                        if (int.TryParse(str[1], out int level) && str.Length == 3 && str[2] != "")
                        {
                            AccesLevels.Add(new AccessLevel(level, str[2].Split(';').ToList<string>()));
                        }
                        break;
                    default:
                        continue;
                }
            }
            Config.Users.Add(new User("admin", AdminPassword,
                Config.AccesLevels.Find(lvl => lvl.Id == 1)));
        }

        public static void SaveConfig()
        {
            using (StreamWriter sw = new StreamWriter(defaultFilename))
            {
                sw.WriteLine($"Language = {Language}");
                sw.WriteLine($"AdminPassword = {AdminPassword}");
                if (LastUsedDB != "<None>")
                {
                    sw.WriteLine($"LastUsedDB:>{LastUsedDB}");
                }
                foreach (var level in AccesLevels)
                {
                    if (level.Id != 1)
                    {
                        sw.WriteLine(level.ToString());
                    }
                }
                foreach (var user in Users)
                {
                    if(user.Name != "admin")
                    {
                        sw.WriteLine(user.ToString());
                    }
                }
            }
        }
        public static bool CheckUser(string username, string password, out User user)
        {
            if (Users.Exists(item => item.Name == username & item.Password == password))
            {
                user = Users.Find(item => item.Name == username & item.Password == password);
                return true;
            }
            user = null;
            return false;
        }

        public static bool AddUser(string username, string password, int accessLevel)
        {
            if (Users.Exists(user => user.Name == username))
            {
                return false;
            }
            if (!Config.AccesLevels.Exists(lvl => lvl.Id == accessLevel))
            {
                return false;
            }
            Users.Add(new User(username, password,
                Config.AccesLevels.Find(lvl => lvl.Id == accessLevel)));
            return true;
        }

        public static void DeleteUser(string username)
        {
            if (Users.Exists(user => user.Name == username))
            {
                Users.Remove(Users.Find(user => user.Name == username));
            }
        }
        public static void DeleteUser(int lvl)
        {
            if (Users.Exists(user => user.AccessLvl.Id == lvl))
            {
                Users.RemoveAll(user => user.AccessLvl.Id == lvl);
            }
        }

        public static bool AddAccessLevel(int level, string[] functions)
        {
            if (AccesLevels.Exists(element => element.Id == level))
            {
                return false;
            }
            AccesLevels.Add(new AccessLevel(level, functions.ToList<string>()));
            return true;
        }

        public static void DeleteAccessLevel(int level)
        {
            if (AccesLevels.Exists(accessLevel => accessLevel.Id == level))
            {
                AccesLevels.Remove(AccesLevels.Find(accessLevel => accessLevel.Id == level));
                DeleteUser(level);
            }
        }

        public static bool CheckAdminPassword(string input)
        {
            return input == AdminPassword;
        }
    }
}
