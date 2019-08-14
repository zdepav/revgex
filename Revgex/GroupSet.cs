using System;
using System.Collections.Generic;
using System.Linq;

namespace ReverseRegex {

    internal class GroupSet {

        private readonly Dictionary<int, RGroup> numbered;
        private readonly Dictionary<string, RGroup> named;

        public GroupSet() {
            numbered = new Dictionary<int, RGroup>();
            named = new Dictionary<string, RGroup>();
        }

        /// <returns>true if successful, false if <paramref name="id"/> is already used</returns>
        public bool Add(int id, RGroup group = null) {
            if (id < 0) throw new ArgumentOutOfRangeException(nameof(id), "Id can't be negative.");
            if (numbered.ContainsKey(id))
                return false;
            numbered.Add(id, group);
            return true;
        }

        /// <returns>true if successful, false if <paramref name="name"/> is already used</returns>
        public bool Add(string name, RGroup group = null) {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (name.Length == 0) throw new ArgumentException("Name can't be empty.");
            if (named.ContainsKey(name))
                return false;
            named.Add(name, group);
            return true;
        }

        public void Specify(int id, RGroup group) {
            if (numbered.ContainsKey(id) && numbered[id] == null)
                numbered[id] = group;
            else throw new ArgumentException("Id not found or already used.");
        }

        public void Specify(string name, RGroup group) {
            if (named.ContainsKey(name) && named[name] == null)
                named[name] = group;
            else throw new ArgumentException("Name not found or already used.");
        }

        public RGroup Get(int id) => numbered.TryGetValue(id, out var g) ? g : null;

        public RGroup Get(string name) => named.TryGetValue(name, out var g) ? g : null;

        public bool IsPresentOrPromised(int id) => numbered.ContainsKey(id);

        public bool IsPresentOrPromised(string name) => named.ContainsKey(name);

        public int GetNextId() => numbered.Count == 0 ? 1 : numbered.Keys.Max() + 1;
    }
}
