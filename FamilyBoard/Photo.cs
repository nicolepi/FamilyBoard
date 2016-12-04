using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyBoard
{
    public class Photo
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string DateCreated { get; set; }
        public virtual ICollection<PhotoComment> Comments { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }

        #endregion

        #region Methods
        public Photo()
        {
            SetDateCreated();
            this.Comments = new List<PhotoComment>();
            
        }

        public Photo(int UserId)
        {
            SetDateCreated();
            this.Comments = new List<PhotoComment>();
            this.UserId = UserId;
        }

        public void SetDateCreated()
        {
            DateCreated = DateTime.Now.ToString();
        }

       
        
        #endregion
    }
}
