using hb_case.Enums;
using hb_case.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Linq;

namespace hb_case
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                // different rover will be created for different callers
                .AddTransient<IRover, Rover>()
                // same objects can be used through same flow(http request in web apis)
                .AddScoped<MoveOrder>()
                .AddScoped<TurnRightOrder>()
                .AddScoped<TurnLeftOrder>()
                // selecting correct order handler with strategy-like pattern
                .AddScoped<Func<Orders, IOrder>>(orderProvider =>
                    key => 
                    { 
                        switch (key)
                        {
                            case Orders.Move:
                                return orderProvider.GetRequiredService<MoveOrder>();
                            case Orders.TurnRight:
                                return orderProvider.GetRequiredService<TurnRightOrder>();
                            case Orders.TurnLeft:
                                return orderProvider.GetRequiredService<TurnLeftOrder>();
                            default:
                                throw new ArgumentException("Not valid OrderHandler.");
                        }
                    })
                .BuildServiceProvider();



            // there is no validation for input.txt file. it is assumed to be valid for this project.
            string[] lines = File.ReadAllLines("input.txt");
            var boundaries = lines[0].Split(" ");
            var plateu = new Plateu(0, 0, Convert.ToInt32(boundaries[0]), Convert.ToInt32(boundaries[1]));

            for (int i = 1; i < lines.Length; i += 2)
            {
                var roverInfo = lines[i].Split(" ");
                var rover = serviceProvider.GetRequiredService<IRover>();
                rover.Initialize(plateu, Convert.ToInt32(roverInfo[0]), Convert.ToInt32(roverInfo[1]), (Directions)char.Parse(roverInfo[2]));

                var orders = lines[i + 1].ToCharArray().Select(c => (Orders)c);
                var orderHandler = serviceProvider.GetRequiredService<Func<Orders, IOrder>>();
                
                foreach (var order in orders)
                {
                    orderHandler(order).Execute(rover);
                }
                Console.WriteLine(rover.GetPositionString());
            }
        }
    }
}
