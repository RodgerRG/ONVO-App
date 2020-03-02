using System;
using ONVO_App.GoonGenerator;
namespace ONVO_App.Structs
{
    public class Goon : Character
    {
        private Goon(int charisma, int power, int speed, int technique, int intelligence, int maxHP, int maxRP, int rpMod, int startingRP) : base(charisma, power, speed, technique, intelligence, maxHP, maxRP, rpMod, startingRP){
            this.quirk = QuirkGenerator.generateQuirk();

            int[] costs = new int[4];
            Random rng = new Random();
            for(int i = 0; i < rng.Next(4, 7); i++) {
                costs[i] = rng.Next(1, maxRP + 1);
            }

            this.skills = new SkillGenerator(0.5, 2, 0.2, 0.3).generateSkills(0, costs);
        }

        private static int factoryCharm = 1;
        private static int factoryPow = 1;
        private static int factorySpeed = 1;
        private static int factoryTech = 1;
        private static int factoryInt = 1;
        private static int factoryHP = 1;
        private static int factoryMRP = 1;
        private static int factoryCRP = 1;
        private static int factoryRPMod = 1;


        public static Goon makeGoon() {
            return new Goon(factoryCharm, factoryPow, factorySpeed, factoryTech, factoryInt, factoryHP, factoryMRP, factoryRPMod, factoryCRP);
        }

        public static bool setCharm(int charm) {
            if(charm >= 1 && charm <= 12) {
                factoryCharm = charm;
                return true;
            } else {
                return false;
            }
        }

        public static bool setPow(int pow) {
            if(pow >= 1 && pow <= 12) {
                factoryPow = pow;
                return true;
            } else {
                return false;
            }
        }

        public static bool setSpeed(int speed) {
            if(speed >= 1 && speed <= 12) { 
                factorySpeed = speed;
                return true;
            } else {
                return false;
            }
        }

        public static bool setTech(int tech) {
            if(tech >= 1 && tech <= 12) {
                factoryTech = tech;
                return true;
            } else {
                return false;
            }
        }

        public static bool setInt(int intel) {
            if(intel >= 1 && intel <= 12) {
                factoryInt = intel;
                return true;
            } else {
                return false;
            }
        }

        public static bool setHP(int hp) {
            if(hp > 0) {
                factoryHP = hp;
                return true;
            } else {
                return false;
            }
        }

        public static bool setMaxRP(int rp) {
            if(rp > 0) {
                factoryMRP = rp;
                return true;
            } else {
                return false;
            }
        }

        public static bool setCurrentRP(int rp) {
            if(rp <= factoryMRP && rp > 0) {
                factoryCRP = rp;
                return true;
            } else {
                return false;
            }
        }

        public static void setRPMod(int mod) {
           factoryRPMod = mod;
        }

        public override string ToString() {
            return string.Format("Current HP: {0} \nMaximum HP: {1} \nCurrent RP: {2} \nMaximum RP: {3} \nRP Modifier: {4} \nPower: {5} \nSpeed: {6} \nTechnique: {7} \nIntelligence: {8} \nCharm: {9} \nQuirk: {10}", 
            currentHP, maxHP, currentRP, maxRP, rpMod, power, speed, technique, intelligence, charisma, quirk);
        }
    }
}