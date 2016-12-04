using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyBoard
{
    static class Board
    {
        #region Properties
        public static List<Photo> Photos { get; set; }
        public static List<Video> Videos { get; set; }
        public static List<User> Users { get; set; }
        #endregion

        #region Constructor
        static Board()
        {
            Photos = new List<Photo>();
            Videos = new List<Video>();
            Users = new List<User>();
        }
        #endregion

        #region Methods
        public static void addPhoto(Photo Photo)
        {
            using (var model = new FamilyBoardModel()) {
                model.Photos.Add(Photo);
                model.SaveChanges();
            }
        }

        public static void addVideo(Video Video)
        {
            using (var model = new FamilyBoardModel())
            {
                model.Videos.Add(Video);
                model.SaveChanges();

            }
        }
        public static void addUser(User User)
        {
            using (var model = new FamilyBoardModel())
            {
                model.Users.Add(User);
                model.SaveChanges();

            }
        }

        public static void addPhotocomment(PhotoComment PhotoComment)
        {
            using (var model = new FamilyBoardModel())
            {
                model.PhotoComments.Add(PhotoComment);
                model.SaveChanges();

            }
        }

        public static void addVideocomment(VideoComment VideoComment)
        {
            using (var model = new FamilyBoardModel())
            {
                model.VideoComments.Add(VideoComment);
                model.SaveChanges();

            }
        }

        public static void PrintContent()
        {
            using (var model = new FamilyBoardModel())
            {
                
                foreach (var photo in model.Photos)
                {
                    Console.WriteLine("Photo Title: {0}", photo.Title);
                    Console.WriteLine("------------------------------");
                    var comments = model.PhotoComments.Where(p => p.PhotoId == photo.Id);
                    //linq
                    foreach (var comment in comments)
                    {
                        Console.WriteLine("Comment: {0}", comment.Content);
                    }
                    Console.WriteLine();
                }
                foreach (var video in model.Videos)
                {
                    Console.WriteLine("Video Title: {0}", video.Title);
                    Console.WriteLine("------------------------------");
                    var comments = model.VideoComments.Where(p => p.VideoId == video.Id);
                    foreach (var comment in comments)
                    {
                        Console.WriteLine("Comment: {0}", comment.Content);
                    }
                    Console.WriteLine();
                }
                
            }
        }
        #endregion
    }

}
