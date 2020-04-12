namespace hb_case.Models
{
    public class Plateu
    {
        public (int LowerX, int LowerY, int UpperX, int UpperY) Boundaries { get; set; }

        public Plateu(int lowerX, int lowerY, int upperX, int upperY)
        {
            Boundaries = (lowerX, lowerY, upperX, upperY);
        }
    }
}
