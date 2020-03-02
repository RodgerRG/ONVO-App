using System;
namespace ONVO_App.GoonGenerator
{
    public struct Goon
    {
        private int charisma;
        private int power;
        private int speed;
        private int technique;
        private int intelligence;
        private int maxHP;
        private int currentHP;
        private int maxRP;
        private int currentRP;
        private int rpMod;
        private string quirk;

        private Skill[] skills;

        private Goon(int charisma, int power, int speed, int technique, int intelligence, int maxHP, int maxRP, int rpMod, int startingRP) {
            this.charisma = charisma;
            this.power = power;
            this.speed = speed;
            this.technique = technique;
            this.intelligence = intelligence;
            this.maxHP = maxHP;
            this.maxRP = maxRP;
            this.currentRP = startingRP;
            this.rpMod = rpMod;
            this.currentHP = maxHP;
            this.quirk = QuirkGenerator.generateQuirk();

            int[] costs = new int[4];
            Random rng = new Random();
            for(int i = 0; i < rng.Next(4, 7); i++) {
                costs[i] = rng.Next(1, maxRP + 1);
            }

            this.skills = new SkillGenerator(0.5, 2, 0.2, 0.3).generateSkills(0, costs);
        }

        public int getCharisma() {
            return charisma;
        }

        public int getPower() {
            return power;
        }

        public int getSpeed() {
            return speed;
        }

        public int getTechnique() {
            return technique;
        }

        public int getIntelligence() {
            return intelligence;
        }

        public int getCurrentHP() {
            return currentHP;
        }

        public int getCurrentRP() {
            return currentRP;
        }

        public int getMaxHP() {
            return maxHP;
        }

        public int getMaxRP() {
            return maxRP;
        }

        public int getRPMod() {
            return rpMod;
        }

        public string getQuirk() {
            return quirk;
        }

        public void changeHealth(int amount) {
            currentHP += amount;
        }

        public bool spendRP(int amount) {
            currentRP += amount;
            if(currentRP < 0) {
                currentRP -= amount;
                return false;
            } else {
                return true;
            }
        }

        public Skill[] getSkills() {
            return skills;
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