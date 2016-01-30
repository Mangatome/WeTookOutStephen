using Assets.Model.Resources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Model.Gameplay
{
    interface AbstractGameplay
    {
        List<AbstractGameplay> getPredecessors();
        ResourceConstraint getConstraint();
    }
}
