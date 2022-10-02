using System;
using System.Drawing;
using System.Text.RegularExpressions;

namespace SudokuFactory
{    
    class SudokuFactory
    {
        public static void Main(string[] args)
        {
        //Standard difficulty
        int difficulty = 4;

        while (true)
        {
            Console.Clear();
            Print.MainMenu(difficulty);
            char menuChoice = Helper.GetMenuInput("mainMenu");

            
            if (menuChoice == '1')
             //Solve manually entered sudoku
            {
                Console.Clear();
                Console.WriteLine("SOLVE A SUDOKU");
                Console.WriteLine("Enter the correct number for each row. Enter 0 to signify empty space.");
                Console.WriteLine("Type 'r' or 'return' to return to the main menu.");
                int[,] ManualSudoku = BoardGenerator.ManualEntry();


                //Go back to main menu if user cancels data entry
                if (ManualSudoku[0, 0] == 99)
                {
                    continue;
                }
                //Error message if user entered non valid sudoku
                else if (!Helper.ValidateManualSudoku(ManualSudoku))
                {
                    Console.WriteLine("The sudoku was not valid. Press any key to return to the main menu.");
                    Console.ReadKey();
                    continue;
                }

                //Attempt to solve sudoku
                Console.WriteLine("\nGenerating solution...\n");
                if (BoardGenerator.FillBoard(ManualSudoku))
                {
                    Console.WriteLine("Solution: ");
                    Print.board(ManualSudoku);
                }

                //Error: Sudoku not solved
                else
                {
                    Console.WriteLine("Forgive us, we could not find a solution for your sudoku.");
                }

                Console.WriteLine("\nPress any key to return to the main menu.");
                Console.ReadKey();
            }

            
            else if (menuChoice == '2')
            //Create random sudoku
            {
                Console.Clear();
                Console.WriteLine("CREATE A SUODKU");
                Console.WriteLine("\nEnter filename: ");
                string filename = Console.ReadLine().ToLower();
                int[,] newSudoku = BoardGenerator.GenerateSudoku(difficulty);
                Helper.SaveSudoku(newSudoku, filename);
                Console.WriteLine("-------------------------------");
                Console.WriteLine("Your new sudoku has been generated and saved. ");
                Console.WriteLine($"Difficulty: {Helper.DifficultyText(difficulty)}");
                Console.WriteLine("-------------------------------");

                Console.WriteLine("\nWould you like the solution? Type 'Yes' or press any key to return to the main menu.");

                string saveSolution = Console.ReadLine().ToLower();
                if (saveSolution == "yes")
                {
                    Helper.SaveSudokuFacit(newSudoku, filename);
                    Console.WriteLine("The solution has been saved. ");
                    Console.WriteLine("\nPress any key to return to the main menu.");
                    Console.ReadKey();  
                }
            }      
            

            else if (menuChoice == '3')
            //Change difficulty of sudoku
            {
                Console.Clear();
                Print.DifficultyMenu(difficulty);
                char selection = Helper.GetMenuInput("difficultyMenu");
                difficulty = Helper.UpdateDifficulty(selection);
            }


            //Exit program
            else if (menuChoice == '4')
            {
                Console.Clear();
                Console.WriteLine("PROGRAM EXITED");
                Console.WriteLine("Bye! Thank you for using SUDOKU TIME 2022.\n");
                System.Environment.Exit(1);
            }
            }
        }
    }          
}