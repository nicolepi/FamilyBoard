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
            using (var model = new FamilyBoardModel()) {
                model.Photos.Add(Photo);
                model.SaveChanges();
            }
        }

        public static void addVideo(Video Video)
        {
            Videos.Add(Video);
        }

        public static void printPhoto()
        {
            using (var model = new FamilyBoardModel())
            {
                foreach (var photo in model.Photos)
                {
                    Console.WriteLine("Photo Title: {0}", photo.Title);
                }
            }
        }
    }

}
