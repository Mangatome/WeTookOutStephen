using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Model.Resources
{
    class ResourceConstraint
    {
        private List<AbstractResource> constraints = new List<AbstractResource>();

        public void addResourceConstraint(AbstractResource resource)
        {
            constraints.Add(resource);
        }

        public bool isSatisfied(ResourceState state)
        {
            foreach(AbstractResource constraint in constraints)
            {
                bool constraintSat = false;
                foreach(AbstractResource resource in state.getResources())
                {
                    if (resource.isMoreThanOrEqual(constraint))
                    {
                        constraintSat = true;
                        break;
                    }
                }
                if (!constraintSat)
                {
                    return false;
                }
            }          
            return true;
        }        
    }
}
