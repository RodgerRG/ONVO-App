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
                break;
                case QuirkType.TRANSFORMATION:
                break;
                case QuirkType.MUTATION:
                break;
            }



            return quirk;
        }

        public enum QuirkType {
            EMITTER = 1, 
            TRANSFORMATION = 2, 
            MUTATION = 3,

        }
    }
}