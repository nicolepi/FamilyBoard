using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyBoard
{
    public class TodoList
    {
        #region Properties
        [Key]
        public int Id { get; set; }
        public bool Done { get; set; }
        public string Content { get; set; }
        public string DateCreated { get; set; }
        public string DateCompleted { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        #endregion

        #region Methods
        public TodoList()
        {
            SetDateCreated();           

        }

        public TodoList(int UserId, String text)
        {
            SetDateCreated();            
            this.UserId = UserId;
            this.Content = text;
            this.Done = false;
        }

        public void SetDateCreated()
        {
            DateCreated = DateTime.Now.ToString();
        }

        public void CompleteItem()
        {
            this.Done = true;
        }

        



        #endregion
    }
}
