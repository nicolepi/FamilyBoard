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
            Photo picture1 = new Photo();
            picture1.Title = "Seattle Summer";
            Board.addPhoto(picture1);
            picture1 = new Photo();
            picture1.Title = "Winter Time";
            Board.addPhoto(picture1);
            Board.printPhoto();
            Console.ReadLine(); //prevent command line from closing
        }
    }
}
