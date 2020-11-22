using _06__repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06__repo_console
{
    class Programui
    {
    private StreamingContentRepository _contentRepo = new StreamingContentRepository();
        public void run()
        {
            seedContentList();
            Menu();

        }

        //menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                

                Console.WriteLine("Select a Menu option\n" +
                    "1. Create New Content\n" +
                    "2. View all content\n" +
                    "3. View content By Title\n" +
                    "4. Update Existing Content\n" +
                    "5. Delete Existing Content\n" +
                    "6. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewContent();
                        break;
                    case "2":
                        DisplayAllContent();
                        break;
                    case "3":
                        DisplayContentByTitle();
                        break;
                    case "4":
                        UpdateExistingContent();
                        break;
                    case "5":
                        DeleteExistingcontent();
                        break;
                    case "6":
                        Console.WriteLine("Goodbye");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }
                Console.WriteLine("Please press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreateNewContent()
        {
            Console.Clear();
            StreamingContent newContent = new StreamingContent();
            
                //title
                Console.WriteLine("Enter the title for the content:");
                newContent.Title = Console.ReadLine();

                //description
                Console.WriteLine("Enter the decription for the content:");
                newContent.Description = Console.ReadLine();

                //maturity rating
                Console.WriteLine("Enter the rating for the content(g, pg, pg-13, etc):");
                newContent.MaturityRating = Console.ReadLine();

                //star rating
                Console.WriteLine("Enter the sta count for the content 5.8, 10, 3.5, ect:");
                string starsAsString = Console.ReadLine();
                newContent.StarRating = double.Parse("starsAsStrings");


                //isfamilyfriendly
                Console.WriteLine("Is this content family friendly? (y/n)");
                string familyFriendlystring = Console.ReadLine().ToLower();

                if (familyFriendlystring == "y")
                {
                    newContent.IsFamilyFriendly = true;

                }
                else
                {
                    newContent.IsFamilyFriendly = false;
                }
                //genretype
                Console.WriteLine("Enter the Gene number:/n"+
                "1. Horror/n"+
                "2. Romcom/n"+
                "3. Scify/n"+
                "4. Documentary/n"+
                "5. Romance/n"+
                "6. Drama/n"+
                "7. Action/n"+
                "7. Action/n");

                string genreAsString = Console.ReadLine();
                int genreAsInt = int.Parse(genreAsString);
                newContent.TypeOfGenre = (GenreType)genreAsInt;

                _contentRepo.AddContentToList(newContent);

                // Horror = 1,
                /* Romcom,
                   Scify,
                  Documentary,
                    Romance,
                     Drama,
                    Action */



            

        }

        private void DisplayAllContent()

        {
            Console.Clear();
            List<StreamingContent> listOfContent = _contentRepo.GetContentList();

            foreach(StreamingContent content in listOfContent)
            {
                Console.WriteLine($"title: {content.Title}\n"+
                    $"Description: { content.Description}");
            }


        }

        private void DisplayContentByTitle()
        {
            Console.Clear();
            Console.WriteLine("enter the title of the content you'd lide to see:");

            string title = Console.ReadLine();

            StreamingContent content =_contentRepo.GetContentByTitle(title);

            if(content != null)
            {
                Console.WriteLine($"title: {content.Title}\n" +
                    $"Description: { content.Description}\n" +
                    $"Maturity Rating: {content.MaturityRating }\n" +
                    $"Stars: {content.StarRating }\n" +
                    $"is family friendly: {content.IsFamilyFriendly}\n" +
                    $"Genre: {content.TypeOfGenre }");
            }
            else
            {
                Console.WriteLine("no content by that title.");
            }
                

        }

        private void UpdateExistingContent()
        {
            DisplayAllContent();

            Console.WriteLine("enter the title of the content you'd like to update:");

            string oldtitle = Console.ReadLine();
            StreamingContent newContent = new StreamingContent();

            //title
            Console.WriteLine("Enter the title for the content:");
            newContent.Title = Console.ReadLine();

            //description
            Console.WriteLine("Enter the decription for the content:");
            newContent.Description = Console.ReadLine();

            //maturity rating
            Console.WriteLine("Enter the rating for the content(g, pg, pg-13, etc):");
            newContent.MaturityRating = Console.ReadLine();

            //star rating
            Console.WriteLine("Enter the sta count for the content 5.8, 10, 3.5, ect:");
            string starsAsString = Console.ReadLine();
            newContent.StarRating = double.Parse(starsAsString);


            //isfamilyfriendly
            Console.WriteLine("Is this content family friendly? (y/n)");
            string familyFriendlystring = Console.ReadLine().ToLower();

            if (familyFriendlystring == "y")
            {
                newContent.IsFamilyFriendly = true;

            }
            else
            {
                newContent.IsFamilyFriendly = false;
            }
            //genretype
            Console.WriteLine("Enter the Gene number:\n" +
            "1. Horror\n" +
            "2. Romcom\n" +
            "3. Scify\n" +
            "4. Documentary\n" +
            "5. Romance\n" +
            "6. Drama\n" +
            "7. Action\n" +
            "7. Action\n");

            string genreAsString = Console.ReadLine();
            int genreAsInt = int.Parse(genreAsString);
            newContent.TypeOfGenre = (GenreType)genreAsInt;

            bool wasUpdated = _contentRepo.UpdateExistingContent(oldtitle, newContent );

            if (wasUpdated)
            {
                Console.WriteLine("content successfully updated!");
            }

            else
            {
                Console.WriteLine("could not update content");
            }



        }

        private void DeleteExistingcontent()
        {
         
            DisplayAllContent();

            Console.WriteLine("\nenter the title you'd like to remove:");

            string input = Console.ReadLine();

            bool wasdeleted=_contentRepo.RemoveContentFromList(input);

            if (wasdeleted)
            {
                Console.WriteLine("the content ws successfully deleted");
            }
            else
            {
                Console.WriteLine("the content could not be deleted.");
            }


        }
        //see mothed
        private void seedContentList()
        {
            StreamingContent sharknado = new StreamingContent("sharknado", "tornados, but with sharks", "TV14", 3.3, true, GenreType.Action);
            StreamingContent theRoom = new StreamingContent("the room", "bunkers life gets turned upside down.", "R", 3.7, false,
                GenreType.Drama);
            StreamingContent rubber = new StreamingContent("rubber", "car tire comes to life and goes on dilling spree.", "r", 5.8, false, GenreType.Documentary);

            _contentRepo.AddContentToList(sharknado);
            _contentRepo.AddContentToList(theRoom);
            _contentRepo.AddContentToList(rubber);
        }

           
    }
}
