using System;
namespace BattleShipProject.Ships
{
    public class Destroyer : Ship
    {
        public Destroyer()
        {
            Name = "Destroyer";
            Size = 3;
            Type = BoxValue.Destroyer;
        }
    }
}
