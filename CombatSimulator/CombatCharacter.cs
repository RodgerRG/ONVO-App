using ONVO_App.Structs;
namespace ONVO_App.CombatSimulator
{
    public class CombatCharacter
    {
        private Character character;
        private int bleedStack, blightStack, burnStack;
        public CombatCharacter(Character character) {
            this.character = character;
            bleedStack = 0;
            blightStack = 0;
            burnStack = 0;
        }

        public void roundOver() {
            blightStack = 0;
            burnStack = 0;
        }

        public Character getCharacter() {
            return character;
        }

        public void addBleed(int bleed) {
            bleedStack += bleed;
        }

        public void addBlight(int blight) {
            blightStack += blight;
        }

        public void addBurn(int burn) {
            burnStack += burn;
        }

        public void applyDamage(int damage) {
            character.changeHealth(damage);
        }
    }
}