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
            Console.WriteLine("Welcome!");
            int choice = -1; 
            bool invalidChoice = false;
            while (choice != 0 || invalidChoice)
            {
                Console.WriteLine("1. Upload a picture.");
                Console.WriteLine("2. Upload a video.");
                Console.WriteLine("3. Leave a comment.");
                Console.WriteLine("0. Exit.");
                Console.Write("Please choose an option: ");
                var input = Console.ReadLine();
                
                if (!int.TryParse(input, out choice))
                {
                    invalidChoice = true;
                    Console.WriteLine("Invalid choice, try again...");
                    continue;
                }
                invalidChoice = false; 
                switch (choice)
                {
                    case 1:
                        {
                            Console.Write("Enter Photo Title: ");
                            var title = Console.ReadLine();
                            var photo = new Photo();
                            photo.Title = title;
                            photo.DateCreated = DateTime.Now.ToString();
                            Board.addPhoto(photo);
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Enter Video Title: ");
                            var title = Console.ReadLine();
                            var video = new Video();
                            video.Title = title;
                            video.DateCreated = DateTime.Now.ToString();
                            Board.addVideo(video);
                            break;
                        }
                    case 3:
                        break;
                    default:
                        break;
                }
            }



            Board.PrintContent();
            Console.ReadLine(); //prevent command line from closing
            Board.PrintContent();
        }
    }
}
