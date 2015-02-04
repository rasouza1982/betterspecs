using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BetterSpecs
{
    public class Speclog
    {
        private static Speclog _current;
        private ICollection<string> _logs;

        private Speclog() 
        {
            _logs = new List<string>();
        }

        public static Speclog Current
        {
            get
            {
                _current = _current ?? new Speclog();
                return _current;
            }
        }

        public void Clear()
        {
            this._logs.Clear();
        }

        public override string ToString()
        {
            var build = new StringBuilder();
            foreach (var log in _logs)
                build.AppendLine(log);

            return build.ToString();
        }

        internal void Write(string message, int indentation = 0)
        {
            RegisterLogs(message, indentation);
            PrintMessage(message, indentation);
        }

        private void RegisterLogs(string message, int indentation)
        {
            message = PrepareMessage(message, indentation);
            _logs.Add(message);
        }

        private void PrintMessage(string message, int indentation)
        {
            message = PrepareMessage(message, indentation);
            Console.WriteLine(message);
        }

        private static string PrepareMessage(string message, int indentation)
        {
            var indent = string.Empty;
            for (int i = 0; i < indentation; i++)
                indent += " ";

            return indent + message;
        }
    }
}
