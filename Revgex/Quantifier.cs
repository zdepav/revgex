using System;

namespace ReverseRegex {

    internal interface IQuantifier {

        int GetQuantity(Random rand, int repetitionLimit);
    }

    internal class QuantifierPlus : IQuantifier {

        public static readonly IQuantifier Instance = new QuantifierPlus();

        public int GetQuantity(Random rand, int repetitionLimit) => 1 + (int)Math.Round((repetitionLimit - 1) * rand.NextGaussianAbsBelow1());
    }

    internal class QuantifierPlusLazy : IQuantifier {

        public static readonly IQuantifier Instance = new QuantifierPlusLazy();

        public int GetQuantity(Random rand, int repetitionLimit) => 1 + (int)Math.Round((repetitionLimit - 1) * Math.Pow(rand.NextGaussianAbsBelow1(), 2));
    }

    internal class QuantifierAsterisk : IQuantifier {

        public static readonly IQuantifier Instance = new QuantifierAsterisk();

        public int GetQuantity(Random rand, int repetitionLimit) => (int)Math.Round(repetitionLimit * rand.NextGaussianAbsBelow1());
    }

    internal class QuantifierAsteriskLazy : IQuantifier {

        public static readonly IQuantifier Instance = new QuantifierAsteriskLazy();

        public int GetQuantity(Random rand, int repetitionLimit) => (int)Math.Round(repetitionLimit * Math.Pow(rand.NextGaussianAbsBelow1(), 2));
    }

    internal class QuantifierOptional : IQuantifier {

        public static readonly IQuantifier Instance = new QuantifierOptional();

        public int GetQuantity(Random rand, int repetitionLimit) => rand.Next(2);
    }

    internal class QuantifierOne : IQuantifier {

        public static readonly IQuantifier Instance = new QuantifierOne();

        public int GetQuantity(Random rand, int repetitionLimit) => 1;
    }

    internal class QuantifierFixed : IQuantifier {

        private readonly int quantity;

        public QuantifierFixed(int quantity) => this.quantity = quantity;

        public int GetQuantity(Random rand, int repetitionLimit) => quantity;
    }

    internal class QuantifierMin : IQuantifier {

        private readonly int min;

        public QuantifierMin(int min) => this.min = min;

        public int GetQuantity(Random rand, int repetitionLimit) => rand.Next(Math.Min(min, repetitionLimit), repetitionLimit + 1);
    }

    internal class QuantifierRange : IQuantifier {

        private readonly int min, max;

        public QuantifierRange(int min, int max) {
            this.min = min;
            this.max = max;
        }

        public int GetQuantity(Random rand, int repetitionLimit) => rand.Next(Math.Min(min, repetitionLimit), Math.Min(max + 1, repetitionLimit));
    }
}
