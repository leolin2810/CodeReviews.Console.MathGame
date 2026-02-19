namespace ConsoleApp1
{
    class Problem
    {
        private string equation = "";
        private int solution;
        private int moduloCheck;
        private int maxVal;

        private void SetMaxVal(int difficulty)
        {
            switch (difficulty)
            {
                case 1:
                    {
                        maxVal = 10;
                        break;
                    }
                case 2:
                    {
                        maxVal = 50;
                        break;
                    }
                case 3:
                    {
                        maxVal = 100;
                        break;
                    }
            }
        }
        public void GenerateEquation(int operation = 5, int difficulty = 1)
        {
            Random random = new();
            SetMaxVal(difficulty);

            if (operation == 5)
            {
                operation = random.Next(0, 4)+1;
            }


            switch (operation)
            {
                // Addition
                case 1:
                    {
                        
                        Random randint1 = new();
                        Random randint2 = new();

                        int addend1 = randint1.Next(0, maxVal);
                        int addend2 = randint2.Next(0, maxVal);

                        equation = $"{addend1} + {addend2}";
                        solution = addend1 + addend2;
                        break;
                    }
                // Subtraction
                case 2:
                    {
                        do
                        {
                            Random randint1 = new();
                            Random randint2 = new();

                            int minuend = randint1.Next(0, maxVal);
                            int subtractend = randint2.Next(0, maxVal);

                            equation = $"{minuend} - {subtractend}";
                            solution = minuend - subtractend;
                        }
                        while (solution < 0);

                        break;
                    }
                //Multiplication
                case 3:
                    {
                        Random randint1 = new();
                        Random randint2 = new();

                        int factor1 = randint1.Next(0, maxVal);
                        int factor2 = randint2.Next(0, maxVal);

                        equation = $"{factor1} * {factor2}";
                        solution = factor1 * factor2;
                        break;
                    }
                // Division
                case 4:
                    {
                        do
                        {
                            Random randint1 = new();
                            Random randint2 = new();

                            int dividend = randint1.Next(0, maxVal);
                            int divisor = randint2.Next(0, maxVal);

                            equation = $"{dividend} \u00f7 {divisor}";

                            try
                            {
                                solution = dividend / divisor;
                            }
                            catch (DivideByZeroException ex)
                            {
                                continue;
                            }

                            moduloCheck = dividend % divisor;
                            //try
                            //{
                                
                            //}
                            //catch (DivideByZeroException ex)
                            //{
                            //    continue;
                            //}
                        }
                        while (moduloCheck != 0 || solution <= 0);

                        break;

                    }
            }
        }

        public void DisplayEquation()
        {
            Console.WriteLine("What is the solution to the following equation?");
            Console.WriteLine(equation);
            //Console.WriteLine(Solution);
        }

        public int CheckSolution(string input)
        {
            int Input;
            if (int.TryParse(input, out Input))
            {
                if (Input == solution)
                {
                    Console.WriteLine("Correct!");
                    return 1;
                }
                else
                {
                    Console.WriteLine($"Incorrect. The correct answer is {solution}.");
                    return 0;
                }
            }
            else
            {
                Console.WriteLine($"Invalid input. The correct answer is {solution}.");
                return 0;
            }
        }
    }
}
