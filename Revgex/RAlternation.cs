using System;
using System.Text;

namespace ReverseRegex {

    internal class RAlternation : RTree {

        private readonly RGroup[] branches;

        public RAlternation(RGroup[] branches) : base(null) => this.branches = branches;

        public override void Generate(GroupSet groups, Random rand, StringBuilder sb, int recursionDepth, int repetitionLimit) {
            if (branches.Length == 0) return;
            rand.Item(branches).Generate(groups, rand, sb, recursionDepth, repetitionLimit);
        }
    }
}