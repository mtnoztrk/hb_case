using hb_case.Enums;

namespace hb_case.Models
{
    public interface IRover
    {
        /// <summary>
        /// Facing direction of the rover
        /// </summary>
        Directions Orientation { get; set; }
        /// <summary>
        /// Adds given value to the X coordinate of the rover
        /// </summary>
        /// <param name="value"></param>
        void AddToX(int value);
        /// <summary>
        /// Adds given value to the Y coordinate of the rover
        /// </summary>
        /// <param name="value"></param>
        void AddToY(int value);
        /// <summary>
        /// Initializes object with given values
        /// </summary>
        /// <param name="plateu"></param>
        /// <param name="startX"></param>
        /// <param name="startY"></param>
        /// <param name="startOrientation"></param>
        void Initialize(Plateu plateu, int startX, int startY, Directions startOrientation);
        /// <summary>
        /// Gets the final position as string of the rover
        /// </summary>
        /// <returns></returns>
        string GetPositionString();
    }
}
