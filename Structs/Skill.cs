namespace ONVO_App.Structs
{
    public struct Skill {
        private int cost;
        private int damage;
        private string[] keywords;
        private bool isDispel;
        private bool makeHidden;
        private int numUses;
        private int burn, bleed, blight;

        public Skill(int cost, int damage, string[] keywords, bool isDispel, int burn, int bleed, int blight, int numUses, bool makeHidden) {
            this.damage = damage;
            this.keywords = keywords;
            this.isDispel = isDispel;
            this.burn = burn;
            this.blight = blight;
            this.bleed = bleed;
            this.cost = cost;
            this.numUses = numUses;
            this.makeHidden = makeHidden;
        }

        public Skill(Skill skill, int damage) {
            this.keywords = skill.getKeywords();
            this.isDispel = skill.IsDispel();
            this.burn = skill.getBurn();
            this.blight = skill.getBlight();
            this.bleed = skill.getBleed();
            this.cost = skill.getCost();
            this.damage = damage;
            this.numUses = skill.getNumUses();
            this.makeHidden = skill.getHidden();
        }

        public override string ToString() {
            string isHeal = "";

            if(isDispel) {
                isHeal = "Heal";
            } else {
                isHeal = "Damage";
            }

            return string.Format("Cost: {0} \n{1}: {2} \nBurn: {3} \nBlight: {4} \nBleed: {5} \nKeywords: {6}", cost, isHeal, damage, burn, blight, bleed, string.Join(", ", keywords));
        }

        public int getCost() {
            return cost;
        }

        public string[] getKeywords() {
            return keywords;
        }

        public int getDamage() {
            return damage;
        }

        public bool IsDispel() {
            return isDispel;
        }

        public int getBurn() {
            return burn;
        }

        public int getBlight() {
            return blight;
        }

        public int getBleed() {
            return bleed;
        }

        public int getNumUses() {
            return numUses;
        }

        public bool getHidden() {
            return makeHidden;
        }

        public bool canUse() {
            if(numUses > 0 || numUses == -1) {
                return true;
            }

            return false;
        }

        public bool useSkill() {
            if(numUses == 0) {
                return false;
            }
            
            if(numUses > 0) {
                numUses -= 1;
            }

            return true;
        }
    }
}