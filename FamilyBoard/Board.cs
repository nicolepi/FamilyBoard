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
        #endregion

        static Board()
        {
            Photos = new List<Photo>();
            Videos = new List<Video>();
        }

        public static void addPhoto(Photo Photo)
        {
            Photos.Add(Photo);
        }

        public static void addVideo(Video Video)
        {
            Videos.Add(Video);
        }

        public static void printPhoto()
        {
            foreach (var photo in Photos)
            {
                Console.WriteLine("Photo Title: {0}, Date Created: {1}, By: {2}", photo.Title, photo.DateCreated, photo.User.UserName);
            }
        }
    }

}
