using System;
using System.Text;

namespace ReverseRegex {

    internal class REmpty : RTree {

        private REmpty() : base(null) { }

        public override void Generate(GroupSet groups, Random rand, StringBuilder sb, int recursionDepth, int repetitionLimit) { }

        public static readonly RTree Instance = new REmpty();
    }
}