using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace $safeprojectname$
{
    public abstract class SimpleEmmiter
    {
        protected bool running;

        protected IParticleSystem system;

        public bool Running
        {
            get { return running; }
            set { running = value; }
        }

        public SimpleEmmiter(IParticleSystem system, bool running = true)
        {
            this.system = system;
            this.running = running;
        }
    }
}
