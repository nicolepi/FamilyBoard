using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        public string Comment { get; set; }
        public string DateCreated { get; set; }
        #endregion

        public Video()
        {
            SetDateCreated();
        }

        public void SetDateCreated()
        {
            DateCreated = DateTime.Now.ToString();
        }

    }
}
