using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        #endregion

        #region Methods
        public Photo()
        {
            SetDateCreated();
            this.Comments = new List<PhotoComment>();
        }
        public void SetDateCreated()
        {
            DateCreated = DateTime.Now.ToString();
        }
        
        #endregion
    }
}
