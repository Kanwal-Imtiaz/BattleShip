using System;

namespace BattleShipProject.Ships
{
    public class Carrier : Ship
    {
        public Carrier()
        {
            Name = "Carrier";
            Size = 5;
            Type = BoxValue.Carrier;
        }
    }
}
