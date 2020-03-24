using System;
using System.Collections;
using ONVO_App.Structs;

namespace ONVO_App.GoonGenerator
{
    public class SkillGenerator
    {
        private double pointToDamageRatio;
        private double levelToPointRatio;
        private double CRtoPointRatio;
        private double pointToHealRatio;

        private Hashtable skillCosts, dotCosts;

        public SkillGenerator(double damageRatio, double levelRatio, double crRatio, double healRatio) {
            pointToDamageRatio = damageRatio;
            pointToHealRatio = healRatio;
            levelToPointRatio = levelRatio;
            CRtoPointRatio = crRatio;

            //it should never be more cost effective to heal.
            if(healRatio <= damageRatio) {
                healRatio = damageRatio + 1;
            }

            skillCosts = new Hashtable();
            dotCosts = new Hashtable();

            makeKeywordTable();
            makeDoTTable();
        }

        public Skill[] generateSkills(int CR, int[] costs) {
            Skill[] skills = new Skill[costs.Length];
            
            for(int i = 0; i < costs.Length; i++) {
                skills[i] = makeSkill(CR, costs[i]);
            }

            return skills;
        }

        public Skill makeSkill(int CR, int cost) {
            Random rng = new Random();
            int points = (int) Math.Round((double) (CR * CRtoPointRatio + cost * levelToPointRatio));

            Skill skill = new Skill();

            switch(rng.Next(1, 3)) {
                //in this case, isDispel is false;
                case 1 :
                    skill = allocatePoints(points, false, cost);
                break;

                //in this case, is Dispel is true;
                case 2 :
                    skill = allocatePoints(points, true, cost);
                break;
            }

            return skill;
        }

        private Skill allocatePoints(int points, bool isDispel, int cost) {
            Random rng = new Random();

            int currentPoints = points;

            int damage = 0;
            int burnCount = 0, blightCount = 0, bleedCount = 0, pointsToSpend;
            ArrayList keywords = new ArrayList();

            while(currentPoints != 0) {
                switch(rng.Next(1, 4)) {
                    //alloc as damage
                    case 1:
                        pointsToSpend = rng.Next(1, currentPoints);
                        damage += (int) Math.Round((double) (pointsToSpend * (isDispel ? pointToHealRatio:pointToDamageRatio)));
                        currentPoints -= pointsToSpend;
                    break;
                    
                    //alloc as keyword
                    case 2:
                        if(isDispel) {
                            continue;
                        }

                        pointsToSpend = rng.Next(1, currentPoints);
                        if(!keywords.Contains(skillCosts[Math.Min(pointsToSpend, 6)].ToString())) {
                            keywords.Add(skillCosts[Math.Min(pointsToSpend, 6)].ToString());
                            currentPoints -= Math.Min(pointsToSpend, 6);
                        }
                    break;
                    
                    //alloc as DoT
                    case 3:
                        pointsToSpend = rng.Next(1, currentPoints);

                        switch(dotCosts[Math.Min(pointsToSpend, 3)]) {
                            case StatusKeywords.BLEED:
                                if(isDispel) {
                                    if(!keywords.Contains("Dispel BLEED")) {
                                        keywords.Add("Dispel BLEED");
                                        currentPoints -= Math.Min(pointsToSpend, 3);
                                    }
                                } else {
                                    bleedCount += 1;
                                    currentPoints -= Math.Min(pointsToSpend, 3);
                                }
                            break;
                            case StatusKeywords.BLIGHT:
                                if(isDispel) {
                                    if(!keywords.Contains("Dispel BLIGHT")) {
                                        keywords.Add("Dispel BLIGHT");
                                        currentPoints -= Math.Min(pointsToSpend, 3);
                                    }
                                } else {
                                    blightCount += 1;
                                    currentPoints -= Math.Min(pointsToSpend, 3);
                                }
                            break;
                            case StatusKeywords.BURN:
                                if(isDispel) {
                                    if(!keywords.Contains("Dispel BLIGHT")) {
                                        keywords.Add("Dispel BLIGHT");
                                        currentPoints -= Math.Min(pointsToSpend, 3);
                                    }
                                } else {
                                    burnCount += 1;
                                    currentPoints -= Math.Min(pointsToSpend, 3);
                                }
                            break;
                        }
                    break;
                }
            }

            return new Skill(cost, damage, keywords.ToArray(Type.GetType("System.String")) as string[], isDispel, burnCount, bleedCount, blightCount, -1, false);
        }

        private void makeKeywordTable() {
            skillCosts.Add(3, SkillKeywords.BLOCK);
            skillCosts.Add(5, SkillKeywords.REFLECT);
            skillCosts.Add(0, SkillKeywords.TRAP);
            skillCosts.Add(1, SkillKeywords.RANGED);
            skillCosts.Add(7, SkillKeywords.ODD);
            skillCosts.Add(4, SkillKeywords.ZONE);
            skillCosts.Add(6, SkillKeywords.OVERWHELM);
            skillCosts.Add(2, SkillKeywords.STUN);
            skillCosts.Add(8, SkillKeywords.DAZE);
        }

        private void makeDoTTable() {
            dotCosts.Add(3, StatusKeywords.BLEED);
            dotCosts.Add(2, StatusKeywords.BLIGHT);
            dotCosts.Add(1, StatusKeywords.BURN);
        }

        private enum SkillKeywords {
            BLOCK = 0,
            REFLECT = 1,
            TRAP = 2,
            RANGED = 3,
            ODD = 4,
            ZONE = 5,
            OVERWHELM = 6,
            STUN = 7,
            DAZE = 8,
        }

        private enum StatusKeywords {
            BLEED = 0,
            BLIGHT = 1,
            BURN = 2,
        }
    }
}