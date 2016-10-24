using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyBoard
{
    public class User
    {
        #region Properties

        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }
        string Password { get; set; }
        #endregion

        #region Methods
        public User(string UserName, string Password)
        {
            this.UserName = UserName;
            this.Password = Password;
            Console.WriteLine("User " + this.UserName + " created.");
        }

        #endregion

    }
}
