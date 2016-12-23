using FamilyBoard;
using System.ComponentModel.DataAnnotations;

namespace FamilyBoard
{
    public class VideoFile
    {
        [Key]
        public int FileId { get; set; }
        [StringLength(255)]
        public string FileName { get; set; }
        [StringLength(100)]
        public string ContentType { get; set; }
        public byte[] Content { get; set; }
        public FileType FileType { get; set; }
        public int VideoId { get; set; }
        public virtual Video Video { get; set; }
    }
}
