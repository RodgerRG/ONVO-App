using ONVO_App.GoonGenerator;
using ONVO_App.Structs;
namespace ONVO_App.Models
{
    public class GoonModel
    {
        public int charisma {get; set;}
        public int power {get; set;}
        public int speed {get; set;}
        public int technique {get; set;}
        public int intelligence {get; set;}
        public int maxHP {get; set;}
        public int currentHP {get; set;}
        public int maxRP {get; set;}
        public int currentRP {get; set;}
        public int rpMod {get; set;}
        public string quirk {get; set;}
        public Skill[] skills {get; set;}

        public GoonModel(int charisma, int power, int speed, int technique, int intelligence, int maxHP, int currentHP, 
        int maxRP, int currentRP, int rpMod, string quirk, Skill[] skills) {
            this.charisma = charisma;
            this.power = power;
            this.speed = speed;
            this.technique = technique;
            this.intelligence = intelligence;
            this.maxHP = maxHP;
            this.currentHP = currentHP;
            this.maxRP = maxRP;
            this.currentRP = currentRP;
            this.rpMod = rpMod;
            this.quirk = quirk;
            this.skills = skills;
        }

        public GoonModel() {
            
        }

        public static explicit operator GoonModel(Character g) => new GoonModel(
            g.getCharisma(), g.getPower(), g.getSpeed(), g.getTechnique(), g.getIntelligence(),
            g.getMaxHP(), g.getCurrentHP(), g.getMaxRP(), g.getCurrentRP(), g.getRPMod(), g.getQuirk(), g.getSkills()
        );
    }
}