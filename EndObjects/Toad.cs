using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    class Toad : StaticEndObject, IEndObjectState
    {
        public Toad(EndObject endObject)
            : base(endObject, EndObjectSpriteFactory.Instance.CreateToad()) { }
    }
}
