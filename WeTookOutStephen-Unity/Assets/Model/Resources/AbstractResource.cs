using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Model.Resources
{
    interface AbstractResource
    {
        /// <summary>
        /// Compare this resource to another and return true if this resource
        /// represents more value than the other. If the resources are incomparable
        /// return false;
        /// </summary>
        /// <param name="otherResource"></param>
        /// <returns></returns>
        bool isMoreThanOrEqual(AbstractResource otherResource);
        /// <summary>
        /// Compare this resource to another and return true if this resource
        /// represents more value than the other. If the resources are incomparable
        /// return false;
        /// </summary>
        /// <param name="otherResource"></param>
        /// <returns></returns>
        bool isLessThanOrEqual(AbstractResource otherResource);
    }
}
