using System;
using System.Text;

namespace ReverseRegex {

    internal class RChar : RTree {

        private readonly char[] possibleChars;

        public RChar(char[] possibleChars, IQuantifier quantifier)
            : base(quantifier) => this.possibleChars = possibleChars;

        public override void Generate(GroupSet groups, Random rand, StringBuilder sb, int recursionDepth, int repetitionLimit) {
            if (possibleChars.Length == 0) return;
            var c = Quantifier.GetQuantity(rand, repetitionLimit);
            for (var i = 0; i < c; ++i)
                sb.Append(possibleChars[rand.Next(possibleChars.Length)]);
        }

        public static readonly char[]
            _all = "\t !\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~".ToCharArray(),
            _w = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_".ToCharArray(),
            _W = "\t\n !\"#$%&'()*+,-./:;<=>?@[\\]^`{|}~".ToCharArray(),
            _d = "0123456789".ToCharArray(),
            _D = "\t\n !\"#$%&'()*+,-./:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~".ToCharArray(),
            _s = " \t\n".ToCharArray(),
            _S = "!\"#$%&'()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~".ToCharArray();
        
        public static RChar Dot(IQuantifier quantifier) => new RChar(_all, quantifier);
        
        public static RChar w(IQuantifier quantifier) => new RChar(_w, quantifier);
        public static RChar W(IQuantifier quantifier) => new RChar(_W, quantifier);

        public static RChar d(IQuantifier quantifier) => new RChar(_d, quantifier);
        public static RChar D(IQuantifier quantifier) => new RChar(_D, quantifier);

        public static RChar s(IQuantifier quantifier) => new RChar(_s, quantifier);
        public static RChar S(IQuantifier quantifier) => new RChar(_S, quantifier);
    }
}