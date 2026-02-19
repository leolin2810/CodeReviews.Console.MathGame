using static System.Formats.Asn1.AsnWriter;

namespace ConsoleApp1
{
    class Program
    {
        private int problemCount = 5;
        private int operation = 5;
        private int difficulty = 1;
        List<Game> games = new();

        static void Main()
        {
            Program Application = new();
            while (true)
            {
                Console.Clear();
                Program.PromptUser();
                Console.WriteLine("-----------------------");
                Application.DisplayCurrentSettings();
                Console.WriteLine("-----------------------");
                Application.EvaluatePromptUserInput();
            }

        }
        /*-------------------------Menu Display Methods-------------------------*/
        public static void PromptUser()
        {
            Console.WriteLine("Welcome to the Math Game!");

            Console.WriteLine("1. Start Game");
            Console.WriteLine("2. Change Number of Problems");
            Console.WriteLine("3. Specify the Operation");
            Console.WriteLine("4. Change the Difficulty");
            Console.WriteLine("5. View Past Scores");
            Console.WriteLine("6. Exit");
        }

        public void DisplayCurrentSettings()
        {
            Console.WriteLine("Current Settings:");
            DisplayProblemCount();
            DisplayOperationType();
            DisplayDifficulty();
        }

        private void DisplayProblemCount()
        {
            Console.WriteLine($"Current number of problems: {problemCount}");
        }

        private void DisplayOperationType()
        {
            switch (operation)
            {
                case 1:
                    {
                        Console.WriteLine("Current operation: Addition");
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("Current operation: Subtraction");
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("Current operation: Multiplication");
                        break;
                    }
                case 4:
                    {
                        Console.WriteLine("Current operation: Division");
                        break;
                    }
                case 5:
                    {
                        Console.WriteLine("Current operation: Random");
                        break;
                    }
            }
        }
        private void DisplayDifficulty()
        {
            Console.WriteLine($"Current difficulty: {difficulty}");
        }

        /*-------------------------Problem Count Methods-------------------------*/
        private static void PromptProblemCount()
        {
            Console.Clear();
            Console.WriteLine("How many problems would you like to practice?");
            Console.WriteLine("Enter a number greater than 0: ");
        }

        public void EvaluatePromptProblemCountInput()
        {
            int Input;
            while (true)
            {
                string temp = Console.ReadLine();

                // Parsing a null returns 0, which is out of range of the conditions between 1 to 5
                if (int.TryParse(temp, out Input))
                {
                    if (Input >= 5)
                    {
                        problemCount = Input;
                        break;
                    }
                    Console.WriteLine("Please enter a number greater than 5.");
                    continue;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

            }
        }

        /*-------------------------Operation Select Methods-------------------------*/
        private static void PromptOperation()
        {
            Console.Clear();
            Console.WriteLine("Which operation would you like to practice?");
            Console.WriteLine("1. Addition");
            Console.WriteLine("2. Subtraction");
            Console.WriteLine("3. Multiplication");
            Console.WriteLine("4. Division");
            Console.WriteLine("5. Random");
            Console.WriteLine("Enter the number associated with the operation you want to practice: ");
        }

        public void EvaluatePromptOperationInput()
        {
            int Input;
            while (true)
            {
                string temp = Console.ReadLine();

                // Parsing a null returns 0, which is out of range of the conditions between 1 to 5
                if (int.TryParse(temp, out Input))
                {
                    if (Input <= 5 && Input >= 1)
                    {

                        operation = Input;
                        Console.WriteLine(operation);
                        break;
                    }
                    Console.WriteLine("Please enter a number between 1 and 5.");
                    continue;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

            }
        }

        /*-------------------------Difficulty Select Methods-------------------------*/
        private static void PromptDifficulty()
        {
            Console.Clear();
            Console.WriteLine("Which difficulty would you like to practice?");
            Console.WriteLine("1. Easy (0-10)");
            Console.WriteLine("2. Medium (0-50)");
            Console.WriteLine("3. Hard (0-100)");
            Console.WriteLine("Enter the number associated with the difficulty you want to practice: ");
        }

        // Technically, the skeleton for this code is a copy of EvaluatePromptOperationInput(), but kept as a separate method for clarity
        public void EvaluatePromptDifficultyInput()
        {
            int Input;
            while (true)
            {
                string temp = Console.ReadLine();

                // Parsing a null returns 0, which is out of range of the conditions between 1 to 5
                if (int.TryParse(temp, out Input))
                {
                    if (Input <= 3 && Input >= 1)
                    {
                        difficulty = Input;
                        break;
                    }
                    ;
                    Console.WriteLine("Please enter a number between 1 and 3.");
                    continue;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");
                }

            }
        }

        /*-------------------------Main User Input Methods-------------------------*/
        public void EvaluatePromptUserInput()
        {
            // Checks for valid input from user
            int Input;
            while (true)
            {
                Console.WriteLine("Enter the number associated with what you want to do: ");
                string temp = Console.ReadLine();

                // Parsing a null returns 0, which is out of range of the conditions between 1 to 5
                if (int.TryParse(temp, out Input))
                {
                    if (Input <= 6 && Input >= 1)
                    {
                        break;
                    }
                    Console.WriteLine("Please enter a number between 1 and 5.");
                    continue;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a number.");

                }

            }

            // Performs the action associated with the user input
            switch (Input)
            {
                case 1:
                    {
                        Console.Clear();
                        Game NewGame = new(problemCount, operation, difficulty);
                        NewGame.ClearProblemList();
                        NewGame.GenerateProblems();
                        DateTime StartTime = DateTime.Now;
                        foreach (Problem problem in NewGame.problems)
                        {
                            problem.DisplayEquation();
                            NewGame.AddScore(problem.CheckSolution(Console.ReadLine()));
                        }
                        DateTime EndTime = DateTime.Now;
                        NewGame.SetTime(StartTime, EndTime);
                        games.Add(NewGame);
                        break;
                    }
                case 2:
                    {
                        PromptProblemCount();
                        EvaluatePromptProblemCountInput();
                        break;
                    }
                case 3:
                    {
                        PromptOperation();
                        EvaluatePromptOperationInput();
                        break;
                    }
                case 4:
                    {
                        PromptDifficulty();
                        EvaluatePromptDifficultyInput();
                        break;
                    }
                case 5:
                    {
                        Console.Clear();
                        Console.WriteLine("Displaying past game scores...");
                        foreach (Game game in games)
                        {
                            game.DisplaySettings();
                            Console.WriteLine("");
                            game.DisplayScore();
                            Console.WriteLine("-----------------------");
                        }
                        Console.WriteLine("Press any key to return to the main menu.");
                        Console.ReadKey();
                        break;
                    }
                case 6:
                    {
                        Console.WriteLine("Exiting...");
                        System.Environment.Exit(0);
                        break;
                    }

                // Given the parsing in the previous step, this shouldn't be reached realistically
                default:
                    {
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                        break;
                    }
            }
        }


    }
}




