using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyBoard
{
    public class VideoComment
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public string DateCreated { get; set; }
        #endregion

        [ForeignKey("Video")]
        public int VideoId { get; set; }
        public virtual Video Video { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public VideoComment()
        {
            SetDateCreated();
        }
        public void SetDateCreated()
        {
            DateCreated = DateTime.Now.ToString();
        }
    }
}
