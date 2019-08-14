using System;
using System.Text;

namespace ReverseRegex {

    internal class RFixedString : RTree {

        private readonly string str;

        public RFixedString(string str, IQuantifier quantifier) : base(quantifier) => this.str = str;

        public override void Generate(GroupSet groups, Random rand, StringBuilder sb, int recursionDepth, int repetitionLimit) {
            if (str.Length == 0) return;
            var c = Quantifier.GetQuantity(rand, repetitionLimit);
            for (var i = 0; i < c; ++i) sb.Append(str);
        }
    }
}