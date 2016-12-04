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
            Console.WriteLine("Welcome to Family Board!\n");            
            int choice = -1;
            bool invalidChoice = false;
            var input = Console.ReadLine();
            int UserId = -1;
            while (choice != 0 || invalidChoice)
            {
                Console.WriteLine("1. Log in, or\n");
                Console.WriteLine("2. Create new user.\n");
                using (var model = new FamilyBoardModel())
                {
                    input = Console.ReadLine();
                    if (!int.TryParse(input, out choice))
                    {
                        invalidChoice = true;
                        Console.WriteLine("Invalid choice, try again...");
                        continue;
                    }

                    invalidChoice = false;
                    choice = int.Parse(input);
                    break;
                }

            }
            if(choice==1)
            {
                while (choice != 0 || invalidChoice)
                {
                    Console.WriteLine("Select a user\n");
                    using (var model = new FamilyBoardModel())
                    {
                        int i = 1;
                        foreach (var user in model.Users)
                        {
                            Console.WriteLine("{0}. {1}", i, user.UserName);
                            i++;
                        }
                        input = Console.ReadLine();
                        if (!int.TryParse(input, out choice))
                        {
                            invalidChoice = true;
                            Console.WriteLine("Invalid choice, try again...");
                            continue;
                        }

                        invalidChoice = false;


                        UserId = int.Parse(input);
                        break;
                    }

                }
            }else if(choice==2)
            {

            }









            







            
            
            choice = -1;
            invalidChoice = false;
            while (choice != 0 || invalidChoice)
            {
                Console.WriteLine("What do you want to do?\n");
                Console.WriteLine("1. Upload a picture.");
                Console.WriteLine("2. Upload a video.");
                Console.WriteLine("3. Leave a photo comment.");
                Console.WriteLine("4. Leave a video comment.");
                Console.WriteLine("0. Exit.\n");
                Console.Write("Please choose an option from above: ");
                input = Console.ReadLine();

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
                            var photo = new Photo(UserId);
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
                        {
                            Console.WriteLine("Select a photo that you want to make a comment:\n");
                            using (var model = new FamilyBoardModel())
                            {
                                int i = 1;
                                foreach (var photo in model.Photos)
                                {
                                    Console.WriteLine("{0}. {1}", i, photo.Title);
                                    i++;
                                }
                                input = Console.ReadLine();
                                if (!int.TryParse(input, out choice))
                                {
                                    invalidChoice = true;
                                    Console.WriteLine("Invalid choice, try again...");
                                    continue;
                                }

                                invalidChoice = false;

                                IEnumerable<Photo> photoQuery =
                                  from photo in model.Photos
                                  where photo.Id == choice
                                  select photo;

                                foreach (Photo photo in photoQuery)
                                {
                                    Console.WriteLine("What do you think about {0}?", photo.Title);

                                }


                                input = Console.ReadLine();
                                PhotoComment comment = new PhotoComment(UserId, choice);
                                comment.Content = input;

                                Board.addPhotocomment(comment);

                                break;
                            }
                        }
                    case 4:
                        {
                            Console.WriteLine("Select a video that you want to make a comment:\n");
                            using (var model = new FamilyBoardModel())
                            {
                                int i = 1;
                                foreach (var video in model.Videos)
                                {
                                    Console.WriteLine("{0}. {1}", i, video.Title);
                                    i++;
                                }
                                input = Console.ReadLine();
                                if (!int.TryParse(input, out choice))
                                {
                                    invalidChoice = true;
                                    Console.WriteLine("Invalid choice, try again...");
                                    continue;
                                }

                                invalidChoice = false;

                                IEnumerable<Video> videoQuery =
                                  from video in model.Videos
                                  where video.Id == choice
                                  select video;
                                foreach (Video video in videoQuery)
                                {
                                    Console.WriteLine("What do you think about {0}?", video.Title);

                                }
                                input = Console.ReadLine();
                                VideoComment comment = new VideoComment();
                                comment.Content = input;
                                comment.VideoId = choice;
                                comment.UserId = 1;
                                Board.addVideocomment(comment);
                                break;
                            }
                        }
                    default:
                        break;
                }




                //Console.ReadLine(); //prevent command line from closing

            }
            Board.PrintContent();
            Console.ReadLine(); //prevent command line from closing
        }
    }
}

