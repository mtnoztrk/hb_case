using hb_case.Enums;
using hb_case.Exceptions;
using hb_case.Models;
using System;
using System.Linq;
using Xunit;

namespace hb_case.test
{
    public class RoverTest
    {
        private readonly Func<Orders, IOrder> _orderHandler;

        public RoverTest()
        {
            _orderHandler = new Func<Orders, IOrder>(key =>
            {
                switch (key)
                {
                    case Orders.Move:
                        return new MoveOrder();
                    case Orders.TurnRight:
                        return new TurnRightOrder();
                    case Orders.TurnLeft:
                        return new TurnLeftOrder();
                    default:
                        throw new ArgumentException("Not valid OrderHandler.");
                }
            });
        }

        [Theory]
        [InlineData("5 5", "1 2 N", "MMMMM")]
        public void OutOfBoundsTest(params string[] input)
        {
            var boundaries = input[0].Split(" ");
            var plateu = new Plateu(0, 0, Convert.ToInt32(boundaries[0]), Convert.ToInt32(boundaries[1]));

            Assert.Throws<OutOfBoundsException>(() =>
            {
                for (int i = 1; i < input.Length; i += 2)
                {
                    var roverInfo = input[i].Split(" ");
                    var rover = new Rover();
                    rover.Initialize(plateu, Convert.ToInt32(roverInfo[0]), Convert.ToInt32(roverInfo[1]), (Directions)char.Parse(roverInfo[2]));

                    var orders = input[i + 1].ToCharArray().Select(c => (Orders)c);

                    foreach (var order in orders)
                    {
                        _orderHandler(order).Execute(rover);
                    }
                    Console.WriteLine(rover.GetPositionString());
                }
            });
        }
    }
}
