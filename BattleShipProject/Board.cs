using System;
using System.Collections.Generic;
using System.Linq;

namespace BattleShipProject
{
    public class Board
    {
        public List<Square> Boxes { get; set; }


        // 10*10 Board grid of squares
        public Board()
        {
            Boxes = new List<Square>();
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Boxes.Add(new Square(i, j));
                }
            }
        }

        public void DisplayBoard()
        {
            Console.WriteLine("  |1 2 3 4 5 6 7 8 9 10");
            Console.WriteLine("--+--------------------");
            for (int row = 1; row <= 10; row++)
            {
                if (row == 10)
                {
                    Console.Write((row).ToString() + "|");
                }
                else Console.Write((row).ToString() + " |");

                for (int ownColumn = 1; ownColumn <= 10; ownColumn++)
                {
                    Console.Write(GetBox(row, ownColumn).ValueHidingShip() + "|");
                }

                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }

        public void DisplayBoardWithShips()
        {
            Console.WriteLine("  |1 2 3 4 5 6 7 8 9 10");
            Console.WriteLine("--+--------------------");
            for (int row = 1; row <= 10; row++)
            {
                if (row == 10)
                {
                    Console.Write((row).ToString() + "|");
                }
                else Console.Write((row).ToString() + " |");

                for (int ownColumn = 1; ownColumn <= 10; ownColumn++)
                {
                    Console.Write(GetBox(row, ownColumn).Value() + "|");
                }

                Console.WriteLine();
            }
            Console.WriteLine("\n");
        }

        //Get box based on coordinates from the list of grid squares/boxes
        public Square GetBox(int row, int column)
        {
            return Boxes.Where(x => x.Row == row && x.Column == column).First();
        }

        //Return the boxes which matche the coordinates for randomly positioning ships
        public List<Square> GetBoxesForShip(int startRow, int startColumn, int endRow, int endColumn)
        {
            return Boxes.Where(x => x.Row >= startRow
                                     && x.Column >= startColumn
                                     && x.Row <= endRow
                                     && x.Column <= endColumn).ToList();
        }
    }
}
