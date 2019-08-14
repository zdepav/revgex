using System;
using System.Linq;
using System.Text;

namespace ReverseRegex {

    internal class RModifier : RActionGroup {

        public enum ModifierType {
            ToUpper,            // 'U'
            ToLower,            // 'l'
            Capitalize,         // 'C'
            ToUnderscores,      // '_'
            ToSpaces,           // ' '
            ToDashes,           // '-'
            RemoveSpaces,       // 'n' or 'N'
            TrimWhitespace,     // 't' or 'T'
            RemoveLeadingZeros, // '0'
            Ignore              // '!'
        }

        private readonly ModifierType type;

        public RModifier(ModifierType type, params RTree[] branches) : base(branches) => this.type = type;

        public override void Generate(GroupSet groups, Random rand, StringBuilder sb, int recursionDepth, int repetitionLimit) {
            if (type == ModifierType.Ignore) return;
            if (branches.Length == 0) return;
            if (recursionDepth >= Revgex.MaxRecursion) return;
            Value = GenerateValue(groups, rand, recursionDepth, repetitionLimit);
            switch (type) {
                case ModifierType.ToUpper:
                    sb.Append(Value.ToUpperInvariant());
                    break;
                case ModifierType.ToLower:
                    sb.Append(Value.ToLowerInvariant());
                    break;
                case ModifierType.Capitalize:
                    var lastCharWasLetter = false;
                    foreach (var c in Value) {
                        if (char.IsLetter(c)) {
                            sb.Append(lastCharWasLetter ? char.ToUpperInvariant(c) : c);
                            lastCharWasLetter = true;
                        } else lastCharWasLetter = false;
                    }
                    break;
                case ModifierType.ToUnderscores:
                    foreach (var c in Value)
                        sb.Append(c == '-' || c == ' ' ? '_' : c);
                    break;
                case ModifierType.ToSpaces:
                    foreach (var c in Value)
                        sb.Append(c == '-' || c == '_' ? ' ' : c);
                    break;
                case ModifierType.ToDashes:
                    foreach (var c in Value)
                        sb.Append(c == '_' || c == ' ' ? '-' : c);
                    break;
                case ModifierType.RemoveSpaces:
                    foreach (var c in Value.Where(c => c != ' '))
                        sb.Append(c);
                    break;
                case ModifierType.TrimWhitespace:
                    sb.Append(Value.Trim());
                    break;
                case ModifierType.RemoveLeadingZeros:
                    var nstr = Value.TrimStart('0');
                    sb.Append(nstr.Length == 0 && Value.Length > 0 ? "0" : nstr);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}