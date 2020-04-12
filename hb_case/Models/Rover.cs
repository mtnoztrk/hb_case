using hb_case.Enums;
using hb_case.Exceptions;

namespace hb_case.Models
{
    public class Rover : IRover
    {
        public Directions Orientation { get; set; }
        
        private int X { get; set; }
        private int Y { get; set; }
        private Plateu _plateu { get; set; }

        public void Initialize(Plateu plateu, int startX, int startY, Directions startOrientation)
        {
            _plateu = plateu;
            X = startX;
            Y = startY;
            Orientation = startOrientation;
        }

        public void AddToX(int value)
        {
            if (X + value < _plateu.Boundaries.LowerX)
                throw new OutOfBoundsException("LowerX violation!");
            else if (X + value > _plateu.Boundaries.UpperX)
                throw new OutOfBoundsException("UpperX violation!");

            X += value;
        }

        public void AddToY(int value)
        {
            if (Y + value < _plateu.Boundaries.LowerY)
                throw new OutOfBoundsException("LowerY violation!");
            else if (Y + value > _plateu.Boundaries.UpperY)
                throw new OutOfBoundsException("UpperY violation!");

            Y += value;
        }

        public string GetPositionString() => $"{X} {Y} {(char)Orientation}";
    }
}
