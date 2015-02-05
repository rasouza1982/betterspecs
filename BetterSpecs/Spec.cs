using System;

namespace BetterSpecs
{
    public class Spec
    {
        private readonly string _prefix;
        private readonly int _indentation;

        protected Spec(int indentation = 0, string prefix = "")
        {
            this._indentation = indentation;
            this._prefix = string.IsNullOrEmpty(prefix) ? string.Empty : prefix + " ";
        }

        public Action this[string message]
        {
            set 
            {
                Speclog.Current.Write(_prefix + message, _indentation);
                value.Invoke(); 
            }
        }
    }
    
    public class It : Spec { public It() : base(4, "It") { } }
    public class Context : Spec { }
}
