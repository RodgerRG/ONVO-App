using ONVO_App.Structs;
namespace ONVO_App.CombatSimulator
{
    public class CombatCharacter
    {
        private Character character;
        private int bleedStack, blightStack, burnStack;
        private bool isHidden;

        private int actionTax = 0;
        public CombatCharacter(Character character) {
            this.character = character;
            bleedStack = 0;
            blightStack = 0;
            burnStack = 0;
        }

        public bool getHidden() {
            return isHidden;
        }

        public void toggleHidden() {
            isHidden = !isHidden;
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

        public bool canMakeAction() {
            int RPAvailable = character.getCurrentRP();

            if(RPAvailable >= 1 + actionTax) {
                return true;
            }

            foreach(Skill s in character.getSkills()) {
                if(s.getCost() < RPAvailable && s.canUse()) {
                    return true;
                }
            }

            return false;
        }

        public void applyBlight() {
            this.applyDamage(blightStack);
        }

        public void applyDOTs() {
            this.applyDamage(bleedStack);
            this.applyDamage(burnStack);
        }
    }
}