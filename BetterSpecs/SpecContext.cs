using System;

namespace BetterSpecs
{
    public class SpecContext
    {
        public It it { get; private set; }
        public Context context { get; private set; }
        public static Action let { set { value.Invoke(); } }
        public static Action before { set { value.Invoke(); } }

        public SpecContext()
        {
            this.it = new It();
            this.context = new Context();
        }
    }
}
