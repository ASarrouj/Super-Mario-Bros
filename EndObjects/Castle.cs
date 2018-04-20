using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace $safeprojectname$
{
    class Castle : StaticEndObject, IEndObjectState
    {
        public Castle(EndObject endObject)
            : base(endObject, EndObjectSpriteFactory.Instance.CreateCastle()) { }
    }
}
