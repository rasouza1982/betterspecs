using System;
using System.Collections.Generic;

namespace BetterSpecs
{
    public abstract class Spec
    {
        protected int _ident;

        public Action this[string text]
        {
            set
            {
                Before();
                Invoke(value, text);
                After();
            }
        }

        internal virtual void After() { }
        internal virtual void Before() { }

        internal virtual void Invoke(Action action, string text)
        {
            text = text.PadLeft(_ident + text.Length, ' ');

            Console.WriteLine(text);
            action.Invoke();
        }
    }

    public class Let
    {
        private readonly Dictionary<string, Func<object>> _let;

        public object this[string key]
        {
            get
            {
                return _let[key].Invoke();
            }
        }

        public Let()
        {
            _let = new Dictionary<string, Func<object>>();
        }

        public void Add(string key, Func<object> action)
        {
            _let.Add(key, action);
        }
    }

    public class Describe : Spec
    {
        internal override void Before()
        {
            Console.WriteLine();
        }

        internal override void After()
        {
            Console.WriteLine();
        }
    }

    public class It : Spec
    {
        internal override void Before()
        {
            _ident = 8;
        }
    }

    public class Context : Spec
    {
        internal override void Before()
        {
            _ident = 4;
        }
    }

}
