using System;
using System.Collections.Generic;
using System.Linq;
using BattleShipProject.Ships;

namespace BattleShipProject
{
    public class Player
    {
        public string Name { get; set; }
        public Board Board { get; set; }
        //public FiringBoard FiringBoard { get; set; }
        public List<Ship> Ships { get; set; }


        //if all ships are shink then player lost
        public bool HasLost()
        {
            if(Ships.All(x => x.IsSunk()))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public Player(string name)
        {
            Name = name;

            // Arbitrary number of ships
            Ships = new List<Ship>()
            {
                new Carrier(),
                new Battleship(),
                new Destroyer(),
                new Submarine(),
                new PatrolBoat(), 
            };

            Board = new Board();
            //FiringBoard = new FiringBoard();
        }

        public void OutputBoards(bool hideShips)
        {
            Console.WriteLine("\n");
            Console.Write(" ** " + Name + " Board ** ");
            if (hideShips)
            {
                Console.WriteLine("\n");
                Board.DisplayBoard();
            }
            else
            {
                Console.WriteLine(" ** With Ships ** ");
                Board.DisplayBoardWithShips();
            }
        }

        public void PlaceShips()
        {
            Random rand = new Random(Guid.NewGuid().GetHashCode());
            foreach (var ship in Ships)
            {
                //Select a random row/column coordinates and a random orientation for placing ships if proposed boxes are empty

                bool isOpen = true;
                while (isOpen)
                {
                    var startcolumn = rand.Next(1, 11); // random number between 1 and 10 for column
                    var startrow = rand.Next(1, 11); //random number between 1 and 10 for row
                    int endrow = startrow, endcolumn = startcolumn;
                    var orientation = rand.Next(1, 11) % 2;

                    //0 for Horizontal placement and 1 for Vertical
                    if (orientation == 0)
                    {
                        for (int i = 1; i < ship.Size; i++)
                        {
                            endrow++;
                        }
                    }
                    else
                    {
                        for (int j = 1; j < ship.Size; j++)
                        {
                            endcolumn++;
                        }
                    }

                    //We cannot place ships beyond the boundaries of the board
                    if (endrow > 10 || endcolumn > 10)
                    {
                        isOpen = true;
                        continue;
                    }

                    //Check if specified boxes are occupied
                    var selectedBoxes = Board.GetBoxesForShip(startrow, startcolumn, endrow, endcolumn);
                    if (selectedBoxes.Any(x => x.IsOccupied()))
                    {
                        isOpen = true;
                        continue;
                    }

                    foreach (var box in selectedBoxes)
                    {
                        box.BoxValue = ship.Type;  //change box value to specific ship type value
                    }
                    isOpen = false;
                }
            }
        }

       //Take attack coordinates from player

        public bool TakeAttack()
        {
            int row=0;
            int col=0;
            bool validInput = true;
            //Get input for attack 
            Console.WriteLine("Enter X-coordinate between 1-10");
            string line = Console.ReadLine();
            int valueRow = int.Parse(line);
            if (valueRow> 0 && valueRow <=10)
            {
                row = valueRow;
            }
            else
            {
                validInput = false;
                
            }

            Console.WriteLine("Enter Y-coordinate between 1-10");
            line = Console.ReadLine();
            int valueCol = int.Parse(line);
            if (valueCol > 0 && valueCol <= 10)
            {
                col = valueCol;
            }
            else
            {
                validInput = false;
            }

            if (validInput)
            {
                Console.WriteLine("\n");
                Console.WriteLine("Firing shot at " + row + " , " + col);
                Console.WriteLine("\n");
                
                ProcessAttackResult(row, col);
                return true;
            }
            else
            {
                Console.WriteLine("* Input not valid. Try again! * ");
                Console.WriteLine("\n");
                return false;
            }

        }

        //Process result of the attack on box, update the board stating whether it was a hit or miss
        public void ProcessAttackResult(int Row, int Col)
        {
            var box = Board.GetBox(Row, Col);

            // if box value is empty and not already been changed to 'X' then its a miss 
            if (!box.IsOccupied() && (box.Value() != "X"))
            {
                Console.WriteLine("It is a Miss! ");
                //update box value on board to miss
                box.BoxValue = BoxValue.Miss;
            }
            else if (box.IsOccupied())
            {
                var ship = Ships.First(x => x.Type == box.BoxValue);
                ship.Hits++;
                Console.WriteLine("It is a Hit! ");
                if (ship.IsSunk())
                {
                    Console.WriteLine("Ship " + ship.Name + " is sunk! ");
                }
                //update board value to hit on board
                box.BoxValue = BoxValue.Hit;
            }
            else
            {
                Console.WriteLine("Already marked as hit! ");
            }
        }



    }
}