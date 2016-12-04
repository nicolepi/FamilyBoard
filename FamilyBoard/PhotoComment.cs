using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyBoard
{
    public class PhotoComment
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public string Content { get; set; }
        public string DateCreated { get; set; }
        #endregion

        [ForeignKey("Photo")]
        public int PhotoId { get; set; }
        public virtual Photo Photo { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        public PhotoComment()
        {
            SetDateCreated();
            
        }

        public PhotoComment(int UserId, int PhotoId)
        {
            SetDateCreated();
            this. UserId = UserId;
            this.PhotoId = PhotoId;
        }
        public void SetDateCreated()
        {
            DateCreated = DateTime.Now.ToString();
        }
    }
}
