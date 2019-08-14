using System;
using System.Linq;
using System.Text;

namespace ReverseRegex {

    internal class RReversedChar : RTree {

        private readonly char[] possibleChars;

        private readonly char[] allChars = "\t\n !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~".ToCharArray();

        public RReversedChar(char[] impossibleChars, IQuantifier quantifier) : base(quantifier) {
            var ic = impossibleChars.Where(c => c == '\t' || c == '\n' || (c >= ' ' && c <= '~')).ToArray();
            possibleChars = new char[225 - impossibleChars.Length];
            Array.Sort(ic);
            for (int i = 0, j = 0, k = 0; i < possibleChars.Length && j < ic.Length && k < allChars.Length; ++i) {
                if (allChars[j] < ic[k]) {
                    possibleChars[i] = allChars[j];
                    ++j;
                } else if (allChars[j] == ic[k]) {
                    ++j;
                    ++k;
                } else ++k;
            }
        }

        public override void Generate(GroupSet groups, Random rand, StringBuilder sb, int recursionDepth, int repetitionLimit) {
            if (possibleChars.Length == 0) return;
            var c = Quantifier.GetQuantity(rand, repetitionLimit);
            for (var i = 0; i < c; ++i) sb.Append(possibleChars[rand.Next(possibleChars.Length)]);
        }
    }
}