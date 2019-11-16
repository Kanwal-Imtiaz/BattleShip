using System;
namespace BattleShipProject.Ships
{
    /// <summary>
    /// Represents a player's ship as placed on their Game Board.
    /// </summary>
    public abstract class Ship
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public int Hits { get; set; }
        public BoxValue Type { get; set; }

        public bool IsSunk()
        {
            if (Hits >= Size)
            {
                return true;
            }
            else return false;
            
        }
    }
}
