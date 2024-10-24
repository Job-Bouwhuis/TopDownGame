using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterRose;

namespace TopDownGame.Utility.ValueModifiers
{
    /// <summary>
    /// A static multiplier updates the value every time the modifiers change, instead recalculating it every time.
    /// <br></br> Useful for values that stay mostly the same, for example Armor or Health.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    internal abstract class StaticModifier<T>
    {
        protected StaticModifier() { }

        /// <summary>
        /// The value as of the current <see cref="BaseValue"/> and each modifier.
        /// </summary>
        public T Value => currentValue;
        T currentValue;

        /// <summary>
        /// The base value of the modifier
        /// </summary>
        public T BaseValue => baseValue;
        T baseValue;

        protected StaticModifier(T baseValue) => SetBaseValue(baseValue);

        protected Dictionary<int, Func<T, T>> Modifiers { get; set; } = [];

        protected abstract T Modify(T value);

        public int Add(T value)
        {
            int key = Modifiers.NextAvalible();
            Modifiers.Add(key, val => value);
            currentValue = Modify(baseValue);
            return key;
        }

        public void Remove(int key)
        {
            Modifiers.Remove(key);
        }

        /// <summary>
        /// Updates the base value of this static modifier.
        /// </summary>
        /// <param name="value"></param>
        public void SetBaseValue(T value)
        {
            baseValue = value;
            currentValue = Modify(baseValue);
        }
    }
}
