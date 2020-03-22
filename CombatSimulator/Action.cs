using ONVO_App.Structs;
namespace ONVO_App.CombatSimulator
{
    public class Action
    {
        private Character source;
        private Character target;
        private Skill skill;

        public Action(Character source, Character target, Skill skill) {
            this.source = source;
            this.target = target;
            this.skill = skill;
        }

        public Character getTarget() {
            return target;
        }

        public Skill GetSkill() {
            return skill;
        }

        public Character getSource() {
            return source;
        }
    }
}