using System;
using System.Runtime.InteropServices;

namespace SudokuFactory
{
    public class Print
    {
        public static void board(int[,] board)
        //Print sudoku from 2d array
        {
            Console.WriteLine("-------------------------------");
            for (int row = 0; row < board.GetLength(0); row += 1)
            {
                for (int col = 0; col < board.GetLength(1); col += 1)
                {
                    Console.Write("{0}| ", board[row, col]);
                }
                Console.WriteLine("");
            }
            Console.WriteLine("-------------------------------");
        }


        public static void MainMenu(int difficulty)
        //Print main menu
        {
            Console.Clear();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("SUDOKU TIME 2022");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Option 1: Solve your own sudoku. ");
            Console.WriteLine($"Option 2: Create a new sudoku. (Difficulty: {Helper.DifficultyText(difficulty)}) ");
            Console.WriteLine("Option 3: Change difficulty. ");
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Option 4: Exit program. ");
            Console.WriteLine("-------------------------------");
        }


        public static void DifficultyMenu(int difficulty)
        //Print difficulty menu
        {
            Console.Clear();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("CHANGE DIFFICULTY");
            Console.WriteLine($"Enter a number to choose difficulty. \nCurrent difficulty: {Helper.DifficultyText(difficulty)}");
            Console.WriteLine("-------------------------------");
            Console.WriteLine($"1. {Helper.DifficultyText(2)}");
            Console.WriteLine($"2. {Helper.DifficultyText(3)}");
            Console.WriteLine($"3. {Helper.DifficultyText(4)}");
            Console.WriteLine($"4. {Helper.DifficultyText(5)}");
            Console.WriteLine($"5. {Helper.DifficultyText(69)}");
            Console.WriteLine("-------------------------------");
        }
    }
}