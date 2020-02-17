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
            Random rng = new Random();
            string output = "";
            
            string[] files = getTextFilePaths();
            ArrayList nouns = new ArrayList();
            ArrayList humanParts = new ArrayList();
            ArrayList adjectives = new ArrayList();

            foreach(string s in files) {
                
                if(s.Contains("nouns")) {
                    nouns = getFile(s);
                }

                if(s.Contains("human_parts")) {
                    humanParts = getFile(s);
                }

                if(s.Contains("adjectives")) {
                    adjectives = getFile(s);
                }
            }

            int mutationType = rng.Next(1, 3);

            switch((MutationType) mutationType) {
                case MutationType.ADDITIONAL:
                    output = string.Format("The user has {0} growing out of {1}", nouns[rng.Next(0, nouns.Count)], humanParts[rng.Next(0, humanParts.Count)]);
                break;
                case MutationType.REPLACEMENT:
                    output = string.Format("The user has a {0} instead of a {1}", nouns[rng.Next(0, nouns.Count)], humanParts[rng.Next(0, humanParts.Count)]);
                break;
            }   

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
                    nouns = getFile(s);
                }

                if(s.Contains("quirks")) {
                    quirks = getFile(s);
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
        private static ArrayList getFile(string path) {
            StreamReader fileStream = new StreamReader(File.OpenRead(path));
            ArrayList contents = new ArrayList();

            while(!fileStream.EndOfStream) {
                contents.Add(fileStream.ReadLine());
            }

            return contents;
        }

        public enum QuirkType {
            EMITTER = 1, 
            TRANSFORMATION = 2, 
            MUTATION = 3,

        }

        /**
        This may be needed, in case the current system has too many weird quirks being generated (like having a gun growing out of a kidney, etc.)
         */
        private enum HumanSystem {
            NERVOUS = 1,
            CIRCULATORY = 2,
            ENDOCRINE = 3,
            DIGESTIVE = 4,
            IMMUNE = 5,
            MUSCULAR = 6,
            RENAL = 7,
            RESPIRATORY = 8,
            SKELETAL = 9,

        }

        private enum MutationType {
            REPLACEMENT = 1,
            ADDITIONAL = 2,

        }
    }
}