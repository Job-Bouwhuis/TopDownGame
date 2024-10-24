using System;
using WinterRose;
using WinterRose.Monogame;

namespace TopDownGame.Utils.ValueModifiers
{
    /// <summary>
    /// Health component. anything that has health should use this component.
    /// </summary>
    internal class Health : ObjectComponent
    {
        public int MaxHealth => AddtitiveHealthModifier.Modify(BaseHealth);
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
        public AdditiveModifier<int> AddtitiveHealthModifier { get; set; } = new();
        public Armor Armor { get; set; }
        private int baseHealth = 1;
        private int currentHealth = 1;

        public void DealDamage(float damage)
        {
            float reduceDamage = Armor.Modify(damage);
            int resultingDamage = reduceDamage.Round(1, MidpointRounding.AwayFromZero);
            currentHealth -= resultingDamage;
        }

        public void Heal(int health)
        {
            currentHealth += health;
            currentHealth = Math.Max(currentHealth, MaxHealth);
        }

        private void Awake()
        {
            currentHealth = MaxHealth;
        }
    }
}
