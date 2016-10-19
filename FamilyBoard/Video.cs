using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyBoard
{
    class Video
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Comment { get; set; }
        public User User { get; set; }
        public DateTime DateCreated { get; private set; }

        public Video(string Title)
        {
            this.Title = Title;
            this.DateCreated = DateTime.Now;
        }
    }
}
