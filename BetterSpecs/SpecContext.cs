using System;

namespace BetterSpecs
{
    public class SpecContext
    {
        public It it { get; private set; }
        public Context context { get; private set; }
        public static Action before { set { value.Invoke(); } }

        public SpecContext()
        {
            this.it = new It();
            this.context = new Context();
        }

        public T let<T>(Func<T> a)
        {
            return a.Invoke();
        }
    }
}
