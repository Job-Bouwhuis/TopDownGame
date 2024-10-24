﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterRose;

namespace TopDownGame.Utility
{
    internal abstract class ValueModifier<T>
    {
        protected ValueModifier() { }

        protected Dictionary<int, Func<T, T>> Modifiers { get; set; } = [];

        public abstract T Modify(T value);

        /// <summary>
        /// Adds a new modifier
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The key at which this modifier lives. This is used to remove it.</returns>
        public int Add(T value)
        {
            int key = Modifiers.NextAvalible();
            Modifiers.Add(key, val => value);
            return key;
        }

        /// <summary>
        /// Removes the modifier at the given key.
        /// </summary>
        /// <param name="key"></param>
        public void Remove(int key)
        {
            Modifiers.Remove(key);
        }

        /// <summary>
        /// Overrides all modifiers to the given dictionary.
        /// </summary>
        /// <param name="modifiers"></param>
        public void SetModifiers(Dictionary<int, Func<T, T>> modifiers)
        {
            Modifiers = modifiers;
        }
    }
}
