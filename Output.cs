using System;
using System.IO;
using ONVO_App.GoonGenerator;
using ONVO_App.Structs;
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

        public void printGoonstoFile(Goon[] goons)  {
            string dir = Directory.GetCurrentDirectory();
            dir = dir + "/logs";

            if(!Directory.Exists(dir)) {
                Directory.CreateDirectory(dir);
            }

            DateTime time = DateTime.Now;
            dir = dir + string.Format("/Goon_File_@{0}-{1}-{2}", time.Day, time.Month, time.Year);

            StreamWriter f = new StreamWriter(File.Create(dir));

            foreach(Goon goon in goons) {
                f.WriteLine(goon + "\n");
            }

            f.Close();
        }
    }
}