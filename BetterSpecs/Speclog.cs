using System;
using System.Collections.Generic;
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
            _logs.Clear();
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
            _logs.Add(Indentation(message, indentation));
        }

        private void PrintMessage(string message, int indentation)
        {
            Console.WriteLine(Indentation(message, indentation));
        }

        private string Indentation(string message, int indentation)
        {
            var indent = string.Empty;
            for (int i = 0; i < indentation; i++)
                indent += " ";

            return indent + message;
        }
    }
}
