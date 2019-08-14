using System;
using System.IO;

namespace ReverseRegex {

    internal class RevgexStringReader {

        private readonly string input;
        private readonly bool ignoreLineEndings;
        private readonly bool ignoreWhitespace;

        private int index;

        public RevgexStringReader(string str) {
            input = str;
            index = 0;
        }

        public RevgexStringReader(string str, bool ignoreLineEndings, bool ignoreWhitespace) {
            input = str;
            index = 0;
            this.ignoreLineEndings = ignoreLineEndings;
            this.ignoreWhitespace = ignoreWhitespace;
            if (ignoreWhitespace && !ignoreLineEndings)
                throw new ArgumentException("ignoreWhitespace implies ignoreLineEndings!");
            while (index < input.Length && CanSkip()) ++index;
        }

        private bool CanSkip() {
            if (index >= input.Length) return false;
            switch (input[index]) {
                case '\n':
                    return ignoreLineEndings && !Escaped(index);
                case '\t':
                case ' ':
                    return ignoreWhitespace && !Escaped(index);
                default:
                    return false;
            }
        }

        /// <returns>whether the character at index i is escaped</returns>
        private bool Escaped(int i) =>
            i > 0 &&
            index < input.Length &&
            input[i - 1] == '\\' &&
            !Escaped(i - 1);

        public int Peek() => index < input.Length ? input[index] : -1;

        public char Read() {
            if (index < input.Length) {
                var c = input[index++];
                while (index < input.Length && CanSkip()) ++index;
                return c;
            }
            throw new IOException("Reading past the end of input string.");
        }

        public void Unread() {
            if (index > 0) {
                do --index;
                while (index > 0 && CanSkip());
            } else throw new IOException("Moving before the start of input string.");
        }

        public void UnreadEscaped() {
            if (index > 0) {
                if (Escaped(index)) --index;
                --index;
                while (index > 0 && CanSkip()) --index;
            } else throw new IOException("Moving before the start of input string.");
        }

        public int Line {
            get {
                var line = 1;
                for (var i = index - 1; i >= 0; --i)
                    if (input[i] == '\n')
                        ++line;
                return line;
            }
        }

        public int Column {
            get {
                var column = 1;
                for (var i = index - 1; i >= 0 && input[i] != '\n'; --i) ++column;
                return column;
            }
        }
    }
}
