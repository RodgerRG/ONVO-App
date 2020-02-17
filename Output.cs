using System;
using ONVO_App.GoonGenerator;

namespace ONVO_App
{
    /**
    This class is responsible for handling all the IO, including the printing to console (For Now).
     */
    public class Output
    {
        public Output() {

        }

        public void printGoons(Goon[] goons) {
            Console.Out.WriteLine("A List of Goons...");
            Console.Out.WriteLine("==================");

            int ind = 1;

            foreach(Goon goon in goons) {
                Console.Out.WriteLine(string.Format("Goon #{0}", ind));
                Console.Out.WriteLine("==================");
                Console.Out.WriteLine(goon);
                Console.Out.WriteLine("==================");

                ind++;
            }
        }
    }
}