using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace SudokuFactory
{
    public class BoardGenerator
    {
        public static int[,] GenerateSudoku(int difficulty)
        //Create sudoku
        {
            BoardGenerator BG = new BoardGenerator();


            //Loop the following to make sure the generated sudoku is solvable
            while (true)
            {
                //Create randomly seeded sudoku board
                int[,] SeededBoard = BG.SeededBoard();


                //Solve sudokuboard
                if (BoardGenerator.FillBoard(SeededBoard))
                {
                    //Remove random numbers from solved board
                    int[,] FinishedProduct = BG.ObfuscateBoard(SeededBoard, difficulty);


                    return FinishedProduct;
                }
            }
        }


        public int[,] ObfuscateBoard(int[,] fullBoard, int obfuscatingAmount)
        //Remove numbers from sudoku board
        {
            Random rand = new Random();
            int[,] ObfuscatedBoard = fullBoard;


            //Ensures we do not overflow array size
            if (obfuscatingAmount >= 9)
            {
                obfuscatingAmount = 8;
            }


            //Replace random numbers with 0(null)
            //Amount of numbers replaced is determioned by param obfuscatingAmount
            for (int row = 0; row < fullBoard.GetLength(0); row++)
            {
                for (int obfuscator = 0; obfuscator < obfuscatingAmount; obfuscator++)
                {
                    int randomCol = rand.Next(0, 9);
                    if (fullBoard[row, randomCol] != 0)
                    {
                        fullBoard[row, randomCol] = 0;
                    }
                    else
                    {
                        obfuscator--;
                    }
                }
            }
            return ObfuscatedBoard;
        }


        public static bool FillBoard(int[,] seededBoard)
        //Algorithm for solving sudoku
        //Modifies existing sudoku, does not return a new one
        {
            //Go through each voxel
            for (int row = 0; row < seededBoard.GetLength(0); row++)
            {
                for (int col = 0; col < seededBoard.GetLength(1); col++)
                {
                    //If the voxel is empty (0), modify it. If no voxel is empty, return true.
                    if (seededBoard[row, col] == 0)
                    {
                        //Try each number 1-9, stop at first legal number. The attempted number is "remembered" via the recursive loop."
                        for (int number = 1; number < 10; number++)
                        {
                            //Check if number is legal
                            if (Helper.IsLegal(seededBoard, row, col, number))
                            {
                                //Tries first available legal number and calls itself recursively.
                                //If there are no empty voxels, returns true
                                seededBoard[row, col] = number;
                                if (FillBoard(seededBoard))
                                {
                                    return true;
                                }
                                //If there is no legal number, we have erred in the past and must backtrack. Set current voxel to empty/0 and return false to backtrack. 
                                else
                                {
                                    seededBoard[row, col] = 0;
                                }
                            }
                        }
                        return false;
                    }
                }
            }
            return true;
        }


        public int[,] SeededBoard()
        //Fill empty sudoku board with random numbers
        {
            Random rand = new Random();
            int[,] SeedBoard = EmptyGrid();
            //Control amount of numbers created
            int seedAmount = 3;


            //Seed board
            for (int row = 0; row < SeedBoard.GetLength(0); row++)
            {
                for (int amount = 0; amount < seedAmount; amount++)
                {
                    int randomValue = rand.Next(1, 10);
                    int randomCol = rand.Next(0, 9);

                    if (Helper.IsLegal(SeedBoard, row, randomCol, randomValue) && SeedBoard[row, randomCol] == 0)
                    {
                        SeedBoard[row, randomCol] = randomValue;
                    }
                    else
                    {
                        amount--;
                    }
                }
            }
            return SeedBoard;
        }


        public static int[,] EmptyGrid()
        //Create "empty" sudoku board
        {
            int size = 9;
            int[,] EmptyBoard = new int[size, size];
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    EmptyBoard[row, col] = 0;
                }
            }
            return EmptyBoard;
        }


        public static int[,] ManualEntry()
        //Create sudoku board from user input
        {
            int size = 9;
            int[,] ManualSudoku = new int[size, size];


            //Get user to type in numbers for each row at a time
            for (int row = 0; row < size; row++)
            {
                while (true)
                {
                    //Make sure user follows protocol
                    Console.Write($"Row {row + 1}: ");
                    string values = Console.ReadLine();


                    //To let user return to main menu
                    if (values.ToLower() == "return" || values.ToLower() == "r")
                    {
                        ManualSudoku[0, 0] = 99;
                        return ManualSudoku;
                    }


                    //Error message if wrong amount of numbers are entered
                    else if (values.Length != 9)
                    {
                        Console.WriteLine("You have entered the wrong amount of numbers. Try again or write 'r' or 'return' to return to the main menu! ");
                    }


                    else
                    {
                        //Turn input into 2d array
                        for (int col = 0; col < values.Length; col++)
                        {
                            //Make sure only numbers are entered
                            if (!Char.IsDigit(values[col]))
                            {
                                Console.WriteLine("Incorrect usage, all characters were not digits. Try again or write 'r' or 'return' to return to the main menu! ");
                                row--;
                                break;
                            }
                            //Each entry is converted from char to string to int and then placed in sudoku
                            ManualSudoku[row, col] = (int)Convert.ToInt32(values[col].ToString());
                        }
                        break;
                    }
                }
            }
            return ManualSudoku;
        }
    }
}