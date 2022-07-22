using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAPP_WPF
{
    public class User
    {
        public readonly string Name;
        public string Password { get; private set; }
        public AccessLevel AccessLvl { get; private set; }

        public User(string name, string password, AccessLevel lvl)
        {
            this.Name = name;
            this.Password = password;
            this.AccessLvl = lvl;
        }

        public void SetPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentNullException("password is empty");
            }
            this.Password = password;
        }

        public void SetAccessLevel(AccessLevel lvl)
        {
            if(lvl == null)
            {
                throw new ArgumentNullException("lvl is null");
            }
            this.AccessLvl = lvl;
        }

        public override string ToString()
        {
            return $"User: {Name} {Password} {AccessLvl.Id}";
        }
    }
}
