using System;
using System.Text;

namespace ReverseRegex {

    internal abstract class RTree {

        public IQuantifier Quantifier { get; }

        protected RTree(IQuantifier quantifier) => Quantifier = quantifier;

        public abstract void Generate(GroupSet groups, Random rand, StringBuilder sb, int recursionDepth, int repetitionLimit);
    }
}
