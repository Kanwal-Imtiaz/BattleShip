using System;
namespace BattleShipProject
{
    public class Square
    {
        public BoxValue BoxValue { get; set; }
        public int Row { get; set; }
        public int Column { get; set; }

        public Square(int row, int column)
        {
           
            Row = row;
            Column = column;
            BoxValue = BoxValue.Empty;
        }

        public string Value()
        {
            return ((char)BoxValue).ToString();

        }

        public string ValueHidingShip()
        {
            
            //If box is a ship then return "-"
            if (IsOccupied())
            {
                return "-";
            }
            else
            {
                return ((char)BoxValue).ToString();
            }


        }



        public bool IsOccupied()
        {
            if (BoxValue == BoxValue.Carrier || BoxValue == BoxValue.Battleship || BoxValue == BoxValue.Destroyer || BoxValue == BoxValue.PatrolBoat || BoxValue == BoxValue.Submarine)
                    
            {
                return true;
            }
            else
            {
                return false;
            }
                 
           
        }

        
    }


    //We have a list for box value, either empty, hit, miss or a ship of any kind
    public enum BoxValue
    {
        Empty = '-',
        Hit = 'X',
        Miss = 'M',
        Carrier = 'C',
        Battleship = 'B',
        Destroyer = 'D',
        Submarine = 'S',
        PatrolBoat = 'P'
    }


}
