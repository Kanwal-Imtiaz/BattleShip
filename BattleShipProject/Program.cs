using System;

namespace BattleShipProject
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            //1.Create a board for player
            Player p1 = new Player("Player");

            //2. Add ships to the board and display board on console
            p1.PlaceShips();
            //display board with ships
            p1.OutputBoards(false); 


            while (!p1.HasLost())
            {
                //3. Take an "attack" at given position and report back whether the attack resulted in a hit or a miss
                bool validInput = false;
                while (!validInput)
                {
                    validInput= p1.TakeAttack();
                    //Console.WriteLine("* Input not valid. Try again! * ");

                }

                //Console.WriteLine("* Valid input * ");
                //display board without ships
                p1.OutputBoards(true);
                
            }

            //4. Return whether the player has lost the game yet (i.e all ships are sunk)
            Console.WriteLine("*** Player has lost the game as all ships are sunk ***");

            Console.ReadLine();
        }
    }
}
