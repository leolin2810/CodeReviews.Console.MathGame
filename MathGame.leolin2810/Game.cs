namespace ConsoleApp1
{
    class Game
    {
        // Defaults to 5 problems per game, but can be changed by user input
        private int problemCount = 5;
        public List<Problem> problems = new();
        private int operation = 5;
        private int difficulty = 1;
        private int score;
        private int time;

        public void AddScore(int score)
        {
            score += score;
        }

        public Game(int problemCountEntry = 5, int operationEntry = 5, int difficultyEntry = 1)
        {
            problemCount = problemCountEntry;
            operation = operationEntry;
            difficulty = difficultyEntry;
        }
        // Current Setting Display
        public void DisplaySettings()
        {
            Console.WriteLine("Current Settings:");
            DisplayProblemCount();
            DisplayOperationType();
            DisplayDifficulty();
            DisplayTime();
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

        public void DisplayScore()
        {
            Console.WriteLine($"Your score was {score} out of {problemCount}.");
        }  

        public void ClearProblemList()
        {
            problems.Clear();
        }

        public void GenerateProblems()
        {

            for (int i = 0; i < problemCount; i++)
            {
                Problem problem = new();
                problem.GenerateEquation(operation, difficulty);
                problems.Add(problem);
            }
        }

        public void SetTime(DateTime start, DateTime end)
        {
            TimeSpan duration = end - start;
            time = duration.Seconds;
        }

        public void DisplayTime()
        {
            Console.WriteLine($"Your time was {time} seconds.");
        }
    }
}

