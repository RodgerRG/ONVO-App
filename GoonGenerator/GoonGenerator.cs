using System;
namespace ONVO_App.GoonGenerator
{
    public class GoonGenerator
    {
        public GoonGenerator() {

        }

        public Goon generateGoon(int level, int minStat, int maxStat, int minHP, int maxHP, int minStartRP, int maxStartRP, int minMaxRP, int maxMaxRP, int minRPMod, int maxRPMod) {
            Random rng = new Random();
            int statsToGo = 25 + level;
            int[] stats = new int[5];

            if(maxStat * 5 < statsToGo) {
                throw new ArgumentException("cannot achieve required stats with the given max!");
            }

            if(minStat > maxStat) {
                throw new ArgumentException("maxStat cannot be less than minStat");
            }

            for(int i = 0; i < 5; i++) {
                int stat = rng.Next(minStat, maxStat);

                while(statsToGo - stat < 0) {
                    stat = rng.Next(minStat, maxStat);
                }

                stats[i] = stat;
            }

            while(!checkSum(stats, 25 + level)) {
                int ind = 0;
                int sum = 0;

                foreach(int stat in stats) {
                    sum += stat;
                }

                if(sum < 25 + level) {
                //don't increment a stat if it pushs the stat over the maximum set value.
                    if(stats[ind % 5] + 1 > maxStat) {
                        ind++;
                        continue;
                    } else {
                        stats[ind % 5] += 1;
                    }
                } else {
                    if(stats[ind % 5] - 1 < minStat) {
                        ind++;
                        continue;
                    } else {
                        stats[ind % 5] -= 1;
                    }
                }

                ind++;
            }

            int hp = rng.Next(minHP, maxHP + 1);
            int startRP = rng.Next(minStartRP, maxStartRP + 1);
            int maxRP = rng.Next(minMaxRP, maxMaxRP + 1);
            int rpMod = rng.Next(minRPMod, maxRPMod + 1);

            if(maxRP < startRP) {
                int temp = startRP;
                startRP = maxRP;
                maxRP = temp;
            }


            return makeGoon(stats, hp, startRP, maxRP, rpMod);
        }

        private bool checkSum(int[] stats, int total) {
            int sum = 0;
            foreach(int stat in stats) {
                sum += stat;
            }

            if(sum == total) {
                return true;
            } else {
                return false;
            }
        }

        private Goon makeGoon(int[] stats, int hp, int startRP, int maxRP, int rpMod) {
            Goon.setCharm(stats[0]);
            Goon.setInt(stats[1]);
            Goon.setPow(stats[2]);
            Goon.setSpeed(stats[3]);
            Goon.setTech(stats[4]);

            Goon.setHP(hp);
            Goon.setCurrentRP(startRP);
            Goon.setMaxRP(maxRP);
            Goon.setRPMod(rpMod);

            return Goon.makeGoon();
        }
    }
}