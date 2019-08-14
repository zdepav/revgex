using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseRegex {

    internal static class Parser {

        public static GroupSet Parse(string str, bool ignoreLineEndings, bool ignoreWhitespace, bool allowPredefinedGroups) =>
            Parse(new RevgexStringReader(str, ignoreLineEndings, ignoreWhitespace), allowPredefinedGroups);

        private static GroupSet Parse(RevgexStringReader inp, bool allowPredefinedGroups) {
            var groups = new GroupSet();
            if (allowPredefinedGroups) {
                groups.Add(":maleName", PredefinedGroups.MaleName);
                groups.Add(":femaleName", PredefinedGroups.FemaleName);
                groups.Add(":surname", PredefinedGroups.Surname);
                groups.Add(":byte", PredefinedGroups.Byte);
                groups.Add(":int", PredefinedGroups.Int);
                groups.Add(":uint", PredefinedGroups.UnsignedInt);
                groups.Add(":usPhone", PredefinedGroups.USPhone);
                groups.Add(":mailSuffix", PredefinedGroups.MailSuffix);
                groups.Add(":passwd", PredefinedGroups.Password);
            }
            groups.Add(0);
            var alternatives = new List<List<RTree>> { new List<RTree>() };
            while (inp.Peek() >= 0) {
                if (inp.Peek() == '|') {
                    inp.Read();
                    alternatives.Add(new List<RTree>());
                } else alternatives[alternatives.Count - 1].Add(ParseSingleSubtree(inp, groups));
            }
            groups.Specify(0,
                alternatives.Count == 1
                    ? new RGroup(alternatives[0].ToArray())
                    : new RGroup(new RAlternation(alternatives.Select(a => new RGroup(a.ToArray())).ToArray())));
            return groups;
        }

        private static RTree ParseSingleSubtree(RevgexStringReader inp, GroupSet groups) {
            var buffer = "";
            while (true) {
                switch (inp.Peek()) {
                    case -1:
                        return buffer.Length > 0
                            ? new RFixedString(buffer, QuantifierOne.Instance)
                            : REmpty.Instance;
                    case '(':
                        return buffer.Length > 0
                            ? new RFixedString(buffer, QuantifierOne.Instance)
                            : ParseAnyGroup(inp, groups);
                    case ')':
                        return buffer.Length > 0
                            ? new RFixedString(buffer, QuantifierOne.Instance)
                            : throw Error(inp, "Unexpected right parenthesis.");
                    case '*':
                    case '+':
                    case '{':
                    case '?':
                        if (buffer.Length > 0) {
                            if (buffer.Length == 1)
                                return new RFixedString(buffer, LookupQuantifier(inp));
                            inp.UnreadEscaped();
                            return new RFixedString(buffer.Substring(0, buffer.Length - 1), LookupQuantifier(inp));
                        }
                        throw Error(inp, $"Unexpected character {inp.Peek()}.");
                    case '\\':
                        if (TryParseSimpleEscapeSequence(inp, out var ch)) {
                            buffer += ch;
                            continue;
                        }
                        return buffer.Length > 0
                            ? new RFixedString(buffer, QuantifierOne.Instance)
                            : ParseEscapeSequence(inp, groups);
                    case '$':
                        return buffer.Length > 0
                            ? new RFixedString(buffer, QuantifierOne.Instance)
                            : ParseValueReference(inp, groups);
                    case '.':
                        if (buffer.Length > 0) {
                            return new RFixedString(buffer, QuantifierOne.Instance);
                        } else {
                            inp.Read();
                            return RChar.Dot(LookupQuantifier(inp));
                        }
                    case '[':
                        return buffer.Length > 0
                            ? new RFixedString(buffer, QuantifierOne.Instance)
                            : ParseCharSet(inp);
                    case '|':
                        return buffer.Length > 0
                            ? new RFixedString(buffer, QuantifierOne.Instance)
                            : REmpty.Instance;
                    default:
                        buffer += inp.Read();
                        continue;
                }
            }
        }

        private static bool TryParseSimpleEscapeSequence(RevgexStringReader inp, out char c) {
            inp.Read(); // '\'
            switch (inp.Peek()) {
                case 'n':
                    inp.Read();
                    c = '\n';
                    return true;
                case 't':
                    inp.Read();
                    c = '\t';
                    return true;
                default:
                    if (inp.Peek() > 0 && "\\[](){}+*?$. \n\t".Contains((char)inp.Peek())) {
                        c = inp.Read();
                        return true;
                    }
                    inp.Unread(); // '\'
                    c = '\0';
                    return false;
            }
        }

        private static RTree ParseEscapeSequence(RevgexStringReader inp, GroupSet groups) {
            inp.Read(); // '\'
            var c = inp.Peek();
            if (c >= '0' && c <= '9') {
                var groupId = inp.Read() - '0';
                c = inp.Peek();
                if (c >= '0' && c <= '9')
                    groupId = groupId * 10 + (inp.Read() - '0');
                if (groupId == 0) throw Error(inp, "Backreference to the entire patternt (zero-th group) is not allowed.");
                if (groups.Get(groupId) == null)
                    throw Error(inp, "Invalid group backreference.");
                return new RGroupRef(groupId, LookupQuantifier(inp));
            }
            switch (c) {
                case -1:
                    throw Error(inp, "Incomplete escape sequence.");
                case ':':
                    var groupName = ParseGroupName(inp);
                    if (groups.Get(groupName) == null)
                        throw Error(inp, "Invalid named group backreference.");
                    return new RNamedGroupRef(groupName, LookupQuantifier(inp));
                case '(':
                    inp.Read();
                    var groupId = 0;
                    c = inp.Peek();
                    do {
                        if (c < '0' || c > '9')
                            throw Error(inp, "Invalid group backreference.");
                        groupId = groupId * 10 + (inp.Read() - '0');
                    } while ((c = inp.Peek()) != ')');
                    inp.Read(); // ')'
                    if (groups.Get(groupId) == null)
                        throw Error(inp, "Invalid group backreference.");
                    return new RGroupRef(groupId, LookupQuantifier(inp));
                case 'w':
                    inp.Read();
                    return RChar.w(LookupQuantifier(inp));
                case 'W':
                    inp.Read();
                    return RChar.W(LookupQuantifier(inp));
                case 's':
                    inp.Read();
                    return RChar.s(LookupQuantifier(inp));
                case 'S':
                    inp.Read();
                    return RChar.S(LookupQuantifier(inp));
                case 'd':
                    inp.Read();
                    return RChar.d(LookupQuantifier(inp));
                case 'D':
                    inp.Read();
                    return RChar.D(LookupQuantifier(inp));
                default:
                    return new RFixedString(inp.Read().ToString(), LookupQuantifier(inp));
            }
        }

        private static RTree ParseValueReference(RevgexStringReader inp, GroupSet groups) {
            inp.Read(); // '$'
            var c = inp.Peek();
            if (c >= '0' && c <= '9') {
                var groupId = inp.Read() - '0';
                c = inp.Peek();
                if (c >= '0' && c <= '9')
                    groupId = groupId * 10 + (inp.Read() - '0');
                if (groupId == 0) throw Error(inp, "Value backreference to the entire patternt (zero-th group) is not allowed.");
                if (groups.Get(groupId) == null)
                    throw Error(inp, "Invalid group backreference.");
                return new RGroupValueRef(groupId, LookupQuantifier(inp));
            }
            switch (c) {
                case -1:
                    throw Error(inp, "Incomplete group value backreference.");
                case ':':
                    var groupName = ParseGroupName(inp);
                    if (groups.Get(groupName) == null)
                        throw Error(inp, "Invalid named group value backreference.");
                    return new RNamedGroupValueRef(groupName, LookupQuantifier(inp));
                case '(':
                    inp.Read();
                    var groupId = 0;
                    c = inp.Peek();
                    do {
                        if (c < '0' || c > '9')
                            throw Error(inp, "Invalid group value backreference.");
                        groupId = groupId * 10 + (inp.Read() - '0');
                    } while ((c = inp.Peek()) != ')');
                    inp.Read(); // ')'
                    if (groups.Get(groupId) == null)
                        throw Error(inp, "Invalid group value backreference.");
                    return new RGroupValueRef(groupId, LookupQuantifier(inp));
                default: throw Error(inp, "Invalid group value backreference.");
            }
        }

        private static RTree ParseCharSet(RevgexStringReader inp) {
            inp.Read(); // '['
            var set = new HashSet<char>();
            var first = true;
            var inverse = false;
            var prevWasSpecial = true;
            var prev = '\0';
            while (true) {
                if (inp.Peek() < 0) throw Error(inp, "Incomplete char set specification.");
                var current = inp.Read();
                switch (current) {
                    case '^':
                        if (first) {
                            inverse = true;
                            prevWasSpecial = true;
                        } else {
                            set.Add('^');
                            prevWasSpecial = false;
                        }
                        break;
                    case '-':
                        if (prevWasSpecial || inp.Peek() == ']') {
                            set.Add('-');
                        } else {
                            var j = prev;
                            if (inp.Peek() < 0) throw Error(inp, "Incomplete char set specification.");
                            var end = inp.Read();
                            if (end == '\\') {
                                if (inp.Peek() < 0) throw Error(inp, "Incomplete char set specification.");
                                end = inp.Read();
                                if ("wWdDsS".Contains(end)) throw new FormatException();
                                if (end == 'n') end = '\n';
                                else if (end == 't') end = '\t';
                            }
                            for (++j; j <= end; ++j) set.Add(j);
                        }
                        prevWasSpecial = false;
                        break;
                    case '\\':
                        if (inp.Peek() < 0) throw Error(inp, "Incomplete char set specification.");
                        current = inp.Read();
                        switch (current) {
                            case 'w':
                                foreach (var c in RChar._w) set.Add(c);
                                prevWasSpecial = true;
                                break;
                            case 'W':
                                foreach (var c in RChar._W) set.Add(c);
                                prevWasSpecial = true;
                                break;
                            case 's':
                                foreach (var c in RChar._s) set.Add(c);
                                prevWasSpecial = true;
                                break;
                            case 'S':
                                foreach (var c in RChar._S) set.Add(c);
                                prevWasSpecial = true;
                                break;
                            case 'd':
                                foreach (var c in RChar._d) set.Add(c);
                                prevWasSpecial = true;
                                break;
                            case 'D':
                                foreach (var c in RChar._D) set.Add(c);
                                prevWasSpecial = true;
                                break;
                            case 't':
                                set.Add('\t');
                                prevWasSpecial = false;
                                break;
                            case 'n':
                                set.Add('\n');
                                prevWasSpecial = false;
                                break;
                            default:
                                set.Add(current);
                                prevWasSpecial = false;
                                break;
                        }
                        break;
                    case ']':
                        return inverse
                            ? new RReversedChar(set.ToArray(), LookupQuantifier(inp))
                            : (RTree)new RChar(set.ToArray(), LookupQuantifier(inp));
                    default:
                        set.Add(current);
                        prevWasSpecial = false;
                        break;
                }
                first = false;
                prev = current;
            }
        }

        private static RTree ParseAnyGroup(RevgexStringReader inp, GroupSet groups) {
            inp.Read(); // '('
            switch (inp.Peek()) {
                case -1:
                    throw Error(inp, "Missing ')'.");
                case '!':
                    return ParseModifier(inp, groups);
                case '?':
                    return ParseControlGroup(inp, groups);
                case '\'':
                case '"':
                    return ParseDelimitedSequence(inp, groups);
                default:
                    return ParseStdGroup(inp, groups);
            }
        }

        private static RTree ParseControlGroup(RevgexStringReader inp, GroupSet groups) {
            inp.Read(); // '?'
            switch (inp.Peek()) {
                case -1:
                    throw Error(inp, "Incomplete control group.");
                case ':':
                    // non-capturing group
                    inp.Read();
                    return new RGroup(ParseGroupBody(inp, groups));
                default:
                    throw Error(inp, "Invalid control group.");
            }
        }

        private static RTree ParseDelimitedSequence(RevgexStringReader inp, GroupSet groups) {
            var type = inp.Read(); // '"' or '
            var delimiter = "";
            while (true) {
                if (inp.Peek() == -1) {
                    throw Error(inp, "Incomplete delimiter specification.");
                } else if (inp.Peek() == ';') {
                    inp.Read();
                    break;
                } else if (inp.Peek() == '\\') {
                    inp.Read();
                    if (inp.Peek() < 0) throw Error(inp, "Incomplete delimiter specification.");
                    delimiter += inp.Read();
                } else delimiter += inp.Read();
            }
            var quantifier = LookupQuantifier(inp);
            var body = ParseGroupBody(inp, groups);
            return new RDelimitedSequence(quantifier, delimiter, type == '\'', body);
        }

        private static RTree ParseModifier(RevgexStringReader inp, GroupSet groups) {
            inp.Read(); // '!'
            var type = ParseModifierType(inp);
            var body = ParseGroupBody(inp, groups);
            return new RModifier(type, body);
        }

        private static RModifier.ModifierType ParseModifierType(RevgexStringReader inp) {
            if (inp.Peek() < 0)
                throw Error(inp, "Missing modifier type.");
            switch (inp.Read()) {
                case 'U': return RModifier.ModifierType.ToUpper;
                case 'l': return RModifier.ModifierType.ToLower;
                case 'C': return RModifier.ModifierType.Capitalize;
                case '_': return RModifier.ModifierType.ToUnderscores;
                case '-': return RModifier.ModifierType.ToDashes;
                case ' ': return RModifier.ModifierType.ToSpaces;
                case 'n':
                case 'N': return RModifier.ModifierType.RemoveSpaces;
                case 't':
                case 'T': return RModifier.ModifierType.TrimWhitespace;
                case '0': return RModifier.ModifierType.RemoveLeadingZeros;
                case '!': return RModifier.ModifierType.Ignore;
                default:  throw Error(inp, "Invalid modifier type.");
            }
        }

        private static RTree ParseStdGroup(RevgexStringReader inp, GroupSet groups) {
            string name = null;
            var id = -1;
            if (inp.Peek() == ':')
                name = ParseGroupName(inp);
            if (name != null) {
                if (!groups.Add(name))
                    throw Error(inp, $"Group name {name} is already used.");
            } else groups.Add(id = groups.GetNextId());
            var body = ParseGroupBody(inp, groups);
            if (name != null) {
                groups.Specify(name, new RGroup(body));
                return new RNamedGroupRef(name, LookupQuantifier(inp));
            } else {
                groups.Specify(id, new RGroup(body));
                return new RGroupRef(id, LookupQuantifier(inp));
            }
        }

        private static string ParseGroupName(RevgexStringReader inp) {
            inp.Read(); // ':'
            var buf = "";
            while (true) {
                switch (inp.Peek()) {
                    case -1: throw Error(inp, "Incomplete group name specification.");
                    case ';':
                        if (buf.Length == 0) throw Error(inp, "Empty group name specification.");
                        inp.Read();
                        return buf;
                    default:
                        buf += inp.Read();
                        continue;
                }
            }
        }

        private static RTree[] ParseGroupBody(RevgexStringReader inp, GroupSet groups) {
            var alternatives = new List<List<RTree>> { new List<RTree>() };
            while (true) {
                switch (inp.Peek()) {
                    case -1:
                        throw Error(inp, "Missing ')'.");
                    case '|':
                        inp.Read();
                        alternatives.Add(new List<RTree>());
                        break;
                    case ')':
                        inp.Read();
                        return alternatives.Count == 1
                            ? alternatives[0].ToArray()
                            : new RTree[] { new RAlternation(alternatives.Select(a => new RGroup(a.ToArray())).ToArray()) };
                    default:
                        alternatives[alternatives.Count - 1].Add(ParseSingleSubtree(inp, groups));
                        break;
                }
            }
        }

        private static IQuantifier LookupQuantifier(RevgexStringReader inp) {
            switch (inp.Peek()) {
                case '+':
                    inp.Read();
                    if (inp.Peek() == '?') {
                        inp.Read();
                        return QuantifierPlusLazy.Instance;
                    }
                    return QuantifierPlus.Instance;
                case '*':
                    inp.Read();
                    if (inp.Peek() == '?') {
                        inp.Read();
                        return QuantifierAsteriskLazy.Instance;
                    }
                    return QuantifierAsterisk.Instance;
                case '?':
                    inp.Read();
                    return QuantifierOptional.Instance;
                case '{':
                    inp.Read();
                    int buf = 0, min = -1;
                    var numberSpecified = false;
                    while (true) {
                        var c = inp.Peek();
                        if (c < 0) throw Error(inp, "Incomplete quantifier (missing '}').");
                        inp.Read();
                        if (c >= '0' && c <= '9') {
                            buf = buf * 10 + (c - '0');
                            numberSpecified = true;
                        } else if (c == ',') {
                            if (numberSpecified) {
                                min = buf;
                                buf = 0;
                                numberSpecified = false;
                            } else throw Error(inp, "Incomplete quantifier (missing number before ',').");
                        } else if (c == '}') {
                            if (numberSpecified) {
                                if (min < 0 || min == buf) return new QuantifierFixed(buf);
                                if (buf < min) throw Error(inp, "Invalid quantifier (max < min).");
                                return new QuantifierRange(min, buf);
                            }
                            if (min < 0) throw Error(inp, "Empty quantifier.");
                            return new QuantifierMin(min);
                        }
                    }
                default: return QuantifierOne.Instance;
            }
        }

        private static FormatException Error(RevgexStringReader inp, string message) {
            return new FormatException($"Error around line {inp.Line}, column {inp.Column}: \n{message}");
        }
    }
}
