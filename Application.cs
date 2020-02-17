using System;
using ONVO_App.GoonGenerator;

namespace ONVO_App
{
    class Program
    {
        static void Main(string[] args)
        {
            GoonGenerator.GoonGenerator goonGen = new GoonGenerator.GoonGenerator();
            Output output = new Output();
            Goon[] goons = goonGen.generateGoons(300, 1, 3, 8, 8, 13, 1, 1, 3, 4, 1, 1);

            output.printGoonstoFile(goons);
        }
    }
}
