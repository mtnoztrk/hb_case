using hb_case.Enums;
using hb_case.Models;

namespace hb_case
{
    public class MoveOrder : IOrder
    {
        public void Execute(IRover rover)
        {
            switch (rover.Orientation)
            {
                case Directions.East:
                    rover.AddToX(1);
                    break;
                case Directions.West:
                    rover.AddToX(-1);
                    break;
                case Directions.South:
                    rover.AddToY(-1);
                    break;
                case Directions.North:
                    rover.AddToY(1);
                    break;
                default:
                    break;
            }
        }
    }
}
