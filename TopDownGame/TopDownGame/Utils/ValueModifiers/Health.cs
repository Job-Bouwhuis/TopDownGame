﻿using System;
using TopDownGame.Utility.ValueModifiers;
using TopDownGame.Utility.ValueModifiers.Values.SaticModifiers;
using WinterRose;
using WinterRose.Monogame;

namespace TopDownGame.Utility
{
    /// <summary>
    /// Health component. anything that has health should use this component.
    /// </summary>
    internal class Health
    {
        /// <summary>
        /// Getting returns the maximum health based on the <see cref="AddititiveHealthModifier"/><br></br><br></br>
        /// Setting this value overrides the <b>base max health</b> <br></br>Add a modifier to <see cref="AddititiveHealthModifier"/> to temporarily increase health if that is desired.
        /// </summary>
        public int MaxHealth
        {
            get => AddititiveHealthModifier.Value;
            set
            {
                if (value is < 1)
                    throw new ArgumentException("Value must be bigger than 0");

                float percentageOfCurrentToMax = (float)currentHealth / MaxHealth;
                AddititiveHealthModifier.SetBaseValue(value);

                currentHealth = (int)(AddititiveHealthModifier.BaseValue * percentageOfCurrentToMax);
            }
        }
        /// <summary>
        /// The current health
        /// </summary>
        public int CurrentHealth => currentHealth;

        /// <summary>
        /// The modifier for base health
        /// </summary>
        public StaticAdditiveModifier<int> AddititiveHealthModifier { get; set; } = new();

        private int currentHealth = 1;

        public Health()
        {
            // Set a default max health so that it doesnt produce a "devide by zero" error when setting the MaxHealth from external code.
            AddititiveHealthModifier.SetBaseValue(100);

            currentHealth = MaxHealth;
        }

        /// <summary>
        /// Subtracts <paramref name="damage"/> from <see cref="CurrentHealth"/>. to a minimum of 0
        /// </summary>
        /// <param name="damage"></param>
        public void DealDamage(int damage)
        {
            currentHealth -= damage;
            currentHealth = Math.Max(currentHealth, 0);
        }

        /// <summary>
        /// Adds <paramref name="amount"/> to <see cref="CurrentHealth"/> to a maximum of <see cref="MaxHealth"/>
        /// </summary>
        /// <param name="amount"></param>
        public void Heal(int amount)
        {
            currentHealth += amount;
            currentHealth = Math.Max(currentHealth, MaxHealth);
        }
    }
}
