using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyBoard
{
    public class Video
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string DateCreated { get; set; }
        public virtual ICollection<VideoComment> Comments { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        #endregion

        #region Methods
        public Video()
        {
            SetDateCreated();
            this.Comments = new List<VideoComment>();
        }

        public Video(int UserId)
        {
            SetDateCreated();
            this.Comments = new List<VideoComment>();
            this.UserId = UserId;
        }

        public void SetDateCreated()
        {
            DateCreated = DateTime.Now.ToString();
        }

        #endregion
    }
}
