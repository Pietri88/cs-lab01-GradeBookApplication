using GradeBook.GradeBooks;
using System;

namespace GradeBook.UserInterfaces
{
    public static class StartingUserInterface
    {
        public static bool Quit = false;
        public static void CommandLoop()
        {
            while (!Quit)
            {
                Console.WriteLine(string.Empty);
                Console.WriteLine(">> What would you like to do?");
                var command = Console.ReadLine().ToLower();
                CommandRoute(command);
            }
        }

        public static void CommandRoute(string command)
        {
            if (command.StartsWith("create"))
                CreateCommand(command);
            else if (command.StartsWith("load"))
                LoadCommand(command);
            else if (command == "help")
                HelpCommand();
            else if (command == "quit")
                Quit = true;
            else
                Console.WriteLine("{0} was not recognized, please try again.", command);
        }

        public static void CreateCommand(string command)
        {
            var parts = command.Split(' ');
            if (parts.Length != 4)
            {
                Console.WriteLine("Command not valid, Create requires a name, type of gradebook, if it's weighted (true / false).");
                return;
            }

            bool isWeighted;
            if (!bool.TryParse(parts[3], out isWeighted))
            {
                Console.WriteLine("Weighted value must be true or false.");
                return;
            }

            BaseGradeBook gradeBook;
            switch (parts[2])
            {
                case "Standard":
                    gradeBook = new StandardGradeBook(parts[1], isWeighted);
                    break;
                case "Ranked":
                    gradeBook = new RankedGradeBook(parts[1], isWeighted);
                    break;
                default:
                    Console.WriteLine($"{parts[2]} is not a supported type of gradebook, please try again");
                    return;
            }

           
        }


        public static void LoadCommand(string command)
        {
            var parts = command.Split(' ');
            if (parts.Length != 2)
            {
                Console.WriteLine("Command not valid, Load requires a name.");
                return;
            }
            var name = parts[1];
            var gradeBook = BaseGradeBook.Load(name);

            if (gradeBook == null)
                return;

            GradeBookUserInterface.CommandLoop(gradeBook);
        }

        public static void HelpCommand()
        {
                  
        
            Console.WriteLine("Commands:");
            Console.WriteLine("  quit - Exits the program.");
            Console.WriteLine("  help - Displays a list of commands and their descriptions.");
            Console.WriteLine("  create 'Name' 'Type' 'Weighted' - Creates a new gradebook where 'Name' is the name of the gradebook, 'Type' is what type of grading it should use, and 'Weighted' is whether or not grades should be weighted (true or false).");
        }
    }
    
}
