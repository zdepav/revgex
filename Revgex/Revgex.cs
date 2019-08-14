using System;
using System.Text;

namespace ReverseRegex {

    public class Revgex {

        private static readonly Random rand = new Random();

        public static int MaxRecursion = 1000;

        private readonly GroupSet groups;

        private readonly RTree tree;

        public Revgex(string str, bool ignoreLineEndings = false, bool ignoreWhitespace = false, bool allowPredefinedGroups = true) {
            groups = str.Length == 0
                ? new GroupSet()
                : Parser.Parse(str.Replace("\r\n", "\n").Replace('\r', '\n'), ignoreLineEndings, ignoreWhitespace, allowPredefinedGroups);
            tree = groups.Get(0) ?? REmpty.Instance;
        }

        public string Generate(int repetitionLimit) {
            var sb = new StringBuilder();
            tree.Generate(groups, rand, sb, 0, repetitionLimit);
            return sb.ToString();
        }
    }
}

//  === CONTROL BLOCKS, MODIFIERS ===                                                       === EXAMPLES ===
//
//  Comment block:
//    (!# comment )                                                                         (!# number ) 0124                                   => 0124
//
//  Replace (translate):
//    (!R chars ! replacements ! value )                                                    (!R abcd ! 1234 ! baac )                            => 2113
//  
//  (!I
//      (:gen-number;
//          \d{4}
//      )
//      (:_number;
//          $:gen-number;
//      )
//  )
//  $:_number; \:gen-number; \:gen-number; $:_number;