using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace ReverseRegex {

    internal class PredefinedGroups {

        private class FixedSetGroup : RGroup {

            private readonly string[] set;

            public FixedSetGroup(params string[] set) => this.set = set;

            public override void Generate(GroupSet groups, Random rand, StringBuilder sb, int recursionDepth, int repetitionLimit) {
                if (recursionDepth >= Revgex.MaxRecursion) return;
                sb.Append(Value = GenerateValue(groups, rand, recursionDepth, repetitionLimit));
            }

            protected override string GenerateValue(GroupSet groups, Random rand, int recursionDepth, int repetitionLimit) =>
                set.Length == 0 ? "" : rand.Item(set);
        }

        private class FixedWeightedSetGroup : RGroup {

            private readonly (string value, int weight)[] set;

            private readonly int weightSum;

            public FixedWeightedSetGroup(params (string value, int weight)[] set) => weightSum = (this.set = set).Sum(item => item.weight);

            public override void Generate(GroupSet groups, Random rand, StringBuilder sb, int recursionDepth, int repetitionLimit) {
                if (recursionDepth >= Revgex.MaxRecursion) return;
                sb.Append(Value = GenerateValue(groups, rand, recursionDepth, repetitionLimit));
            }

            protected override string GenerateValue(GroupSet groups, Random rand, int recursionDepth, int repetitionLimit) {
                var i = rand.Next(weightSum);
                foreach (var (value, weight) in set) {
                    if (i < weight)
                        return value;
                    i -= weight;
                }
                return ""; // this will never be reached
            }
        }

        private class FunctionGroup : RGroup {

            private readonly Func<Random, string> func;

            public FunctionGroup(Func<Random, string> func) => this.func = func;

            public override void Generate(GroupSet groups, Random rand, StringBuilder sb, int recursionDepth, int repetitionLimit) {
                if (recursionDepth >= Revgex.MaxRecursion) return;
                sb.Append(Value = GenerateValue(groups, rand, recursionDepth, repetitionLimit));
            }

            protected override string GenerateValue(GroupSet groups, Random rand, int recursionDepth, int repetitionLimit) => func(rand);
        }

        public static readonly RGroup MaleName = new FixedSetGroup(
            "Diego", "Gabriel", "Alejandro", "Samuel", "Juanandres", "Tomas", "Thiago", "Santino", "Santiago", "Rodrigo", "Kevin", "Dyllan", "Keven",
            "Martin", "Bruno", "Francisco", "Agustin", "Matias", "Miguel", "Arthur", "David", "Pedro", "Bernardo", "Nicolas", "Lucas", "Matheus",
            "Heitor", "Rafael", "Elijah", "Jackson", "Logan", "Robert", "Michael", "Ethan", "Jack", "Richard", "Charles", "Joseph", "Thomas", "John",
            "Jacob", "Luis", "Felix", "Nathan", "Fabian", "Cesar", "Alexis", "Ian", "James", "Benjamin", "Vicente", "Mateo", "Jose", "Alexander",
            "Alonso", "Javier", "Maximiliano", "Joaquin", "Mason", "Ramon", "Juan", "Antonio", "Carlos", "Jeronimo", "Stevenson", "Stanley", "Noah",
            "Peterson", "Daniel", "Wilson", "Jameson", "Evens", "Ricardo", "Emmanuel", "Liam", "William", "Joshua", "Justin", "Ajani", "Adrian",
            "Jaden", "Iker", "Jayden", "Sebastian", "Dylan"
        );

        public static readonly RGroup FemaleName = new FixedSetGroup(
            "Mary", "Patricia", "Abril", "Micaela", "Linda", "Barbara", "Susan", "Margaret", "Dorothy", "Sofia", "Maria", "Lucia", "Martina",
            "Catalina", "Elena", "Emilia", "Valentina", "Paula", "Jennifer", "Alysha", "Isabella", "Isabelle", "Emily", "Emely", "Julieta", "Harper",
            "Valeria", "Nicole", "Samantha", "Victoria", "Sophia", "Julia", "Laura", "Amaia", "Manuela", "Luiza", "Helena", "Kamila", "Giovanna",
            "Milagros", "Luz", "Abigail", "Ariana", "Luciana", "Avery", "Alexandra", "Charlotte", "Lily", "Ava", "Emma", "Lea", "Olivia", "Alice",
            "Florence", "Zoe", "Chloe", "Beatrice", "Concepcion", "Rosalie", "Camila", "Fernanda", "Isidora", "Florencia", "Maite", "Josefa",
            "Amanda", "Antonella", "Agustina", "Carolina", "Mariana", "Elizabeth", "Beatriz", "Ramona", "Liz", "Maria Jose", "Gabriela", "Sara",
            "Salome", "Daniela", "Widelene", "Mirlande", "Islande", "Lovelie", "Judeline", "Angeline", "Esther", "Chedeline", "Jessica", "Gabrielle",
            "Amelia", "Tianna", "Brianna", "Jada", "Myrlande", "Lovely", "Mikaela", "Raquel", "Noemi", "Mabel", "Mia"
        );

        public static readonly RGroup Surname = new FixedSetGroup(
            "Smith", "Murphy", "Lam", "Martin", "Brown", "Roy", "Tremblay", "Lee", "Gagnon", "Wilson", "Cote", "Bouchard", "Gauthier", "Morin",
            "Lavoie", "Fortin", "Gagne", "Diaz", "Mora", "Rodriguez", "Gonzalez", "Hernandez", "Morales", "Sanchez", "Ramirez", "Perez", "Calderon",
            "Gutierrez", "Rojas", "Salas", "Vargas", "Torres", "Segura", "Valverde", "Villalobos", "Araya", "Herrera", "Lopez", "Madrigal", "Garcia",
            "Martinez", "Fernandez", "Alvarez", "Reyes", "Pena", "Jimenez", "Rosario", "Santana", "Nunez", "Castillo", "De la Cruz", "Cruz",
            "Guzman", "Gomez", "Santos", "Feliz", "Vasquez", "De los Santos", "Mejia", "Polanco", "Almonte", "Flores", "Rivera", "Rivas", "Ramos",
            "Portillo", "Escobar", "Orellana", "Romero", "Aguilar", "Alvarado", "De Leon", "Estrada", "Marroquin", "Mendez", "Velasquez", "Johnson",
            "Williams", "Jones", "Miller", "Davis", "Anderson", "Taylor", "Thomas", "Moore", "Jackson", "Thompson", "White", "Harris", "Clark",
            "Lewis", "Robinson", "Walker", "Hall", "Young", "Allen", "Wright", "King", "Scott", "Green", "Baker", "Adams", "Nelson", "Hill",
            "Campbell", "Mitchell", "Roberts", "Carter", "Phillips", "Evans", "Turner", "Parker", "Collins", "Edwards", "Stewart", "Morris",
            "Nguyen", "Cook", "Rogers", "Morgan", "Peterson", "Cooper", "Reed", "Bailey", "Bell", "Kelly", "Howard", "Ward", "Cox", "Richardson",
            "Wood", "Watson", "Brooks", "Bennett", "Gray", "James", "Hughes", "Price", "Myers", "Long", "Foster", "Sanders", "Ross", "Powell",
            "Sullivan", "Russell", "Ortiz", "Jenkins", "Perry", "Butler", "Barnes", "Fisher", "Garza", "Gonzales", "Trevino"
        );

        public static readonly RGroup Int = new FunctionGroup(rand => ((int)Math.Round(rand.NextDouble() * uint.MaxValue + int.MinValue)).ToString());

        public static readonly RGroup UnsignedInt = new FunctionGroup(rand => ((uint)Math.Round(rand.NextDouble() * uint.MaxValue)).ToString());

        public static readonly RGroup Byte = new FunctionGroup(rand => rand.NextByte().ToString());

        public static readonly RGroup Password = new FunctionGroup(_ => {
            var rand = new RNGCryptoServiceProvider();
            var charTypes = new[] {
                "abcdefghijklmnopqrstuvwxyz",
                "ABCDEFGHIJKLMNOPQRSTUVWXYZ",
                "0123456789",
                ",.-$%+-*/=_#&@()[]{}<>:;?!\"'|"
            };
            var typeAppearances = new[] { 1, 1, 1, 1 };
            var la = new byte[1];
            rand.GetBytes(la);
            var l = la[0] % 8 + 8; // 8 .. 15
            var chrTps = new byte[l - 4];
            rand.GetBytes(chrTps);
            foreach (var type in chrTps) ++typeAppearances[type % 4];
            var passwd = "";
            var r = new byte[3];
            for (var i = 0; i < l; ++i) {
                while (true) {
                    rand.GetBytes(r);
                    var type = r[0] % 4;
                    if (typeAppearances[type] > 0) {
                        var j = (int)Math.Floor(BitConverter.ToUInt32(r, 1) / (double)ushort.MaxValue * charTypes[type].Length);
                        passwd += charTypes[type][j];
                        --typeAppearances[type];
                        break;
                    }
                }
            }
            return passwd;
        });

        private static readonly string[] USPhonePrefixes = {
            "1-264", "1-268", "54", "297", "1-242", "1-246", "501", "1-441", "591", "55", "1-284", "1", "599", "1-345", "56", "57", "506", "53",
            "599-9", "1-767", "1-809", "593", "503", "500", "594", "299", "1-473", "590", "502", "592", "509", "504", "1-876", "596", "52", "1-664",
            "505", "507", "595", "51", "1-787", "590", "1-869", "1-758", "590", "508", "1-784", "1-721", "500", "597", "1-868", "1-649", "1-829",
            "1-340", "598", "1-849", "58", "1-939"
        };

        public static readonly RGroup USPhone = new FunctionGroup(rand => $"+{rand.Item(USPhonePrefixes)}-{rand.Next(1000):D3}-{rand.Next(10000):D4}");

        public static readonly RGroup MailSuffix = new FixedWeightedSetGroup(
            ("@gmail.com", 5), ("@icloud.com", 1), ("@yahoo.com", 1), ("@inbox.com", 1), ("@mail.com", 1), ("@aol.com", 1), ("@zoho.eu", 1), ("@yandex.com", 1)
        );
    }
}
