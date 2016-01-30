using Assets.Model.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Model.Gameplay
{
    class GameplayProvider
    {
        private List<AbstractGameplay> gameplays;
        private Random rndGen;

        public GameplayProvider(int seed)
        {
            rndGen = new Random(seed);
        }

        public void registerGameplay(AbstractGameplay gameplay)
        {
            gameplays.Add(gameplay);
        }

        public AbstractGameplay getNext(AbstractGameplay current, ResourceState resourceState)
        {
            List<AbstractGameplay> possibleGameplays = new List<AbstractGameplay>();
            foreach (AbstractGameplay ag in gameplays)
            {
                if (ag.getPredecessors().Contains(current) && ag.getConstraint().isSatisfied(resourceState))
                {
                    possibleGameplays.Add(ag);
                }
            }
            if (possibleGameplays.Count == 0)
            {
                return null;
            }
            return possibleGameplays[rndGen.Next(possibleGameplays.Count)];
        }
    }
}
