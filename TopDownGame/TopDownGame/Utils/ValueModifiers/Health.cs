using System;
using TopDownGame.Utils.ValueModifiers;
using WinterRose;
using WinterRose.Monogame;

namespace TopDownGame.Utils
{
    /// <summary>
    /// Health component. anything that has health should use this component.
    /// </summary>
    internal class Health
    {
        public int MaxHealth => AddititiveHealthModifier.Modify(BaseHealth);
        public int CurrentHealth => currentHealth;
        public int BaseHealth
        {
            get => baseHealth;
            set
            {
                if (value is < 1)
                    throw new ArgumentException("Value must be bigger than 0");
                baseHealth = value;
            }
        }
        public AdditiveModifier<int> AddititiveHealthModifier { get; set; } = new();
        private int baseHealth = 1;
        private int currentHealth = 1;
        public Armor Armor;

        public void Hurt(int damage)
        {
            currentHealth -= damage;
            currentHealth = Math.Max(currentHealth, 0);
        }

        public void Heal(int amount)
        {
            currentHealth += amount;
            currentHealth = Math.Max(currentHealth, MaxHealth);
        }

        private void Awake()
        {
            currentHealth = MaxHealth;
        }
    }
}
