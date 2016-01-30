using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Model.Resources
{
    class ResourceState
    {
        private List<AbstractResource> resources;

        public void addResource(AbstractResource resource)
        {
            resources.Add(resource);
        }

        public List<AbstractResource> getResources()
        {
            return resources;
        }
    }
}
