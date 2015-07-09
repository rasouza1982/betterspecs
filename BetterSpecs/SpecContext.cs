using System;
using System.Linq;
using System.Collections.Generic;

namespace BetterSpecs
{
    public class SpecContext
    {

        public It it { get; private set; }
        public Context context { get; private set; }
        public Describe describe { get; private set; }
        public Let let { get; private set; }

        public SpecContext()
        {
            this.it = new It();
            this.let = new Let();
            this.context = new Context();
            this.describe = new Describe();
        }
    }
}
