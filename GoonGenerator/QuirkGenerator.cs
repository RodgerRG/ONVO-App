using System.Collections;
using System.IO;
using System;
namespace ONVO_App.GoonGenerator
{
    public static class QuirkGenerator
    {
        public static string generateQuirk() {
            Random rng = new Random();
            int type = rng.Next(1, 4);
            string quirk = "";
            
            switch((QuirkType) type) {
                case QuirkType.EMITTER:
                    quirk = generateEmitterQuirk();
                    break;
                case QuirkType.TRANSFORMATION:
                    quirk = generateTransformationQuirk();
                    break;
                case QuirkType.MUTATION:
                    quirk = generateMutationQuirk();
                    break;
            }

            return quirk;
        }

        private static string generateEmitterQuirk() {
            string output = "";
            return output;
        }

        private static string generateMutationQuirk() {
            string output = "";
            return output;
        }

        private static string generateTransformationQuirk() {
            Random rng = new Random();
            string output = "";
            
            string[] files = getTextFilePaths();
            ArrayList nouns = new ArrayList();
            ArrayList quirks = new ArrayList();

            foreach(string s in files) {
                
                if(s.Contains("nouns")) {
                    nouns = getNouns(s);
                }

                if(s.Contains("quirks")) {
                    quirks = getQuirks(s);
                }
            }

            output = string.Format("Transform into a {0}", nouns[rng.Next(0, nouns.Count)]);           

            return output;
        }

        private static string[] getTextFilePaths() {
            string currentDir = System.IO.Directory.GetCurrentDirectory();
            string[] dirs = System.IO.Directory.GetDirectories(currentDir);
            string[] files = null;
            foreach(string s in dirs) {
                if(s.Contains("res")) {
                    files = System.IO.Directory.GetFiles(s);
                }
            }

            string[] output = new string[2];

            foreach(string s in files) {
                if(s.Contains("nouns")) {
                    output[0] = s;
                }
                if(s.Contains("quirks")) {
                    output[1] = s;
                }
            }

            
            return output;
        }

        /**
        TODO: Add threading to these two methods as they manipulate data streams
         */
        private static ArrayList getNouns(string path) {
            StreamReader nounStream = new StreamReader(File.OpenRead(path));
            ArrayList nouns = new ArrayList();

            while(!nounStream.EndOfStream) {
                nouns.Add(nounStream.ReadLine());
            }

            return nouns;
        }

        private static ArrayList getQuirks(string path) {
            StreamReader quirkStream = new StreamReader(File.OpenRead(path));
            ArrayList quirks = new ArrayList();

            while(!quirkStream.EndOfStream) {
                quirks.Add(quirkStream.ReadLine());
            }

            return quirks;
        }

        public enum QuirkType {
            EMITTER = 1, 
            TRANSFORMATION = 2, 
            MUTATION = 3,

        }
    }
}