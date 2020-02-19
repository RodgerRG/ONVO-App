using ONVO_App.GoonGenerator;
using ONVO_App.SocketManager;
using System;
namespace ONVO_App
{
    class Program
    {
        static void Main(string[] args)
        {
            GoonGenerator.GoonGenerator goonGen = new GoonGenerator.GoonGenerator();
            Output output = new Output();
            Goon[] goons = goonGen.generateGoons(300, 1, 3, 8, 8, 13, 1, 1, 3, 4, 1, 1);

            output.printGoons(goons);
            output.printGoonstoFile(goons);

            SocketController sc = new SocketController();
            sc.start();

            Console.Out.WriteLine("Type STOP to stop the server...");
            string input = Console.In.ReadLine();

            while(input != "STOP") {
                input = Console.In.ReadLine();
            }
        }
    }
}
