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
            User nicole = new User("nicolepi", "123456");
            User henry = new User("henrypi", "2234567");
            Photo picture1 = new Photo("Seattle Summer",nicole);
            Board.addPhoto(picture1);
            picture1 = new Photo("Taipei Vacation", henry);
            Board.addPhoto(picture1);
            Board.printPhoto();            
            Console.ReadLine(); //prevent command line from closing
        }
    }
}
