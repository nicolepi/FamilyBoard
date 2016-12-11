using System.Collections.Generic;

namespace FamilyBoardUI.Models
{
    public class CommentWithPhotoModel
    {
        public CommentWithPhotoModel(IEnumerable<FamilyBoard.PhotoComment> photoComments, FamilyBoard.Photo photo)
        {
            this.PhotoComments = photoComments;
            this.Photo = photo;
        }
        
        public IEnumerable<FamilyBoard.PhotoComment> PhotoComments { get; private set; }

        public FamilyBoard.Photo Photo { get; private set; }
    }
}