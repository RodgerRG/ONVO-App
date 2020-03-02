namespace ONVO_App.Structs
{
    public class Player : Character
    {
        public Player(int charisma, int power, int speed, int technique, int intelligence, int maxHP, int maxRP, int rpMod, int startingRP, string quirk, Skill[] skills) : base(charisma, power, speed, technique, intelligence, maxHP, maxRP, rpMod, startingRP){
             this.quirk = quirk;
             this.skills = skills;
        }

        public override string ToString() {
            return "";
        }
    }
}