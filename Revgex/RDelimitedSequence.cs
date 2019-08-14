using System;
using System.Text;

namespace ReverseRegex {

    internal class RDelimitedSequence : RActionGroup {

        private readonly IQuantifier quantifier;

        private readonly string delimiter;

        private readonly bool @fixed;

        public RDelimitedSequence(IQuantifier quantifier, string delimiter, bool @fixed, RTree[] branches) : base(branches) {
            this.quantifier = quantifier;
            this.delimiter = delimiter;
            this.@fixed = @fixed;
        }

        public override void Generate(GroupSet groups, Random rand, StringBuilder sb, int recursionDepth, int repetitionLimit) {
            if (branches.Length == 0) return;
            if (recursionDepth >= Revgex.MaxRecursion) return;
            var c = quantifier.GetQuantity(rand, repetitionLimit);
            if (@fixed) {
                Value = GenerateValue(groups, rand, recursionDepth, repetitionLimit);
                for (var i = 0; i < c; ++i) {
                    if (i > 0) sb.Append(delimiter);
                    sb.Append(Value);
                }
            } else {
                for (var i = 0; i < c; ++i) {
                    if (i > 0) sb.Append(delimiter);
                    base.Generate(groups, rand, sb, recursionDepth, repetitionLimit);
                }
            }
        }
    }
}
