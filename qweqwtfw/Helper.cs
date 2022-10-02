using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Reflection;
using System.Drawing.Drawing2D;
using System.Text.RegularExpressions;


namespace SudokuFactory
{
    public class Helper
    {
        public static Bitmap DrawSudoku(int[,] newSudoku)
        {
            int pictureSizeX = 1240;
            int pictureSizeY = 1754;
            Bitmap bitmap = new Bitmap(pictureSizeX, pictureSizeY, System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            Graphics g = Graphics.FromImage(bitmap);


            //Drawing tools
            Pen bigRectPen = new Pen(Color.Black, 5);
            Pen medRectPen = new Pen(Color.Black, 3);
            Pen smallRectPen = new Pen(Color.Black);
            SolidBrush fillBrush = new SolidBrush(Color.White);


            //Get directory
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string[] dir2 = dir.Split("bin");
            string imgDirectory = dir2[0] + @"\img\";


            //Get all number images
            object imageNumber1 = Bitmap.FromFile(imgDirectory + "one.png");
            object imageNumber2 = Bitmap.FromFile(imgDirectory + "two.png");
            object imageNumber3 = Bitmap.FromFile(imgDirectory + "three.png");
            object imageNumber4 = Bitmap.FromFile(imgDirectory + "four.png");
            object imageNumber5 = Bitmap.FromFile(imgDirectory + "five.png");
            object imageNumber6 = Bitmap.FromFile(imgDirectory + "six.png");
            object imageNumber7 = Bitmap.FromFile(imgDirectory + "seven.png");
            object imageNumber8 = Bitmap.FromFile(imgDirectory + "eight.png");
            object imageNumber9 = Bitmap.FromFile(imgDirectory + "nine.png");


            //Size of main box
            int boxSize = 900;
            //Size of square
            int squareSize = 900 / 9;
            //Starter coordinates for box and numbers
            int startX = (pictureSizeX - boxSize) / 2;
            int startY = 100;


            //Draw background
            g.FillRectangle(fillBrush, 0, 0, pictureSizeX, pictureSizeY);


            //Draw header
            //Create string to draw.
            String drawString = "Sudoku";


            //Create font and brush.
            Font drawFont = new Font("Georgia", 24);
            SolidBrush drawBrush = new SolidBrush(Color.Black);


            //Create point for upper-left corner of drawing.
            float x = (float)1100 / 2 + 10;
            float y = 25.0F;


            //Draw string to screen.
            g.DrawString(drawString, drawFont, drawBrush, x, y);


            //Draw main square
            g.DrawRectangle(bigRectPen, startX, startY, boxSize, boxSize);


            //Draw boxes
            for (int i = 0; i < 9; i += 3)
            {
                for (int j = 0; j < 9; j += 3)
                {
                    g.DrawRectangle(medRectPen, startX + (100 * i), startY + (100 * j), boxSize / 3, boxSize / 3);
                }
            }


            //Draw small squares
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    g.DrawRectangle(smallRectPen, startX + (100 * i), startY + (100 * j), boxSize / 9, boxSize / 9);
                }
            }


            //Draw numbers
            for (int row = 0; row < newSudoku.GetLength(0); row++)
            {
                for (int col = 0; col < newSudoku.GetLength(1); col++)
                {
                    switch (newSudoku[row, col])
                    {
                        case 0:
                            break;
                        case 1:
                            g.DrawImage((System.Drawing.Image)imageNumber1, new Rectangle(startX + (100 * row), startY + (100 * col), squareSize, squareSize));
                            break;
                        case 2:
                            g.DrawImage((System.Drawing.Image)imageNumber2, new Rectangle(startX + (100 * row), startY + (100 * col), squareSize, squareSize));
                            break;
                        case 3:
                            g.DrawImage((System.Drawing.Image)imageNumber3, new Rectangle(startX + (100 * row), startY + (100 * col), squareSize, squareSize));
                            break;
                        case 4:
                            g.DrawImage((System.Drawing.Image)imageNumber4, new Rectangle(startX + (100 * row), startY + (100 * col), squareSize, squareSize));
                            break;
                        case 5:
                            g.DrawImage((System.Drawing.Image)imageNumber5, new Rectangle(startX + (100 * row), startY + (100 * col), squareSize, squareSize));
                            break;
                        case 6:
                            g.DrawImage((System.Drawing.Image)imageNumber6, new Rectangle(startX + (100 * row), startY + (100 * col), squareSize, squareSize));
                            break;
                        case 7:
                            g.DrawImage((System.Drawing.Image)imageNumber7, new Rectangle(startX + (100 * row), startY + (100 * col), squareSize, squareSize));
                            break;
                        case 8:
                            g.DrawImage((System.Drawing.Image)imageNumber8, new Rectangle(startX + (100 * row), startY + (100 * col), squareSize, squareSize));
                            break;
                        case 9:
                            g.DrawImage((System.Drawing.Image)imageNumber9, new Rectangle(startX + (100 * row), startY + (100 * col), squareSize, squareSize));
                            break;
                    }
                }
            }
            return bitmap;
        }


        public static void SaveSudoku(int[,] sudoku, string filename)
        {
            //Draw sudoku
            Bitmap newSudoku = DrawSudoku(sudoku);

            
            //Get directory 
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);


            //Save
            newSudoku.Save(dir + $"\\{filename}.png");  
        }


        public static void SaveSudokuFacit(int[,] sudoku, string filename)
        {
            //Solve board
            BoardGenerator.FillBoard(sudoku);


            //Draw sudoku
            Bitmap newSudokuFacit = DrawSudoku(sudoku);


            //Get directory
            string dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            
            //Save
            newSudokuFacit.Save(dir + $"\\{filename}_facit.png");
        }


        public static int UpdateDifficulty(char selection)
        //Update difficulty
        {
            if (selection == '1')
            {
                return 2;
            }
            else if (selection == '2')
            {
                return 3;
            }
            else if (selection == '3')
            {
                return 4;
            }
            else if (selection == '4')
            {
                return 5;
            }
            else
            {
                return 7;
            }
        }


        public static string DifficultyText(int difficulty)
        //Translate difficulty to text
        {
            if (difficulty == 2)
            {
                return "Child's play!";
            }
            else if (difficulty == 3)
            {
                return "Easy";
            }
            else if (difficulty == 4)
            {
                return "Normal";
            }
            else if (difficulty == 5)
            {
                return "Heroic";
            }
            else
            {
                return "Legendary";
            }
        }


        public static char GetMenuInput(string menuType)
        //Get input
        {
            while (true)
            {
                var input = Console.ReadLine();
                if (menuType == "mainMenu")
                {
                    if (ValidateMenuInput(input))
                    {
                        char selection = input[0];
                        return selection;
                    }
                }
                else if (menuType == "difficultyMenu")
                {
                    if (ValidateDifficultyInput(input))
                    {
                        char selection = input[0];
                        return selection;
                    }
                }
            }
        }


        public static bool ValidateMenuInput(string input)
        //Validate main menu input
        {
            if (input.Length != 1 || !Char.IsDigit(input, 0) || (int)Convert.ToInt32(input[0].ToString()) < 0 || (int)Convert.ToInt32(input[0].ToString()) > 4)
            {
                Console.WriteLine("Please, enter 1, 2, 3 or 4 in the console to select an option. ");
                return false;
            }
            else
            {
                return true;
            }
        }


        public static bool ValidateDifficultyInput(string input)
        //Validate input difficulty
        {
            if (input.Length != 1 || !Char.IsDigit(input, 0) || (int)Convert.ToInt32(input[0].ToString()) < 0 || (int)Convert.ToInt32(input[0].ToString()) > 5)
            {
                Console.WriteLine("Please, enter 1, 2, 3, 4 or 5 in the console to select an option. ");
                return false;
            }
            else
            {
                return true;
            }
        }


        public static bool ValidateManualSudoku(int[,] board)
        //Validate manually entered sudoku
        {
            int ticker = 0;

            //Check each entered number for legality
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] != 0)
                    {
                        if (!IsLegal(board, row, col, board[row, col]))
                        {
                            //Ticker so that it does not give false negative on current row/col
                            ticker++;
                            if (ticker > 1)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }


        public static bool IsLegal(int[,] board, int row, int col, int number)
        //Check if number is legal
        {
            //Check rows and cols
            for (int i = 0; i < board.GetLength(0); i++)
            {
                if (board[i, col] == number)
                {
                    return false;
                }
                if (board[row, i] == number)
                {
                    return false;
                }
            }
            //Check 3x3 box
            int boxRow = 0;
            int boxCol = 0;
            if (row > 2 && row < 6)
            {
                boxRow = 3;
            }
            else if (row > 5 && row < 9)
            {
                boxRow = 6;
            }
            if (col > 2 && col < 6)
            {
                boxCol = 3;
            }
            else if (col > 5 && col < 9)
            {
                boxCol = 6;
            }
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[(j + boxRow), (i + boxCol)] == number)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}