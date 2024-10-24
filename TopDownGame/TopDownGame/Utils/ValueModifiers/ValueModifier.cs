using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterRose;

namespace TopDownGame.Utils
{
    internal abstract class ValueModifier<T>
    {
        protected ValueModifier() { }

        protected Dictionary<int, Func<T, T>> Modifiers { get; set; } = [];

        public abstract T Modify(T value);

        public int Add(T value)
        {
            int key = Modifiers.NextAvalible();
            Modifiers.Add(key, val => value);
            return key;
        }

        public void Remove(int key)
        {
            Modifiers.Remove(key);
        }
    }
}
