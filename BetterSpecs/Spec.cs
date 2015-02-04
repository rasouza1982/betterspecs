using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterSpecs
{
    public class Spec
    {
        private int _indentation;

        protected Spec(int indentation = 0)
        {
            this._indentation = indentation;
        }

        public Action this[string message]
        {
            set 
            {
                Speclog.Current.Write(message, _indentation);
                value.Invoke(); 
            }
        }
    }

    public class It : Spec
    {
        public It() : base(4) { }
    }

    public class Context : Spec
    {
        public Context() : base() { }
    }
}
