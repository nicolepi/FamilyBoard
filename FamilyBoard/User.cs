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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        string Password { get; set; }
        public virtual ICollection<VideoComment> VideoComments { get; set; }
        public virtual ICollection<PhotoComment> PhotoComments { get; set; }
        public virtual ICollection<Photo> Photos { get; set; } 
        public virtual ICollection<Video> Videos { get; set; }
        public virtual ICollection<TodoList> TodoLists { get; set; }
        #endregion

        #region Methods
        public User()
        {
            
        }

        public User(string UserName)
        {
            this.UserName = UserName;
        }

        #endregion

    }
}
