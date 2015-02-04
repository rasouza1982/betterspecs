using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterSpecs
{
    public class SpecContext
    {
        public It it { get; private set; }
        public Context context { get; private set; }
        public Action before { set { value.Invoke(); } }
        public Action let { set { value.Invoke(); } }

        public SpecContext()
        {
            this.it = new It();
            this.context = new Context();
        }
    }
}
