using Assets.Model.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Model.Resources
{
    class IntResource : AbstractResource
    {
        private int id;
        private int value;

        public IntResource(int id, int initialValue)
        {
            this.id = id;
            this.value = initialValue;
        }

        public int getValue()
        {
            return value;
        }

        public void setValue(int value)
        {
            this.value = value;
        }

        /// <summary>
        /// Use a negative difference to decrement.
        /// </summary>
        /// <param name="difference"></param>
        public void incrementValue(int difference)
        {
            this.value += difference;
        }

        private bool sameResourceType(AbstractResource otherResource)
        {
            if (otherResource is IntResource)
            {
                IntResource other = otherResource as IntResource;
                if (other.id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public bool isLessThanOrEqual(AbstractResource otherResource)
        {
            if (sameResourceType(otherResource))
            {
                IntResource other = otherResource as IntResource;
                return value <= other.value;
            }
            return false;
        }

        public bool isMoreThanOrEqual(AbstractResource otherResource)
        {
            if (sameResourceType(otherResource))
            {
                IntResource other = otherResource as IntResource;
                return value >= other.value;
            }
            return false;
        }
    }
}
