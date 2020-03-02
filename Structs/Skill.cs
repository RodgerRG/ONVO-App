namespace ONVO_App.Structs
{
    public struct Skill {
        private int cost;
        private int damage;
        private string[] keywords;
        private bool isDispel;

        private int burn, bleed, blight;

        public Skill(int cost, int damage, string[] keywords, bool isDispel, int burn, int bleed, int blight) {
            this.damage = damage;
            this.keywords = keywords;
            this.isDispel = isDispel;
            this.burn = burn;
            this.blight = blight;
            this.bleed = bleed;
            this.cost = cost;
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
    }
}