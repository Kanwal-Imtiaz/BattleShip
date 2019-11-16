using System;

namespace BattleShipProject.Ships
{
    public class Battleship : Ship
    {
        public Battleship()
        {
            Name = "Battleship";
            Size = 4;
            Type = BoxValue.Battleship;
        }
    }
}
