using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            Photo Picture1 = new Photo();
            Picture1.Title = "Seattle Summer";
            Board.addPhoto(Picture1);

            Picture1 = new Photo();
            Picture1.Title = "Winter Vacation";
            Board.addPhoto(Picture1);

            Video Video1 = new Video();
            Video1.Title = "Poodle Mishmish's Birthday Party";
            Board.addVideo(Video1);

            User Nicole = new User();
            Nicole.UserName = "nicolepi";
            Nicole.FirstName = "Nicole";
            Nicole.LastName = "Pi";
            Board.addUser(Nicole);
            
                     
            
            Board.PrintContent();
            Console.ReadLine(); //prevent command line from closing
        }
    }
}
