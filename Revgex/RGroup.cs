using System;
using System.Text;

namespace ReverseRegex {

    internal class RGroup : RTree {

        protected readonly RTree[] branches;

        public string Value { get; protected set; }

        public RGroup(params RTree[] branches)
            : base(null) {
            Value = null;
            this.branches = branches;
        }

        public override void Generate(GroupSet groups, Random rand, StringBuilder sb, int recursionDepth, int repetitionLimit) {
            if (branches.Length == 0) return;
            if (recursionDepth >= Revgex.MaxRecursion) return;
            sb.Append(Value = GenerateValue(groups, rand, recursionDepth, repetitionLimit));
        }

        // equivalent to Generate if no value was generated yet
        public void RecallLastValue(GroupSet groups, Random rand, StringBuilder sb, int recursionDepth, int repetitionLimit) {
            if (branches.Length == 0) return;
            if (recursionDepth >= Revgex.MaxRecursion) return;
            if (Value != null) sb.Append(Value);
            else sb.Append(Value = GenerateValue(groups, rand, recursionDepth, repetitionLimit));
        }

        protected virtual string GenerateValue(GroupSet groups, Random rand, int recursionDepth, int repetitionLimit) {
            if (branches.Length == 0) return "";
            var sb2 = new StringBuilder();
            foreach (var b in branches)
                b.Generate(groups, rand, sb2, recursionDepth + 1, repetitionLimit);
            return sb2.ToString();
        }
    }

    internal interface IGroupRef {

        bool IsValid (GroupSet groups);
    }

    internal class RGroupRef : RTree, IGroupRef {

        private readonly int groupId;

        public RGroupRef(int groupId, IQuantifier quantifier) : base(quantifier) => this.groupId = groupId;

        public override void Generate(GroupSet groups, Random rand, StringBuilder sb, int recursionDepth, int repetitionLimit) {
            var g = groups.Get(groupId);
            if (g == null) return;
            var c = Quantifier.GetQuantity(rand, repetitionLimit);
            for (var i = 0; i < c; ++i)
                g.Generate(groups, rand, sb, recursionDepth, repetitionLimit);
        }

        public bool IsValid(GroupSet groups) => groups.Get(groupId) != null;
    }

    internal class RNamedGroupRef : RTree, IGroupRef {

        private readonly string groupName;

        public RNamedGroupRef(string groupName, IQuantifier quantifier) : base(quantifier) => this.groupName = groupName;

        public override void Generate(GroupSet groups, Random rand, StringBuilder sb, int recursionDepth, int repetitionLimit) {
            var g = groups.Get(groupName);
            if (g == null) return;
            var c = Quantifier.GetQuantity(rand, repetitionLimit);
            for (var i = 0; i < c; ++i)
                g.Generate(groups, rand, sb, recursionDepth, repetitionLimit);
        }

        public bool IsValid(GroupSet groups) => groups.Get(groupName) != null;
    }

    internal class RGroupValueRef : RTree, IGroupRef {

        private readonly int groupId;

        public RGroupValueRef(int groupId, IQuantifier quantifier) : base(quantifier) => this.groupId = groupId;

        public override void Generate(GroupSet groups, Random rand, StringBuilder sb, int recursionDepth, int repetitionLimit) {
            var g = groups.Get(groupId);
            if (g == null) return;
            var c = Quantifier.GetQuantity(rand, repetitionLimit);
            for (var i = 0; i < c; ++i)
                g.RecallLastValue(groups, rand, sb, recursionDepth, repetitionLimit);
        }

        public bool IsValid(GroupSet groups) => groups.Get(groupId) != null;
    }

    internal class RNamedGroupValueRef : RTree, IGroupRef {

        private readonly string groupName;

        public RNamedGroupValueRef(string groupName, IQuantifier quantifier) : base(quantifier) => this.groupName = groupName;

        public override void Generate(GroupSet groups, Random rand, StringBuilder sb, int recursionDepth, int repetitionLimit)  {
            var g = groups.Get(groupName);
            if (g == null) return;
            var c = Quantifier.GetQuantity(rand, repetitionLimit);
            for (var i = 0; i < c; ++i)
                g.RecallLastValue(groups, rand, sb, recursionDepth, repetitionLimit);
        }

        public bool IsValid(GroupSet groups) => groups.Get(groupName) != null;
    }
}
