using ONVO_App.GoonGenerator;
namespace ONVO_App.Structs
{
    public abstract class Character
    {
        protected int charisma;
        protected int power;
        protected int speed;
        protected int technique;
        protected int intelligence;
        protected int maxHP;
        protected int currentHP;
        protected int maxRP;
        protected int currentRP;
        protected int rpMod;
        protected string quirk;
        protected Skill[] skills;

        public Character(int charisma, int power, int speed, int technique, int intelligence, int maxHP, int maxRP, int startingRP, int rpMod) {
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
            currentHP -= amount;
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

        public abstract override string ToString();
    }
}