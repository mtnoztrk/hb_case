using hb_case.Enums;
using hb_case.Models;

namespace hb_case
{
    public class TurnLeftOrder : IOrder
    {
        public void Execute(IRover rover)
        {
            switch (rover.Orientation)
            {
                case Directions.East:
                    rover.Orientation = Directions.North;
                    break;
                case Directions.West:
                    rover.Orientation = Directions.South;
                    break;
                case Directions.South:
                    rover.Orientation = Directions.East;
                    break;
                case Directions.North:
                    rover.Orientation = Directions.West;
                    break;
                default:
                    break;
            }
        }
    }
}
