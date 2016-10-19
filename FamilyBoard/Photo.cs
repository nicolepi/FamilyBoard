using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyBoard
{
    class Photo
    {
        #region Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public User User { get; set; }
        public DateTime DateCreated { get; private set; }
        #endregion

        #region Methods
        public Photo(string Title, User UserName)
        {
            this.Title = Title;
            this.User = UserName;
            this.DateCreated = DateTime.Now;
        }
        
        #endregion
    }
}
