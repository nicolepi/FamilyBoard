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

        public static void PrintContent()
        {
            using (var model = new FamilyBoardModel())
            {
                foreach (var photo in model.Photos)
                {
                    Console.WriteLine("Photo Title: {0}", photo.Title);
                }
                foreach (var video in model.Videos)
                {
                    Console.WriteLine("Video Title: {0}", video.Title);
                }
                foreach (var user in model.Users)
                {
                    Console.WriteLine("User {0} created, Username: {1}", user.FirstName, user.UserName);
                }
            }
        }
        #endregion
    }

}
